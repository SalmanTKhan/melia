using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Melia.Shared.Game.Const.Web
{
	[JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
	public class GuildInfo
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string ShortDesc { get; set; }
		public string LongDesc { get; set; }
		public string PhotoId { get; set; }
		[JsonConverter(typeof(DateFormatConverter), "M/dd/yyyy HH:mm:ss tt")]
		public DateTime RegTime { get; set; }
		public int Level { get; set; }
		public int Exp { get; set; }
		public int ActivityPoint { get; set; }
		public int ApplicationCount { get; set; }
		public AdditionalInfo AdditionalInfo { get; set; }
	}

	[JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
	public class AdditionalInfo
	{
		public string LeaderName { get; set; }
		[JsonConverter(typeof(DateFormatConverter), "M/dd/yyyy")]
		public DateTime CreatedTime { get; set; }
		public int UpdatedTime { get; set; }
		public int ActiveMemberCount { get; set; }
		public int AvgLv { get; set; }
		public int MemberCount { get; set; }
	}

	public class GuildMemberInfoList
	{
		[JsonProperty("memberList")]
		public List<GuildMemberInfo> MemberList { get; set; }
	}

	public class GuildMemberInfo
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("team_lv")]
		public int TeamLv { get; set; }

		[JsonProperty("lv")]
		public int Lv { get; set; }

		[JsonProperty("aid")]
		public long Aid { get; set; }
	}

	public class GuildApplication
	{
		[JsonProperty("account_idx")]
		public string AccountId { get; set; }
		[JsonProperty("account_team_name")]
		public string AccountTeamName { get; set; }
		[JsonProperty("guild_idx")]
		public string GuildId { get; set; }
		[JsonProperty("msg_text")]
		public string Message { get; set; }
		[JsonProperty("reg_time")]
		public string RegistrationTime { get; set; }
		[JsonProperty("is_accept")]
		public int IsAccepted { get; set; }
	}

	public class GuildMemberTitle
	{
		[JsonProperty("claims")]
		public List<int> Claims { get; set; }

		[JsonProperty("titleIndex")]
		public int TitleIndex { get; set; }

		[JsonProperty("titleName")]
		public string TitleName { get; set; }
	}


	public class DateFormatConverter : IsoDateTimeConverter
	{
		public DateFormatConverter(string format)
		{
			DateTimeFormat = format;
		}
	}
}
