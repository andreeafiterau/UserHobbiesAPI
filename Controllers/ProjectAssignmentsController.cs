﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Dtos;
using WebApi.Helpers;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]//MAIN ROUTE
    public class ProjectAssignmentsController : ControllerBase
    {
        //ATTRIBUTES
        private IProjectAssignmentsService _projectAssignmentsService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        //CONSTRUCTOR
        public ProjectAssignmentsController(
            IProjectAssignmentsService projectAssignmentsService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _projectAssignmentsService = projectAssignmentsService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        //GETALL PROJECTS
        [HttpGet("{id}")]
        public IActionResult GetAll(int id)
        {
            var projects = _projectAssignmentsService.GetByUserId(id);
            var projectDtos = _mapper.Map<IList<ProjectDto>>(projects);
            return Ok(projectDtos);
        }

    }
}
