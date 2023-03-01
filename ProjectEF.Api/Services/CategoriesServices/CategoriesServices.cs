using Newtonsoft.Json;
using ProjectEF.Shared.DataObjectLayer;

namespace ProjectEF.Api.Services.CategoriesServices
{
    public class CategoriesServices : ICategoriesServices
    {
        private readonly HttpClient httpClient;
        public CategoriesServices(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<bool> IsCategoryAvilable(Guid CategoryId)
        {
            var responseJSON = await httpClient.GetStringAsync($"{CategoryId}");
            var response = JsonConvert.DeserializeObject<CategoryDto>(responseJSON);
            return response != null;


        }
    }
}
