using System.ComponentModel.DataAnnotations;

namespace Mango.Web.Models
{
	public class CouponDto
	{
		[Key]
		public int CouponId { get; set; }
		[Required]
		public string CouponCode { get; set; }
		[Required]
		public double DiscountAmount { get; set; }
		[Required]
		public int MinAmount { get; set; }
	}
}
