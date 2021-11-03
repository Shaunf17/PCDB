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
        private readonly IComponentRepository<CPU> _CPURepository;
        private readonly IComponentRepository<Storage> _StorageRepository;
        private readonly IComponentRepository<CPUCooler> _CPUCoolerRepository;
        private readonly IComponentRepository<Memory> _MemoryRepository;
        
        public ComponentsController()
        {
            _CPURepository = new ComponentsRepository<CPU>();
            _StorageRepository = new ComponentsRepository<Storage>();
            _CPUCoolerRepository = new ComponentsRepository<CPUCooler>();
            _MemoryRepository = new ComponentsRepository<Memory>();

        }

        public ActionResult Index()
        {
            List<IComponent> componentList = new List<IComponent>();
            //componentList.AddRange(_CPURepository.GetAll());
            //componentList.AddRange(_StorageRepository.GetAll());
            //componentList.AddRange(_CPUCoolerRepository.GetAll());
            //componentList.AddRange(_MemoryRepository.GetAll());

            var repo = new ComponentsRepository<Component>();
            componentList.AddRange(repo.GetAll());

            return View(componentList);
        }

        public ActionResult SeedData()
        {
            CPU cpu = new CPU()
            {
                CoreClock = "3.9GHz",
                CoreCount = 12,
                Description = "New AMD Ryzen experience",
                Name = "Ryzen 7 5800X",
                Price = 79.99m
            };

            var repo = new ComponentsRepository<Component>();
            repo.Insert(cpu);
            repo.Save();

            return Content("Success");
        }

        public ActionResult Details()
        {
            var repo = new ComponentsRepository<Component>();
            var compList = repo.GetAll();

            string result = "";
            foreach (var comp in compList)
            {
                result += $"\n{comp.Name} | {comp.Description} | {comp.Price}";
                if (comp is CPU)
                {
                    var cpu = (CPU)comp;
                    result += $"\n{cpu.CoreClock} | {cpu.CoreCount}";
                }
            }

            return Content(result);
        }
    }
}