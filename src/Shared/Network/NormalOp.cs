namespace Melia.Shared.Network
{
	public static class NormalOp
	{
		/// <summary>
		/// Sub-opcodes used with BC_NORMAL.
		/// </summary>
		public static class Barrack
		{
			public const int SetBarrackCharacter = 0x00;
			public const int SetPosition = 0x02;
			public const int SetCompanionPosition = 0x03;
			public const int SetBarrack = 0x05;
			public const int CompanionInfo = 0x09;
			public const int SetCompanion = 0x0A;
			public const int DeleteCompanion = 0x0B;
			public const int TeamUI = 0x0C;
			public const int ZoneTraffic = 0x0D;
			public const int PlayAnimation = 0x0E;
			public const int StartGameFailed = 0x0F;
			public const int Run = 0x10;
			public const int Mailbox = 0x11;
			public const int MailboxState = 0x13;
			public const int MailUpdate = 0x14;
			public const int SetSessionKey = 0x15;
			public const int ClientIntegrityFailure = 0x18;
			public const int BarrackSlotCount = 0x19;
			public const int NGSCallback = 0x1A;
			public const int ThemaSuccess = 0x1B;
			public const int CharacterInfo = 0x1C;
		}

		/// <summary>
		/// Sub-opcodes used with ZC_NORMAL.
		/// </summary>
		public static class Zone
		{
			public const int SkillProjectile = 0x06;
			public const int ClearEffects = 0x13;
			public const int FadeOut = 0x38;
			public const int BarrackSlotCount = 0x3C;
			public const int AccountUpdate = 0x4C;
			public const int Skill = 0x57;
			public const int ParticleEffect = 0x61;
			public const int Unknown_A1 = 0xA1;
			public const int Unknown_E4 = 0xE4;

			public const int TimeActionStart = 0x00;
			public const int TimeActionEnd = 0x01;
			public const int Skill_MissileThrow = 0x06;
			public const int SkillFallingProjectile = 0x07;
			public const int Skill_ItemToss = 0x09;
			public const int PlayEffectAtPosition = 0x0F;
			/// <summary>
			/// DRT_ACTOR_ATTACH_EFFECT
			/// </summary>
			public const int AttachEffect = 0x12;
			public const int Died = 0x13;
			public const int SkillEffect_14 = 0x14;
			public const int PlayEffect = 0x16;
			public const int PlayForceEffect = 0x17;
			public const int Unknown_1B = 0x1B;
			public const int UpdateSkillEffect = 0x1F;
			public const int SetEntityColor = 0x20;
			public const int Skill_CallLuaFunc = 0x26;
			public const int SetSkillProperties = 0x2B;
			/// <summary>
			/// Assister Summon Skill Related?
			/// </summary>
			public const int SetScale = 0x2E;
			public const int PlaySound = 0x2F;
			/// <summary>
			/// Knockback related?
			/// </summary>
			public const int Knockback = 0x34;
			public const int TextEffect = 0x3D;
			public const int Skill_ModifyAttackStance = 0x40;
			public const int Skill_40 = 0x42;
			public const int AttackCancel = 0x43;
			/// <summary>
			/// Seen when cloaking skill is used
			/// </summary>
			public const int Skill_45 = 0x45;
			public const int SkillCancel = 0x46;
			public const int AccountProperties = 0x4D;
			public const int Skill_DynamicCastStart = 0x4F;
			public const int Skill_DynamicCastEnd = 0x50;
			public const int NPC_PlayTrack = 0x53;
			public const int SetNPCTrackPosition = 0x54;
			public const int MiniGame = 0x55;
			public const int IndunAddonMsg = 0x56;
			public const int IndunAddonMsgParam = 0x58;
			/// <summary>
			/// Skill related? Seen when casting Lethargy or Mon_weekly_pattern_Skill_36
			/// SKL_RUN_SCRIPT or MONSKL_CRE_PAD
			/// </summary>
			public const int SkillRunScript = 0x59;
			public const int Skill_SetActorHeight = 0x5C;
			public const int Skill_5F = 0x5F;
			public const int Skill_EffectMovement = 0x64;
			public const int Unknown_64 = 0x66;
			public const int SetupCutscene = 0x6E;
			public const int Unknown_6D = 0x6F;
			public const int Unknown_6E = 0x70;
			public const int LoadCutscene = 0x78;
			//public const int SetSkillSpeed = 0x77;
			public const int SetHitDelay = 0x7A;
			public const int SetSkillSpeed = 0x7B;
			public const int SetSkillUseOverHeat = 0x7C;
			public const int SetSkill_7B = 0x7D;
			public const int Skill_7F = 0x81;
			public const int SetMainAttackSkill = 0x87;
			public const int SkillToggle = 0x88;
			public const int Skill_88 = 0x8A;
			public const int SkillCollisionToGround = 0x8B;
			public const int Unknown_8D = 0x8F;
			public const int PetPlayAnimation = 0x90;
			public const int CutsceneTrack = 0x96;
			public const int SetTrackFrame = 0x97;
			public const int SetInvisible = 0x99;
			public const int ShowItemBalloon = 0x9C;
			public const int ShowBook = 0x9E;
			public const int ShowScroll = 0x9F;
			public const int PetInfo = 0xA4;
			public const int Pet_AssociateWorldId = 0xA7;
			public const int Pet_AssociateHandleWorldId = 0xA9;
			public const int PetExpUp = 0xAA;
			public const int PetBuff = 0xB4;
			public const int RidePet = 0xB5;
			public const int PetOwner = 0xB6;
			public const int OffsetY = 0xB7;
			public const int PetFlying = 0xB9;
			public const int SetPetDefaultAnimation = 0xBD;
			public const int Skill_MoveJump = 0xC2;
			public const int Skill_Unknown_C6 = 0xC8;
			public const int Skill_Unknown_C7 = 0xC9;
			public const int PlayGatherCorpseParts = 0xCC;
			public const int Skill_Unknown_D4 = 0xD4;
			public const int PlayCorpsePartsRing = 0xD8;
			public const int RemoveEffect = 0xDA;
			public const int DropCorpseParts = 0xDB;
			public const int PlayThrowCorpseParts = 0xDC;
			public const int ItemCollectionList = 0xDD;
			public const int UnlockCollection = 0xDF;
			public const int UpdateCollection = 0xE0;
			public const int Unknown_E0 = 0xE2;
			public const int PlayTextEffect = 0xE3;
			public const int Unknown_E5 = 0xE7;
			public const int Notice = 0xF0;
			public const int GlobalJobCount = 0xF2;
			public const int PartyMemberData = 0xF4;
			public const int PartyNameChange = 0xF7;
			public const int PartyInvite = 0xF8;
			public const int PartyPropertyChange = 0xF9;
			public const int PartyMemberPropertyChange = 0xFA;
			public const int Unknown_FB = 0xFB;
			public const int MarketRetrievalItems = 0xFC;
			public const int MarketRegisterItem = 0xFD;
			public const int MarketBuyItem = 0xFE;
			public const int MarketCancelItem = 0xFF;
			public const int SummonPlayAnimation = 0x107;
			public const int ApplyBuff = 0x10B;
			public const int RemoveBuff = 0x10C;
			public const int Skill_10B = 0x10D;
			public const int Unknown_10F = 0x112;
			public const int CancelDynamicCast = 0x113;
			public const int Unknown_11A = 0x11C;
			public const int Shop_Unknown11C = 0x11E;
			public const int Skill_125 = 0x125;
			public const int Skill_124 = 0x126;
			public const int Skill_127 = 0x129;
			public const int ChannelTraffic = 0x12D;
			public const int Unknown_130 = 0x130;
			public const int SetActorLabel = 0x132;
			public const int Unknown_134 = 0x137;
			public const int SetGreetingMessage = 0x138;
			public const int ShowParty = 0x13C;
			public const int Revive = 0x13E;
			public const int ShopAnimation = 0x13F;
			public const int SetSessionKey = 0x146;
			public const int StatusEffect = 0x14D;
			public const int DisconnectError = 0x151;
			public const int ItemDrop = 0x152;
			public const int FightState = 0x157;
			public const int NGSCallback = 0x170;
			public const int StorageSilverTransaction = 0x171;
			public const int MarketMinMaxInfo = 0x172;
			public const int MemberMapStatusUpdate = 0x17A;
			public const int HeadgearVisibilityUpdate = 0x17C;
			public const int SetSkillsProperties = 0x181;
			public const int UpdateSkillUI = 0x189;
			public const int InstanceDungeonMatchMaking = 0x18E;
			public const int FishingRankData = 0x190;
			public const int AdventureBook = 0x197;
			public const int Unknown_198 = 0x19A;
			public const int Unknown_19B = 0x19E;
			public const int Unknown_19D_SetTime = 0x19F;
			public const int PetIsInactive = 0x1A6;
			public const int SetSubAttackSkill = 0x1A7;
			public const int Unknown_1A6 = 0x1A8;
			public const int Skill_1A9 = 0x1AB;
			public const int WigVisibilityUpdate = 0x1AC;
			public const int UsedMedalTotal = 0x1B7;
			public const int Unknown_1B6 = 0x1B8;
			public const int SteamAchievement = 0x1BE;
			public const int Skill_ItemRotate = 0x1BF;
			public const int SubWeaponVisibilityUpdate = 0x1C5;
		}

		/// <summary>
		/// Sub-opcodes used with SC_NORMAL.
		/// </summary>
		public static class Social
		{
			public const int Unknown_00 = 0x00;
			public const int Unknown_01 = 0x01;
			public const int Unknown_02 = 0x02;
			public const int AddMessage = 0x03;
			public const int MessageList = 0x04;
			public const int CreateRoom = 0x05;
			public const int SystemMessage = 0x07;
			public const int FriendInfo = 0x08;
			public const int FriendResponse = 0x09;
			public const int Buff_0C = 0x0C;
			public const int PartyInfo = 0x0D;
			public const int FriendRequested = 0x10;
			public const int FriendBlocked = 0x11;
			public const int Unknown_19 = 0x19;

			// Different range for relation server?
			public const int LikeSuccess = 0x7D05;
			public const int UnlikeSuccess = 0x7D07;
			public const int LikeCount = 0x7D0B;
			public const int LikeFailed = 0x7D0D;
		}

		public static class GuildOp
		{
			public const int Message = 0x10;
			public const int MessageParameter = 0x11;
			public const int GuildMessage = 0x13;
		}
	}
}
