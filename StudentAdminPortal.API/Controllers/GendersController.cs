﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentAdminPortal.API.DomainModels;
using StudentAdminPortal.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdminPortal.API.Controllers
{
    [ApiController]
    public class GendersController : Controller
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;

        public GendersController(IStudentRepository studentRepository, IMapper mapper)
        {
            this.studentRepository= studentRepository;
            this.mapper = mapper;
        }

     

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> getAllGenders()
        {
            var genderlist = await studentRepository.GetGendersAsync();
            if (genderlist == null || !genderlist.Any())
            {
                return NotFound();
            }

            return Ok(mapper.Map<List<Gender>>(genderlist));
        }
    }
}