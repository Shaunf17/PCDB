using PCDB.Interfaces;
using PCDB.Models;
using PCDB.Models.Components;
using PCDB.Repositories;
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
        //private readonly IComponentRepository<IComponent> _ComponentRepository;

        private readonly IComponentRepository<CPU> _CPURepository;
        private readonly IComponentRepository<CPUCooler> _CPUCoolerRepository;
        private readonly IComponentRepository<Memory> _MemoryRepository;
        
        public ComponentsController()
        {
            //_ComponentRepository = new ComponentsRepository<IComponent>();

            _CPURepository = new ComponentsRepository<CPU>();
            _CPUCoolerRepository = new ComponentsRepository<CPUCooler>();
            _MemoryRepository = new ComponentsRepository<Memory>();
        }

        public ActionResult Index()
        {
            List<IComponent> componentList = new List<IComponent>();
            componentList.AddRange(_CPURepository.GetAll());
            componentList.AddRange(_CPUCoolerRepository.GetAll());
            componentList.AddRange(_MemoryRepository.GetAll());

            return View(componentList);
        }
    }
}