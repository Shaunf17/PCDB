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
        private readonly IComponentRepository _CPURepository;
        private readonly IComponentRepository _MemoryRepository;

        public ComponentsController()
        {
            _CPURepository = new CPURepository();
            _MemoryRepository = new MemoryRepository();
        }

        public ActionResult Index()
        {
            //ComponentsViewModel componentsViewModel = new ComponentsViewModel()
            //{
            //    CPU = (List<CPU>)_CPURepository.GetAll()
            //};

            List<IComponent> componentList = new List<IComponent>();
            componentList.AddRange(_CPURepository.GetAll());
            componentList.AddRange(_MemoryRepository.GetAll());

            return View(componentList);
        }
    }
}