using System;

namespace FunctionOliAPI.Entities
{
    public class DataSent
    {
        public string NameCustomer { get; set; }
        public string EmailCustomer { get; set; }
        public int IdBusiness { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class DataBack
    {
        public int IdCustomer { get; set; }
        public string UrlWebchat { get; set; }
    }
}
