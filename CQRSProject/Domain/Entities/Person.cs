namespace CQRSApp.Domain.Entities
{
    public class Person
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string TaxId { get; set; }
    }
}
