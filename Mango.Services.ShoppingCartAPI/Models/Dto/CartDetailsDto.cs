using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Mango.Services.ShoppingCartAPI.Models.Dto
{
	public class CartDetailsDto
	{
		public int CartDetailsId { get; set; }
		public int CartHeaderId { get; set; }
		public CartHeader? CartHeader { get; set; }
		public int ProdcutId { get; set; }
		public ProductDto? Product { get; set; }
		public int Count { get; set; }
	}
}
