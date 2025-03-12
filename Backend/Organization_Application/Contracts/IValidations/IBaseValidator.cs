namespace TQMS_Organization_Application.Contracts.IValidations
{
    public interface IBaseValidator<TEntity> where TEntity : class
    {
        void ValidateEntity(TEntity entity);
    }
}
