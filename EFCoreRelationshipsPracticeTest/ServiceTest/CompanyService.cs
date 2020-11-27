using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreRelationshipsPractice;
using EFCoreRelationshipsPractice.Dtos;
using EFCoreRelationshipsPractice.Repository;
using EFCoreRelationshipsPractice.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace EFCoreRelationshipsPracticeTest.ServiceTest
{
    [Collection("IntegrationTest")]
    public class CompanyServiceTest : TestBase
    {
        public CompanyServiceTest(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task Should_delete_company_and_related_profile_employee_success_via_company_service()
        {
            var scope = Factory.Services.CreateScope();
            var scopedServices = scope.ServiceProvider;

            CompanyDbContext context = scopedServices.GetRequiredService<CompanyDbContext>();
            var companyDto = GenerateCompanyDto();

            CompanyService companyService = new CompanyService(context);

            var companyId = await companyService.AddCompany(companyDto);

            Assert.Equal(1, context.Companies.Count());
            Assert.Equal(companyDto.Employees.Count, context.Employees.Count());
            Assert.Equal(1, context.Profiles.Count());

            await companyService.DeleteCompany(companyId);

            Assert.Equal(0, context.Companies.Count());
            Assert.Equal(0, context.Profiles.Count());
            Assert.Equal(0, context.Employees.Count());
        }

        [Fact]
        public async Task Should_create_company_success_via_company_service()
        {
            var scope = Factory.Services.CreateScope();
            var scopedServices = scope.ServiceProvider;

            CompanyDbContext context = scopedServices.GetRequiredService<CompanyDbContext>();
            CompanyDto companyDto = GenerateCompanyDto();

            CompanyService companyService = new CompanyService(context);

            await companyService.AddCompany(companyDto);

            Assert.Equal(1, context.Companies.Count());
        }

        private static CompanyDto GenerateCompanyDto()
        {
            CompanyDto companyDto = new CompanyDto();
            companyDto.Name = "IBM";
            companyDto.Employees = new List<EmployeeDto>()
            {
                new EmployeeDto()
                {
                    Name = "Tom",
                    Age = 19
                }
            };

            companyDto.Profile = new ProfileDto()
            {
                RegisteredCapital = 100010,
                CertId = "100",
            };
            return companyDto;
        }
    }
}