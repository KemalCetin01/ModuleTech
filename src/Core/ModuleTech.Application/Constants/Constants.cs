using ModuleTech.Domain.Enums;

namespace ModuleTech.Application.Constants;


public partial class Constants
{
    public class GroupRoleConstants
    {
        public const string ErrorWhenDeleted = "Error When Deleted";
        public const string KeycloakError = "Keycloak Error";
        public const string UserInRole = "There are active users associated with the permission you wish to delete. Please check the user permissions.";
    }
    public class EmployeeRoleConstants
    {

        public const string EmployeeRoleAddedError = "An Error Occured While Adding UserEmployee Role";
        public const string EmployeeRoleDeletedError = "An Error Occured While Deleting UserEmployee Role";
        public const string EmployeeRoleUpdatedError = "An Error Occured While Updating UserEmployee Role";
        public const string EmployeeRoleConflict = "UserEmployee Role Already Exists!";
        public const string EmployeeRoleNotFound = "UserEmployee Role Not Found";

        public const string EmployeeRoleSpaceControl = "The Name Field Nannot Contain a Space.";

        public const string ErrorWhenDeleted = "Error When Deleted";

        public const string Name = "name";
        public const string Description = "description";
        public const string DiscountRate = "discountRate";

    }
    public class B2BUserConstants
    {
        public const string RecordNotFound = "Record Not Found";

        public const string currentAccountName = "currentAccountName";
        public const string currentId = "currentId";
        public const string fullName = "fullName";
        public const string representative = "representative";
        public const string email = "email";
        public const string Id = "id";
        public const string CreatedDate = "createdDate";
    }

    public class EmployeeConstants
    {
        public const string EmployeeAdded = "UserEmployee Successfully Added";
        public const string EmployeeUpdated = "UserEmployee Successfully Updated";
        public const string EmployeeDeleted = "UserEmployee Successfully Deleted.";

        public const string EmployeeAddedError = "An Error Occured While Adding UserEmployee";
        public const string EmployeeDeletedError = "An Error Occured While Deleting UserEmployee";
        public const string EmployeeUpdatedError = "An Error Occured While Updating UserEmployee";
        public const string EmployeeConflict = "UserEmployee Already Exists!";

        public const string EmployeeCountDiff = "The number of parameters in the selected message template does not match the number of parameters sent.";

        public const string EmployeeNotFound = "UserEmployee Not Found";
        public const string EmployeeIdCanNotBeNullOrEmpty = "UserEmployee ID cannot be null or empty";

        public const string FullName = "fullName";
        public const string PhoneNumber = "phoneNumber";
        public const string Role = "role";
        public const string DiscountRate = "discountRate";
        public const string Email = "email";
        public const string LastDateEntry = "lastDateEntry";
    }
    public const string NumberSequence = "1234567890";

    public const string IsVerifiedUser = "This user is verified!";
    public const int OtpLenght = 6;
    public const string TurkeyCountryCode = "TR";
    public const SiteStatusEnum SiteStatusOpen = SiteStatusEnum.Open;
    public const SiteStatusEnum SiteStatusClosed = SiteStatusEnum.Closed;
    public const UserStatusEnum UserStatusDeleted = UserStatusEnum.Deleted;
    public const UserStatusEnum UserStatusActive = UserStatusEnum.Active;
    public const UserStatusEnum UserStatusInactive = UserStatusEnum.Inactive;
}