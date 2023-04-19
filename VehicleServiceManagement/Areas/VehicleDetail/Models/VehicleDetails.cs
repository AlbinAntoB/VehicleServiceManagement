using System;
using System.Collections.Generic;
using VehicleServiceManagement.Areas.Complaints.Models;

namespace VehicleServiceManagement.Areas.VehicleDetail.Models
{
    //Properties of vehicledetails
    public class VehicleDetails
    {
        public string CustomerName { get; set; }
        public int VehicleId { get; set; }
        public string CustomerId { get; set; }
        public string VehicleNo { get; set; }
        public string VehicleBrand { get; set; }
        public int VehicleModel { get; set; }
        public string VehicleColor { get; set; }
        public decimal VehicleKmsRan { get; set; }
        public DateTime ExpectedDelivery { get; set; }
        public string DeliveryStatus { get; set; }
        public decimal TotalPrice { get; set; }

        public string ComplaintId { get; set; }
        public int VehicleTypeId { get; set; }
    }
    //Properties of VehicleTypes
    public class VehicleTypes
    {
        public int VehicleTypeId { get; set; }
        public string VehicleType { get; set; }
    }
    //comman view modal of vehicle details
    public class VehicleCommanModel
    {
        public VehicleDetails vehicleDetails;
        public List<VehicleDetails> vehicleDetailsList;
        public List<VehicleTypes> vehicleTypesList;
        public VehicleTypes vehicleTypes;
        public List<CustomerComplaints> customerComplaintsList;
    }
}
