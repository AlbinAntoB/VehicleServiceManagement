using System.Collections.Generic;
using System;
namespace VehicleServiceManagement.Models
{
    //proprties of customer
    public class CustomerModel
    {
        public  int CustomerId  {get;set;}
        public  string CustomerName  {get;set;}
        public  string Email  {get;set;}
        public  string MobileNo  {get;set;}
        public  string Address  {get;set;}
        public  string Password  {get;set;}
        public int UserRoll { get; set; }

        public Int64 Pages { get; set; }
        public Int64 Entries { get; set; }

    }
    //This is to get report of the  of customer count
    public class AdminReport
    {
        public int TotalCount { get; set; }
        public int VehicleCount { get; set; }
        public int ComplaintsCount { get; set; }
        public int FeedbackCount { get; set; }
    }
    //Properties of gst
    public class Gst
    {
        public int GstId { get; set; }
        public decimal AboveThousand { get; set; }
        public decimal LessThousand { get; set; }
    }
    //Comman view model for customer
    public class CustomerCommanModel
    {
        public Int64 Count { get; set; }
        public CustomerModel customerModel;
        public AdminReport adminReport;
        public List<AdminReport> adminReportList { get; set; }
        public List<CustomerModel> customermodelList { get; set; }
        public List<CustomerCommanModel> customerCommanModelList { get; set; }
        public Gst gst;
        public List<Gst> GstList;
    }
}
