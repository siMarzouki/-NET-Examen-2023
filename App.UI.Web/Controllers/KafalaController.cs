using App.ApplicationCore.Domain;
using App.ApplicationCore.Interfaces;
using App.ApplicationCore.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.UI.Web.Controllers
{
    public class KafalaController : Controller
    {

        IUnitOfWork unitOfWork;
        IService<Kafala> kafalaService;
        IDonatorService donatorService;
        IBeneficiaryService beneficiaryService;

        public KafalaController(IUnitOfWork unitOfWork,
        IService<Kafala> kafalaService,
        IDonatorService donatorService,
        IBeneficiaryService beneficiaryService)
        {
            this.unitOfWork = unitOfWork;
            this.kafalaService = kafalaService;
            this.donatorService = donatorService;
            this.beneficiaryService = beneficiaryService;
        }

       



        // GET: KafalaController
        public ActionResult Index()
        {
            return View();
        }

        

        // GET: KafalaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: KafalaController/Create
        public ActionResult Create()
        {
            ViewBag.beneficiaries = new SelectList(beneficiaryService.GetAll(), "CIN", "CIN");
            ViewBag.donators = new SelectList(donatorService.GetAll(), "Id", "Id");

            return View();
        }

        // POST: KafalaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Kafala kafala)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return View();
                }

                kafalaService.Add(kafala);
                unitOfWork.Commit();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: KafalaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: KafalaController/Edit/5
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

        // GET: KafalaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: KafalaController/Delete/5
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
