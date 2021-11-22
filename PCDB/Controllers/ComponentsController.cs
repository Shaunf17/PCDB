using MvcPaging;
using PCDB.Interfaces;
using PCDB.Models;
using PCDB.Models.Components;
using PCDB.Repositories;
using PCDB.Services;
using PCDB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PCDB.Controllers
{
    public class ComponentsController : Controller
    {
        private readonly IComponentRepository<Component> _componentRepository;

        public ComponentsController() : this(new ComponentsRepository<Component>())
        { }

        public ComponentsController(IComponentRepository<Component> componentRepository)
        {
            _componentRepository = componentRepository;

        }

        public ActionResult Index(int? page)
        {
            int defaultPageSize = 5;
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            return View(_componentRepository.GetAll().OrderBy(c => c.Name).ToPagedList(currentPageIndex, defaultPageSize));
        }

        public ActionResult Delete(int id)
        {
            _componentRepository.Delete(id);
            _componentRepository.Save();
            return RedirectToAction("Index", routeValues: null);
        }

        [Route("Components/View/{componentId}/{componentName}", Name = "ComponentDetails")]
        public ActionResult Details(string componentName)
        {
            Component component = _componentRepository.FindByName(componentName.Replace('_', ' '));
            
            if (component == null) return View("ComponentNotFound");
            return View(component);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View(new ComponentCreateViewModel());
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(Component component, HttpPostedFileBase image)//, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                component.ImageUrl = ImageHelper.UploadComponentImage(component, image);

                _componentRepository.Insert(component);
                _componentRepository.Save();
            }

            return RedirectToAction("Index", routeValues: null);
        }

        public ActionResult CreatePartial(string componentValue)
        {
            var type = Enum.Parse(typeof(ComponentType), componentValue);
            switch (type)
            {
                case ComponentType.CPU:
                    return PartialView("_Component_CreateCPU");
                case ComponentType.CPUCooler:
                    return PartialView("_Component_CreateCPUCooler");
                case ComponentType.Memory:
                    return PartialView("_Component_CreateMemory");
            }

            //return PartialView("_Component_CreateCPU");
            return null;
        }

        [HttpPost]
        public ActionResult CreateCPU(CPU cpu, HttpPostedFileBase ComponentImage)
        {
            return Create(cpu, ComponentImage);
        }

        [HttpPost]
        public ActionResult CreateCPUCooler(CPUCooler cpuCooler, HttpPostedFileBase ComponentImage)
        {
            return Create(cpuCooler, ComponentImage);
        }

        public ActionResult CPU()
        {
            var _cpuRepository = new ComponentsRepository<CPU>();
            return View(_cpuRepository.GetAll());
        }

        public async void Send()
        {
            EmailService emailService = new EmailService();
            await emailService.SendAsync(new Microsoft.AspNet.Identity.IdentityMessage() { Destination = "shaunf1996@hotmail.co.uk" });
        }
    }
}