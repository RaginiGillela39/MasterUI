
using TQMS_Admin_Domain.Entities;

namespace TQMS_Admin_Application.Validations
{
    public class LevelHierarchyValidation : ILevelHierarchyValidator
    {
        public void ValidateEntity(LevelHierarchy levelHierarchy)
        {
            Guard.IsNotNull(levelHierarchy, nameof(levelHierarchy));
            Guard.IsNotNullOrWhiteSpace(levelHierarchy.Name, nameof(levelHierarchy.Name));
        }
    }
}
