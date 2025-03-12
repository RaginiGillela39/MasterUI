namespace TQMS_Organization_Application.Validations
{
    public class OrganizationValidation : IOrganizationValidator
    {
        public void ValidateEntity(Organization organization)
        {
            Guard.IsNotNull(organization, nameof(organization));
            Guard.IsNotNullOrWhiteSpace(organization.Name, nameof(organization.Name));
        }
    }
}
