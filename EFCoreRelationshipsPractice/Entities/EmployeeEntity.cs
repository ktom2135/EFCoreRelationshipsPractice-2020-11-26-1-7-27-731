﻿using System.ComponentModel.DataAnnotations.Schema;
using EFCoreRelationshipsPractice.Dtos;

namespace EFCoreRelationshipsPractice.Entities
{
    public class EmployeeEntity
    {
        public EmployeeEntity()
        {
        }

        public EmployeeEntity(EmployeeDto employeeDto)
        {
            this.Age = employeeDto.Age;
            this.Name = employeeDto.Name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public CompanyEntity Company { get; set; }

        [ForeignKey("CompanyIdForeignKey")]
        public int CompanyId { get; set; }
    }
}