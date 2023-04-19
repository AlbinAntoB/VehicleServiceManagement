using System.Collections.Generic;
using VehicleServiceManagement.Areas.VehicleDetail.Models;
namespace VehicleServiceManagement.Areas.Complaints.Models
{
    // Customer Complaints properties
    public class CustomerComplaints
    {
        public int ComplaintId { get; set; }
        public string Complaints { get; set; }
        public decimal Price { get; set; }
        public int VehicleTypeId { get; set; }
    }
    //This is commanview modal
    public class ComplaintsCommanModel
    {
        public CustomerComplaints customerComplaints;
        public List<CustomerComplaints> customerComplaintsList;
        public List<VehicleTypes> vehicleTypesList;
    }
}
