namespace Ws.RestWs.Dto
{
    public class SaticiDTO:BaseDTO
    {
        public string sallerName { get; set; }
        public string surname { get; set; }
        public string phoneNumber { get; set; }
        public string campanyName { get; set; }
        public string companyLogoPath { get; set; }
        // Çalışan DTO (Employee ile aynı id ye sahip)
        public int id { get; set; }
        public string address { get; set; }
        public string passwd { get; set; }
        public string roleName { get; set; }
        // Satici Türü Employee Tablosu Icın
        public ContactType contactType { get; set; }
    }
    public enum ContactType
    {
        FIRM,EMPLOYEE,OWNER,PASSANGER_CAR
    }
}