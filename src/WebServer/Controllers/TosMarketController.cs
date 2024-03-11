using System.Net;
using System.Text;
using System.Threading.Tasks;
using EmbedIO.Routing;
using EmbedIO;
using EmbedIO.WebApi;
using Melia.Shared.Game.Const.Web;
using Melia.Web.Serializer;
using Melia.Web.Util;
using Newtonsoft.Json;
using Yggdrasil.Logging;

namespace Melia.Web.Controllers
{
	public class TosMarketController : WebApiController
	{
		JsonSerializerSettings JsonSerializerSettings { get; set; } = new JsonSerializerSettings()
		{
			DateFormatString = "yyyy-MM-dd HH:mm:ss",
		};

		[Route(HttpVerbs.Get, "/")]
		public void GetIndex()
		{
			this.WriteText("index");
		}

		private void WriteText(string content)
		{
			var data = Encoding.UTF8.GetBytes(content);
			using (var stream = this.HttpContext.OpenResponseStream())
				stream.Write(data, 0, data.Length);
		}

		/// <summary>
		/// Market Search Request
		/// </summary>
		/// <param name="page"></param>
		/// <param name="perPage"></param>
		/// <returns></returns>
		/// <example>PUT /market/search/1/11</example>
		[Route(HttpVerbs.Put, "/market/search/{page}/{perPage}")]
		public async Task<string> PutMarketSearch(int page, int perPage)
		{
			if (!this.Request.IsAuthorized())
			{
				Log.Warning("MarketSearch: Unauthorized request from {0} to {1}", this.Request.LocalEndPoint.Address.ToString(), this.Request.RemoteEndPoint.Address.ToString());
				await this.HttpContext.SendStringContentAsync("Unauthorized_Request", "text/plain", Encoding.UTF8, HttpStatusCode.Unauthorized);
				return "";
			}
			var data = await this.HttpContext.GetRequestDataAsyncJson<MarketSearch>();
			var searchResult = WebServer.Instance.Market.GetMarketItems(page, perPage, data);
			return JsonConvert.SerializeObject(searchResult, this.JsonSerializerSettings);
		}

		// PUT /market/search_recipe/1/7
		/// <summary>
		/// Market Search Recipe Request
		/// </summary>
		/// <param name="page"></param>
		/// <param name="perPage"></param>
		/// <returns></returns>
		[Route(HttpVerbs.Put, "/market/search_recipe/{page}/{perPage}")]
		public async Task<string> PutMarketSearchRecipe(int page, int perPage)
		{
			if (!this.Request.IsAuthorized())
			{
				Log.Warning("MarketSearchRecipe: Unauthorized request from {0} to {1}", this.Request.LocalEndPoint.Address.ToString(), this.Request.RemoteEndPoint.Address.ToString());
				await this.HttpContext.SendStringContentAsync("Unauthorized_Request", "text/plain", Encoding.UTF8, HttpStatusCode.Unauthorized);
				return "";
			}
			var data = await this.HttpContext.GetRequestDataAsyncJson<MarketSearch>();
			var searchResult = WebServer.Instance.Database.GetMarketItems(page, perPage, data);
			// TODO: Find Recipe Items?
			return JsonConvert.SerializeObject(searchResult, this.JsonSerializerSettings);
		}

		// GET /market/my_sell_list
		[Route(HttpVerbs.Get, "/market/my_sell_list")]
		public async Task<string> GetMarketMySellList()
		{
			if (!this.Request.IsAuthorized(out var character))
			{
				Log.Warning("GetMarketMySellList: Unauthorized request from {0} to {1}", this.Request.LocalEndPoint.Address.ToString(), this.Request.RemoteEndPoint.Address.ToString());
				await this.HttpContext.SendStringContentAsync("Unauthorized_Request", "text/plain", Encoding.UTF8, HttpStatusCode.Unauthorized);
				return "";
			}
			var data = await this.HttpContext.GetRequestDataAsyncJson<MarketSearch>();
			var searchResult = WebServer.Instance.Market.GetMarketItems(character.Id);
			return JsonConvert.SerializeObject(searchResult, this.JsonSerializerSettings);
		}

		// GET /market/min_price/649026 HTTP/1.1
		[Route(HttpVerbs.Get, "/market/min_price/{itemId}")]
		public async Task<string> GetMarketItemMinPrice(int itemId)
		{
			if (!this.Request.IsAuthorized())
			{
				Log.Warning("GetMarketMySellList: Unauthorized request from {0} to {1}", Request.LocalEndPoint.Address.ToString(), Request.RemoteEndPoint.Address.ToString());
				await this.HttpContext.SendStringContentAsync("Unauthorized_Request", "text/plain", Encoding.UTF8, HttpStatusCode.Unauthorized);
				return "";
			}

			var minPrice = WebServer.Instance.Market.GetMarketItemMinPrice(itemId);
			return $"{minPrice}";
		}
	}
}
