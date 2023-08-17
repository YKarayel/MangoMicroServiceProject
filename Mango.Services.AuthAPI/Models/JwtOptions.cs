using Microsoft.Extensions.Options;
using System.Reflection.Metadata.Ecma335;

namespace Mango.Services.AuthAPI.Models
{
	public class JwtOptions
	{
		public string Issuer { get; set; } = string.Empty;
		public string Audiance { get; set; } = string.Empty;
		public string Secret { get; set; } = string.Empty;
	}
}
