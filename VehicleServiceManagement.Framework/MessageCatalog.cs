using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleSeviceManagement.Framework
{
    public static class MessageCatalog
    {
        public abstract class Customer
        {
            public class Property
            {
                #region Fields

                public string CUSTOMERID { get; set; }
                public string USERNAME { get; set; }
                public string PASSWORD { get; set; }
                public string CONFIRMPASSWORD { get; set; }
                public string DOB { get; set; }
                public string FATHERNAME { get; set; }
                public string MOTHERNAME { get; set; }
                public string MOBILENO { get; set; }
                public string EMAIL { get; set; }
                public string ADDRESS { get; set; }
                public string CITY { get; set; }
                public string LEAVINGDATE { get; set; }


                #endregion
            }
            public abstract class CustomerProperty
            {
                #region Fields         

                public const string CUSTOMERID = "CustomerId";
                public const string CUSTOMERNAME = "CustomerName";
                public const string EMAIL = "Email";
                public const string MOBILENO = "MobileNo";
                public const string ADDRESS = "Address";
                public const string USERNAME = "UserName";
                public const string PASSWORD = "Password";
                public const string REGISTERTIONNO = "RegistertionNo";
                public const string VEHICLEID = "VehicleId";
                public const string VEHICLENO = "VehicleNo";
                public const string VEHICLEBRAND = "VehicleBrand";
                public const string VEHICLEMODEL = "VehicleModel";
                public const string VEHICLECOLOR = "VehicleColor";
                public const string VEHICLETYPE = "VehicleType";
                public const string VEHICLEKMSRAN = "VehicleKmsRan";
                public const string COMPLAINTID = "ComplaintId";
                public const string COMPLAINTS = "Complaints";
                public const string PRICE = "Price";
                public const string VEHICLETYPEID = "VehicleTypeId";
                public const string SPAREPARTS = "SpareParts";
                public const string COMPLAINTON = "ComplaintOn";
                public const string EXPECTEDDELIVERY = "ExpectedDelivery";
                public const string DELIVERYSTATUS = "DeliveryStatus";
                public const string TOTALPRICE = "TotalPrice";
                public const string USERROLL = "UserRoll";
                public const string OVERALL = "OverAll";
                public const string ALLPROBLEMS = "AllProblems";
                public const string DELIVERYVEHICLE = "DeliveryVehicle";
                public const string ANYOTHERSUGGESTIONS = "Anyothersuggestions";
                public const string REREPAIR = "ReRepair";
                public const string SERVICEID = "ServiceId";
                public const string DELIVERYON = "DeliveryOn";
                public const string FROMON = "FromOn";
                public const string OTP = "Otp";
                public const string DOB = "DOB";
                public const string DOJ = "DOJ";
                public const string SUBJECTID = "SubjectId";
                public const string SUBJECT = "Subject";
                public const string MARK = "Mark";
                public const string AADHARNO = "AadharNo";
                public const string CLASS = "Class";
                public const string DISTRICT = "District";
                public const string STATE = "State";
                public const string GENDER = "Gender";
                public const string LEAVINGDATE = "LeavingDate";
                public const string ISACTIVE = "IsActive";
                public const string ISDELETE = "IsDelete";
                public const string GSTID = "GstId";
                public const string ABOVETHOUSAND= "AboveThousand";
                public const string LESSTHOUSAND= "LessthanThousand";
                public const string OffsetRows = "OffsetRows";
                public const string Entries = "Entries";


                #endregion
            }
            #region Passengers related Messages
            public static class PassengersMessage
            {
                public const string Success = "Passenger is Added successfully.";
                public const string SaveUserSuccess = "Passenger details saved successfully.";
                public const string Failure = "Passenger registration is failed.";
                public const string DeleteSuccess = "Passenger is deleted successfully.";
                public const string DeleteFailure = "Passenger  delete failed.";
                public const string Exists = "Passenger is registered already.";
                public const string SaveFail = "Unable to save the Passenger information.";

            }
            #endregion

        }

        public static class ErrorCodes
        {
            public const string ListSuccess = "200";
            public const string ListFailed = "201";
            public const string SaveSuccess = "202";
            public const string SaveFailed = "203";
            public const string DeleteSuccess = "204";
            public const string DeleteFailed = "205";
            public const string NoRecordFound = "206";
            public const string RecordNotFound = "207";
            public const string InValidKey = "208";
            public const string ParmeterRequied = "209";
            public const string InValidToken = "210";
            public const string ExpectationFailed = "211";
            public const string NoBarcode = "212";
            public const string StudentNotYetRegister = "214";
            public const string GoToMealsCountPage = "215";
            public const string NotYetRegisterForMealsCount = "216";

            public const string InValidBarcode = "212";
            public const string DBFailed = "213";

            public const string BadRequest = "400";
            public const string UnAuthorized = "401";
            public const string RequestTimeOut = "408";
            public const string ServiceTimeout = "440";
            public const string InvalidCredentials = "422";
            public const string PreconditionFailed = "412";
        }

        public static class ErrorMessages
        {
            public const string ListSuccess = "Success";
            public const string ListFailed = "Unable to get the record";
            public const string SaveSuccess = "Meals count details saved successfully";
            public const string SaveFailed = "Failed to save the meals count details";
            public const string DeleteSuccess = "Record deleted successfully.";
            public const string DeleteFailed = "Delete failed: record doesn't exist.";
            public const string NoRecordFound = "No record found";
            public const string RecordNotFound = "Record not found";
            public const string InValidKey = "Invalid key";
            public const string ParmeterRequied = "Parameter is required";
            public const string InValidToken = "Invalid token";
            public const string ExpectationFailed = "Unexpected error occurred while processing the data,Please check your inputs";
            public const string InValidBarcode = "Invalid Barcode";
            public const string DBFailed = "Failed to connect to database server";

            public const string BadRequest = "The request was invalid or cannot be served. The exact error should be explained in the error payload as above.";
            public const string Unauthorised = "The request requires an user authentication.";
            public const string Forbidden = "The server understood the request, but is refusing it or the access is not allowed.";
            public const string Notfound = "There is no resource behind the URL.";
            public const string ServiceUnavailable = "Service unavailable.";

            public const string NoBarcode = "Barcode not found, Please use current barcode";
            public const string StudentNotYetRegister = "Student not yet register for current term";
            public const string NotYetRegisterForMealsCount = "You are either not registered or it is an invalid barcode. please contact your homeroom teacher.";
            public const string GoToMealsCountPage = "Meals count is not taken for today, Do you wish to take meals count now?";
        }

        public static class PageTitle
        {
            public const string VIEWDYNAMICFORM = "View Online Form";
            public const string CREATEDYNAMICCONTROLS = "Create Form Controls";
            public const string CREATEDYNAMICSECTION = "Create Form Section";
            public const string RENDERDYNAMICFORM = "Render Dynamic Form";
        }

        public static class MessageTitle
        {
            public const string Category = "Category";
            public const string UserList = "User Datails";
            public const string Viper = "Viper";
            public const string Add = "Add";
            public const string MealsCount = "Meals Count";
            public const string SchoolContractEndDates = "My School Contract End Dates";
            public const string InvoiceHistory = "Invoice History";
            public const string MissingHelpLinks = "Missing Help Links";
            public const string Settings = "Settings";
            public const string View = "View";
            public const string ActiveForm = "Active Form";
            public const string OnlineForm = "Online Form";
            public const string PublishForm = "Publish Form";
            public const string eForms = "eForms";
            public const string Archive = "Archive";
            public const string StaffDetails = "Staff Details";
            public const string Documentation_Library = "Documentation Library";
            public const string FAQ = "FAQs";
            public const string FAQ_Categories = "FAQ Categories";
            public const string Saint_Day = "Saint of the day";
            public const string RestoreDeletedAssignment = "Restore Assignment";
            public const string DeleteClassAttendance = "Delete Attendance";
            public const string RestoreDeletedClasses = "Restore Deleted Classes";
            public const string ClearClassRoster = "Clear Class Rosters";
            public const string DesignateHomerooms = "Designate Homerooms";
            public const string Support_Ticket = "Tickets Details";
            public const string Support_Ticket_Comments = "Ticket Comments";
            public const string AccountManager = "Account Managers";
            public const string ContactUser = "Contact User";
            public const string OrganizationProfile = "Organization-profile";
            public const string DataUpload = "Data Upload";
            public const string AcrStaffAdmin = "ACR Staff Admin";
            public const string AddClass = "Add Class";
            public const string SchoolProfile = "School Profile";
            public const string Mattmoneysetup = "Matt Money Setup";
            public const string SchoolInfo = "School Info";
            public const string CatholicContent = "Catholic Content";
            public const string GenerateRandomPassword = "Generate Random Password";
            public const string InvoiceItems = "Invoice Items";
            public const string UserRole = "User Roles";
            public const string StaffDirectory = "Staff Directory";
            public const string SystemMessages = "System Message";
            public const string Skills = "Skills";
            public const string SkillScales = "Skill Scales";
            public const string Success = "Success!";
            public const string Error = "Oh No!";
            public const string TrainingSchedule = "Training Schedule";
            public const string OrderBillingAccounting = "Order-Billing Accounting";
            public const string StaffList = "Staff List";
            public const string UserDetails = "User Details";
            public const string PermissionDetails = "Permission Details";
            public const string FileLibrary = "File Library";
            public const string ClergyDetails = "Clergy Details";
            public const string ParishDetails = "Parish Details";
            public const string SchoolGroup = "School Group";
            public const string Notification = "Notification";
            public const string SchoolGroupList = "School Group List";
            public const string ProductInformation = "Product Information";
            public const string LearnerBehaviour = "Learner Behaviour";
            public const string PrivateMessage = "Private Message";
            public const string LearnerBehaviorsScale = "Learner Behaviors Scale";
            public const string SchoolSettings = "School Settings";
            public const string SchoolComments = "School Comments";
            public const string ParentAlert = "Activate Parent Alert";
            public const string CommentCode = "Comment Code";
            public const string Gradingscale = "Grading Scale";
            public const string SkillsScale = "Skill Scale";
            public const string DisableUser = "Disable User";
            public const string delete = "IsProspect User";
            public const string EventDetails = "Event Details";
            public const string Ticket = "Ticket";
        }

        public static class Style
        {
            public static string alert_danger = "<div class='alert alert-danger alert-dismissable'><button type='button' class='close' data-dismiss='alert' aria-hidden='true'>×</button>{0}</div>";
            public static string alert_sucess = "<div class='alert alert-success alert-dismissable'><button type='button' class='close' data-dismiss='alert' aria-hidden='true'>×</button>{0}</div>";
            public static string alert_info = "<div class='alert alert-info alert-dismissable'><button type='button' class='close' data-dismiss='alert' aria-hidden='true'>×</button>{0}</div>";
            public static string alert_warning = "<div class='alert alert-warning alert-dismissable'><button type='button' class='close' data-dismiss='alert' aria-hidden='true'>×</button>{0}</div>";
            public static string toastr_style = "'{0}','{1}','{2}'";
            public static string display_none = "none";
            public static string display_block = "block";
        }

        public static class MessageCodes
        {
            public const string Failed = "0";
            public const string Success = "1";
            public const string ExistsNotAvailable = "2";   // Return 2 to indicate value cannot be added because a non-available item already has that name
            public const string Exists = "3";  // Return 3 to indicate value cannot be added because a record already exists with that name
        }

        public static class ToastrStyle
        {
            public static string Toastr_Style = "'{0}','{1}','{2}'";
        }

        public static class ToastrTypes
        {
            public static string Success = "success";
            public static string Info = "info";
            public static string Error = "error";
            public static string Warning = "warning";
            public static string Primary = "primary";
            public static string Incorrect = "Invalid Username or Psassword";
            public static string ToastrMessage = "ToastrMessage";
        }

        public static class Messages
        {
            public const string Category_already_exist = "Category_already_exist is already exists";
            public const string controlnotanysection_exists = "Please add at least one field in any section.";
            public const string already_exist = "User Role is already exists";
            public const string already_exists = "Record Exists Already.";
            public const string Field_exists = "Field Exists Already.";
            public const string PassWord_Reset = "Password Reset Successfully.";
            public const string Form_already_exists = "Form Exists Already.";
            public const string Template_already_exists = "Template Exists Already.";
            public const string support_exists = "Support data exist already.";
            public const string save_success = "Saved Successfully.";
            public const string update_success = "Updated Successfully.";
            public const string success = "Success.";
            public const string SickDaysCopied = "Copied Accumulated Sick Days.";
            public const string delete_success = "Deleted Successfully.";
            public const string cancel_success = "Cancelled Successfully.";
            public const string cancel_failed = "Cancelled Failed.";
            public const string no_record = "No record found";
            public const string no_recordexists = "No Record Exists to Import to SMS.";
            public const string restore_success = "Resotred SMS Previous Data Successfully.";
            public const string restore_fail = "Unable to Resotre SMS Previous Data!..";
            public const string save_fail = "Unable to Save..!";
            public const string fieldcreate_save = "Field Created Successfully.";
            public const string fieldcreate_fail = "Unable to Create Field..!";

            public const string update_fail = "Unable to Update..!";
            public const string delete_fail = "Unable to Delete..!";
            public const string record_referred = "Record in referred..!";
            public const string sectionnot_exists = "Please Add Section.";
            public const string controlnot_exists = "Please add at least one field.";
            public const string publish = "Published Successfully.";
            public const string publish_fail = "Unable to Publish Form..!";
            public const string template_publish_fail = "Unable to Publish Template..!";
            public const string Unpublish = "Unpublished Successfully.";
            public const string Unpublish_fail = "Unable to Unpublish Form..!";
            public const string Template_Unpublish_fail = "Unable to Unpublish Template..!";
            public const string Copy_form = "Copied Form Successfully.";
            public const string Template_Copy_form = "Copied Template Successfully.";
            public const string Copy_field = "Field Copied Successfully.";
            public const string Copy_fail = "Unable to Copy Form..!";
            public const string Copy_fieldfail = "Unable to Copy Field..!";
            public const string archive_form = "Form Archived Successfully.";
            public const string Template_archive_form = "Template Archived Successfully.";
            public const string archive_fail = "Unable to Archive..!";
            public const string Unarchive_fail = "Unable to Unarchive..!";
            public const string Unarchive_form = "Form Unarchived Successfully.";
            public const string Template_Unarchive_form = "Template Unarchived Successfully.";
            public const string MailSend_success = "Mail Send Successfully.";

            public const string SaveSuccess = "Saved Successfully.";
            public const string PrivateMessageDeleted = "Your message has been deleted Successfully.";
            public const string PrivateMessageRestore = "Your message has been restored Successfully.";
            public const string UpdateSuccess = "Updated Successfully.";
            public const string DeleteSuccess = "Deleted Successfully.";
            public const string SaveFailed = "Unable to save the information.";
            public const string UpdateFailed = "Unable to update the information.";
            public const string DeleteFailed = "Unable to delete the information.";
            public const string Exists = "Already Exists.";
            public const string AccountExists = "Account Already Exists.";
            public const string ExistsNonAvailable = "Exists already.";
            public const string Error = "Unable to process your request.";
            public const string DeleteUser_fail = "Unable Delete this User..!";
            public const string Delete_User = "User Deleted Successfully.";
            public const string DisableUser = "User Disabled Successfully.";
            public const string DisableUser_fail = "Unable Disable this User..!";
            public const string Restored_Success = "Restored Successfully.";
            public const string Restored_fail = "Restored failed.";
            public const string NoClassesSelected = "No assignments are selected.";
            public const string RemovedUserSuccess = "The user has been removed from the event.";
            public const string RemovedUserError = "Unable to  remove the user from the event.";
            public const string AddedUserSuccess = "The user has  been added to the event.";
            public const string AddedUserError = "Unable to  add the user to the event.";
            public const string NoClassesSelectedForDelete = "No classes or students are selected.";

            public const string RemovedSchoolSuccess = "The school has been removed from the event.";
            public const string RemovedschoolError = "Unable to  remove the school from the event.";
            public const string AddedschoolSuccess = "The school has  been added to the event.";
            public const string AddedschoolError = "Unable to  add the school to the event.";

            public const string SaintDay_Exist = "Already exists in this post date.";
            public const string Image_Mismatch = "Image name is mismatch.";
            public const string Exists_File_Name = "File name is already exists.";

            public const string Registration_Success = "Your account has been registered successfully.";
            public const string DateUpload = "Data has been uploaded Successfully.";
            public const string Registration_Fail = "Unable to register the user..!";
            public const string CredentialExist = "Email or Password is already exists";
            public const string Change = "Change";
            public const string Emailnotexist = "Email is not exist";
            public const string UserRole_already_exist = "User Role is already exists";
            public const string ACH_Account_Status = "Your EFT Account already setup is not yet active. You will be able to setup another EFT Account only after the previous account is in active status.";
            public const string MedicationLogWarning = "The number of times this medication was due to be given today has already been reached.";

            public const string InvalidID = "Enter Valid GoogleID.";
        }

        public static class SIS_Controller
        {
            public const string LoginController = "Login";
            public const string HomeController = "Home";
            public const string SchoolLoginController = "SchoolLogin";

            public const string DashboardController = "Dashboard";
            public const string AutoLoginController = "AutoLogin";

            public static class LoginControllerAction
            {
                public const string Login = "Index";
                public const string FindSchool = "FindSchool";
                public const string OptionCLogin = "OptionCLogin";
            }

            public static class AutoLoginControllerAction
            {
                public const string Login = "Login";
            }

            // List all the Login Controller Action
            public static class SchoolLoginControllerAction
            {
                public const string Index = "Index";
                public const string OptionCLogin = "OptionCLogin";
                public const string FindSchool = "FindSchool";
                public const string Authenticate = "Authenticate";
                public const string Logout = "Logout";
            }

            // List all the Login Controller Action
            public static class DashboardControllerAction
            {
                public const string Index = "Index";
                public const string AccessDenied = "AccessDenied";
            }

            // List all the Home Controller Action
            public static class HomeControllerAction
            {
                public const string Index = "Index";
                public const string Authenticate = "Authenticate";
                public const string Logout = "Logout";
            }
        }

        public static class DFController
        {
            // List all the Controller Names

            public const string DynamicControlController = "DynamicControl";
            public const string DynamicFormController = "DynamicForm";
            public const string FieldMappingController = "FieldMapping";
            public const string OnlineFormController = "OnlineForms";
            public const string BlankFormController = "BlankForm";
            public const string CommunicationController = "Communication";
            public const string ParentOnlineFormsController = "ParentOnlineForms";
            public const string StaffOnlineForms = "StaffOnlineForms";
            public const string StudentOnlineForms = "StudentOnlineForms";

            public static class OnlineFormControllerAction
            {
                public const string ActiveForms = "ActiveForms";
                public const string AddOnlineForms = "AddOnlineForms";
                public const string ViewOnlineForms = "ViewOnlineForms";
                public const string ParentActiveForms = "ParentActiveForms";
                public const string GetParentChild = "GetParentChild";
                public const string ArchiveForm = "ArchiveForm";
                public const string AllArchiveForm = "AllArchiveForm";
                public const string ViewTemplate = "ViewTemplate";
            }

            public static class ParentControllerAction
            {
                public const string ParentViewResponse = "ParentViewResponse";
            }

            public static class NewBlankFormControllerAction
            {
                public const string NewBlankForm = "NewBlankForm";
                public const string ViewBlankForms = "ViewBlankForms";
                public const string FormPreview = "FormPreview";
            }

            public static class NewOnlineFormControllerAction
            {
                public const string NewOnlineForm = "NewOnlineForm";
            }

            // List all the DynamicControl Controller Action
            public static class DynamicControlControllerAction
            {
                public const string ViewDynamicForm = "ViewDynamicForm";
                public const string CreateDynamicForm = "CreateDynamicForm";
                public const string CreateDynamicSection = "CreateDynamicSection";
                public const string CreateDynamicControls = "CreateDynamicControls";
                public const string ActiveForms = "ActiveForms";
                public const string ParentActiveForms = "ParentActiveForms";
                public const string AddFieldMapping = "Add";
                public const string OnlineFormsTemplate = "OnlineFormsTemplate";
                public const string StaffOnlineForms = "StaffOnlineForms";
                public const string ViewTemplate = "ViewTemplate";
            }

            // List all the Dynamic Form Controller Action
            public static class DynamicFormControllerAction
            {
                public const string RenderDynamicForm = "RenderDynamicForm";
                public const string DynamicFormRecords = "DynamicFormRecords";
                public const string MoveNextForm = "MoveNextForm";
                public const string ImportSMS_SPHistory = "ImportSMS_SPHistory";
            }

            // List all the Dynamic Form Controller Action
            public static class StaffOnlineFormsAction
            {
                public const string ViewFormResponses = "ViewFormResponses";
                public const string StaffRenderDynamicForm = "StaffRenderDynamicForm";
                public const string StaffOnlineForms = "StaffOnlineForms";
                public const string StaffActiveForms = "StaffActiveForms";
            }

            public static class StudentOnlineFormsAction
            {
                public const string StudentRenderForm = "StudentRenderForm";
                public const string StudentActiveForms = "StudentActiveForms";
                public const string StudentViewResponse = "StudentViewResponse";
            }

            // List all the Dynamic Form Controller Action
            public static class FieldMappingControllerAction
            {
                public const string Add = "Add";
                public const string Index = "Index";
                public const string Delete = "Delete";
                public const string AboutUs = "AboutUs";
            }
        }

        public static class ParentAlertURLs
        {
            public static string AlertsFilePath = @"\Attachment\ParentAlerts\";
        }

        public static class Viper_Controller
        {
            public const string DioceseLoginController = "DioceseLogin";
            public const string DashboardController = "Dashboard";

            public static class DioceseLoginControllerAction
            {
                public const string Index = "Index";
            }

            public static class DashboardControllerAction
            {
                public const string Index = "Index";
            }
        }
    }
}