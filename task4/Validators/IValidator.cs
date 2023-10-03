namespace task4;

public interface IValidator<TEntity>
{
    bool Validate(TEntity target);
}