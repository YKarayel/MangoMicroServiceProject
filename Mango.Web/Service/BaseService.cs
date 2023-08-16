using Mango.Web.Models;
using Mango.Web.Service.IService;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using static Mango.Web.Utility.SD;

namespace Mango.Web.Service
{
	public class BaseService : IBaseService
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public BaseService(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public async Task<ResponseDto?> SendAsync(RequestDto requestDto)
		{
			HttpClient client = _httpClientFactory.CreateClient("MangoAPI");
			HttpRequestMessage message = new();
			message.Headers.Add("Accept", "application/json");
			//token

			message.RequestUri = new Uri(requestDto.Url);

			if (requestDto.Data != null)
				message.Content = new StringContent(JsonSerializer.Serialize(requestDto.Data), Encoding.UTF8, "application/json");

			HttpResponseMessage? apiResponse = null;

			switch (requestDto.ApiType)
			{
				case ApiType.POST:
					message.Method = HttpMethod.Post;
					break;

				case ApiType.DELETE:
					message.Method = HttpMethod.Delete;
					break;

				case ApiType.PUT:
					message.Method = HttpMethod.Put;
					break;

				default:
					message.Method = HttpMethod.Get;
					break;
			}

			apiResponse = await client.SendAsync(message);
			try
			{
				switch (apiResponse.StatusCode)
				{
					case HttpStatusCode.NotFound:
						return new() { IsSuccess = false, Message = "Not Found" };

					case HttpStatusCode.Forbidden:
						return new() { IsSuccess = false, Message = "Forbidden" };

					case HttpStatusCode.Unauthorized:
						return new() { IsSuccess = false, Message = "Unauthorized" };

					case HttpStatusCode.InternalServerError:
						return new() { IsSuccess = false, Message = "InternalServerError" };

					default:
						var apiResponseDto = await apiResponse.Content.ReadFromJsonAsync<ResponseDto>();
						return apiResponseDto;
				}
			}
			catch (Exception ex)
			{
				var dto = new ResponseDto()
				{
					Message = ex.Message.ToString(),
					IsSuccess = false
				};
				return dto;
			}
		}
	}
}
