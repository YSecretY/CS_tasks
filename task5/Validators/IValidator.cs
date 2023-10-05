namespace task5.Validators;

public interface IValidator<TEntity>
{
    /// <summary>
    /// Checks if given entity is valid.
    /// </summary>
    /// <param name="entity">Given entity.</param>
    /// <returns></returns>
    public bool IsValid(TEntity entity);
}