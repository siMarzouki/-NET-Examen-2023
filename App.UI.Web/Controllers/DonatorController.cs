using App.ApplicationCore.Domain;
using App.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.UI.Web.Controllers
{
    public class DonatorController : Controller
    {
        IUnitOfWork unitOfWork;
        IDonatorService donatorService;
        IService<Kafala> kafalaService;

        public DonatorController(IUnitOfWork unitOfWork, IDonatorService donatorService,IService<Kafala> kafalaService)
        {
            this.unitOfWork = unitOfWork;
            this.donatorService = donatorService;
            this.kafalaService = kafalaService;
        }

        // GET: KafalaController
        public ActionResult KafflaByDonator(int id)
        {
            
            return View(kafalaService.GetMany(k=>k.Donator.Id==id));
        }

        // GET: DonatorController
        public ActionResult Index()
        {
            return View(donatorService.GetAll());
        }

        // GET: DonatorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DonatorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DonatorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DonatorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DonatorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DonatorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DonatorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
