using System;

namespace Melia.Shared.Game.Const
{
	public enum TeamNameChangeResult : int
	{
		TeamNameAlreadyExist = -1,
		Okay = 0,
		TeamChangeFailed = 1,
	}

	public enum MailboxMessageState : byte
	{
		Unread = 0,
		Read = 1,
		Store = 2,
		Delete = 3,
		RequestLoad = 4,
		Count = 5,
	}

	/// <summary>
	/// Effects sent when leaving
	/// </summary>
	public enum LeaveType
	{
		Warp = 0,
		NoEffect = 1,
		Item = 2,
		Companion = 4,
	}

	[Flags]
	public enum MarketItemStatus
	{
		Listed = 1,
		Sold = 2,
		SilverReceived = 4,
		ItemReceived = 8,
		Expired = 16,
		Cancelled = 32,
	}

	public enum HeightOffset
	{
		TOP = 0,
		MID = 1,
		BOT = 2,
		UNK = 3,
	}
}
