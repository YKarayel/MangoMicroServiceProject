using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Http.Headers;
using Mango.Services.ShoppingCartAPI.Models.Dto;

namespace Mango.Services.ShoppingCartAPI.Models
{
    public class CartDetails
	{
		[Key]
        public int CartDetailsId { get; set; }
		[ForeignKey("CartHeaderId")]
        public int CartHeaderId { get; set; }
        public CartHeader CartHeader { get; set; }
        public int ProductId { get; set; }
        [NotMapped]
        public ProductDto Product { get; set; }
        public int Count { get; set; }





    }
}
