namespace ProjectEF.Api.Services.CategoriesServices
{
    public interface ICategoriesServices
    {
        Task<bool> IsCategoryAvilable(Guid CategoryIds);
    }
}
