using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Utility;
using static Mango.Web.Utility.SD;

namespace Mango.Web.Service
{
	public class CouponService : ICouponService
	{
		private readonly IBaseService _baseService;

		public CouponService(IBaseService baseService)
		{
			_baseService = baseService;
		}

		public async Task<ResponseDto?> CreateCouponAsync(CouponDto couponDto)
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = ApiType.POST,
				Data = couponDto,
				Url = SD.CouponAPIBase + "/api/coupon"

			});
		}

		public async Task<ResponseDto?> DeleteCouponAsync(int id)
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = ApiType.DELETE,
				Url = SD.CouponAPIBase + "/api/coupon/"+id

			});
		}

		public async Task<ResponseDto?> GetAllCouponAsync()
		{
			return await _baseService.SendAsync(new RequestDto(){
				ApiType = ApiType.GET,
				Url = SD.CouponAPIBase+"/api/coupon"
				
			});
		}

		public async Task<ResponseDto?> GetCouponAsync(string couponCode)
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = ApiType.GET,
				Url = SD.CouponAPIBase + "/api/coupon/GetByCode"+couponCode

			});
		}

		public async Task<ResponseDto?> GetCouponByIdAsync(int id)
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = ApiType.GET,
				Url = SD.CouponAPIBase + "/api/coupon/" + id

			});
		}

		public async Task<ResponseDto?> UpdateCouponAsync(CouponDto couponDto)
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = ApiType.PUT,
				Data = couponDto,
				Url = SD.CouponAPIBase + "/api/coupon"

			});
		}
	}
}
