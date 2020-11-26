using EFCoreRelationshipsPractice.Entities;

namespace EFCoreRelationshipsPractice.Dtos
{
    public class ProfileDto
    {
        public ProfileDto()
        {
        }

        public ProfileDto(ProfileEntity profile)
        {
            this.CertId = profile.CertId;
            this.RegisteredCapital = profile.RegisteredCapital;
        }

        public int RegisteredCapital { get; set; }
        public string CertId { get; set; }
    }
}