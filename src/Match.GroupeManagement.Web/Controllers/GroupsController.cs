using System;
using System.Collections.Generic;
using System.Linq;
using Match.GroupManagement.Business.Services;
using Match.GroupManagement.Web.Mappers;
using Match.GroupManagement.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Match.GroupeManagement.Web.Controllers
{
    [Route("Groups")]
    public class GroupsController : Controller
    {
        private readonly IGroupsService _groupService;

        public GroupsController(IGroupsService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_groupService.GetAll().ToViewModel());
        }
        [Route("{id}")]
        public IActionResult Details(long id)
        {
            var group = _groupService.GetById(id);

            if (group == null)
            {
                return NotFound();
            }

            return View(group.ToViewModel());
        }
        [Route("{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long id, GroupViewModel model)
        {
            var group = _groupService.Update(model.ToServiceModel());

            if(group == null)
            {
                return NotFound();
            }

            return RedirectToAction("Index");
        }
        [Route("Create")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Route("Create")]
        [HttpPost]
        public IActionResult Create(GroupViewModel model)
        {
            _groupService.Add(model.ToServiceModel());

            return RedirectToAction("Index");
        } 
    }
}
