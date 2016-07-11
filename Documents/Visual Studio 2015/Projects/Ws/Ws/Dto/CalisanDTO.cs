namespace Ws.RestWs.Dto
{
    public class CalisanDTO:BaseDTO
    {
        public EmployeeType employeeType { get; set; }
        public string nameSurname { get; set; }
        public string address { get; set; } 
        //Çalıştıgı firma 
        public int firmID { get; set; }
        public double payment { get; set; }
        //Id is comming EmployeeTable
        public int id { get; set; }
        public string passwd { get; set; }
        public string userName { get; set; }
        public int roleID { get; set; }
        //Unvanı muhendis vs gbii
        public string title { get; set; }

    }
    public enum EmployeeType
    {
        PATRON, ISCİ, ARAC,ADMIN
    }
}