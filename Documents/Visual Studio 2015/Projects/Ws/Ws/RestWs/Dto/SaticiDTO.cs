namespace Ws.RestWs.Dto
{
    public class SaticiDTO:BaseDTO
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string phoneNumber { get; set; }
        public string campanyName { get; set; }
        public string companyLogoPath { get; set; }
        // Çalışan DTO (Employee ile aynı id ye sahip)
        public int id { get; set; }
    }
}