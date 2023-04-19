using System;
using System.Collections.Generic;
namespace VehicleServiceManagement.Areas.Report.Models
{
    // For report properties
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
    // This is comman view modal for report
    public class reportCommanModel
    {
        public report report;
        public List<report> reportList;
        public Feedback feedback;
        public List<Feedback> feedbackList { get; set; }
    }
    // This is feedback properties
    public class Feedback
    {

        public string CustomerName { get; set; }
        public int OverAll { get; set; }
        public int AllProblems { get; set; }
        public int DeliveryVehicle { get; set; }
        public string Anyothersuggestions { get; set; }
    }
}
