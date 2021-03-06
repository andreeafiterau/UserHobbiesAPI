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
    public class RolesController : ControllerBase
    {
        //ATTRIBUTES
        private IRoleService _roleService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        //CONSTRUCTOR
        public RolesController(
            IRoleService roleService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _roleService = roleService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        //GETALL USERS
        [HttpGet]
        public IActionResult GetAll()
        {
            var roles = _roleService.GetAll();
            var rolesDtos = _mapper.Map<IList<RoleDto>>(roles);
            return Ok(rolesDtos);
        }

    }
}
