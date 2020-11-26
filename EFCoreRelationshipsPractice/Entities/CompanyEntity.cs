namespace EFCoreRelationshipsPractice.Entities
{
    public class CompanyEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Location { get; set; }

        public ProfileEntity Profile { get; set; }
    }

    public class ProfileEntity
    {
        public int Id { get; set; }
        public int RegisteredCapital { get; set; }
        public string CertId { get; set; }
    }
}