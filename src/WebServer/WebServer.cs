using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using EmbedIO;
using EmbedIO.Files;
using EmbedIO.Net;
using EmbedIO.WebApi;
using Melia.Shared;
using Melia.Shared.Data.Database;
using Melia.Shared.L10N;
using Melia.Shared.Network.Inter.Messages;
using Melia.Web.Controllers;
using Melia.Web.Database;
using Melia.Web.Logging;
using Melia.Web.Modules;
using Melia.Web.Serializer;
using Melia.Web.World;
using Yggdrasil.Logging;
using Yggdrasil.Network.Communication;
using Yggdrasil.Util;
using Yggdrasil.Util.Commands;

namespace Melia.Web
{
	public class WebServer : Server
	{
		public readonly static WebServer Instance = new WebServer();

		private EmbedIO.WebServer _webServer;
		private EmbedIO.WebServer _guildServer;
		private EmbedIO.WebServer _marketServer;

		/// <summary>
		/// The server's market manager.
		/// </summary>
		public MarketManager Market { get; set; } = new MarketManager();

		/// <summary>
		/// The server's guild manager.
		/// </summary>
		public GuildManager Guild { get; set; } = new GuildManager();

		/// <summary>
		/// The server's database.
		/// </summary>
		public WebDb Database { get; } = new WebDb();

		/// <summary>
		/// Returns the server's inter-server communicator.
		/// </summary>
		public Communicator Communicator { get; private set; }

		/// <summary>
		/// Runs the server.
		/// </summary>
		/// <param name="args"></param>
		public override void Run(string[] args)
		{
			this.GetServerId(args, out var groupId, out var serverId);
			var title = string.Format("Web ({0}, {1})", groupId, serverId);

			ConsoleUtil.WriteHeader(ConsoleHeader.ProjectName, title, ConsoleColor.DarkRed, ConsoleHeader.Logo, ConsoleHeader.Credits);
			ConsoleUtil.LoadingTitle();

			this.NavigateToRoot();
			this.LoadConf(this.Conf);
			this.LoadData(ServerType.Web);
			this.LoadServerList(this.Data.ServerDb, ServerType.Web, groupId, serverId);
			this.InitDatabase(this.Database, this.Conf);
			this.CheckDependencies();

			this.StartCommunicator();
			this.StartWebServer();
			this.StartGuildWebServer();
			this.StartMarketWebServer();

			ConsoleUtil.RunningTitle();

			new ConsoleCommands().Wait();
		}

		/// <summary>
		/// Checks and downloads dependencies, such as PHP.
		/// </summary>
		private void CheckDependencies()
		{
			var phpFilePath = this.Conf.Web.PhpCgiFilePath;
			var phpFolderPath = Path.GetDirectoryName(phpFilePath);

			// If the binary exists we got all we need
			if (File.Exists(phpFilePath))
				return;

			// If the binary doesn't exist, and the intended path is
			// not inside the user folder, we'll let the user figure
			// out what to do, since they changed the path.
			if (!phpFilePath.Replace("\\", "/").StartsWith("user/tools/"))
			{
				Log.Error("Configured PHP CGI binary not found at '{0}', please check your web configuration.", phpFilePath);
				ConsoleUtil.Exit(1);
				return;
			}

			// If the binary wasn't found, and we're not Windows, this is
			// the end of the road for now.
			// TODO: Add auto-download for Linux and MacOS?
			if (Environment.OSVersion.Platform != PlatformID.Win32NT)
			{
				Log.Error("The configured PHP binary couldn't be found and we can't set it up automatically. Please install PHP on your system and set the binary path in the web configuration.");
				ConsoleUtil.Exit(1);
				return;
			}

			Log.Info("PHP not found. Downloading now...");

#pragma warning disable SYSLIB0014 // Type or member is obsolete
			using (var wc = new WebClient())
			{
				var downloadRootUrl = "https://windows.php.net";
				var downloadPageUrl = downloadRootUrl + "/download";
				var downloadPageContents = wc.DownloadString(downloadPageUrl);

				// Get link to the first PHP zip file, which should be the
				// latest.
				var match = Regex.Match(downloadPageContents, @"/downloads/releases/php-\d+\.\d+\.\d+-nts-Win32-vs16-x64\.zip");
				if (!match.Success)
				{
					Log.Warning("Failed to find PHP download on '{0}'. Please install PHP and set its path manually in the web web configuration or you won't be able to use all of the web server's features.", downloadPageUrl);
					return;
				}

				var tempFileName = Path.GetTempFileName();
				//var downloadUrl = this.Conf.Web.PhpDownloadUrl;
				var downloadUrl = downloadRootUrl + match.Value;
				var fileName = Path.GetFileName(downloadUrl);

				Log.Info("Filename: {0}", fileName);

				try
				{
					wc.Headers.Set(HttpRequestHeader.UserAgent, "Melia");
					wc.DownloadProgressChanged += (s, e) => Console.Write("         Download Progress: {0,3:0}%\r", e.ProgressPercentage);

					var task = wc.DownloadFileTaskAsync(downloadUrl, tempFileName);
					task.Wait();

					Log.Info("PHP download complete, extracting...");

					if (!Directory.Exists(phpFolderPath))
						Directory.CreateDirectory(phpFolderPath);

					ZipFile.ExtractToDirectory(tempFileName, phpFolderPath);

					Log.Info("PHP extraction complete, setting up...");

					var productionIniFilePath = Path.Combine(phpFolderPath, "php.ini-production");
					var iniFilePath = Path.Combine(phpFolderPath, "php.ini");
					File.Copy(productionIniFilePath, iniFilePath);

					Log.Info("Successfully downloaded PHP to '{0}'.", phpFolderPath);
				}
				catch (Exception)
				{
					Log.Warning("Failed to download PHP from '{0}'. Please configure your PHP path manually or you won't be able to use all of the web server's features.", downloadUrl);
				}
				finally
				{
					try { File.Delete(tempFileName); }
					catch { }
				}
			}
#pragma warning restore SYSLIB0014 // Type or member is obsolete
		}

		/// <summary>
		/// Starts the communicator and attempts to connect to the
		/// coordinator.
		/// </summary>
		private void StartCommunicator()
		{
			Log.Info("Attempting to connect to coordinator...");

			var commName = ServerType.Barracks.ToString();

			this.Communicator = new Communicator(commName);
			this.Communicator.Disconnected += this.Communicator_OnDisconnected;
			this.Communicator.MessageReceived += this.Communicator_OnMessageReceived;

			this.ConnectToCoordinator();
		}

		/// <summary>
		/// Attempts to establish a connection to the coordinator.
		/// </summary>
		private void ConnectToCoordinator()
		{
			var barracksServerInfo = this.GetServerInfo(ServerType.Barracks, 1);

			try
			{
				this.Communicator.Connect("Coordinator", barracksServerInfo.InterIp, barracksServerInfo.InterPort);

				this.Communicator.Subscribe("Coordinator", "ServerUpdates");
				this.Communicator.Subscribe("Coordinator", "AllServers");

				Log.Info("Successfully connected to coordinator.");
			}
			catch (Exception ex)
			{
				Log.Error("Failed to connect to coordinator, trying again in 5 seconds...");
				Log.Error(ex.Message);
				Thread.Sleep(5000);

				this.ConnectToCoordinator();
			}
		}

		/// <summary>
		/// Called when the connection to the coordinator was lost.
		/// </summary>
		/// <param name="commName"></param>
		private void Communicator_OnDisconnected(string commName)
		{
			Log.Error("Lost connection to coordinator, will try to reconnect in 5 seconds...");
			Thread.Sleep(5000);

			this.ConnectToCoordinator();
		}

		/// <summary>
		/// Called when a message was received from the coordinator.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="message"></param>
		private void Communicator_OnMessageReceived(string sender, ICommMessage message)
		{
			//Log.Debug("Message received from '{0}': {1}", sender, message);

			switch (message)
			{
				case ServerUpdateMessage serverUpdateMessage:
				{
					this.ServerList.Update(serverUpdateMessage);
					break;
				}
			}
		}

		/// <summary>
		/// Starts web server.
		/// </summary>
		private void StartWebServer()
		{
			try
			{
				var serverInfo = this.ServerInfo;
				var url = string.Format("http://*:{0}/", serverInfo.Port);

				Swan.Logging.Logger.NoLogging();
				Swan.Logging.Logger.RegisterLogger(new YggdrasilLogger(this.Conf.Log.Filter));

				EndPointManager.UseIpv6 = false;

				_webServer = new EmbedIO.WebServer(url);

				// The PHP module handles all requests to PHP scripts,
				// including defaulting to index.php and prioritizing
				// the user folder. Should this fail, we'll try static
				// requests to user and system.
				// TODO: Look into handling PHP scripts from a FileModule,
				//   adding a pre-processor.

				_webServer.WithWebApi("/toslive/patch/", m => m.WithController<TosPatchController>());
				_webServer.WithWebApi("/api/", m => m.WithController<ApiController>());

				_webServer.WithModule(new PhpModule("/"));

				if (Directory.Exists("user/web/"))
				{
					_webServer.WithStaticFolder("/", "user/web/", false, fm =>
					{
						fm.DefaultDocument = "index.htm";
						fm.OnMappingFailed = FileRequestHandler.PassThrough;
						fm.OnDirectoryNotListable = FileRequestHandler.PassThrough;
					});
				}

				if (Directory.Exists("system/web/"))
				{
					_webServer.WithStaticFolder("/", "system/web/", false, fm =>
					{
						fm.DefaultDocument = "index.htm";
					});
				}

				_webServer.RunAsync();

				if (_webServer.State == WebServerState.Stopped)
				{
					Log.Error("Failed to start web server, make sure there's only one instance running.");
					ConsoleUtil.Exit(1);
				}

				// Disabled for now. Giving the URLs makes things easier,
				// but the IP should ideally match what the user will
				// actually use to connect.
				//Log.Info("Client XML Config:");
				//Log.Info("  ServerListURL: {0}", url + "toslive/patch/serverlist.xml");
				//Log.Info("  StaticConfigURL: {0}", url + "toslive/patch/");

				Log.Status("Server now running on '{0}'", url);
			}
			catch (Exception ex)
			{
				Log.Error("Failed to start web server: {0}", ex);
				ConsoleUtil.Exit(1);
			}
		}

		/// <summary>
		/// Starts guild web server.
		/// </summary>
		private void StartGuildWebServer()
		{
			try
			{
				this.Guild.Load();

				var url = string.Format("http://*:{0}/", this.Conf.Web.GuildPort);

				Swan.Logging.Logger.NoLogging();
				Swan.Logging.Logger.RegisterLogger(new YggdrasilLogger(this.Conf.Log.Filter));

				EndPointManager.UseIpv6 = false;

				var options = new WebServerOptions()
						.WithMode(HttpListenerMode.EmbedIO)
						//.WithCertificate(cert1)
						.WithUrlPrefix(url);
				_guildServer = new EmbedIO.WebServer(options);

				var webFolder = "system/web/";
				if (Directory.Exists("user/web/"))
					webFolder = "user/web/";


				_guildServer
					//.WithBearerToken("/", "0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9eyJjbGF")
					.WithWebApi("/", m => m.WithController<TosGuildController>())
					.WithStaticFolder("/", webFolder, false, fm =>
					{
						fm.DefaultDocument = "index.htm";
						fm.OnMappingFailed = FileRequestHandler.PassThrough;
						fm.OnDirectoryNotListable = FileRequestHandler.PassThrough;
					});
				_guildServer.RunAsync();

				if (_guildServer.State == WebServerState.Stopped)
				{
					Log.Error("Failed to start guild server, make sure there's only one instance running.");
					ConsoleUtil.Exit(1);
				}

				Log.Status("Guild Server now running on '{0}'", url);
			}
			catch (Exception ex)
			{
				Log.Error("Failed to start web server: {0}", ex);
				ConsoleUtil.Exit(1);
			}
		}

		/// <summary>
		/// Starts market web server.
		/// </summary>
		private void StartMarketWebServer()
		{
			try
			{
				this.Market.Load();

				var url = string.Format("http://*:{0}/", this.Conf.Web.MarketPort);

				Swan.Logging.Logger.NoLogging();
				Swan.Logging.Logger.RegisterLogger(new YggdrasilLogger(this.Conf.Log.Filter));

				EndPointManager.UseIpv6 = false;

				var options = new WebServerOptions()
						.WithMode(HttpListenerMode.EmbedIO)
						//.WithCertificate(cert1)
						.WithUrlPrefix(url);
				_marketServer = new EmbedIO.WebServer(options);

				var webFolder = "system/web/";
				if (Directory.Exists("user/web/"))
					webFolder = "user/web/";

				_marketServer
					//.WithBearerToken("/", "0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9eyJjbGF")
					.WithWebApi("/", CustomResponseSerializer.None(false), m => m.WithController<TosMarketController>())
					.WithStaticFolder("/", webFolder, false, fm =>
					{
						fm.DefaultDocument = "index.htm";
						fm.OnMappingFailed = FileRequestHandler.PassThrough;
						fm.OnDirectoryNotListable = FileRequestHandler.PassThrough;
					});
				_marketServer.RunAsync();

				if (_marketServer.State == WebServerState.Stopped)
				{
					Log.Error("Failed to start market server, make sure there's only one instance running.");
					ConsoleUtil.Exit(1);
				}

				Log.Status("Market Server now running on '{0}'", url);
			}
			catch (Exception ex)
			{
				Log.Error("Failed to start web server: {0}", ex);
				ConsoleUtil.Exit(1);
			}
		}
	}
}
