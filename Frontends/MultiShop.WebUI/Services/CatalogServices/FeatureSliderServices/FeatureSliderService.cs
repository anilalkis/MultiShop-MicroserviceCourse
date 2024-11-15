﻿using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CatalogServices.SliderServices
{
	public class FeatureSliderService : IFeatureSliderService
	{
		private readonly HttpClient _httpClient;

		public FeatureSliderService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public Task ChangeStatusToFalseAsync(string id)
		{
			throw new NotImplementedException();
		}

		public Task ChangeStatusToTrueAsync(string id)
		{
			throw new NotImplementedException();
		}

		public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto)
		{
			await _httpClient.PostAsJsonAsync<CreateFeatureSliderDto>("featuresliders", createFeatureSliderDto);
		}

		public async Task DeleteFeatureSliderAsync(string id)
		{
			await _httpClient.DeleteAsync("featuresliders?id=" + id);
		}

		public async Task<List<ResultFeatureSliderDto>> GetAllFeatureSlidersAsync()
		{
			var responseMessage = await _httpClient.GetAsync("featuresliders");
			var jsonData = await responseMessage.Content.ReadAsStringAsync();
			var values = JsonConvert.DeserializeObject<List<ResultFeatureSliderDto>>(jsonData);
			return values;
		}

		public async Task<UpdateFeatureSliderDto> GetByIdFeatureSliderAsync(string id)
		{
			var responseMessage = await _httpClient.GetAsync("featuresliders/" + id);
			var jsonData = await responseMessage.Content.ReadAsStringAsync();
			var values = JsonConvert.DeserializeObject<UpdateFeatureSliderDto>(jsonData);

			return values;
		}

		public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto)
		{
			await _httpClient.PutAsJsonAsync("featuresliders", updateFeatureSliderDto);
		}
	}
}