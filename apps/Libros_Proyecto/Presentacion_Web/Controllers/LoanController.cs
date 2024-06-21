using System.Threading.Tasks;
using System.Web.Mvc;
using Data;
using Newtonsoft.Json;
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
                System.Diagnostics.Debug.WriteLine("Datos recibidos en el controlador web: " + JsonConvert.SerializeObject(prestamo));
                await _loanService.CreateLoanAsync(prestamo);
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
        public async Task<ActionResult> EditPrestamo(PRESTAMO prestamo)
        {
            if (ModelState.IsValid)
            {
                await _loanService.UpdateLoanAsync(prestamo.IDCLIENTE, prestamo.IDLIBRO, prestamo);
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

        // Nueva acción para cargar clientes disponibles desde LoanService
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
