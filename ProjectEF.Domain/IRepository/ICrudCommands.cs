namespace ProjectEF.Domain.IRepository
{
    public interface ICrudCommands<T>
    {
        IEnumerable<T> ReadAll();
        T? ReadById(Guid ID);
        string Create(T Input);
        string Update(T Input/*,Guid ID*/);
        string Delete(Guid ID);
    }
}
