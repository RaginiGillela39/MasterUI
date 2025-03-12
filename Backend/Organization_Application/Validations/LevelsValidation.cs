namespace TQMS_Admin_Application.Validations
{
    public class LevelsValidation:ILevelsValidator
    {
        public void ValidateEntity(Levels levels)
        {
            Guard.IsNotNull(levels, nameof(levels));
            Guard.IsNotNullOrWhiteSpace(levels.Name, nameof(levels.Name));
        }
    }
}
