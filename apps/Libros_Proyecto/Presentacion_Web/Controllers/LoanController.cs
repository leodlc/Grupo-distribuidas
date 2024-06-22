using System.Threading.Tasks;
using System.Web.Mvc;
using Data;
using Presentacion_Web.Service;

namespace Presentacion_Web.Controllers
{
    public class LoanController : Controller
    {
        private readonly LoanService _loanService;

        public LoanController(LoanService loanService)
        {
            _loanService = loanService;
        }

        public async Task<ActionResult> Index()
        {
            var loans = await _loanService.GetLoansAsync();
            return View(loans);
        }

        public ActionResult Create()
        {
            return PartialView("_CrearPrestamoForm", new PRESTAMO());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PRESTAMO prestamo)
        {
            if (ModelState.IsValid)
            {
                //await _loanService.CreateLoanAsync(prestamo);
                //return RedirectToAction("Index");
                if (prestamo.IDCLIENTE == 0 && prestamo.IDLIBRO == 0)
                {
                    await _loanService.CreateLoanAsync(prestamo);
                }
                else
                {
                    //await _loanService.UpdateLoanAsync(prestamo.IDCLIENTE, prestamo.IDLIBRO, prestamo);
                }
                return RedirectToAction("Index");
            }
            return PartialView("_CrearPrestamoForm", prestamo);
        }

        public async Task<ActionResult> Edit(int idCliente, int idLibro)
        {
            var prestamo = await _loanService.GetLoanByClientAndBookAsync(idCliente, idLibro);
            if (prestamo == null)
            {
                return HttpNotFound();
            }
            return PartialView("_CrearPrestamoForm", prestamo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int idCliente, int idLibro, PRESTAMO prestamo)
        {
            if (ModelState.IsValid)
            {
                //prestamo.IDCLIENTE = idCliente;
                //prestamo.IDLIBRO = idLibro;
                await _loanService.UpdateLoanAsync(idCliente, idLibro, prestamo);
                return RedirectToAction("Index");
            }
            return PartialView("_CrearPrestamoForm", prestamo);
        }

        public async Task<ActionResult> Delete(int idCliente, int idLibro)
        {
            var prestamo = await _loanService.GetLoanByClientAndBookAsync(idCliente, idLibro);
            if (prestamo == null)
            {
                return HttpNotFound();
            }
            return View(prestamo);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int idCliente, int idLibro)
        {
            await _loanService.DeleteLoanAsync(idCliente, idLibro);
            return RedirectToAction("Index");
        }

        public async Task<JsonResult> GetClientesDisponibles()
        {
            var clientes = await _loanService.GetClientesDesdePrestamoAsync();
            return Json(clientes, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> GetLibrosDisponibles()
        {
            var libros = await _loanService.GetLibrosDesdePrestamoAsync();
            return Json(libros, JsonRequestBehavior.AllowGet);
        }
    }
}