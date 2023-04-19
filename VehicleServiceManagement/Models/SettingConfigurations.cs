namespace VehicleServiceManagement.Models
{
    /// <summary>
    /// Creating a common setting configuration Model
    /// </summary>
    public class SettingConfigurations
    {
        public SMTPMailConfig SMTPMailConfig { get; set; }
    }
    /// <summary>
    /// Properties of SMTPMailConfig
    /// </summary>
    public class SMTPMailConfig
    {
        public string ContactUsMailId { get; set; }
        public string emailFromAddress { get; set; }
        public string SMTPServer { get; set; }
        public string SMTPPort { get; set; }
        public string DisplayName { get; set; }
        public string MUserName { get; set; }
        public string MPassword { get; set; }
        public string SendMailFlag { get; set; }
        public string IsSSLEnabled { get; set; }
        public string LoginURL { get; set; }
        public string subject { get; set; }
        public string password { get; set; }
        public string enableSSL { get; set; }
        public string body { get; set; }

    }
}
