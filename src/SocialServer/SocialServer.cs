using System;
using System.Threading;
using Melia.Shared;
using Melia.Shared.Data.Database;
using Melia.Shared.Network.Inter.Messages;
using Melia.Social.Commands;
using Melia.Social.Database;
using Melia.Social.Network;
using Melia.Social.World;
using Yggdrasil.Logging;
using Yggdrasil.Network.Communication;
using Yggdrasil.Network.TCP;
using Yggdrasil.Util;
using Yggdrasil.Util.Commands;

namespace Melia.Social
{
	/// <summary>
	/// Represents a social server.
	/// </summary>
	public class SocialServer : Server
	{
		public readonly static SocialServer Instance = new SocialServer();

		private TcpConnectionAcceptor<SocialConnection> _acceptor;

		/// <summary>
		/// Returns the server's inter-server communicator.
		/// </summary>
		public Communicator Communicator { get; private set; }

		/// <summary>
		/// Returns a reference to the server's packet handlers.
		/// </summary>
		public PacketHandler PacketHandler { get; private set; }

		/// <summary>
		/// Returns reference to the server's database interface.
		/// </summary>
		public SocialDb Database { get; } = new SocialDb();

		/// <summary>
		/// Returns reference to the server's chat command handlers.
		/// </summary>
		public ChatCommands ChatCommands { get; } = new ChatCommands();

		/// <summary>
		/// Returns reference to the server's account manager.
		/// </summary>
		public UserManager UserManager { get; } = new UserManager();

		/// <summary>
		/// Returns reference to the server's chat manager.
		/// </summary>
		public ChatManager ChatManager { get; } = new ChatManager();

		/// <summary>
		/// Runs the server.
		/// </summary>
		/// <param name="args"></param>
		public override void Run(string[] args)
		{
			this.GetServerId(args, out var groupId, out var serverId);
			var title = string.Format("Social ({0}, {1})", groupId, serverId);

			ConsoleUtil.WriteHeader(ConsoleHeader.ProjectName, title, ConsoleColor.DarkCyan, ConsoleHeader.Logo, ConsoleHeader.Credits);
			ConsoleUtil.LoadingTitle();

			Log.Init($"SocialServer_{groupId}_{serverId}");

			this.NavigateToRoot();

			this.LoadConf();
			this.LoadLocalization(this.Conf);
			this.LoadData(ServerType.Social);
			this.LoadServerList(this.Data.ServerDb, ServerType.Social, groupId, serverId);
			this.InitDatabase(this.Database, this.Conf);
			this.LoadPacketHandler();
			this.LoadManagers();

			this.StartCommunicator();
			this.StartAcceptors();

			ConsoleUtil.RunningTitle();
			new ConsoleCommands().Wait();
		}

		/// <summary>
		/// Loads and initializes the server's managers.
		/// </summary>
		private void LoadManagers()
		{
			Log.Info("Loading information from the database...");

			this.UserManager.LoadUsers();
		}

		/// <summary>
		/// Initializes packet handler based on the server type.
		/// </summary>
		private void LoadPacketHandler()
		{
			if (this.ServerInfo.Id == 1)
				this.PacketHandler = new PacketHandlerChat();
			else
				this.PacketHandler = new PacketHandlerRelation();
		}

		/// <summary>
		/// Starts the server's TCP connection acceptors.
		/// </summary>
		private void StartAcceptors()
		{
			_acceptor = new TcpConnectionAcceptor<SocialConnection>(this.ServerInfo.Port);
			_acceptor.ConnectionAccepted += this.OnConnectionAccepted;
			_acceptor.Listen();

			Log.Status("Server ready, listening on {0}.", _acceptor.Address);
		}

		/// <summary>
		/// Starts the communicator and attempts to connect to the
		/// coordinator.
		/// </summary>
		private void StartCommunicator()
		{
			Log.Info("Attempting to connect to coordinator...");

			var commName = "" + this.ServerInfo.Type + this.ServerInfo.Id;

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

				if (this.ServerInfo.Id == 1)
					this.Communicator.Subscribe("Coordinator", "Chat");
				else
					this.Communicator.Subscribe("Coordinator", "Relation");

				Log.Info("Successfully connected to coordinator.");
			}
			catch
			{
				Log.Error("Failed to connect to coordinator, trying again in 5 seconds...");
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
			Log.Debug("Message received from '{0}': {1}", sender, message);

			// TODO: Would be nice to have a proper message handler system.
			switch (message)
			{
				case ShoutMessage shoutMessage:
				{
					foreach (var user in this.UserManager.GetUsers(u => u.Connection != null))
						Send.SC_NORMAL.Shout(user.Connection, shoutMessage.Sender, shoutMessage.AccountId, shoutMessage.Text, shoutMessage.ServerType);
					break;
				}
			}
		}

		/// <summary>
		/// Called when a new connection is accepted.
		/// </summary>
		/// <param name="conn"></param>
		private void OnConnectionAccepted(SocialConnection conn)
		{
			Log.Info("New connection accepted from '{0}'.", conn.Address);
		}
	}
}
