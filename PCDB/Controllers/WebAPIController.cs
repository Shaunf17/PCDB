using PCDB.Interfaces;
using PCDB.Models.Components;
using PCDB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PCDB.Controllers
{
    [RoutePrefix("api/Components")]
    public class WebAPIController : ApiController
    {
        private readonly IComponentRepository<Component> _componentRepository;

        public WebAPIController() : this(new ComponentsRepository<Component>())
        { }

        public WebAPIController(IComponentRepository<Component> componentRepository)
        {
            _componentRepository = componentRepository;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok(_componentRepository.GetAll());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            return Ok(_componentRepository.Find(id));
        }

        [HttpGet]
        [Route("{name}")]
        public IHttpActionResult GetByName(string name)
        {
            return Ok(_componentRepository.FindByNameMultiple(name));
        }

        [HttpPost]
        [Route("Create")]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult Create()
        {
            return Ok("Hello world");
        }
    }
}
