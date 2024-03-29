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
    public class StudentsController : Controller
    {

        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;

        public StudentsController(IStudentRepository studentRepository, IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetStudentsAsync()
        {
            var Students = await studentRepository.GetStudentsAsync();

            //var domainModelStudents = new List<Student>();

            //foreach (var student in Students)
            //{
            //    domainModelStudents.Add(new Student()
            //    {
            //        Id = student.Id,
            //        FirstName = student.FirstName,
            //        LastName = student.LastName,
            //        DateOfBirth = student.DateOfBirth,
            //        Email = student.Email,
            //        Mobile = student.Mobile,
            //        ProfileImageUrl = student.ProfileImageUrl,
            //        GenderID = student.GenderID,
            //        Address = new Address()
            //        {
            //            Id = student.Address.Id,
            //            PhysicalAddress = student.Address.PhysicalAddress,
            //            PostalAddress = student.Address.PostalAddress
            //        },
            //        Gender = new Gender()
            //        { 
            //            Id = student.Gender.Id,
            //            Description = student.Gender.Description,
            //        },
            //    });
            //}

            return Ok(mapper.Map<List<Student>>(Students));

        }

        [HttpGet]
        [Route("[controller]/{studentId:guid}")]
        public async Task<IActionResult> GetStudentAsync([FromRoute] Guid studentId)
        {
            var student = await studentRepository.GetStudentAsync(studentId);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<Student>(student));

        }

        [HttpPut]
        [Route("[controller]/{studentId:guid}")]
        public async Task<IActionResult> UpdateStudentAsync([FromRoute] Guid studentId, [FromBody] UpdateStudentRequest request)
        {
            if (await studentRepository.Exists(studentId))
            {
                // Update Details
                var updatedStudent = await studentRepository.UpdateStudent(studentId, mapper.Map<DataModels.Student>(request));
                if (updatedStudent != null)
                {
                    return Ok(mapper.Map<Student>(updatedStudent));
                }
            }
            return NotFound();
        }
    }
}
