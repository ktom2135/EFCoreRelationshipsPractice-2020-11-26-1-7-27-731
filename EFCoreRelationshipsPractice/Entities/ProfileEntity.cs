using System.ComponentModel.DataAnnotations.Schema;
using EFCoreRelationshipsPractice.Dtos;

namespace EFCoreRelationshipsPractice.Entities
{
    public class ProfileEntity
    {
        public ProfileEntity()
        {
        }

        public ProfileEntity(ProfileDto profileDto)
        {
            this.CertId = profileDto.CertId;
            this.RegisteredCapital = profileDto.RegisteredCapital;
        }

        public int Id { get; set; }
        public int RegisteredCapital { get; set; }
        public string CertId { get; set; }

        public CompanyEntity Company { get; set; }

        [ForeignKey("CompanyIdForeignKey")]
        public int CompanyId { get; set; }
    }
}