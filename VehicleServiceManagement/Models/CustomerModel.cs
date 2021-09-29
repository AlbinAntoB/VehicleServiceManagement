using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleServiceManagement.Models
{
    public class CustomerModel
    {
        public  int CustomerId  {get;set;}
        public  string CustomerName  {get;set;}
        public  string Email  {get;set;}
        public  string MobileNo  {get;set;}
        public  string Address  {get;set;}
        public  string Password  {get;set;}
        public int UserRoll { get; set; }

    }
    public class CustomerCommanModel
    {
        public CustomerModel customerModel;
        public List<CustomerModel> customermodelList;
        public CustomerComplaints customerComplaints;
        public List<CustomerComplaints> customerComplaintsList;
        public VehicleTypes vehicleTypes;
        public List<VehicleTypes> vehicleTypesList;
        public List<CustomerCommanModel> customerCommanModelList { get; set; }
        public report report;
        public List<report> reportList;
        public VehicleDetails vehicleDetails;
        public List<VehicleDetails> vehicleDetailsList;
    }
    public class CustomerComplaints
    {
        public int ComplaintId { get; set; }
        public string Complaints { get; set; }
        public decimal Price { get; set; }
        public int VehicleTypeId { get; set; }
    }
    public class VehicleTypes
    {
        public int VehicleTypeId { get; set; }
        public string VehicleType { get; set; }
    }
    public class VehicleDetails
    {
        public int VehicleId { get; set;}
        public string CustomerId { get; set; }
        public string VehicleNo { get; set; }
        public string VehicleBrand { get; set; }
        public int VehicleModel { get; set; }
        public string VehicleColor { get; set; }
        public decimal VehicleKmsRan { get; set; }
        public DateTime ExpectedDelivery { get; set; }
        public  decimal TotalPrice { get; set; }

        public string ComplaintId { get; set; }
        public int VehicleTypeId { get; set; }
    }
    public class report
    {
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public string VehicleNo { get; set; }
        public string VehicleBrand { get; set; }
        public int VehicleModel { get; set; }
        public string VehicleColor { get; set; }
        public decimal VehicleKmsRan { get; set; }
        public DateTime ExpectedDelivery { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
