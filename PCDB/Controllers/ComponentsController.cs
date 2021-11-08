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
        
        public ComponentsController()
        {
            _componentRepository = new ComponentsRepository<Component>();

        }

        public ActionResult Index()
        {
            return View(_componentRepository.GetAll());
        }

        [Route("Components/View/{componentName}", Name = "ComponentDetails")]
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
        public ActionResult Create(Component component)
        {
            if (ModelState.IsValid)
            {
                _componentRepository.Insert(component);
                _componentRepository.Save();
            }

            return Content("Success");
        }

        public ActionResult CreatePartial(string componentValue)
        {
            var type = Enum.Parse(typeof(ComponentType), componentValue);
            switch (type)
            {
                case ComponentType.CPU:
                    return PartialView("_Component_CreateCPU");
                    
            }

            //return PartialView("_Component_CreateCPU");
            return null;
        }

        public void CreateCPU(CPU cpu)
        {
            Create(cpu);
        }

        public void CreateCPUCooler(CPUCooler cpuCooler)
        {
            Create(cpuCooler);
        }

        public ActionResult CPU()
        {
            var _cpuRepository = new ComponentsRepository<CPU>();
            return View(_cpuRepository.GetAll());
        }

        public void Send()
        {
            EmailService emailService = new EmailService();
            emailService.SendAsync(new Microsoft.AspNet.Identity.IdentityMessage() { Destination = "shaunf1996@hotmail.co.uk" });
        }
    }
}