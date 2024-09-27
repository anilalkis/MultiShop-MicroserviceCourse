using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;

namespace MultiShop.WebUI.Services.CatalogServices.SliderServices
{
	public interface IFeatureSliderService
	{
		Task<List<ResultFeatureSliderDto>> GetAllFeatureSlidersAsync();
		Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto);
		Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto);
		Task DeleteFeatureSliderAsync(string id);
		Task<UpdateFeatureSliderDto> GetByIdFeatureSliderAsync(string id);
		Task ChangeStatusToFalseAsync(string id);
		Task ChangeStatusToTrueAsync(string id);
	}
}
