/***************************************************************************************************************************************************
 * Created by       : Justine
 * Created On       : 14 Mar 2018
 * 
 * Reviewed By      : 
 * Reviewed On      : 
 * 
 * Purpose          : This is to hold all the common enum values for the easy access 
***********************************************************************************************************/
namespace VehicleSeviceManagement.Framework
{
    public class EnumCommand
    {
        public enum DataType
        {
            BigInt,
            Boolean,
            Byte,
            Char,
            Date,
            DateTime,
            smalldatetime,
            Decimal,
            Double,
            Money,
            Int,
            Int16,
            Int32,
            Int64,
            SByte,
            Single,
            String,
            TimeSpan,
            UInt16,
            UInt32,
            UInt64,
            ByteArray,
            Varchar,
            nVarchar,
            None,
            Memo,
            Blob,
            Text,
            Xml,
            bit

        }

        public enum SQLType
        {
            SQLStatic,
            SQLDynamic,
            SQLStoredProcedure
        }



        #region DB Related
        public enum DBConnectionType
        {
            MasterDBConnection,
            ClusterDBConnection

        }
        #endregion
        public enum DataSource
        {
            DataSet,
            DataReader,
            DataTable,
            DataView,
            Scalar,
            ExecuteXmlReader
        }


        public enum RenderActionQuery
        {
            AllRecords = 0,
            SaveRecords = 1,
            DeleteRecords = 2,
            SelectById = 3,

           
        }
         public enum ActionQuery
        {
            AllRecords = 0,
            InsertRecoreds = 1,
            SaveRecords = 2,
            DeleteRecords = 3,
        }
        public enum QueryRenderAction
        {
            ActiveForms = 1,
            StudentActiveForms = 2,
            AllDynamicFormsBySchoolId = 2,
            allArchiveForm = 16,
            DynamicFormsByFormId = 3,
            SesctionByFormId = 4,
            StaffRenderForm =1 ,
            staffRenderForm = 18,
            StudentRecordId = 1,
            ControlsByFormId = 5,
            DynamicEditDataByRecordId = 6,
            ActionId = 7,
            DynamicSectionBySectionId = 10,
            ParentActiveFormsActionId = 13,
            NextFormActionId = 14,
            TeplateActionId = 15,
            FilterStudentActionId = 1,
            FilterStaffActionId = 3,
            CopyStudentActionId = 2,
            ExportUserFormStatus=17

        }
        public enum UserData
        {
            USERID,
            USERNAME,
            FIRSTNAME,
            LASTNAME,
            ORGANIZATIONID,
            PERMISSION,
            GRADELEVEL,
            SECTION,
            USERROLE,
            MIDDLENAME,
            TITLE,
            SUFFIX,
            DOB,
            GENDER,
            PASSWORD,
            ORGANIZATIONNAME,
            ORGANIZATIONSTATE,
            ORGANIZATIONDIOCESE,
            DIOID,
            STATEID,

        }
        public enum DefalutVlaue
        {
            defalut = 0,
            FlagId1 = 1,
            FlagId2 = 2
        }

        public enum QueryAddFormAction
        {
            TemplateActionId = 12,
            FormCategoryActionId = 13,
            FieldMoveRightActionId = 6,
            FieldMoveLeft = 5,
            CopyField = 4,
            DeleteDynamicField = 3,
            GetFieldMapping = 7,
            EditDynamicField = 9,
            SaveFieldActionId = 1,
            EditFieldActionId = 2,
            AddBetweenFieldActionId = 8,
            SectionMoveDown = 5,
            SectionMoveUp = 4,
            DeleteDynamicSection = 3,
            SaveDynamicSection = 1,
            EditDynamicSection = 2,
            GetSectionById = 10,
            AddDynamicSection = 10,
            AddFormSection = 1,
            SaveOnlineForms = 1,
            EditOnlineForms = 2,
            DeleteDynamicForm = 3,
            ArchiveForm = 6,
            SetActiveForm = 10,
            UnArchiveForm = 7,
            GetFormsData = 1,
            GetViperTemplates = 14,
            PublishUnPublishForm = 11,
            UpdateTemplateActionId = 5,
            AttachmentActionId = 8,
            FielUpdateActionId = 7,
            RequiredUpdateActionId = 7,
            TemplateCopyActionId = 1,
            CopyActionId = 2,
            ActiveForms = 1,
            AllDynamicFormsBySchoolId = 2,
            DynamicFormsByFormId = 3,
            SesctionByFormId = 4,
            ControlsByFormId = 5,
            DynamicEditDataByRecordId = 6,
            ActionId = 7,
            DynamicSectionBySectionId = 10,
            AtutoSaveActionId = 1,
            AtutoSaveBlankActionId = 9,
        }
        public enum QuerySupportAction
        {
            InputTypeId = 1,
            SchoolId = 2,
            FamilyRoleId = 3,
            LoadIndexActionId = 4
        }

        public enum Reports
        {
            MissingAttendance = 12,
            DelinquentBalances = 243
        }

        public enum Modules
        {
            Billing=24
        }

        public static class Constants
        {
            public const string NoAccessPage = "~/home/no-access/";
            public const string ErrorPage = "~/error/";
            public const int SiteID = 3;    //family
        }

        public enum FamilySection
        {
            Lunch = 1,
            Billing = 2,
            PrivateMessages = 3,
            Discipline = 4,
            Alerts = 5,
            NurseVisits = 6,
            ReportCards = 7,
            ReEnrollment = 8,
            AcademicInformation = 9,

        }
        public enum DiocesePermissions
        {

            General = 5000,                     // basic logon privilages - added to every user on logon

            //Group: Diocese Security
            Admin_ManagePermissions = 5001,     // manage user privilages
            Admin_AddUpdateDeleteUsers = 5007,  // manage users

            //Group: Diocese Administrative
            Admin_UpdateDioceseProfile = 5002,  // update diocese info
            Parish_AddUpdateDelete = 5003,      // update parish info

            Notifications = 5004,                       // create, update notifications
            Notifications_SendToDioceseUsers = 5005,    // send to diocese users

            Admin_ManageSchoolGroups = 5006,    // add, update school groups (catholic or religious ed)
            Admin_ManageTrainingEvents = 5013,  // manage training events
            Admin_ManageClergy = 5023,
            Admin_ManageFiles = 5024,
            Admin_AddDataRequest = 5025,
            Admin_ApproveDataRequest = 5026,

            // Group: Catholic School Super User -- all catholic school related privilages

            //Group: Catholic School Basic - sees the school list
            CatholicSchool_General = 5014,

            // Group: Catholic School Student/Parent Directory 
            CatholicSchool_DirectoryStaff = 5008,
            CatholicSchool_DirectoryStudents = 5009,
            CatholicSchool_DirectoryParents = 5010,
            CatholicSchool_DirectoryAlumni = 5011,

            // Group: Catholic School Admin - sensitive catholic school stuff
            CatholicSchool_LoginToSchool = 5012,

            // Group: Catholic Schhol Reports - reports
            CatholicSchool_Reports = 5015,

            // permissions that make up the religious ed section of the site
            // Groups: Basic, Student/Parent Directory, Admin, Reports
            ReligiousEd_Schools = 5016,             // view religiuos ed schools
            ReligiousEd_DirectoryStaff = 5017,
            ReligiousEd_DirectoryStudents = 5018,
            ReligiousEd_DirectoryParents = 5019,
            ReligiousEd_DirectoryAlumni = 5020,
            ReligiousEd_LoginToSchool = 5021,       // login as administrator to the school
            ReligiousEd_Reports = 5022,             // run religious ed reports

            Scholarship_General = 5030,              // manage donors etc

            //AdHoc Report Permissions
            Admin_CreateAdHocReport = 5035,
            Admin_ViewAdHocReport = 5036,

            Admin_UpdateDioceseUserID = 5037,
            Admin_StudentSearch = 5038,

            // Enum  Diocese Permission
            
            AccessNonCustomer = 1110,
            UpdateNonCustomer = 1111,
            AccessCustomer = 1112,
            UpdateCustomer = 1113,
            Sales = 1114,
            AddComment = 1115,
            AccessInternalData = 1116


        }

        public enum FamilyPermissions
        {

            //All
            General = 6000,                     // basic logon privilages - added to every user on logon

            //Parents Only
            Communication_PrivateMessages = 6001,
            Communication_ManageAlerts = 6004,

            Office_Billing = 6002,
            Office_LunchOrder = 6003,
            Office_FamilyProfile = 6006,

            Faith_MassCardRequest = 6005,

            Student_NurseVisits = 6007,

            Office_TeacherConferences = 6008,

            Student_ReportCards = 6009,

            General_ChangePassword = 6010,

            Office_ReEnrollment = 6011,

            Student_Scholarship = 6012,
            CommuniCation_Academicinformation=6013

        }

        public enum TicketingPermissions
        {
            Access = 1000,
            Update = 1001,
            Create = 1002
        }

        public enum SchoolPermissions
        {
            AccessNonCustomer = 1100,
            UpdateNonCustomer = 1101,
            AccessCustomer = 1102,
            UpdateCustomer = 1103,
            Sales = 1104,
            AddComment = 1105,
            AccessInternalData = 1106
        }

    }
}
