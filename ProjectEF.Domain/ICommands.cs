namespace ProjectEF.Domain
{
    public interface ICommands<T>
    {
        public IEnumerable<T> Read(Guid? ID);
        public string Save(T Input);
        public string Update(T Input,Guid ID);
        public string Delete(Guid ID);
    }
}
