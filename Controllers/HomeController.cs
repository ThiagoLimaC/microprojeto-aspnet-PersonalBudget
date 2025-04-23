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

            return View(registros);
        }

        [HttpPost]
        public IActionResult Filtrar(string[] filtro)
        {
            string id = string.Join("-", filtro);
            return RedirectToAction("Index", new { ID = id });
        }

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
    }
}
