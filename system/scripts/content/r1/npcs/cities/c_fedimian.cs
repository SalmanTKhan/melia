//--- Melia Script ----------------------------------------------------------
// Fedimian
//--- Description -----------------------------------------------------------
// NPCs found in and around Fedimian.
//---------------------------------------------------------------------------

using Melia.Shared.Game.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class CFedimianNpcScript : GeneralScript
{
	public override void Load()
	{
		// Grita
		//-------------------------------------------------------------------------
		AddNpc(100, 147449, "Grita", "c_fedimian", 127, 538, 517, 34, "FEDIMIAN_GRITA", "", "", 0);
		
		// [Squire Master]{nl}Justina Legwyn
		//-------------------------------------------------------------------------
		AddNpc(3, 147439, "[Squire Master]{nl}Justina Legwyn", "c_fedimian", 694, 291, 114, 90, "JOB_SQUIRE3_1_NPC", "", "");
		
		// Statue of Goddess Vakarine
		//-------------------------------------------------------------------------
		AddNpc(10, 40120, "Statue of Goddess Vakarine", "c_fedimian", -280, 162, -239, 7, "WARP_C_FEDIMIAN", "STOUP_CAMP", "STOUP_CAMP");
		
		// Fedimian Suburbs
		//-------------------------------------------------------------------------
		AddNpc(11, 40001, "Fedimian Suburbs", "c_fedimian", 782, 160, -160, 80, "", "FEDMIAN_TO_REMAINS40", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(12, 20041, "", "c_fedimian", -531, 163, -428, 90, "", "JOB_FEDIMIAN_TRIGGER", "");
		
		// Security Guard
		//-------------------------------------------------------------------------
		AddNpc(101, 20011, "Security Guard", "c_fedimian", -493, 179, -534, 182, "FEDIMIAN_DETECTIVE_GUARD", "", "");
		
		// Guard Leaper
		//-------------------------------------------------------------------------
		AddNpc(104, 20013, "Guard Leaper", "c_fedimian", -566, 462, 168, 90, "CRIMINAL", "GHOST_APPEAR", "");
		
		// Girl
		//-------------------------------------------------------------------------
		AddNpc(105, 20148, "Girl", "c_fedimian", -788, 451, 283, 38, "REMAIN39_SQ03_GIRL", "", "");
		
		// [Rogue Master]{nl}Gema
		//-------------------------------------------------------------------------
		AddNpc(106, 57238, "[Rogue Master]{nl}Gema", "c_fedimian", 169, 426.3, 162.18, 90, "MASTER_ROGUE", "", "");
		
		// [Item Merchant]{nl}Muras
		//-------------------------------------------------------------------------
		AddNpc(108, 151034, "[Item Merchant]{nl}Muras", "c_fedimian", -631.32, 169.31, -174.9, 0, "FED_TOOL", "", "");
		
		// [Equipment Merchant]{nl}Yorgis
		//-------------------------------------------------------------------------
		AddNpc(109, 151035, "[Equipment Merchant]{nl}Yorgis", "c_fedimian", -219.15, 178.05, -558.35, 90, "FED_EQUIP", "FED_EQUIP_HQ_REINFORCE", "FED_EQUIP_HQ_REINFORCE");
		
		// Starving Demon's Way
		//-------------------------------------------------------------------------
		AddNpc(110, 40001, "Starving Demon's Way", "c_fedimian", 846.02, 679.58, 1136.69, 166, "", "FEDMIAN_PILGRIM46", "");
		
		// Fedimian Public House
		//-------------------------------------------------------------------------
		AddNpc(111, 40001, "Fedimian Public House", "c_fedimian", -844, 212, -100, 180, "", "FEDIMIAN_REQUEST1", "");
		
		// Bulletin Board
		//-------------------------------------------------------------------------
		AddNpc(113, 40070, "Bulletin Board", "c_fedimian", 245.72, 478.36, 398.1, 8, "FEDIMIAN_SIGN1", "", "");
		
		// Old Man
		//-------------------------------------------------------------------------
		AddNpc(114, 20165, "Old Man", "c_fedimian", -899.01, 521.34, 333.52, 34, "FEDIMIAN_OLDMAN1", "", "");
		
		// Bulletin Board
		//-------------------------------------------------------------------------
		AddNpc(115, 40070, "Bulletin Board", "c_fedimian", 671.12, 160.55, -84.22, 9, "FEDIMIAN_SIGN2", "", "");
		
		// Bulletin Board
		//-------------------------------------------------------------------------
		AddNpc(116, 40070, "Bulletin Board", "c_fedimian", -879.49, 447.56, 87.51, 20, "FEDIMIAN_SIGN3", "", "");
		
		// Bulletin Board
		//-------------------------------------------------------------------------
		AddNpc(117, 40070, "Bulletin Board", "c_fedimian", 630.71, 747.1, 1101.49, 19, "FEDIMIAN_SIGN4", "", "");
		
		// JOB_ROGUE5_1
		//-------------------------------------------------------------------------
		AddNpc(118, 20026, "JOB_ROGUE5_1", "c_fedimian", -606.66, 447.56, 63.17, 90, "", "JOB_ROGUE5_1", "");
		
		// [Hackapell Master]{nl}Flint Boulder
		//-------------------------------------------------------------------------
		AddNpc(119, 57232, "[Hackapell Master]{nl}Flint Boulder", "c_fedimian", 366.58, 482.24, 763.9, 37, "MASTER_HACKAPELL", "", "");
		
		// [Druid Master]{nl}Gina Greene
		//-------------------------------------------------------------------------
		AddNpc(120, 57227, "[Druid Master]{nl}Gina Greene", "c_fedimian", 432.94, 482.24, 808.29, 20, "JOB_DRUID3_1_NPC", "", "");
		
		// Fedimian Resident
		//-------------------------------------------------------------------------
		AddNpc(122, 147437, "Fedimian Resident", "c_fedimian", -658, 168, -250, 69, "FEDIMIAN_NPC_11", "", "");
		
		// Klaipeda Peddler
		//-------------------------------------------------------------------------
		AddNpc(123, 20114, "Klaipeda Peddler", "c_fedimian", 11, 543, 550, 90, "FEDIMIAN_NPC_12", "", "");
		
		// Notice for Pilgrims
		//-------------------------------------------------------------------------
		AddNpc(124, 153020, "Notice for Pilgrims", "c_fedimian", 806.82, 679.58, 1108.36, 15, "PILGRIM_PRE_BOARD", "", "");
		
		// [Doppelsoeldner Master]{nl}Guerra
		//-------------------------------------------------------------------------
		AddNpc(125, 147443, "[Doppelsoeldner Master]{nl}Guerra", "c_fedimian", 220.7, 160.55, -81.84, 0, "MASTER_DOPPELSOELDNER", "", "");
		
		// [Blacksmith]{nl}Anna
		//-------------------------------------------------------------------------
		AddNpc(126, 151036, "[Blacksmith]{nl}Anna", "c_fedimian", 120, 160, -504, 75, "BLACKSMITH_FEDIMIAN", "", "");
		
		// [Market Manager]{nl}Molun
		//-------------------------------------------------------------------------
		AddNpc(127, 20171, "[Market Manager]{nl}Molun", "c_fedimian", -391, 160, -266, 0, "MARKET_FEDIMIAN", "", "");
		
		// [Storage Keeper]{nl}Zadan
		//-------------------------------------------------------------------------
		AddNpc(128, 156027, "[Storage Keeper]{nl}Zadan", "c_fedimian", -187, 160, -235, 22, "WAREHOUSE_FEDIMIAN", "", "");
		
		// [Accessory Merchant]{nl}Joana
		//-------------------------------------------------------------------------
		AddNpc(130, 151038, "[Accessory Merchant]{nl}Joana", "c_fedimian", -130.2, 177.28, -496.14, 0, "FED_ACCESSORY", "", "");
		AddNpc(131, 151029, " ", "c_fedimian", -221.9414, 177.8838, -169.4255, 6, "", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(132, 147469, " ", "c_fedimian", 186.81, 825.15, 855.79, 90, "SHINOBI_POTTER", "", "", 0);
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(132, 147469, " ", "c_fedimian", -735.82, 208.22, -133.69, 90, "SHINOBI_POTTER", "", "", 0);
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(132, 147469, " ", "c_fedimian", 354.63, 482.24, 826.61, 99, "SHINOBI_POTTER", "", "", 0);
		
		// [TP Trader]{nl}Leticia
		//-------------------------------------------------------------------------
		AddNpc(134, 20068, "[TP Trader]{nl}Leticia", "c_fedimian", 189.8829, 161.3876, -205.7937, 0, "TP_NPC", "", "");
		
		// Fedimian Guard
		//-------------------------------------------------------------------------
		AddNpc(136, 10033, "Fedimian Guard", "c_fedimian", -95.84, 818.92, 605.49, 90, "FEDIMIAN_NPC_TEMPLE04", "", "");
		AddNpc(137, 152076, "", "c_fedimian", -92.58688, 818.92, 721.2022, 13, "", "", "");
		AddNpc(137, 152076, "", "c_fedimian", -134.9591, 818.92, 705.868, 14, "", "", "");
		AddNpc(137, 152076, "", "c_fedimian", -201.4937, 818.92, 534.6089, 100, "", "", "");
		AddNpc(137, 152076, "", "c_fedimian", -204.6036, 818.92, 497.8776, -78, "", "", "");
		AddNpc(137, 152076, "", "c_fedimian", -372.6004, 796.67, 463.2302, 102, "", "", "");
		AddNpc(137, 152076, "", "c_fedimian", -452.8279, 796.67, 542.6366, 11, "", "", "");
		AddNpc(137, 152076, "", "c_fedimian", -242.5749, 818.92, 526.9411, 101, "", "", "");
		AddNpc(137, 152076, "", "c_fedimian", -432.6172, 824.71, 694.2933, 12, "", "", "");
		AddNpc(137, 152076, "", "c_fedimian", -483.02, 824.71, 735.56, 11, "", "", "");
		AddNpc(137, 152076, "", "c_fedimian", -477.21, 824.71, 761.59, 90, "", "", "");
		
		// [Identifier]{nl}Sandra
		//-------------------------------------------------------------------------
		AddNpc(150, 157039, "[Identifier]{nl}Sandra", "c_fedimian", -41, 160, -223, 360, "FEDIMIAN_APPRAISER", "TUTO_APPRAISE_NPC", "", 0);
		
		// [Appraiser Master]{nl}Sandra
		//-------------------------------------------------------------------------
		AddNpc(1003, 157039, "[Appraiser Master]{nl}Sandra", "c_fedimian", -41, 160, -223, 360, "FEDIMIAN_APPRAISER_NPC", "", "", 1);
		AddNpc(2000, 20025, " ", "c_fedimian", -541.93, 169.41, -302.48, 90, "", "", "");
		AddNpc(2001, 20040, "", "c_fedimian", 145.6077, 160.9488, -203.0807, 90, "", "", "");
		
		// [Matador Master]{nl}Kridella Otero
		//-------------------------------------------------------------------------
		AddNpc(2002, 153194, "[Matador Master]{nl}Kridella Otero", "c_fedimian", 740.2928, 291.8288, 259.6365, 26, "MATADOR_MASTER", "", "", 1);
		
		// Adventurer Anastazija
		//-------------------------------------------------------------------------
		AddNpc(2003, 155168, "Adventurer Anastazija", "c_fedimian", 406.736, 312.0165, 58.32973, 0, "EXPLORER_ANASTAZIJA", "", "");
		
		// Traveling Merchant Geraldas
		//-------------------------------------------------------------------------
		AddNpc(2004, 150000, "Traveling Merchant Geraldas", "c_fedimian", -641.1408, 447.5573, -51.47062, 90, "NPC_JUNK_SHOP_FEDIMIAN_ORSHA", "", "");
		
		// Bulletin Board
		//-------------------------------------------------------------------------
		AddNpc(2005, 40070, "Bulletin Board", "c_fedimian", -133.3012, 365.9291, 58.58133, 5, "FEDIMIAN_OFFICIAL_BOARD", "", "");
		
		// [Exorcist Master]{nl}Sydow Merrinblock
		//-------------------------------------------------------------------------
		AddNpc(2006, 153208, "[Exorcist Master]{nl}Sydow Merrinblock", "c_fedimian", 89.2861, 478.357, 356.2659, 16, "EXORCIST_MASTER", "", "");
		
		// Gintaras
		//-------------------------------------------------------------------------
		AddNpc(2007, 20118, "Gintaras", "c_fedimian", 154.9777, 478.8553, 350.6737, 16, "CHAR420_STEP321_NPC", "", "", 1);
		
		// Zigmas
		//-------------------------------------------------------------------------
		AddNpc(2008, 147483, "Zigmas", "c_fedimian", 154.9777, 478.8553, 350.6737, 16, "CHAR420_STEP323_NPC1", "", "", 1);
		
		// [Blacksmith]{nl}Teliavelis
		//-------------------------------------------------------------------------
		AddNpc(2009, 161002, "[Blacksmith]{nl}Teliavelis", "c_fedimian", -881.679, 208.2247, -227.4336, 90, "FEDIMIAN_TERIAVELIS", "FEDIMIAN_TERIAVELIS", "");
		
		// [Outlaw Master]{nl}Maea Kellefinker
		//-------------------------------------------------------------------------
		AddNpc(2011, 156157, "[Outlaw Master]{nl}Maea Kellefinker", "c_fedimian", 488.8739, 484.7497, 963.166, 12, "OUTLAW_MASTER_W_NPC", "", "");
		
		// [Outlaw Master]{nl}Jazz Kellefinker
		//-------------------------------------------------------------------------
		AddNpc(2012, 156156, "[Outlaw Master]{nl}Jazz Kellefinker", "c_fedimian", 446.8587, 484.7497, 926.9231, 151, "OUTLAW_MASTER_M_NPC", "", "");
		AddNpc(5202, 20026, " ", "c_fedimian", 25.68116, 160.555, -220.0483, -5, "", "", "");
		
		// Pajauta
		//-------------------------------------------------------------------------
		AddNpc(5203, 154120, "Pajauta", "c_fedimian", 58.90117, 318.2176, 4.509953, 14, "PAYAUTA_EP11_NPC_CITY_1", "", "", 1);
		
		// Sentry Ailee
		//-------------------------------------------------------------------------
		AddNpc(5204, 147416, "Sentry Ailee", "c_fedimian", -569.502, 171.6972, -492.7643, 142, "INSTANCE_DUNGEON", "", "");
		AddNpc(5207, 40095, " ", "c_fedimian", 377.2883, 160.555, -142.0534, 45, "", "", "");
		
		// Housing Helper Kupole
		//-------------------------------------------------------------------------
		AddNpc(5208, 154125, "Housing Helper Kupole", "c_fedimian", -629.5562, 175.9425, -430.9118, 90, "NPC_PERSONAL_HOUSING_MANAGER", "", "");
		
		// [Event] Goddess Roulette
		//-------------------------------------------------------------------------
		AddNpc(5212, 20040, "[Event] Goddess Roulette", "c_fedimian", -369, 160, -357, 45, "EVENT_POPO_ROULETTE_NPC", "", "");
		
		// [Teliavelis's Disciple]{nl}Naujoves
		//-------------------------------------------------------------------------
		AddNpc(5216, 157105, "[Teliavelis's Disciple]{nl}Naujoves", "c_fedimian", -881.4329, 208.2247, -291.846, 87, "FEDIMIAN_NAUJOVES", "", "");
		
		// [Demon God's Temptation]{nl}Illusion of Demon God Ragana
		//-------------------------------------------------------------------------
		AddNpc(5231, 154130, "[Demon God's Temptation]{nl}Illusion of Demon God Ragana", "c_fedimian", -222.6911, 160.555, -404.5667, 211, "SHOP_NPC_RAGANA_CITY_1", "", "");
		AddNpc(5232, 150004, "", "c_fedimian", -412.0341, 453.7242, 705.3024, 90, "", "", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(5233, 150008, "", "c_fedimian", -275.1527, 482.2432, 665.6674, 2, "KLAPEDA_FISHING_BOARD", "", "");
		
		// [Fishing Shop]{nl}Joha's Tackle Box
		//-------------------------------------------------------------------------
		AddNpc(5234, 154119, "[Fishing Shop]{nl}Joha's Tackle Box", "c_fedimian", -289.8217, 482.2432, 555.596, 90, "FISHING_SUB_NPC", "", "");
		
		// [Kingdom Reconstruction] Notice Board
		//-------------------------------------------------------------------------
		AddNpc(5245, 157106, "[Kingdom Reconstruction] Notice Board", "c_fedimian", 90.77071, 160.555, -298.6885, 188, "REPUTATION_QUEST_BOARD_01", "", "");
		
		// [Professional Alchemist]{nl}Quabast
		//-------------------------------------------------------------------------
		AddNpc(5244, 20190, "[Professional Alchemist]{nl}Quabast", "c_fedimian", -735.7271, 169.3097, -298.9478, 90, "ALCHEIST_EXPERT_NPC_FEDIMIAN", "", "");
		
		// Unknown Sanctuary Gate
		//-------------------------------------------------------------------------
		AddNpc(5257, 155174, "Unknown Sanctuary Gate", "c_fedimian", 511.1686, 160.555, -40.84446, 61, "UNKNOWN_SANTUARY_GATE_GUILD", "", "");
		
		// [Bounty Hunt]{nl}Wanted Board
		//-------------------------------------------------------------------------
		AddNpc(5259, 9000001, "[Bounty Hunt]{nl}Wanted Board", "c_fedimian", -329.2578, 160.555, -257.8914, 0, "BOUNTY_HUNT_START", "", "");
		
		// Goddess Ingredient Exchange Helper 
		//-------------------------------------------------------------------------
		AddNpc(5260, 151042, "Goddess Ingredient Exchange Helper ", "c_fedimian", -305.6815, 180, -460.033, 135, "EP13CARE_TRADE", "", "");
		
		// Goddess' Blessing
		//-------------------------------------------------------------------------
		AddNpc(5261, 160121, "Goddess' Blessing", "c_fedimian", -150.1284, 160.555, -213.9672, 200, "BLESSED_CUBE", "", "");
		
		// [Skill Transmutation Helper]{nl}Kupole
		//-------------------------------------------------------------------------
		AddNpc(5294, 160088, "[Skill Transmutation Helper]{nl}Kupole", "c_fedimian", -528.8466, 169.3097, -144.759, 24, "DUCTILITY_NPC", "", "");
		
		// [Equipment Transmutation Helper] Kupole
		//-------------------------------------------------------------------------
		AddNpc(5294, 160088, "[Equipment Transmutation Helper] Kupole", "c_fedimian", -528.8466, 169.3097, -144.759, 24, "DUCTILITY_NPC", "", "");
		
		// [Event]{nl}Ghost Maiden
		//-------------------------------------------------------------------------
		AddNpc(5264, 160103, "[Event]{nl}Ghost Maiden", "c_fedimian", -533.1298, 169.3096, -178.2003, 90, "CITY_EVENT_2110_NPC", "", "");
		
		// [Event]{nl}Pumpkin Stew Cauldron
		//-------------------------------------------------------------------------
		AddNpc(5265, 160104, "[Event]{nl}Pumpkin Stew Cauldron", "c_fedimian", -514.274, 171.0021, -217.6038, 90, "EVENT_2110_POT_NPC", "", "");
		
		// [Event]{nl}Fallen City Refugee
		//-------------------------------------------------------------------------
		AddNpc(5266, 160105, "[Event]{nl}Fallen City Refugee", "c_fedimian", -447.1804, 173.2039, -228.2204, 90, "CITY_EVENT_2110_NPC2", "", "");
		
		// TOS Coin Helper
		//-------------------------------------------------------------------------
		AddNpc(5500, 160157, "TOS Coin Helper", "c_fedimian", -284, 160, -346, 90, "EVENT_TOS_WHOLE_NPC", "", "");
		
		// [Previous Goddess Token Shop]{nl}Kupole
		//-------------------------------------------------------------------------
		AddNpc(5501, 160178, "[Previous Goddess Token Shop]{nl}Kupole", "c_fedimian", 209.5653, 160.5551, -452.2791, 90, "PREVIOUS_COIN_SHOP", "", "");
		
		// [Black Market]{nl}Auctioneer
		//-------------------------------------------------------------------------
		AddNpc(5502, 20140, "[Black Market]{nl}Auctioneer", "c_fedimian", -392, 178, -506, 90, "BLACK_MARKET", "", "");
		
		// [Snigo's Memory]{nl}Little Glacia
		//-------------------------------------------------------------------------
		AddNpc(5503, 160193, "[Snigo's Memory]{nl}Little Glacia", "c_fedimian", -484.44, 160.6, -426.36, 45, "LITTLE_GLACIER", "", "");
		
		// [Event]{nl}New Year's Helper Cuvid
		//-------------------------------------------------------------------------
		AddNpc(5504, 160204, "[Event]{nl}New Year's Helper Cuvid", "c_fedimian", -525.4, 169.4096, -348.9, 45, "EVENT_NEWYEAR_ASSIST", "", "");
	}
}
