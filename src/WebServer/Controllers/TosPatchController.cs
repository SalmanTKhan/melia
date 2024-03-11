using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using EmbedIO;
using EmbedIO.Routing;
using Melia.Shared.Data.Database;
using Melia.Shared.Network.Crypto;
using Melia.Web.Util;
using Yggdrasil.Logging;

namespace Melia.Web.Controllers
{
	/// <summary>
	/// Controller for the files the client downloads on launch.
	/// </summary>
	public class TosPatchController : BaseController
	{
		private Codec _codec { get; } = new Codec();

		/// <summary>
		/// Serves a list of barrack servers.
		/// </summary>
		[Route(HttpVerbs.Get, "/serverlist.xml")]
		public void GetServerList()
		{
			var serverGroupDataList = WebServer.Instance.Data.ServerDb.Entries.Values.OrderBy(a => a.Id);

			using (var str = new Utf8StringWriter())
			using (var xml = new XmlTextWriter(str))
			{
				xml.WriteStartDocument();
				xml.WriteWhitespace("\n");
				xml.WriteStartElement("serverlist");
				xml.WriteWhitespace("\n");

				foreach (var groupData in serverGroupDataList)
				{
					xml.WriteWhitespace("\t");
					xml.WriteStartElement("server");
					xml.WriteAttributeString("GROUP_ID", groupData.Id.ToString());
					xml.WriteAttributeString("TRAFFIC", "0");
					xml.WriteAttributeString("ENTER_LIMIT", "100");
					xml.WriteAttributeString("NAME", groupData.Name);

					var barracksServersData = groupData.Servers.Where(a => a.Type == ServerType.Barracks).ToArray();
					for (var i = 0; i < barracksServersData.Length; ++i)
					{
						var serverData = barracksServersData[i];

						xml.WriteAttributeString("Server0_IP", serverData.Ip);
						xml.WriteAttributeString("Server0_Port", serverData.Port.ToString());
					}

					xml.WriteEndElement();
					xml.WriteWhitespace("\n");
				}

				xml.WriteEndElement();
				xml.WriteWhitespace("\n");
				xml.WriteEndDocument();

				this.SendText("text/xml", str.ToString());
			}
		}

		/// <summary>
		/// Serves a config file that determines, among other things,
		/// whether to enable HacksShield and Steam logins.
		/// </summary>
		[Route(HttpVerbs.Get, "/static__Config.txt")]
		public void GetStaticConfig()
		{
			var staticConfigFile = "system/web/toslive/patch/static__Config.txt";
			if (File.Exists("user/web/toslive/patch/static__Config.txt"))
				staticConfigFile = "user/web/toslive/patch/static__Config.txt";
			SendText("text/plain", File.ReadAllText(staticConfigFile));
		}

		[Route(HttpVerbs.Get, "/updater/patcher.version.txt")]
		public byte[] GetPatcher()
		{
			var patcherVersion = new StringBuilder();
			patcherVersion.AppendLine("0    ");
			patcherVersion.AppendLine("");
			var result = Encoding.UTF8.GetBytes(patcherVersion.ToString());
			result = _codec.EncryptFile(result);
			return result;
		}

		[Route(HttpVerbs.Get, "/updater/patcher.version_2.txt")]
		public void GetPatcherV2()
		{
			var patcherVersion = "0";
			this.SendText("text/plain", patcherVersion);
		}

		[Route(HttpVerbs.Get, "/updater/updater.list.txt")]
		public byte[] GetUpdaterList()
		{
			var filePath = $"system/web/toslive/patch/updater/updater.list.txt";
			if (File.Exists($"user/web/toslive/patch/updater/updater.list.txt"))
				filePath = $"user/web/toslive/patch/updater/updater.list.txt";
			if (File.Exists(filePath))
			{
				return FileUtils.FileToByteArray(filePath);
			}

			var updaterList = new StringBuilder();
			updaterList.AppendLine("tos.exe");
			updaterList.AppendLine("patch.ini");
			updaterList.AppendLine("");
			var result = Encoding.UTF8.GetBytes(updaterList.ToString());
			return result;
		}

		[Route(HttpVerbs.Get, "/{type}/{file}")]
		public void GetPatcherFile(string type, string file)
		{
			try
			{
				var filePath = $"system/web/toslive/patch/{type}/{file}";
				if (File.Exists($"user/web/toslive/patch/{type}/{file}"))
					filePath = $"user/web/toslive/patch/{type}/{file}";
				if (File.Exists(filePath))
				{
					var encryptedFile = File.ReadAllBytes(filePath);
					encryptedFile = _codec.EncryptFile(encryptedFile);
					this.SendText("text/plain", Encoding.ASCII.GetString(encryptedFile));
					return;
				}
			}
			catch (Exception ex)
			{
				Log.Error(ex);
				throw HttpException.NotFound();
			}
		}
	}
}
