using System.Diagnostics;
using microprojeto_aspnet_PersonalBudget.Data;
using microprojeto_aspnet_PersonalBudget.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace microprojeto_aspnet_PersonalBudget.Controllers
{
    public class HomeController : Controller
    {
        // Injeção de dependência do contexto do banco de dados
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }


        public IActionResult Index(string id)
        {
            var filtros = new Filtros(id);

            ViewBag.Filtros = filtros;
            ViewBag.Etiquetas = _context.Etiquetas.ToList();
            ViewBag.Statuses = _context.Statuses.ToList();
            ViewBag.VencimentoValores = Filtros.VencimentoValoresFiltro;

            IQueryable<Registro> consulta = _context.Registros
                .Include(e => e.Etiqueta)
                .Include(s => s.Status);

            if (filtros.TemEtiqueta)
            {
                consulta = consulta.Where(t => t.EtiquetaId == filtros.EtiquetaId);
            }
            if (filtros.TemStatus)
            {
                consulta = consulta.Where(t => t.StatusId == filtros.StatusId);
            }
            if (filtros.TemVencimento)
            {
                var hoje = DateTime.Today;

                if (filtros.EPassado)
                {
                    consulta = consulta.Where(t => t.DataVencimento < hoje);
                }

                if (filtros.EFuturo)
                {
                    consulta = consulta.Where(t => t.DataVencimento > hoje);
                }

                if (filtros.EHoje)
                {
                    consulta = consulta.Where(t => t.DataVencimento == hoje);
                }
            }

            var registros = consulta.OrderBy(t => t.DataVencimento).ToList();

            ViewBag.Total = registros.Sum(t => t.Valor);
            ViewBag.TotalNaoPago = registros.Where(t => t.StatusId == "nao-pago").Sum(t => t.Valor);
            ViewBag.TotalLiquido = 4000 - ViewBag.Total;


            return View(registros);
        }
        public IActionResult Adicionar()
        {
            ViewBag.Etiquetas = _context.Etiquetas.ToList();
            ViewBag.Statuses = _context.Statuses.ToList();

            var registro = new Registro { StatusId = "nao-pago" };

            return View(registro);
        }

        // ao clicar no botão Filtrar o método redireciona para o Index
        // passando o novo id do filtro
        [HttpPost]
        public IActionResult Filtrar(string[] filtro)
        {
            string id = string.Join("-", filtro);
            return RedirectToAction("Index", new { ID = id });
        }

        // ao clicar no botão Pagar, o método busca o registro no banco
        // que corresponde ao id passado e altera o status para pago
        // e redireciona para o Index com o id do filtro atual
        [HttpPost]
        public IActionResult MarcarPago([FromRoute] string id, Registro registroSelecionado)
        {
            registroSelecionado = _context.Registros.Find(registroSelecionado.Id);

            if (registroSelecionado != null)
            {
                registroSelecionado.StatusId = "pago";
                _context.SaveChanges();
            }

            return RedirectToAction("Index", new { ID = id });
        }

        [HttpPost]
        public IActionResult Adicionar(Registro registro)
        {
            if (ModelState.IsValid)
            {
                _context.Registros.Add(registro);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Etiquetas = _context.Etiquetas.ToList();
                ViewBag.Statuses = _context.Statuses.ToList();

                return View(registro);
            }
        }

        [HttpPost]
        public IActionResult DeletarPagos(string id)
        {
            var paraDeletar = _context.Registros.Where(s => s.StatusId == "pago").ToList();

            foreach (var registro in paraDeletar)
            {
                _context.Registros.Remove(registro);
            }

            _context.SaveChanges();

            return RedirectToAction("Index", new { ID = id });
        }
    }
}
