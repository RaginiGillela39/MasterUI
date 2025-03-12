namespace TQMS_Organization_Application.Validations
{
    public class DepartmentValidation : IDepartmentValidator
    {
        public void ValidateEntity(Department department)
        {
            Guard.IsNotNull(department, nameof(department));
            Guard.IsNotNullOrWhiteSpace(department.Name, nameof(department.Name));
        }
    }
}
