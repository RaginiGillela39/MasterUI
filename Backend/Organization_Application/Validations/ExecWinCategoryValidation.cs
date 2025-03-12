
using TQMS_Admin_Domain.Entities;

namespace TQMS_Admin_Application.Validations
{
    public class ExecWinCategoryValidation : IExecWinCategoryValidator
    {
        public void ValidateEntity(ExecutiveWindowCategory executiveWindowCategory)
        {
            Guard.IsNotNull(executiveWindowCategory, nameof(executiveWindowCategory));
            Guard.IsNotNullOrWhiteSpace(executiveWindowCategory.Name, nameof(executiveWindowCategory.Name));
        }
    }
}
