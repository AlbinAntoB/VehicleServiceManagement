using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleSeviceManagement.Framework
{
    public static class URLRouting
    {
        public class AdmissionsRouting
        {
            public const string WelcomePage = "welcome-page";
            public const string WelcomePageSuccess = "welcome-page-success";
            public const string Registration = "user-registration";
            public const string RegistrationSuccess = "user-registration-success";
            public const string AdmisssionFamilyDetails = "family-details-admisssion";
            public const string AdmissionParentList = "parent-list-admisssion";
            public const string AdmissionAddParent = "addnew-parent-admisssion";
            public const string AdmissionStudentList = "student-list-admisssion";
            public const string AdmissionAddStudents = "addnew-student-admisssion";
            public const string SubmitToSchool = "submit-student-school";
            public const string SaveProspectAdmissions = "save-prospect-admissions";
            public const string SaveFamilyAdmissions = "save-family-admissions";
            public const string SaveParentAdmissions = "save-parent-admissions";
            public const string SubmitPayment = "submit-payment-admissions";
            public const string MMSubmitPayment = "MM-payment-admissions";
            public const string MMexistingSubmitPayment = "MM-existing-payment-admissions";
            public const string MMpaymentaccounts = "MM-payment-accounts";
            public const string Logout = "logout-admissions";
            public const string Unsubscribe = "Unsubscribe";
            public const string UnsubscribeVerification = "Unsubscribe-verification";
            public const string UnsubscribeEmail = "Unsubscribe-Email";
        }

        public static class DirectoriesRouting
        {
            public const string UserProfile = "~/user-profile";
            public const string AddUserProfile = "~/add-user-profile";
            public const string MyUserProfile = "~/my-user-profile";
            public const string RegisterNewUser = "~/register-new-user";
            public const string AddNewStaff = "~/add-new-staff";

            public const string ParishDetails = "~/parish-details";
            public const string ParishDetailsAdd = "~/add-parish-details";
            public const string ParishAssociate = "~/parish-associate";
            public const string DisabledUser = "~/disabled-user";
            public const string StudentsDetails = "~/students-details";
            public const string DeleteStudent = "~/delete-student";
            public const string ProspectsDetails = "~/prospects-details";
            public const string RelativesDetails = "~/relatives-details";
            public const string FamilyDetails = "~/family-details";
            public const string StaffDetails = "~/staff-details";
            public const string StudentsAlumni = "~/students-alumni";
            public const string DirectoriesDashboard = "~/directories-dashboard";
            public const string StudentPhotoUpload = "~/student-photo-upload";
            public const string Profile = "~/profile";
            public const string FamilyAlert = "~/family-alert";
            public const string FamilyPermissions = "~/family-permissions";
            public const string CustomFieldLabels = "~/custom-field-labels";
            public const string DirectoriesReports = "~/directories-report-list";
            public const string DirectoriesTools = "~/directories-tools";
            public const string RelativeLogin = "~/relative-login";
            
            //Student Register
            public const string AcademicSupport = "~/academic-support";

            public const string Demographics = "~/demographics";
            public const string GovernmentPrograms = "~/government-programs";
            public const string Sacraments = "~/sacraments";
            public const string StudentHomeSituation = "~/student-home-situation";
            public const string SecurityProfile = "~/security-profile";
            public const string Immunizations = "~/immunizations";
            public const string ImmunizationHistory = "~/immunization-history";
            public const string NewImmunization = "~/new-immunization";
            public const string MedicalInfo = "~/medical-info";
            public const string Medications = "~/medications";
            public const string NurseProfile = "~/nurse-profile";
            public const string StudentNurseVisit = "~/student-nurse-visit";

            //public const string MedicalProviderList = "~/medical-provider-list";
            public const string AddMedicalProvider = "~/add-medical-provider";

            public const string PrimaryHospital = "~/primary-hospital";
            public const string SecondaryHospital = "~/secondary-hospital";
            public const string NurseVisitRecord = "~/nurse-visit-record";
            public const string AddNurseProfile = "~/add-nurse-profile";
            public const string NewMedication = "~/new-medication";
            public const string EditMedication = "~/edit-medication";
            public const string ParishList = "~/parish-list";
            public const string Conduct = "~/conduct";
            public const string EmergencyContact = "~/emergency-contact";
            public const string AddEmergencyContact = "~/add-emergency-contact";
            public const string StudentSchedule = "~/student-schedule";

            // Staff
            public const string StaffDemographics = "~/staff-demographics";

            public const string StaffVirtusSafeguarding = "~/staff-virtus-safeguarding";
            public const string StaffSchoolRelated = "~/staff-school-related";

            public const string StaffEmergencyContact = "~/staff-emergency-contact";
            public const string StaffImmunizations = "~/staff-immunizations";
            public const string StaffFamilyAlert = "~/staff-family-alert";
            public const string StaffSchedule = "~/staff-schedule-list";
            public const string ProfessionalDevelopmentEvents = "~/professional-development-events";
            public const string AddProfessionalEvent = "~/add-professional-event";
            public const string ProfessionalEditDates = "~/professional-edit-dates";

            // Proffional Development Events
            public const string ProfDevCategories = "~/prof-dev-categories";

            public const string ProfDevProvider = "~/prof-dev-provider";
            public const string ProfDevProviderAdd = "~/prof-dev-provider-add";
            public const string ProfDevTimeofDay = "~/prof-dev-timeofday";
            public const string ProfDevDashboard = "~/prof-dev-dashboard";

            //Relative
            public const string RelativeDemographics = "~/relative-demographics";

            public const string RelativeFamilyAlert = "~/relative-family-alert";
            public const string RelativeFamilyPermissions = "~/relative-family-permissions";

            // Daily Nurse Activity
            public const string MedicationNotifications = "~/medication-notifications";

            public const string MedicationDashboard = "~/medication-dashboard";

            // Administration Log
            public const string NewAdministrationLog = "~/new-administration-log";

            public const string MedicationAdministrationLog = "~/medication-administration-log";
            public const string EditAdministrationLog = "~/edit-administration-log";

            //Conduct
            public const string AboutConduct = "about-conduct-forms";

            public const string General = "general";
            public const string History = "history";
            public const string ConductHistory = "conduct-history";
            public const string ConductItems = "conduct-items";
            public const string Location = "location";
            public const string Action = "action";
            public const string StudentConduct = "student-conduct";

            //Student Profile Summary
            public const string ProfileSummary = "~/student-profiles";

            public const string ProfileMain = "~/profile-main";

            public const string ProfileDemographics = "~/profile-demographics";
            public const string ProfileFamilyinfo = "~/profile-familyinfo";
            public const string ProfileGovtPrograms = "~/profile-govt-programs";
            public const string ProfileMedicalProfile = "~/profile-medical-profile";
            public const string ProfileSacraments = "~/profile-sacraments";
            public const string ProfileStudentSecurity = "~/profile-student-security";
            public const string ProfileUniqueFamilyinfo = "~/profile-unique-familyinfo";
            public const string DailyLog = "~/daily-log";

            public const string PublicSchoolList = "~/public-school-list";

            // Medical Provider
            public const string MedicalProviderAdd = "~/medical-provider-add";

            public const string MedicalProviderList = "~/medical-provider-list";

            // Public School Mangager
            public const string PublicSchoolManager = "~/public-school-manager";

            public const string AddSchool = "~/add-school";
            public const string AddDistrict = "~/add-district";
            public const string DistrictSummary = "~/district-summary";
            public const string SchoolSummary = "~/school-summary";
            public const string DistrictStudentList = "~/district-student-list";
            public const string PublicSchoolStudentList = "~/public-school-student-list";
            public const string ExcludeDistricts = "~/exclude-districts";
            public const string DistrictDelete = "~/district";
            public const string PublicSchoolDelete = "~/public-school";

            // Groups
            public const string AddGroup = "~/add-group";

            public const string GroupList = "~/group-list";
            public const string BillingGroupMembers = "~/billing-group-members";

            public const string GradeLevelRequirements = "~/grade-level-requirements";

            public const string MenuNavigation = "~/menu-navigation";
            public const string StaffMenuNavigation = "~/staff-menu-navigation";
            public const string RelativeMenuNavigation = "~/relative-menu-navigation";
        }

        public static class AdminEformsRouting
        {
            public const string RenderDynamicForm = "~/admin-add-record";
            public const string StaffRenderDynamicForm = "~/staff-add-record";
            public const string StudentRenderDynamicForm = "~/staff-student-add-record";
        }
        public static class EdFiRouting
        {
            public const string EdFiAutoLogin = "EdFi-auto-login";
        }
        public static class OnlineFormsRouting
        {
            public const string AboutDynamicForm = "~/admin-about-us";
            public const string StaffAboutUs = "~/staff-about-us";

            public const string eFormsList = "~/eforms-list";
            public const string StaffeFormsList = "~/staff-eforms-list";
            public const string FamilyeFormsList = "~/family-eforms-list";

            public const string ViewOnlineForm = "~/view-online-forms";
            public const string StaffActiveForms = "~/staff-active-forms";
            public const string ActiveForms = "~/active-forms";
            public const string FormStatus = "~/form-status";
            public const string AdminForms = "~/admin-forms";
            public const string OnlineFormsIndex = "~/online-forms-index";
            public const string GetParentChild = "~/parent-active-forms";
            public const string GetStudentActiveForms = "~/student-active-forms";
            public const string AddOnlineForms = "~/add-online-form";
            public const string DeleteDynamicForm = "~/view-forms";

            public const string AllArchiveForm = "~/archive-forms";
            public const string SaveNewField = "~/add-new-field";
            public const string SaveFormField = "~/add-new-form-form";
            public const string OnlineFormsTemplate = "~/template-forms";
            public const string PreviewForm = "~/preview-forms";
            public const string PreviewPDFExport = "~/Preview-pdf-export";
            public const string ViewTemplate = "~/eforms-templates";
            public const string ViewFormCategory = "~/form-category";

            public const string RenderDynamicForm = "~/add-record";
            public const string StudentActiveForms = "~/student-active-eforms";
            public const string StudentRenderForm = "~/student-add-record";

            // public const string RenderDynamicForm = "~/parent-add-record";
            public const string DynamicFormRecords = "~/view-responses";
            public const string ParentViewResponse = "~/parent-multiple-response";
            public const string StudentViewResponse = "~/student-view-response";

            public const string ViewFormResponses = "~/view-form-responses";

            public const string ParentActiveForms = "~/parent-portal-active-forms";
            public const string Index = "~/field-mapping";
            public const string Add = "~/field-add";
            public const string FormExcelImport = "~/form-excel-import";
            public const string StaffFormExcelImport = "~/staff-form-excel-import";
            public const string ImportSMS_SPHistory = "~/sms_sp_history";
        }

        public static class SupportMenuRouting
        {
            public const string DocumentationLibraryView = "~/documentationlibrary-view";
            public const string FAQView = "~/faq-view";
            public const string OnlineTrainingView = "~/onlinetraining-view";
            public const string SecureMessageView = "~/securemessage-view";
            public const string Modules = "~/modules";
            public const string ContactInformationView = "~/contactinformation-view";
            public const string Documents = "~/documents";
            public const string TrainingVideosView = "~/trainingvideos-view";
            public const string SuccessMesasage = "~/successmesasage-view";
            public const string CommunitySupport = "~/community-suppport";
            public const string OptioncLMS = "~/optionclms";
            public const string SiteMap = "~/site-map";
        }

        public static class ParentPortal
        {
            public const string dashborad = "~/dashborad";

            public static class Student
            {
                public const string AttendanceHistory = "~/attendance-history";
                public const string AssignmentOverview = "~/assignment-overview";
                public const string Assignments = "~/assignments";
                public const string Classes = "~/student-classes";
                public const string ReportCards = "~/report-cards";
                public const string TermGrades = "~/term-grades";
                public const string NurseVisit = "~/nurse-visit";
                public const string behavior = "~/student-behavior";
                public const string LoadLMSStandard = "~/lms-standard";
                public const string Scholarship = "~/scholarship";
                public const string SystemPage = "~/system-page";

                public const string LMSNotififcation = "~/LMS-Notififcation";
                public const string StudentResourceAssignment = "~/student-resource-assignment";
                public const string StudentResources = "~/student-resource";
                public const string ViewReportCard = "~/ViewReportCard";
            }

            public static class StudentLMS
            {
                // public const string StudentResources = "~/student-resource";
                //public const string FileLibrary = "~/file-library";
            }

            public static class Communication
            {
                public const string PrivateMesssages = "~/private-messsages";
                public const string FileLibrary = "~/file-library";
                public const string ManageAlerts = "~/manage-alerts";
                public const string UpdateAlerts = "~/UpdateAlerts";
                public const string MassCardRequest = "~/masscard-request";
                public const string Documents = "~/documents";
            }

            public static class Office
            {
                public const string Calendar = "~/calendar";
                public const string ContactInformations = "~/contact-informations";
                public const string FamilyProfile = "~/family-profile";
                public const string MealsOrder = "~/meals-order";
                public const string StudentProfile = "~/student-profile";
                public const string TeacherConferences = "~/teacher-conferences";
            }
        }

        public static class OptionSISRouting
        {
            public const string Dashboard = "~/dashboard";
            public const string ModuleDashboard = "~/module-dashboard";

            public const string SaintoftheDay_View = "~/saint-of-the-day-view";
            public const string GetNotifications = "~/get-notifications";
            public const string OptionCLogin = "~/login";
            public const string Authentication = "~/authentication";
            public const string FindSchool = "~/find-school";
            public const string ForgotPassword = "~/forgot-password";
            public const string ResetPassword = "reset-password";
            public const string UpdatePassword = "update-password";
            public const string ResumeLogin = "resume-login";

            public const string ParentDashboard = "~/_Dashboard";
            public const string FamilyDashboard = "~/family-dashboard";
            public const string ClassDashboardTasks = "class-dashboard-tasks";
            public const string SetMenu = "~/set-menu";
            public const string SetMenuParent = "~/set-menu-parent";
            public const string Registration_Cath = "~/cath-registration";

            public const string OldOptionCLogin = "~/old-optionc-login";
        }

        public static class LessonPlanRouting
        {
            public const string LessonPlanDetailsAdd = "~/add-Lesson-plan-detail";
            public const string LessonPlanDetailsSave = "~/save-Lesson-plan-detail";
            public const string PushNotificationDetails = "~/push-notification-details";
            public const string AddPushNotification = "~/add-push-notification";
            public const string LessonPlanPreview = "~/lesson-plan-preview";


            public const string LessonPlanTemplateAdd = "~/lesson-plan-template-add";
            public const string LessonPlanTemplateView = "~/lesson-plan-template-view";
            public const string LessonPlanTemplatePreview = "~/lesson-plan-template-preview";


            public const string LessonPlanDetailsView = "~/view-lesson-plan";
            public const string AdminLessonPlanDetailsView = "~/admin-view-lesson-plan";
            public const string LessonPlanDetailsEdit = "~/edit-lesson-plan";
            public const string SubmitforReview = "~/lesson-plan-submit-for-review";
            public const string LessonPlanDetailsTemplateChoose = "~/choose-lesson-plan-template";
            public const string LessonPlanDetailsAbout = "~/about-lesson-plan-details";
            public const string LessonPlanDetailsStaffDashboard = "~/Staff-lesson-plan-detail";
            public const string LessonPlanDetailsAdminDashboard = "~/admin-lesson-plan-detail";
            public const string LessonPlanDetailsPreview = "~/preview-lesson-plan-detail";
            public const string AssignmentWeightage = "assignment-weightage";
            public const string MyLessonPlansSettings = "my-lessonplan-settings";

            public const string LessonPlanDetailsPreviewone = "~/preview-lesson-plan-detail-one";
            public const string LessonPlanDetailsPreviewtwo = "~/preview-lesson-plan-detail-two";
            public const string LessonPlanDetailsPreviewthree = "~/preview-lesson-plan-detail-three";
            public const string LessonPlanDetailsPreviewfour = "~/preview-lesson-plan-detail-four";
            public const string LessonPlanDetailsPreviewfive = "~/preview-lesson-plan-detail-five";
            public const string LessonPlanDetailsPreviewsix = "~/preview-lesson-plan-detail-six";
            public const string LessonPlanDetailsPreviewseven = "~/preview-lesson-plan-detail-seven";
            public const string LessonPlanDetailsPrevieweight = "~/preview-lesson-plan-detail-eight";
        }

        public static class LessonPlanStandardsRouting
        {
            public const string AddLessonPlanstandards = "~/add-Lesson-plan-standards";
        }

        public static class AssignmentRouting
        {
            public const string Assignments = "~/add-assignment";
            public const string AssignmentList = "~/assignment-list";
            public const string ClassFiles = "~/class-files";
            public const string MissingAssignment = "~/missing-assignment";
            public const string ClassAverages = "~/class-averages";
            public const string GeneralLog = "~/student-access-log";

            public const string Settings = "~/settings";
            public const string ExportMissingAssignment = "~/export-missing-assignment";
        }

        public static class FeeManagementRouting
        {
            public const string DashboardView = "~/admin-dashboard";
            public const string FeeDashboardView = "~/fee-dashboard";
            public const string AdminDashboardView = "~/billing-dashboard-details";
            public const string BillingItemsView = "~/billing-items-View";
            public const string BillingItemAdd = "~/billing-item-Add";
            public const string BillingCategroyAdd = "~/billing-category-Add";
            public const string BillingCateories = "~/billing-categories";
            public const string BillingGroupsView = "~/billing-groups-View";
            public const string BillingGroupAdd = "~/billing-group-Add";
            public const string BillingGroupMembers = "~/billing-group-members-view";
            public const string ReportList = "~/report-list";
            public const string AccountBillingStatement = "~/account-balance-statement";
            public const string ACHActivityReport = "~/ach-activity-report";
            public const string CardActivityReport = "~/card-activity-report";
            public const string ACHDetailReport = "~/ach-detail-report";
            public const string CardDetailReport = "~/card-detail-report";
            public const string ACHBankFundingReport = "~/ach-bankfunding-report";
            public const string TransactionFaild = "~/transaction-failed";
            public const string ACHTransactionSummary = "~/transaction-summary";
            public const string CardBankFundingReport = "~/card-bankfunding-report";
            public const string AccountBillingStatementPDF = "~/account-balance-statementpdf";
            public const string AgingofReceivable = "~/billing-agingofreceivable";
            public const string ArrearsReport = "~/billing-arrearsreport";
            public const string ArrearsTransaction = "~/billing-arrearstransaction";
            public const string OverAllBillingBalance = "~/overall-billing-balance";
            public const string BillingItemUsage = "~/billing-item-usage";
            public const string CurrentBalanceNotices = "~/billing-current-balance-notice";
            public const string DelinquentAccountBalanceNotices = "~/delinquent-account-balance-notice";
            public const string LunchTransaction = "~/billing-lunch-transaction";
            public const string BillingPaymentStatement = "~/billing-payment-statement";
            public const string PaymentTransaction = "~/billing-payment-transaction";
            public const string MakePayment = "~/billing-payment";
            public const string MakePayments = "~/billing-payments";
            public const string BillingSettings = "~/billing-settings";
            public const string LedgerView = "~/billing-ledger-view";
            public const string ChargesAdd = "~/billing-charges";
            public const string RecurringList = "~/billing-recurring-list";
            public const string StudentGroupCodes = "~/Student-Group-Codes";
            public const string GroupCodeTotals = "~/group-code-totals";
            public const string TransactionList = "~/transaction-list";
            public const string EFTCCTransactionList = "~/eft-cc-transaction-list";
            public const string ParentAccountSetup = "~/parent-account-setup";
            public const string AutoPaymentStatus = "~/auto-payment-status";
            public const string ACHAnnualServiceFee = "~/ach-annual-service-fee";
        }

        public static class AttendanceRouting
        {
            public const string HomeroomsMissingAttendance = "~/homerooms-missing-attendance";
            public const string MonthlyAttendanceByClass = "~/monthly-attendance-by-class";
            public const string AttendanceReports = "~/attendance-reports";
            public const string MonthlyAttendance = "~/monthly-attendance";
            public const string MissingAttendance = "~/missing-attendance";
            public const string AttendanceTotalsIndividualClass = "~/attendance-totals-individual-class";
            public const string AttendanceTotalsIndividualStudent = "~/attendance-totals-individual-student";
            public const string DailyAttendanceHomerooms = "~/daily-attendance-homerooms";
            public const string DailyAttendance = "~/daily-attendance";
            public const string AttendanceByClass = "~/attendance-by-class";
            public const string PerfectAttendance = "~/perfect-attendance";
            public const string YearlyAbsenceRateByGrade = "~/yearly-absence-rate-by-grade";
            public const string FirstDaysAttendance = "~/first-days-attendance";
            public const string TardyQuarterTime = "~/tardy-quarter-time";
            public const string PerfectAttendanceByTerm = "~/perfect-attendance-by-term";
            public const string TotalTimeMissed = "~/total-time-missed";
            public const string CumulativeAttendanceTotalsByClass = "~/cumulative-attendance-totals-by-class";
            public const string AttendanceTotalsByClassReport = "~/attendance-totals-by-class-report";
            public const string OverallAttendance = "~/overall-attendance";
            public const string AttendanceTotalsIndividualStudentEntireYear = "~/attendance-totals-individual-student-entire-year";
            public const string YearlyAttendanceDetails = "~/yearly-attendance-details";
            public const string MonthlyAttendanceSessions = "~/monthly-attendance-sessions";
            public const string MonthlyAttendanceSessionsPDF = "~/monthly-attendance-sessions-pdf";
            public const string DailyAttendanceYearSummary = "~/daily-attendance-year-summary";
            public const string DailyAttendanceHistoryReport = "~/daily-attendance-history";
            public const string DailyAttendanceYearSummaryPDF = "~/daily-attendance-year-summary-pdf";
            public const string DailyAttendanceHistoryReportPDF = "~/daily-attendance-history-pdf";
            public const string ClassRoster = "~/class-roster";
            public const string ClassReports = "~/class-reports";
            public const string DeleteStudentFromClass = "~/delete-student-from-class";
            public const string AddStudentToClass = "~/add-student-to-class";
            public const string StaffAttendanceStatusList = "~/staff-attendance-status-list";
            public const string StaffAttendanceStatusSave = "~/staff-attendance-status-save";
            public const string StaffAttendanceStatusDelete = "~/staff-attendance-status-delete";
            public const string StaffAttendance = "~/staff-attendance";
            public const string StaffAccumulatedSickDays = "~/staff-accumulated-sickdays";
            public const string StudentAttendance = "~/student-attendance";
            public const string StudentAttendanceOptions = "~/student-attendance-options";
            public const string Absentees = "~/Absentees";
            public const string AttendanceOptionsSave = "~/attendance-options-save";
            public const string ResetFirstAttendanceDate = "~/reset-first-attendance-date";
            public const string StudentAttendanceStatusList = "~/student-attendance-status-list";
            public const string StudentAttendanceStatusAdd = "~/student-attendance-status-add";
            public const string StudentAttendanceStatusEdit = "~/student-attendance-status-edit";
            public const string StudentAttendanceStatusSave = "~/student-attendance-status-save";
            public const string MyAttendanceSettings = "my-attendance-settings";
            public const string GetClassPermissionsforGradebook = "get-classpermissions-for-gradebook";
            public const string GetClassPermissions = "get-classpermissions";

            public const string MyAssignmentsSettings = "~/myassignments-settings";

        }

        public static class GradebookRouting
        {
            public const string Index = "~/gradebook";
            public const string Test = "~/Test";
            public const string StandardGradebook = "~/standard-gradebook";
            public const string Help = "~/gradebook-help";
            public const string ScalesDashboard = "~/scales-dashboard";
            public const string AlphaScales = "~/alpha-scales";

            public const string SaveAlphaScaleGroup = "~/save-alphascale-group";
            public const string SaveAlphaScaleGroupValue = "~/save-alphascale-group-value";
            public const string UpdateAlphaScaleGroup = "~/update-alphascale-group";
            public const string DeleteAlphaScaleGroup = "~/delete-alphascale-group";
            public const string DeleteAlphaScaleGroupValue = "~/delete-alphascale-group-value";
            public const string EditAlphaScaleGroup = "~/edit-alphascale-group";
            public const string EditAlphaScaleGroupValue = "~/edit-alphascale-group-value";
            public const string MealsDiscount = "~/meals-studenteligibility";

            public const string AlphaScaleEdit = "~/alpha-scales-edit";
            public const string AlphaScaleValueEdit = "~/alpha-scale-value-edit";

            //public const string BehaviorScales = "~/learner-behavior-scales";
            public const string CommentCodes = "~/comment-codes";

            public const string GradeScales = "~/grade-scales";
            public const string SkillScales = "~/skill-scales";
            public const string SkillsGrade = "~/skills-grade";
            public const string LearnerBehaviors = "~/learner-behaviors";
            public const string ExportLearnerBehaviors = "~/export-learner-behaviors";
            public const string ExportLearnerBehaviorScale = "~/export-learner-behaviors-scale";
            
            public const string LearnerBehaviorScales = "~/learner-behavior-scales";
            public const string LearnerBehaviorsGrade = "~/learner-behaviors-grade";
            public const string FinalTermGrades = "~/final-term-grades";
            public const string GroupGradesNonCalculated = "~/groupgrades-noncalculated";
            public const string GroupGrades = "~/groupgrades";
            public const string WeightsSummary = "~/weights-summary";
            public const string AssignmentSubmissionHistory = "~/assignment-submission-history";
            public const string DownloadAssignmentFile = "~/download-assignment-file";
            public const string UpdateWeightType = "~/update-weight-type";
            public const string SingleStudentTermGrades = "~/single-student-grading";
            public const string StudentGrades = "~/student-grades";
            public const string AssignmentGrades = "~/assignment-grades";
            public const string StudentGradebook = "~/student-gradebook";
            public const string GPADashboard = "~/gpa-dashboard";
            public const string GPADetails = "~/gpa-details";
            public const string GPADefinition = "~/gpa-definition";
            public const string GPAByTerm = "~/gpa-by-term";
            public const string CourseListGo = "~/Course-List-Go";            
        }

        public static class CommunicationRouting
        {
            public const string Index = "~/communication-dashboard";
            public const string ViewAnnouncements = "~/view-announcement";
            public const string SaveAnnouncements = "~/save-announcement";
            public const string EditAnnouncements = "~/edit-announcement";
            public const string DeleteAnnouncements = "~/delete-announcement";
            public const string ViewAnnouncementsHistory = "~/view-announcement-history";
            public const string PreviewAnnouncementSummary = "~/preview-announcement-history";
            public const string AddAnnouncements = "~/add-announcement";
            public const string BulletinDateGo = "~/view-history-datego";
            public const string DateListGo = "~/view-datego";

            public const string ViewCalendar = "~/view-calendar";
            public const string AddCalendar = "~/add-calendar";
            public const string ViewGoogleCalendar = "~/view-google-calendar";
            public const string SaveGoogleCalendar = "~/save-google-calendar";
            public const string DeleteCalendarDetails = "~/delete-calendar";

            public const string ViewFileLibrary = "~/view-filelibrary";
            public const string ViewFileAccessLog = "~/view-file-accesslog";
            public const string IndividualFileAccessLog = "~/individualfile-accesslog";
            public const string AddFileLibrary = "~/add-filelibrary";
            public const string SaveFileUpload = "~/save-filelibrary";
            public const string DeleteFileLibrary = "~/delete-filelibrary";
            public const string PreviewFile = "~/preview-file-library";

            public const string FileLibraryCategories = "~/view-filelibrary-categories";
            public const string AddFileCategories = "~/add-filelibrary-categories";
            public const string DeleteFileCategory = "~/delete-filelibrary-categories";
        }

        public static class CoursePlanRouting
        {
            public const string UnitPlanAdd = "~/add-unit-plan";
            public const string UnitPlanPreview = "~/unit-plan-preview";
            public const string UnitPlanSubmitReview = "~/unit-plan-submit-review";
            public const string UnitPlanReview = "~/unit-plan-review";
            public const string UnitPlanView = "~/view-unit-plan";
            public const string UnitPlanTemplateAdd = "~/unit-plan-template-add";
            public const string UnitPlanTemplatePreview = "~/unit-plan-template-preview";
            public const string UnitPlanTemplateView = "~/unit-plan-template-view";
            public const string UnitPlanSettings = "~/settings-unit-plan";
            public const string TemplateView = "~/templateview-unit-plan";
            public const string DeleteUnitPlanDetails = "~/Delete-unit-plan";
            public const string UnitPlanAbout = "~/about-unit-plan";
        }

        public static class DataUpdate
        {
            public const string StudentPhotoUploadTemplate = "~/student-photo-upload-template";
            public const string Publicschoolmanager = "~/public-school-manager-report";
            public const string StudentProfileSummary = "~/student-profile-summary";
            public const string ExportStudentPhotoUploadTemplate = "~/export-student-photo-upload-template";
        }

        public static class MyInformationsRouting
        {
            //MySchedule
            public const string MySchedule = "~/staff-schedule";

            public const string MassCardRequests = "masscard-requests";
            public const string MyFiles = "my-files";
            public const string MyOptionCOnlineTraining = "my-optionc-online-training";
            public const string MyScheduledTraining = "my-scheduled-training";
            public const string BillingAccounts = "my-billing-accounts";
            public const string LoadLmsStandard = "~/Learning-Management-Standard";
            public const string DownloadFile = "download-file";
        }

        public static class MySettingsRouting
        {
            public const string MyLunchSettings = "my-school-meals-settings";
            public const string MyGeneralSettings = "my-general-settings";
            public const string Classes = "classes";
            public const string Sorts = "sorts";
        }

        public static class MyMessages
        {
            //MySchedule
            public const string InboxMessage = "inbox-message";
        }

        public static class PermissionsRouting
        {
            public const string PermissionsDashboard = "dashboard-permissions";

            public const string AdminPermissions = "admin-permissions";

            public const string ProfileAlumniPermissions = "profile-alumni-permissions";
            public const string ProfileRelativePermissions = "profile-relative-permissions";
            public const string ProfileStudentPermissions = "profile-student-permissions";
            public const string ProfileStaffPermissions = "profile-staff-permissions";

            public const string ReportPermissions = "report-permissions";
            public const string ClassPermissions = "class-permissions";
            public const string UserPermissions = "user-permissions";
        }

        public static class TermManagerRouting
        {
            public const string TermManager = "term-manager";

            public const string AddNewYear = "add-newyear";
            public const string EditYear = "edit-year";
            public const string DeleteYear = "delete-year";

            public const string AddNewTerm = "add-newterm";
            public const string EditTerm = "edit-term";
            public const string DeleteTerm = "delete-term";

            public const string AddNewCalculatedTerm = "add-newCalculatedterm";
            public const string AddNewCalculatedTerm2 = "add-new-CalculatedTerm";
            public const string EditCalculatedTerm = "edit-Calculatedterm";
            public const string DeleteCalculatedTerm = "delete-Calculatedterm";
        }

        public static class MyClassess
        {
            public const string ViewMyClass = "view-myclass";
            public const string ClassCatalog = "class-catalog";
            public const string NOA = "no-access";
        }

        public static class ClassAdministration
        {
            public const string EmergencyDrills = "emergency-drills";
            public const string EmergencyDrillsAdd = "emergency-drills-add";
        }

        public static class TermScheduling
        {
            public const string TermSchedulingView = "term-scheduling-view";
            public const string Aboutus = "term-about-us";
            public const string GeneralSettings = "term-scheduling-GeneralSettings";
            public const string BellSchedule = "bell-schedule";
            public const string ClassRooms = "class-rooms";
            public const string AddNewBase = "new-view";
            public const string ViewClass = "view-class?ID=";
            public const string AddNewSave = "new-save";
            public const string HomeRoom = "home-room";
            public const string Teacher = "teacher";
            public const string ViewRedirect = "course-catalog-view";
            public const string AddCourse = "course-catalog-add";
            public const string CheckAdd = "/course-catalog-validate";
            public const string Save = "/course-catalog-save";
            public const string AddBuilding = "building-add";
            public const string AddRoom = "room-add";
            public const string SaveBuilidingData = "building-save";
            public const string SaveRoomData = "room-save";
            public const string UpdateBuliding = "building-update";
            public const string UpdateRoom = "room-update";
            public const string GenerateTimeSchedule = "term-scheduling-Generatetimetable";
            public const string CopyTermSchedule = "copy-term-schedule";
        }

        public static class Grading
        {
            public const string SkillsList = "skill-list";
        }
       
        public static class StaffEvaluation
        {
            public const string StaffEvaluationView = "staff-evaluation-view";
            public const string StaffDirectory = "staff-directory-list";
            public const string AddEvaluation = "add-evaluation";
            public const string PrintEvaluation = "print-evaluation";
            public const string UpdateEvaluation = "update-evaluation";
        }

        public static class HomePageRouting
        {
            public const string Logout = "logout";
            public const string Dashboard = "~/dashboard";
        }

        public static class ReportList
        {
            public const string NotYetEnrolledStudents = "not-yet-enrolled-students";
            public const string EnrolledStudents = "enrolled-students";
        }

        public static class ScholarshipRouting
        {
            public const string StudentList = "student-list";
            public const string StudentDetails = "student-details";
            public const string DonorList = "donar-list";
            public const string DonorDetails = "donor-details";
            public const string SaveDonorDetails = "save-donor-details";

            public const string FileList = "file-list";
            public const string ScholarshipUpload = "scholarship-upload";
            public const string ManualUpdate = "manual-update";
            public const string EnrollmentVerificationExport = "enrollment-verification-export";
            public const string GetDonorFilesPage = "download-donor-pdf";
            public const string GetDonorFilesZip = "download-donor-files";
        }

        public static class DioceseCommuncations
        {
            // Data Request
            public const string CategoryList = "/category-list";

            public const string AddCategory = "/new-category";
            public const string SubmissionList = "/submission-list";
            public const string CategoryDetails = "category-details";
            public const string SaveNewCategory = "save-Category-details";
            public const string NewDataRequest = "new-data-request";
            public const string DataRequestDetails = "data-request-details";
            public const string DataRequestList = "data-request-list";
            public const string DataRequestSchool = " school-list";
            public const string DataRequestArchived = "archived-request-list";
        }

        public static class FileAttachmentPath
        {
            public static string IMPORTSMSPREVIOUSDATA = @"\Attachment\\ImportSMS\\";
            public static string eFormsSMSSPBackup = "/eFormsSMSSPBackup/";
        }


        public static class DonorDetails
        {
            // Account Settings
            public const string AddAccountSettings = "account-add";
            public const string ViewAccountSettings = "account-view";
            //Donations
            public const string AddToCartDonation = "add-to-cart";
            public const string DonationAdd = "donation-add";
            public const string DonationLIst = "donation-list";
            public const string Inhands = "in-hands";
            public const string MakeDonation = "make-donation";
            //Donor 
            public const string DonorAdd = "donor-add";
            public const string DonorList = "donor-list";
            //Events
            public const string EventAdd = "event-add";
            public const string EventList = "event-list";
            public const string Events = "events";
            public const string EventDetails = "event-details";
            //Feedback
            public const string FeedbackAdd = "feedback-add";
            public const string ViewFeedback = "feedback-list";
            //Reports
            public const string DonationListReport = "donations";
            public const string DonationSummary = "donation-summary";
            //End User
            public const string AddtoCart = "addtocart";
            public const string AddtoWishlist = "addtowishlist";
            public const string MyGiving = "my-giving";
            public const string Event = "event";
            public const string Event_Details = "event-info";
            public const string Make_Donation = "donation";

            //Sample Pages
            public const string SampleView = "sample-view";
            public const string SampleAdd = "Sample-add";

        }

    }
}