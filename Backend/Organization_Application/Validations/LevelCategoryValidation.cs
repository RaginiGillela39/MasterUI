
using TQMS_Admin_Application.Contracts.IValidations;
using TQMS_Admin_Domain.Entities;

namespace TQMS_Admin_Application.Validations
{
    public class LevelCategoryValidation : ILevelCategoryValidator
    {
        public void ValidateEntity(LevelCategory levelCategory)
        {
            Guard.IsNotNull(levelCategory, nameof(levelCategory));
            Guard.IsNotNullOrWhiteSpace(levelCategory.Name, nameof(levelCategory.Name));
        }
    }
}
