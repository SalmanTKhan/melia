//--- Melia Script ----------------------------------------------------------
// Klaipeda
//--- Description -----------------------------------------------------------
// NPCs found in and around Klaipeda.
//---------------------------------------------------------------------------

using Melia.Shared.Game.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class CKlaipeNpcScript : GeneralScript
{
	public override void Load()
	{
		// [Item Merchant]{nl}Mirina
		//-------------------------------------------------------------------------
		AddNpc(1, 20115, "[Item Merchant]{nl}Mirina", "c_Klaipe", 510.7029, -1.292879, -349.3194, 90, "EMILIA", "", "");
		
		// [Equipment Merchant]{nl}Dunkel
		//-------------------------------------------------------------------------
		AddNpc(2, 20111, "[Equipment Merchant]{nl}Dunkel", "c_Klaipe", 394, -1, -475, 90, "AKALABETH", "", "");
		
		// [Accessory Merchant]{nl}Ronesa
		//-------------------------------------------------------------------------
		AddNpc(3, 20104, "[Accessory Merchant]{nl}Ronesa", "c_Klaipe", 268.7077, -1.343773, -610.9401, 90, "ALFONSO", "ADDHELP_NPCSHOP", "");
		
		// [Templar Master]{nl}Knight Commander Uska
		//-------------------------------------------------------------------------
		AddNpc(4, 20113, "[Templar Master]{nl}Knight Commander Uska", "c_Klaipe", -424.6251, 149.1097, 172.4264, 30, "KLAPEDA_USKA", "", "");
		
		// [Cleric Master]{nl}Rozalija
		//-------------------------------------------------------------------------
		AddNpc(113, 20112, "[Cleric Master]{nl}Rozalija", "c_Klaipe", -222.3671, 149.1097, 363.4704, 405, "MASTER_CLERIC", "", "", 0);
		
		// Klaipeda Resident
		//-------------------------------------------------------------------------
		AddNpc(7, 20158, "Klaipeda Resident", "c_Klaipe", -9, 156, 131, 22, "ACT_VILLAGERS", "", "");
		
		// Mother of a Soldier
		//-------------------------------------------------------------------------
		AddNpc(8, 20114, "Mother of a Soldier", "c_Klaipe", -60, 148, 42, 82, "ACT_SMOM", "", "");
		
		// [Priest Master]{nl}Boruble
		//-------------------------------------------------------------------------
		AddNpc(114, 57229, "[Priest Master]{nl}Boruble", "c_Klaipe", -180.3134, 149.1097, 382.513, 0, "MASTER_PRIEST", "", "");
		
		// Bulletin Board
		//-------------------------------------------------------------------------
		AddNpc(209, 40090, "Bulletin Board", "c_Klaipe", -80, 148, 387, 30, "KLAPEDA_SIGN9", "", "");
		
		// [Blacksmith]{nl}Zaras
		//-------------------------------------------------------------------------
		AddNpc(13, 20105, "[Blacksmith]{nl}Zaras", "c_Klaipe", 600, -1, -83, 90, "BLACKSMITH", "TUTO_REPAIR_NPC", "");
		
		// [Krivis Master]{nl}Herkus
		//-------------------------------------------------------------------------
		AddNpc(115, 57228, "[Krivis Master]{nl}Herkus", "c_Klaipe", -1108, 240, 512, 405, "MASTER_KRIWI", "", "");
		
		// Indifferent Widow
		//-------------------------------------------------------------------------
		AddNpc(11, 20114, "Indifferent Widow", "c_Klaipe", -409, -1, -647, -2, "TUTO_GIRL", "", "");
		
		// Refugee
		//-------------------------------------------------------------------------
		AddNpc(2001, 20139, "Refugee", "c_Klaipe", -60, 79, -446, 12, "KLAPEDA_NPC_14", "", "");
		
		// [Market Manager]{nl}Logi
		//-------------------------------------------------------------------------
		AddNpc(2002, 20169, "[Market Manager]{nl}Logi", "c_Klaipe", 254.7493, 79.85956, 225.7428, 90, "KLAPEDA_MARKET", "TUTO_MARKET_NPC", "");
		AddNpc(101, 20041, "Manage the hide and seek", "c_Klaipe", -325, 148, 17, 261, "", "", "");
		
		// [Peltasta Master]{nl}Maria Leed
		//-------------------------------------------------------------------------
		AddNpc(103, 20028, "[Peltasta Master]{nl}Maria Leed", "c_Klaipe", -225, 97, -385, -10, "MASTER_PELTASTA", "", "");
		
		// [Cryomancer Master]{nl}Aleister Crowley
		//-------------------------------------------------------------------------
		AddNpc(106, 20137, "[Cryomancer Master]{nl}Aleister Crowley", "c_Klaipe", -205, 79, -515, 96, "MASTER_ICEMAGE", "", "");
		
		// [Quarrel Shooter Master]{nl}Ream Toiler
		//-------------------------------------------------------------------------
		AddNpc(108, 147445, "[Quarrel Shooter Master]{nl}Ream Toiler", "c_Klaipe", -236, 241, 867, 315, "MASTER_QU", "", "");
		
		// [Ranger Master]{nl}Nemoken
		//-------------------------------------------------------------------------
		AddNpc(109, 147343, "[Ranger Master]{nl}Nemoken", "c_Klaipe", -516.443, 149.1097, 10.18389, 96, "MASTER_RANGER", "", "");
		
		// [Swordsman Master]{nl}Rashua
		//-------------------------------------------------------------------------
		AddNpc(110, 20023, "[Swordsman Master]{nl}Rashua", "c_Klaipe", -92, 241, 784, 315, "MASTER_SWORDMAN", "", "");
		
		// [Wizard Master]{nl}Lucia
		//-------------------------------------------------------------------------
		AddNpc(111, 20021, "[Wizard Master]{nl}Lucia", "c_Klaipe", -100, 96, -275, 0, "MASTER_WIZARD", "", "");
		
		// [Archer Master]{nl}Edmundas Tiller
		//-------------------------------------------------------------------------
		AddNpc(112, 147447, "[Archer Master]{nl}Edmundas Tiller", "c_Klaipe", -910, 241, 280, 390, "MASTER_ARCHER", "", "");
		
		// Bulletin Board
		//-------------------------------------------------------------------------
		AddNpc(130, 40070, "Bulletin Board", "c_Klaipe", -66, -1, -752, -2, "KLAPEDA_SIGN30", "", "");
		
		// Bulletin Board
		//-------------------------------------------------------------------------
		AddNpc(131, 40070, "Bulletin Board", "c_Klaipe", 195, -1, -641, 12, "KLAPEDA_SIGN31", "", "");
		
		// Bulletin Board
		//-------------------------------------------------------------------------
		AddNpc(132, 40070, "Bulletin Board", "c_Klaipe", 58, 79, -359, 34, "KLAPEDA_SIGN32", "", "");
		
		// Bulletin Board
		//-------------------------------------------------------------------------
		AddNpc(133, 40070, "Bulletin Board", "c_Klaipe", -63, 148, -108, 83, "KLAPEDA_SIGN33", "", "");
		
		// Bulletin Board
		//-------------------------------------------------------------------------
		AddNpc(134, 40070, "Bulletin Board", "c_Klaipe", -165, -1, -958, 64, "KLAPEDA_SIGN_WELCOME", "", "");
		
		// Signboard
		//-------------------------------------------------------------------------
		AddNpc(135, 40070, "Signboard", "c_Klaipe", 744, -1, 192, -36, "KLAPEDA_SIGN35", "", "");
		
		// About the Goddess Statue
		//-------------------------------------------------------------------------
		AddNpc(136, 40070, "About the Goddess Statue", "c_Klaipe", -125, 148, -11, 42, "KLAPEDA_SIGN36", "", "");
		
		// Holiday Notice
		//-------------------------------------------------------------------------
		AddNpc(10005, 40070, "Holiday Notice", "c_Klaipe", 617, -1, 61, 90, "KLAPEDA_BOARD_01", "", "");
		
		// Lyliana
		//-------------------------------------------------------------------------
		AddNpc(10006, 147473, "Lyliana", "c_Klaipe", 615.23, -1.35, 132.44, 90, "HUEVILLAGE_58_3_KLAIPEDA_NPC", "", "");
		
		// [Companion Trader]{nl}Christina
		//-------------------------------------------------------------------------
		AddNpc(10009, 153005, "[Companion Trader]{nl}Christina", "c_Klaipe", 6, -1, -760, 360, "PETSHOP_KLAIPE", "", "");
		
		// Velheider
		//-------------------------------------------------------------------------
		AddNpc(10011, 47521, "Velheider", "c_Klaipe", -22, -1, -757, 360, "PETSHOP_KLAIPE_PET", "", "");
		
		// [Wings of Vaivora]{nl}Lena
		//-------------------------------------------------------------------------
		AddNpc(10013, 152005, "[Wings of Vaivora]{nl}Lena", "c_Klaipe", 68.44363, 148.8388, 485.8954, -14, "JOURNEY_SHOP", "TUTO_JOURNAL_NPC", "");
		
		// [Klaipeda's Magic Association]{nl}Henrika
		//-------------------------------------------------------------------------
		AddNpc(10014, 152004, "[Klaipeda's Magic Association]{nl}Henrika", "c_Klaipe", -292, 149, 291, 405, "COLLECTION_SHOP", "", "");
		
		// Gytis Settlement Area
		//-------------------------------------------------------------------------
		AddNpc(10015, 40001, "Gytis Settlement Area", "c_Klaipe", 240.6537, 148.8095, 895.663, 154, "", "KLAPEDA_TO_SIAUL50_1", "");
		
		// [Storage Keeper]{nl}Rita
		//-------------------------------------------------------------------------
		AddNpc(10016, 154018, "[Storage Keeper]{nl}Rita", "c_Klaipe", 307.8934, 79.85956, 298.521, 90, "WAREHOUSE", "TUTO_STORAGE_NPC", "");
		
		// [Oracle Master]{nl}Apolonija Barbora
		//-------------------------------------------------------------------------
		AddNpc(117, 57224, "[Oracle Master]{nl}Apolonija Barbora", "c_Klaipe", -1095.955, 243.7694, 272.9396, 90, "MASTER_ORACLE", "", "");
		
		// Statue of Goddess Ausrine
		//-------------------------------------------------------------------------
		AddNpc(10017, 154039, "Statue of Goddess Ausrine", "c_Klaipe", -206.574, 148.8251, 98.63973, 45, "WARP_C_KLAIPE", "STOUP_CAMP", "STOUP_CAMP");
		
		// [TP Trader]{nl}Leticia
		//-------------------------------------------------------------------------
		AddNpc(10018, 20068, "[TP Trader]{nl}Leticia", "c_Klaipe", 282.7217, 79.85956, 148.8087, 90, "TP_NPC", "TUTO_TPSHOP_NPC", "");
		AddNpc(10019, 20026, "HIDDEN_MIKO_KLAIPE_TRIGGER", "c_Klaipe", 379.7536, -1.343773, -1056.552, 90, "", "", "");
		
		// Mercenary Post Manager Rota
		//-------------------------------------------------------------------------
		AddNpc(302, 151037, "Mercenary Post Manager Rota", "c_Klaipe", -638, 240, 1017, 405, "FEDIMIAN_ROTA_02", "", "");
		
		// Receptionist Ramda
		//-------------------------------------------------------------------------
		AddNpc(303, 147484, "Receptionist Ramda", "c_Klaipe", -609, 241, 867, 405, "MISSIONSHOP_NPC_01", "", "");
		
		// Receptionist Liam
		//-------------------------------------------------------------------------
		AddNpc(304, 154054, "Receptionist Liam", "c_Klaipe", -435.3569, 241.052, 895.4382, 360, "PARTYQUEST_NPC_01", "", "");
		
		// Receptionist Donnes
		//-------------------------------------------------------------------------
		AddNpc(305, 151039, "Receptionist Donnes", "c_Klaipe", -542, 241, 882, 405, "DROPITEM_REQUEST1_NPC", "", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(306, 47248, "", "c_Klaipe", -77.60321, 149.0709, -142.1835, 90, "KLAPEDA_FISHING_CAT", "KLAPEDA_FISHING_CAT", "");
		
		// Selphie
		//-------------------------------------------------------------------------
		AddNpc(10020, 147473, "Selphie", "c_Klaipe", -605.3381, -1.34, -479.0974, -3, "LOWLV_GREEN_SELPHUI", "", "");
		
		// Baron Munchausen
		//-------------------------------------------------------------------------
		AddNpc(10021, 155017, "Baron Munchausen", "c_Klaipe", -949, 241, 365, 405, "LOWLV_BOASTER_MUENCHHAUSEN", "", "", 0);
		AddNpc(10022, 20026, "", "c_Klaipe", 547.71, -1.33, 382.05, 90, "", "", "");
		AddNpc(5002, 20025, " ", "c_Klaipe", 82.39, 149.19, 73.38, 270, "", "", "");
		AddNpc(10023, 150004, "Fishing Spot", "c_Klaipe", -827.2349, 217.9105, 729.8553, 90, "", "", "");
		
		// Fishing Spot Notice Board
		//-------------------------------------------------------------------------
		AddNpc(10024, 150008, "Fishing Spot Notice Board", "c_Klaipe", -671.2596, 241.052, 653.7202, 45, "KLAPEDA_FISHING_BOARD", "", "");
		
		// [Fishing Manager]{nl}Joha
		//-------------------------------------------------------------------------
		AddNpc(10025, 147517, "[Fishing Manager]{nl}Joha", "c_Klaipe", -616, 241, 723, 45, "KLAPEDA_FISHING_MANAGER", "", "");
		AddNpc(10026, 150004, "Fishing Spot", "c_Klaipe", -1032.822, 217.9105, 436.1237, 90, "", "", "");
		AddNpc(10026, 150004, "Fishing Spot", "c_Klaipe", -1019.782, 248.2324, 101.6718, 90, "", "", "");
		AddNpc(10026, 150004, "Fishing Spot", "c_Klaipe", -554.4673, 217.9105, 975.0009, 90, "", "", "");
		AddNpc(10023, 150004, "Fishing Spot", "c_Klaipe", -162.7503, 240.7268, 974.8879, 90, "", "", "");
		
		// Team Battle League{nl}Valis
		//-------------------------------------------------------------------------
		AddNpc(10027, 158000, "Team Battle League{nl}Valis", "c_Klaipe", -389.748, 241.052, 605.1042, 90, "WORLDPVP_START", "", "");
		AddNpc(10028, 20026, "", "c_Klaipe", 284.7182, 79.85956, 91.90858, 90, "", "", "");
		
		// Rima
		//-------------------------------------------------------------------------
		AddNpc(10029, 20148, "Rima", "c_Klaipe", 519.8436, -1.156548, 326.1438, 90, "CHAR119_MSTEP3_4_NPC", "", "", 1);
		
		// Sentinel Rian
		//-------------------------------------------------------------------------
		AddNpc(10061, 147410, "Sentinel Rian", "c_Klaipe", -321.1135, 241.052, 896.6875, 0, "INSTANCE_DUNGEON", "", "");
		
		// [Onmyoji Master]{nl}Ahiro Seimei
		//-------------------------------------------------------------------------
		AddNpc(118, 153203, "[Onmyoji Master]{nl}Ahiro Seimei", "c_Klaipe", -589, 149, -161, 90, "ONMYOJI_MASTER", "", "", 1);
		
		// [Kedora Alliance]{nl}Geraldasia
		//-------------------------------------------------------------------------
		AddNpc(10062, 157056, "[Kedora Alliance]{nl}Geraldasia", "c_Klaipe", -384.9556, 240.7268, 1045.116, 0, "NPC_JUNK_SHOP_KLAPEDA", "", "");
		
		// Beauty Shop
		//-------------------------------------------------------------------------
		AddNpc(10063, 40001, "Beauty Shop", "c_Klaipe", -1039.639, 240.7425, 682.0443, 242, "BEAUTY_IN_MOVE", "BEAUTY_IN_MOVE", "");
		
		// Class Tree Change Helper
		//-------------------------------------------------------------------------
		AddNpc(5185, 151042, "Class Tree Change Helper", "c_Klaipe", -435, 149, -144, 180, "CTRLTYPE_RESET_NPC", "", "", 0);
		
		// [Scout Master]{nl}Recon Rimgaile
		//-------------------------------------------------------------------------
		AddNpc(10064, 57234, "[Scout Master]{nl}Recon Rimgaile", "c_Klaipe", -930.8004, 241.052, 133.2633, 90, "JOB_SCOUT3_1_NPC", "", "");
		AddNpc(5218, 20026, " ", "c_Klaipe", 70, 155, 315, 90, "", "", "");
		AddNpc(10066, 20026, " ", "c_Klaipe", -350.4608, 149.1097, -128.6886, 193, "", "", "");
		AddNpc(10067, 40095, " ", "c_Klaipe", 63.86081, 149.1097, 373.3645, -90, "", "", "");
		
		// [Professional Alchemist]{nl}Abelu
		//-------------------------------------------------------------------------
		AddNpc(10073, 20190, "[Professional Alchemist]{nl}Abelu", "c_Klaipe", -125.7215, 96.88016, -308.4914, 84, "ALCHEIST_EXPERT_NPC_KLAPEDA", "", "");
		
		// Housing Helper Kupole
		//-------------------------------------------------------------------------
		AddNpc(10068, 154125, "Housing Helper Kupole", "c_Klaipe", -267.7074, -1.21924, -723.6546, 4, "NPC_PERSONAL_HOUSING_MANAGER", "", "");
		
		// [Event] Goddess Roulette
		//-------------------------------------------------------------------------
		AddNpc(10080, 20026, "[Event] Goddess Roulette", "c_Klaipe", -712, 241, 531, 45, "EVENT_POPO_ROULETTE_NPC", "", "");
		
		// [Demon God's Temptation]{nl}Illusion of Demon God Ragana
		//-------------------------------------------------------------------------
		AddNpc(10090, 154130, "[Demon God's Temptation]{nl}Illusion of Demon God Ragana", "c_Klaipe", 411.4446, 79.85956, 208.2908, 16, "SHOP_NPC_RAGANA_CITY_1", "", "");
		
		// [Kingdom Reconstruction] Notice Board
		//-------------------------------------------------------------------------
		AddNpc(10101, 157106, "[Kingdom Reconstruction] Notice Board", "c_Klaipe", 67.48899, 149.067, -10.15458, 225, "REPUTATION_QUEST_BOARD_01", "", "");
		AddNpc(5275, 20026, " ", "c_Klaipe", 70, 155, 315, 90, "", "", "");
		
		// Mysterious Storyteller
		//-------------------------------------------------------------------------
		AddNpc(10113, 150256, "Mysterious Storyteller", "c_Klaipe", 118.7831, 149.1092, 93.82877, -32, "TOSHERO_TUTO_NPC_01", "", "", 1);
		
		// Unknown Sanctuary Gate
		//-------------------------------------------------------------------------
		AddNpc(10115, 155174, "Unknown Sanctuary Gate", "c_Klaipe", -510.5378, 149.1097, 68.49586, 81, "UNKNOWN_SANTUARY_GATE_GUILD", "", "");
		
		// [Bounty Hunt]{nl}Wanted Board
		//-------------------------------------------------------------------------
		AddNpc(5282, 9000000, "[Bounty Hunt]{nl}Wanted Board", "c_Klaipe", -526.7698, 241.052, 908.6937, 90, "BOUNTY_HUNT_START", "", "");
		
		// Goddess Ingredient Exchange Helper 
		//-------------------------------------------------------------------------
		AddNpc(10116, 151042, "Goddess Ingredient Exchange Helper ", "c_Klaipe", -249.0009, 149.1097, -86.20673, 180, "EP13CARE_TRADE", "", "");
		AddNpc(10121, 20026, "", "c_Klaipe", 439.8372, 79.85956, 100.1043, 270, "", "", "");
		AddNpc(10122, 20026, "", "c_Klaipe", 445.5905, 79.85956, 48.7312, 270, "", "", "");
		AddNpc(10123, 20026, "", "c_Klaipe", 432.7874, 79.85956, 154.3851, 270, "", "", "");
		
		// Goddess' Blessing
		//-------------------------------------------------------------------------
		AddNpc(10125, 160121, "Goddess' Blessing", "c_Klaipe", 363.902, 79.85956, 287.629, 200, "BLESSED_CUBE", "", "");
		
		// [Skill Transmutation Helper]{nl}Kupole
		//-------------------------------------------------------------------------
		AddNpc(10126, 160088, "[Skill Transmutation Helper]{nl}Kupole", "c_Klaipe", 300.6426, 79.85956, -30.70284, 90, "DUCTILITY_NPC", "", "");
		
		// [Equipment Transmutation Helper] Kupole
		//-------------------------------------------------------------------------
		AddNpc(10126, 160088, "[Equipment Transmutation Helper] Kupole", "c_Klaipe", 300.6426, 79.85956, -30.70284, 90, "DUCTILITY_NPC", "", "");
		
		// [Previous Goddess Token Shop]{nl}Kupole
		//-------------------------------------------------------------------------
		AddNpc(10127, 160178, "[Previous Goddess Token Shop]{nl}Kupole", "c_Klaipe", -293.0878, 149.1097, -86.89342, 144, "PREVIOUS_COIN_SHOP", "", "");
		
		// [Event]{nl}Ghost Maiden
		//-------------------------------------------------------------------------
		AddNpc(10128, 160103, "[Event]{nl}Ghost Maiden", "c_Klaipe", -764.9106, 241.052, 574.467, 90, "CITY_EVENT_2110_NPC", "", "");
		
		// [Event]{nl}Pumpkin Stew Cauldron
		//-------------------------------------------------------------------------
		AddNpc(10129, 160104, "[Event]{nl}Pumpkin Stew Cauldron", "c_Klaipe", -815.0399, 241.052, 510.5818, 90, "EVENT_2110_POT_NPC", "", "");
		
		// [Event]{nl}Fallen City Refugee
		//-------------------------------------------------------------------------
		AddNpc(10130, 160105, "[Event]{nl}Fallen City Refugee", "c_Klaipe", -809.9025, 241.052, 559.7675, 90, "CITY_EVENT_2110_NPC2", "", "");
		
		// TOS Coin Helper
		//-------------------------------------------------------------------------
		AddNpc(5500, 160157, "TOS Coin Helper", "c_Klaipe", -664, 241, 576, 90, "EVENT_TOS_WHOLE_NPC", "", "");
		
		// [Popo Boost Care]{nl}Kupole
		//-------------------------------------------------------------------------
		AddNpc(10131, 160088, "[Popo Boost Care]{nl}Kupole", "c_Klaipe", -374, 149, -107, 90, "CARE_POPOBOOST_STATUS", "", "");
		
		// [Black Market]{nl}Auctioneer
		//-------------------------------------------------------------------------
		AddNpc(10132, 20140, "[Black Market]{nl}Auctioneer", "c_Klaipe", 439, 79, 74, 90, "BLACK_MARKET", "", "");
		
		// [Snigo's Memory]{nl}Little Glacia
		//-------------------------------------------------------------------------
		AddNpc(10133, 160193, "[Snigo's Memory]{nl}Little Glacia", "c_Klaipe", -602.16, 241.15, 628.5, 45, "LITTLE_GLACIER", "", "");
		
		// [Event]{nl}New Year's Helper Cuvid
		//-------------------------------------------------------------------------
		AddNpc(10135, 160204, "[Event]{nl}New Year's Helper Cuvid", "c_Klaipe", -604, 241, 576, 45, "EVENT_NEWYEAR_ASSIST", "", "");
	}
}
