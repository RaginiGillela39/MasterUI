

namespace TQMS_Organization_Application.Validations
{
    public class BranchValidation : IBranchValidator
    {
        public void ValidateEntity(Branch branch)
        {
            Guard.IsNotNull(branch, nameof(branch));
            Guard.IsNotNullOrWhiteSpace(branch.Name, nameof(branch.Name));
        }
    }
}
