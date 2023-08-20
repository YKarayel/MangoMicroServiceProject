using System.ComponentModel.DataAnnotations;
using static Mango.Web.Utility.SD;

namespace Mango.Web.Models
{
	public class RequestDto
	{
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }
        [Range(1,100)]
        public int Count { get; set; } = 1;
    }
}
