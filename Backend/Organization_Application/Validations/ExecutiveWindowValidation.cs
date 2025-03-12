
using TQMS_Admin_Domain.Entities;

namespace TQMS_Admin_Application.Validations
{
    public class ExecutiveWindowValidation : IExecutiveWindowValidator
    {
        public void ValidateEntity(ExecutiveWindow executiveWindow)
        {
            Guard.IsNotNull(executiveWindow, nameof(executiveWindow));
            Guard.IsNotNullOrWhiteSpace(executiveWindow.Name, nameof(executiveWindow.Name));
        }
    }
}
