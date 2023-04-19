using System;
using System.Collections.Generic;
namespace VehicleServiceManagement.Areas.Service.Models
{
    //Properties of service Followup
    public class ServiceFollowup
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int ServiceId { get; set; }
        public DateTime DeliveryOn { get; set; }
        public decimal TotalPrice { get; set; }
        public string ReRepair { get; set; }
        public DateTime FromOn { get; set; }
    }
    // Comman view modal of service
    public class SeviceFollowCommanModel
    {
        public ServiceFollowup serviceFollowup;
        public List<ServiceFollowup> serviceFollowupList { get; set; }
    }
}
