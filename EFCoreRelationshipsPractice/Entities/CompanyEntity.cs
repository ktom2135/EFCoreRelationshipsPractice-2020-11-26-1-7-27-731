﻿using System.Collections.Generic;
using EFCoreRelationshipsPractice.Dtos;

namespace EFCoreRelationshipsPractice.Entities
{
    public class CompanyEntity
    {
        public CompanyEntity()
        {
        }

        public CompanyEntity(CompanyDto companyDto)
        {
            this.Name = companyDto.Name;
            this.Profile = new ProfileEntity(companyDto.Profile);
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public string Location { get; set; }

        public ProfileEntity Profile { get; set; }

        public List<EmployeeEntity> Employees { get; set; }
    }

    public class EmployeeEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}