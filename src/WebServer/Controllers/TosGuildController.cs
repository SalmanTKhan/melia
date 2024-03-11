using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EmbedIO.Routing;
using EmbedIO;
using EmbedIO.WebApi;
using Melia.Shared.Game.Const.Web;
using Melia.Web.Util;
using Newtonsoft.Json;
using Yggdrasil.Logging;

namespace Melia.Web.Controllers
{
	public class TosGuildController : WebApiController
	{
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

		// /accountwarehouse/get
		[Route(HttpVerbs.Get, "/accountwarehouse/get")]
		public async Task GetAccountWarehouse()
		{
			if (!this.Request.IsAuthorized())
			{
				Log.Warning("GetAccountWarehouse: Unauthorized request from {0} to {1}", this.Request.LocalEndPoint.Address.ToString(), this.Request.RemoteEndPoint.Address.ToString());
				await this.HttpContext.SendStringContentAsync("Unauthorized_Request", "text/plain", Encoding.UTF8, HttpStatusCode.Unauthorized);
				return;
			}

			// {"list":[{"index":"0","title":""},{"index":"1","title":""},{"index":"2","title":""},{"index":"3","title":""},{"index":"4","title":""}]}
			var accountWarehouse = new AccountWarehouse();
			var isFound = true;
			var json = JsonConvert.SerializeObject(accountWarehouse, Formatting.Indented);
			if (isFound)
				await this.HttpContext.SendStringContentAsync(json, "text/plain", Encoding.UTF8, HttpStatusCode.OK);
			else
				await this.HttpContext.SendStringContentAsync("43 : 지금 당장 하실 수 없습니다.", "text/plain", Encoding.UTF8, HttpStatusCode.BadRequest);
		}

		/**
		 * Guilds
		 **/
		// /featuredguildlist/{page}/{applicationCount/level}/desc
		// /featuredguildlist/1/level/desc
		// /featuredguildlist/enable_join/1/level/desc
		[Route(HttpVerbs.Get, "/featuredguildlist/{page}/{type}/desc")]
		public async Task GetFeaturedGuildList(int page, string type)
		{
			// TODO Find Guild Member Title from DB?
			var guilds = new List<GuildInfo>();
			var isFound = true;
			var json = JsonConvert.SerializeObject(guilds, Formatting.Indented);
			var test = "[{\"shortDesc\":\"Hello savior!  We are TOS_SupportGuild! If you need help, please contact us anytime :) \",\"longDesc\":\"\",\"photoId\":\"e99f90ec-e3df-4d6e-8f39-f80b93f3e321\",\"regTime\":\"8/10/2021 3:23 AM\",\"name\":\"TOS_SupportGuild\",\"level\":20,\"exp\":34676800,\"activityPoint\":173913,\"id\":\"506544147923578\",\"applicationCount\":0,\"additionalInfo\":{\"updatedTime\":0,\"createdTime\":\"6/29/2021\",\"leaderName\":\"[GM] Lemon\",\"activeMemberCount\":0,\"avgLv\":446,\"memberCount\":517}},{\"shortDesc\":\"A social guild with mild aspirations of greatness; Try hard at your own pace. o/\",\"longDesc\":\"\",\"photoId\":\"24f2ad4d-a268-4cc1-853c-0599ae4b37ed\",\"regTime\":\"4/1/2022 11:01 PM\",\"name\":\"Reverie\",\"level\":20,\"exp\":33814220,\"activityPoint\":176195,\"id\":\"400230822450961\",\"applicationCount\":0,\"additionalInfo\":{\"updatedTime\":0,\"createdTime\":\"2/11/2020\",\"leaderName\":\"Azusagi\",\"activeMemberCount\":0,\"avgLv\":467,\"memberCount\":15}},{\"shortDesc\":\"Melody Guild\",\"longDesc\":\"\",\"photoId\":\"d843c38a-f2d5-42c0-b0a0-ef61708a6b81\",\"regTime\":\"5/21/2019 2:13 PM\",\"name\":\"Melody\",\"level\":20,\"exp\":33754232,\"activityPoint\":101611,\"id\":\"214374702897287\",\"applicationCount\":0,\"additionalInfo\":{\"updatedTime\":0,\"createdTime\":\"6/22/2016\",\"leaderName\":\"Louka\",\"activeMemberCount\":0,\"avgLv\":464,\"memberCount\":8}},{\"shortDesc\":\"Impetus is recruiting for PVP/GVG and PVE/Raids. We do guild events Sundays at 6:00 PM server time.\",\"longDesc\":\"\",\"photoId\":\"b1e76803-a9cd-4fb8-85d0-d8892da8c6cf\",\"regTime\":\"4/11/2022 8:35 PM\",\"name\":\"Impetus\",\"level\":20,\"exp\":33753672,\"activityPoint\":296094,\"id\":\"240591183396568\",\"applicationCount\":0,\"additionalInfo\":{\"updatedTime\":0,\"createdTime\":\"9/1/2016\",\"leaderName\":\"Narcissus\",\"activeMemberCount\":0,\"avgLv\":458,\"memberCount\":42}},{\"shortDesc\":\"Si eres Hispano, únete a Tornado. Guild 100% casual PVE\",\"longDesc\":\"\",\"photoId\":\"eed655bc-be1c-49e8-a896-27af49990a5c\",\"regTime\":\"8/22/2021 11:46 PM\",\"name\":\"Tornado\",\"level\":20,\"exp\":33753576,\"activityPoint\":6885,\"id\":\"277283089987006\",\"applicationCount\":0,\"additionalInfo\":{\"updatedTime\":0,\"createdTime\":\"1/30/2017\",\"leaderName\":\"Sasayaki\",\"activeMemberCount\":0,\"avgLv\":225,\"memberCount\":2}},{\"shortDesc\":\"To Infinity and Beyond! Infinity is one of the oldest guilds in the game.  PVP and PVE, new players and old returning players welcome. \",\"longDesc\":\"\",\"photoId\":\"5791f43a-26c2-4b26-b2e1-ac957cdee39d\",\"regTime\":\"8/4/2021 6:34 PM\",\"name\":\"Infinity\",\"level\":20,\"exp\":33744664,\"activityPoint\":164626,\"id\":\"104651175056730\",\"applicationCount\":0,\"additionalInfo\":{\"updatedTime\":0,\"createdTime\":\"4/7/2016\",\"leaderName\":\"Imix\",\"activeMemberCount\":0,\"avgLv\":441,\"memberCount\":31}}]";

			if (isFound)
				await this.HttpContext.SendStringContentAsync(test, "application/json", Encoding.UTF8, HttpStatusCode.OK);
			else
				await this.HttpContext.SendStringContentAsync("1 : 해당 팀에 권한이 없습니다.", "text/plain", Encoding.UTF8, HttpStatusCode.BadRequest);
		}


		[Route(HttpVerbs.Get, "/guild/{guildId}")]
		public async Task GetGuild(long guildId)
		{
			if (!this.Request.IsAuthorized())
			{
				Log.Warning("GetGuild: Unauthorized request from {0} to {1}", this.Request.LocalEndPoint.Address.ToString(), this.Request.RemoteEndPoint.Address.ToString());
				await this.HttpContext.SendStringContentAsync("Unauthorized_Request", "text/plain", Encoding.UTF8, HttpStatusCode.Unauthorized);
				return;
			}

			var guild = WebServer.Instance.Database.GetGuild(guildId);
			var json = JsonConvert.SerializeObject(guild, Formatting.Indented);
			await this.HttpContext.SendStringContentAsync(json, "application/json", Encoding.UTF8, HttpStatusCode.OK);
		}

		/// <summary>
		/// Guild Action
		/// </summary>
		/// <returns></returns>
		[Route(HttpVerbs.Post, "/guild/{guildId}/action")]
		public async Task PostGuildAction(long guildId)
		{
			if (!this.Request.IsAuthorized())
			{
				Log.Warning("PostGuildAction: Unauthorized request from {0} to {1}", this.Request.LocalEndPoint.Address.ToString(), this.Request.RemoteEndPoint.Address.ToString());
				await this.HttpContext.SendStringContentAsync("Unauthorized_Request", "text/plain", Encoding.UTF8, HttpStatusCode.Unauthorized);
				return;
			}
			var data = await this.HttpContext.GetRequestFormDataAsync();
			if (int.TryParse(data["claimCode"], out var claimCode))
			{
				// TODO: Do something with claim code
			}
		}

		// /guild/400230822450961/memberinfolist/1
		[Route(HttpVerbs.Get, "/guild/{guildId}/memberinfolist/{page}")]
		public async Task GetGuildMemberList(long guildId, int page)
		{
			if (!this.Request.IsAuthorized())
			{
				Log.Warning("GetGuildMemberList: Unauthorized request from {0} to {1}", this.Request.LocalEndPoint.Address.ToString(), this.Request.RemoteEndPoint.Address.ToString());
				await this.HttpContext.SendStringContentAsync("Unauthorized_Request", "text/plain", Encoding.UTF8, HttpStatusCode.Unauthorized);
				return;
			}

			if (!WebServer.Instance.Guild.TryGetGuildMembers(guildId, out var members))
			{
				Log.Warning("GetGuildMemberList: Unauthorized request from {0} to {1}", this.Request.LocalEndPoint.Address.ToString(), this.Request.RemoteEndPoint.Address.ToString());
				await this.HttpContext.SendStringContentAsync("Unauthorized_Request", "text/plain", Encoding.UTF8, HttpStatusCode.Unauthorized);
				return;
			}

			var json = JsonConvert.SerializeObject(members, Formatting.Indented);
			await this.HttpContext.SendStringContentAsync(json, "application/json", Encoding.UTF8, HttpStatusCode.OK);
		}

		// /guildbanner/506544147923578
		[Route(HttpVerbs.Get, "/guildbanner/{guildId}")]
		public IEnumerable<byte> GetGuildBanner(long guildId)
		{
			if (!this.Request.IsAuthorized())
			{
				Log.Warning("GetGuildBanner: Unauthorized request from {0} to {1}", this.Request.LocalEndPoint.Address.ToString(), this.Request.RemoteEndPoint.Address.ToString());
				this.HttpContext.SendStringContentAsync("Unauthorized_Request", "text/plain", Encoding.UTF8, HttpStatusCode.Unauthorized);
				return Enumerable.Empty<byte>();
			}

			var filePath = $"user/web/GuildBanner/{guildId}.png";

			if (!File.Exists(filePath))
			{
				// 100 : There is no registered image.
				this.HttpContext.SendStringContentAsync("100 : 등록된 이미지가 없습니다.", "text/plain", Encoding.UTF8, HttpStatusCode.OK);
				return Enumerable.Empty<byte>();
			}

			this.Response.ContentType = "image/jpeg";
			this.Response.SendChunked = true;
			return FileUtils.FileToByteArray(filePath);
		}

		// /guildemblem/506544147923578
		[Route(HttpVerbs.Get, "/guildemblem/{guildId}")]
		public IEnumerable<byte> GetGuildEmblem(long guildId)
		{
			if (!this.Request.IsAuthorized())
			{
				Log.Warning("GetGuildEmblem: Unauthorized request from {0} to {1}", this.Request.LocalEndPoint.Address.ToString(), this.Request.RemoteEndPoint.Address.ToString());
				this.HttpContext.SendStringContentAsync("Unauthorized_Request", "text/plain", Encoding.UTF8, HttpStatusCode.Unauthorized);
				return Enumerable.Empty<byte>();
			}

			var filePath = $"user/web/GuildEmblem/{guildId}.png";

			if (!File.Exists(filePath))
			{
				// 100 : There is no registered image.
				this.HttpContext.SendStringContentAsync("100 : 등록된 이미지가 없습니다.", "text/plain", Encoding.UTF8, HttpStatusCode.OK);
				return Enumerable.Empty<byte>();
			}

			this.Response.ContentType = "image/jpeg";
			this.Response.SendChunked = true;
			return FileUtils.FileToByteArray(filePath);
		}

		/// <summary>
		/// Get guild intro image
		/// </summary>
		/// <param name="guildId"></param>
		/// <returns></returns>
		[Route(HttpVerbs.Get, "/guild/image/{guildId}")]
		public IEnumerable<byte> GetGuildImage(long guildId)
		{
			if (!this.Request.IsAuthorized())
			{
				Log.Warning("GetGuildImage: Unauthorized request from {0} to {1}", this.Request.LocalEndPoint.Address.ToString(), this.Request.RemoteEndPoint.Address.ToString());
				this.HttpContext.SendStringContentAsync("Unauthorized_Request", "text/plain", Encoding.UTF8, HttpStatusCode.Unauthorized);
				return Enumerable.Empty<byte>();
			}

			var filePath = $"system/web/guild/covers/{guildId}.png";
			if (!File.Exists(filePath))
				filePath = $"user/web/GuildIntroImage/{guildId}.png";
			if (!File.Exists(filePath))
				filePath = "system/web/guild/covers/1.png";
			if (!File.Exists(filePath))
			{
				// 100 : There is no registered image.
				this.HttpContext.SendStringContentAsync("100 : 등록된 이미지가 없습니다.", "text/plain", Encoding.UTF8, HttpStatusCode.OK);
				return Enumerable.Empty<byte>();
			}

			this.Response.ContentType = "image/jpeg";
			this.Response.SendChunked = true;
			return FileUtils.FileToByteArray(filePath);
		}

		/// <summary>
		/// Apply to a guild
		/// </summary>
		/// <param name="guildId"></param>
		/// <param name="accountId"></param>
		/// <returns></returns>
		// /guildlist/application/guild/578656648822807
		[Route(HttpVerbs.Get, "/guildlist/application/guild/{guildId}")]
		public async Task GetGuild(long guildId, long accountId)
		{
			if (this.Request.IsAuthorized())
			{
				// Check Permission
				await this.HttpContext.SendStringContentAsync("1 : 해당 팀에 권한이 없습니다.", "text/plain", Encoding.UTF8, HttpStatusCode.BadRequest);
			}
		}

		/// <summary>
		/// Create a new guild member title
		/// </summary>
		/// <param name="guildId"></param>
		/// <param name="guildMemberTitle"></param>
		/// <returns></returns>
		[Route(HttpVerbs.Put, "/guild/{guildId}/membertitle")]
		public async Task PutGuildMemberTitle(long guildId, [JsonData] GuildMemberTitle guildMemberTitle)
		{
			if (!this.Request.IsAuthorized(out var character))
			{
				Log.Warning("PutGuildMemberTitle: Unauthorized request from {0} to {1}", this.Request.LocalEndPoint.Address.ToString(), this.Request.RemoteEndPoint.Address.ToString());
				await this.HttpContext.SendStringContentAsync("Unauthorized_Request", "text/plain", Encoding.UTF8, HttpStatusCode.Unauthorized);
				return;
			}
			var isCreated = true;
			if (isCreated)
				await this.HttpContext.SendStringContentAsync("200 : success", "text/plain", Encoding.UTF8, HttpStatusCode.OK);
		}

		// /partyfind/get_list/{raid/quest/etc}/{1}
		[Route(HttpVerbs.Get, "/partyfind/get_list/{type}/{page}")]
		public async Task GetPartyFindList(string type, int page)
		{
			if (!this.Request.IsAuthorized())
			{
				Log.Warning("GetPartyFindList: Unauthorized request from {0} to {1}", Request.LocalEndPoint.Address.ToString(), Request.RemoteEndPoint.Address.ToString());
				await this.HttpContext.SendStringContentAsync("Unauthorized_Request", "text/plain", Encoding.UTF8, HttpStatusCode.Unauthorized);
				return;
			}

			switch (type)
			{
				case "raid":
				case "quest":
				case "etc":
				default:
					await this.HttpContext.SendStringContentAsync("43 : 지금 당장 하실 수 없습니다.", "text/plain", Encoding.UTF8, HttpStatusCode.BadRequest);
					break;
			}
		}

		// /partyfind/search/raid/1
		[Route(HttpVerbs.Get, "/partyfind/search/raid/{page}")]
		public async Task GetPartyFindSearchRaid(int page)
		{
			await this.HttpContext.SendStringContentAsync("43 : 지금 당장 하실 수 없습니다.", "text/plain", Encoding.UTF8, HttpStatusCode.BadRequest);
		}

		// /status_ranking/pc_gear_score/PC/{0}
		[Route(HttpVerbs.Get, "/status_ranking/pc_gear_score/PC/{page}")]
		public async Task GetRankingGearScore(int page)
		{
			if (!this.Request.IsAuthorized())
			{
				Log.Warning("Unauthorized request from {0} to {1}", Request.LocalEndPoint.Address.ToString(), Request.RemoteEndPoint.Address.ToString());
				await this.HttpContext.SendStringContentAsync("Unauthorized_Request", "text/plain", Encoding.UTF8, HttpStatusCode.Unauthorized);
				return;
			}

			// {"my_rank":5941,"my_score":1583,"size":10,"list":[{"guild_name":"FullMoonCafe","team_name":"Sylvarant","char_name":"Lloyd","guild_idx":"313743066131156","type":"pc_gear_score","value":7867,"rank":1},{"guild_name":"Yorozuya","team_name":"StickyWicky","char_name":"Slyrs","guild_idx":"224948912369217","type":"pc_gear_score","value":7864,"rank":2},{"guild_name":"Yorozuya","team_name":"Jetlogs","char_name":"Sentinel","guild_idx":"224948912369217","type":"pc_gear_score","value":7840,"rank":3},{"guild_name":"Impetus","team_name":"nobodyweed","char_name":"vektor","guild_idx":"240591183396568","type":"pc_gear_score","value":7832,"rank":4},{"guild_name":"Yorozuya","team_name":"KaiBooBoo","char_name":"HaeSer","guild_idx":"224948912369217","type":"pc_gear_score","value":7831,"rank":5},{"guild_name":"Yorozuya","team_name":"Otaton","char_name":"OnePunchGirl","guild_idx":"224948912369217","type":"pc_gear_score","value":7831,"rank":6},{"guild_name":"FullMoonCafe","team_name":"Platinum-Sperm","char_name":"Rhodium","guild_idx":"313743066131156","type":"pc_gear_score","value":7827,"rank":7},{"guild_name":"Reverie","team_name":"Narusaka","char_name":"MuTang","guild_idx":"400230822450961","type":"pc_gear_score","value":7818,"rank":8},{"guild_name":"Yorozuya","team_name":"Heroes","char_name":"Cinnabunny","guild_idx":"224948912369217","type":"pc_gear_score","value":7814,"rank":9},{"guild_name":"FullMoonCafe","team_name":"Jett","char_name":"Faye","guild_idx":"313743066131156","type":"pc_gear_score","value":7811,"rank":10}]}
			var gearScore = new GearScore();
			var isFound = false;
			var json = JsonConvert.SerializeObject(gearScore, Formatting.Indented);
			if (isFound)
				await this.HttpContext.SendStringContentAsync(json, "text/plain", Encoding.UTF8, HttpStatusCode.OK);
			else
				await this.HttpContext.SendStringContentAsync("43 : 지금 당장 하실 수 없습니다.", "text/plain", Encoding.UTF8, HttpStatusCode.BadRequest);
		}
	}
}
