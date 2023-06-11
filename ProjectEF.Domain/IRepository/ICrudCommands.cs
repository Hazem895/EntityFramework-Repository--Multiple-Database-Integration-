namespace ProjectEF.Domain.IRepository
{
    public interface ICrudCommands<T>
    {
        Task<IEnumerable<T>> ReadAll();
        Task<T?> ReadByID(Guid ID);
        Task<bool> Create(T Input);
        Task<bool> Update(T Input/*,Guid ID*/);
        Task<bool> Delete(Guid ID);
        Task<bool> Delete(string code);
    }
}
