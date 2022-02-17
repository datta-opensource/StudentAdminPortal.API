﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdminPortal.API.DataModels
{
    public class Student
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        public long Mobile { get; set; }

        public string ProfileImageUrl { get; set; }

        public Guid GenderID { get; set; }

        //Navigation Properties

        public Gender Gender { get; set; }

        public Address Address { get; set; }
    }
}
