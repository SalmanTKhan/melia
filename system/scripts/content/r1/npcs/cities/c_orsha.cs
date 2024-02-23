//--- Melia Script ----------------------------------------------------------
// Orsha
//--- Description -----------------------------------------------------------
// NPCs found in and around Orsha.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class COrshaNpcScript : GeneralScript
{
	public override void Load()
	{
		// Orsha Bulletin Board
		//-------------------------------------------------------------------------
		AddNpc(1, 40070, "Orsha Bulletin Board", "c_orsha", -1077.49, 500.61, 332.74, 28, "ORSHA_KEDORLA_BOARD01", "", "");
		
		// [Blacksmith]{nl}Ilanai
		//-------------------------------------------------------------------------
		AddNpc(2, 20066, "[Blacksmith]{nl}Ilanai", "c_orsha", -133.44, 175.98, -285.69, 73, "ORSHA_BLACKSMITH", "TUTO_REPAIR_NPC", "");
		
		// [Equipment Merchant]{nl}Jura
		//-------------------------------------------------------------------------
		AddNpc(3, 20056, "[Equipment Merchant]{nl}Jura", "c_orsha", 21, 176, 154, 123, "ORSHA_EQUIPMENT_DEALER", "ADDHELP_NPCSHOP", "");
		
		// Orsha Resident
		//-------------------------------------------------------------------------
		AddNpc(4, 20063, "Orsha Resident", "c_orsha", 384.97, 175.85, 231.72, -60, "ORSHA_KEDORLA_MEMBER01", "", "");
		
		//   [Lord of Orsha]{nl}Inesa Hamondale
		//-------------------------------------------------------------------------
		AddNpc(5, 20065, "  [Lord of Orsha]{nl}Inesa Hamondale", "c_orsha", 86.99, 176.27, 713.25, 10, "C_ORSHA_HAMONDAIL", "", "");
		
		// Lord's Guard
		//-------------------------------------------------------------------------
		AddNpc(7, 20060, "Lord's Guard", "c_orsha", 140.98, 176.28, 712.85, -20, "C_ORSHA_SOLDIER_02", "", "");
		
		// [Orsha Bishop]{nl}Urbonas
		//-------------------------------------------------------------------------
		AddNpc(8, 154057, "[Orsha Bishop]{nl}Urbonas", "c_orsha", 895.18, 176.37, 702.91, 0, "C_ORSHA_URBONAS", "", "", 1);
		
		// [Item Merchant]{nl}Alf
		//-------------------------------------------------------------------------
		AddNpc(9, 20055, "[Item Merchant]{nl}Alf", "c_orsha", 231, 175, 166, 120, "ORSHA_TOOL_NPC", "", "");
		AddNpc(10, 40032, " ", "c_orsha", 0, 176, 150, 90, "", "", "");
		
		// [Accessory Merchant]{nl}Jurus
		//-------------------------------------------------------------------------
		AddNpc(11, 20057, "[Accessory Merchant]{nl}Jurus", "c_orsha", 462.1917, 175.9214, -29.93526, -11, "ORSHA_ACCESSARY_NPC", "ORSHA_HQ1_CONDITION", "");
		
		// [Taoist Master]{nl}GeHong
		//-------------------------------------------------------------------------
		AddNpc(99, 153172, "[Taoist Master]{nl}GeHong", "c_orsha", -327.4769, 214.7283, 655.0816, 4, "DAOSHI_MASTER", "", "");
		
		// [Peltasta Submaster]{nl}Nirin Dameoff
		//-------------------------------------------------------------------------
		AddNpc(101, 155063, "[Peltasta Submaster]{nl}Nirin Dameoff", "c_orsha", -853, 500, -62, 100, "JOB_2_PELTASTA_NPC", "", "");
		
		// [Hoplite Master]{nl}Aidas Valor
		//-------------------------------------------------------------------------
		AddNpc(102, 147325, "[Hoplite Master]{nl}Aidas Valor", "c_orsha", -1070.18, 500.61, 229.96, 88, "JOB_2_HOPLITE_NPC", "", "");
		
		// [Cleric Submaster]{nl}Tamara Easton
		//-------------------------------------------------------------------------
		AddNpc(103, 155083, "[Cleric Submaster]{nl}Tamara Easton", "c_orsha", -269.96, 175.98, -378.04, 80, "JOB_2_CLERIC_NPC", "", "");
		
		// [Krivis Submaster]{nl}Mellinda Dicherin
		//-------------------------------------------------------------------------
		AddNpc(104, 155084, "[Krivis Submaster]{nl}Mellinda Dicherin", "c_orsha", -612.21, 368.42, 608.86, 74, "JOB_2_KRIVIS_NPC", "", "");
		
		// [Priest Submaster]{nl}Boira
		//-------------------------------------------------------------------------
		AddNpc(105, 155085, "[Priest Submaster]{nl}Boira", "c_orsha", 723.44, 176.38, 642.36, 15, "JOB_2_PRIEST_NPC", "", "");
		
		// [Bokor Submaster]{nl}Bobo Icelin
		//-------------------------------------------------------------------------
		AddNpc(106, 155086, "[Bokor Submaster]{nl}Bobo Icelin", "c_orsha", 462.4, 176.4, 608.87, 0, "JOB_2_BOKOR_NPC", "", "");
		
		// [Rodelero Master]{nl}Kamiya
		//-------------------------------------------------------------------------
		AddNpc(107, 57235, "[Rodelero Master]{nl}Kamiya", "c_orsha", -451, 279, 419, 25, "JOB_2_RODELERO_NPC", "", "");
		
		// [Cataphract Master]{nl}Memet Culag
		//-------------------------------------------------------------------------
		AddNpc(108, 147327, "[Cataphract Master]{nl}Memet Culag", "c_orsha", 934.65, 73.98, 146.95, 71, "JOB_2_CATAPHRACT_NPC", "", "");
		
		// [Paladin Submaster]{nl}Sylvia Naimon
		//-------------------------------------------------------------------------
		AddNpc(110, 155088, "[Paladin Submaster]{nl}Sylvia Naimon", "c_orsha", 942.27, 73.98, 475.77, 95, "JOB_2_PALADIN_NPC", "", "");
		
		// Priest Pranas
		//-------------------------------------------------------------------------
		AddNpc(112, 155044, "Priest Pranas", "c_orsha", 915.74, 176.36, 708.51, 21, "C_ORSHA_PRANAS", "", "", 1);
		
		// Lemprasa Pond
		//-------------------------------------------------------------------------
		AddNpc(113, 40001, "Lemprasa Pond", "c_orsha", -1422.59, 472.79, 368.31, 258, "", "WARP_ORSHA_TO_EP13_F_SIAULIAI_1", "");
		
		// Lord's Guard
		//-------------------------------------------------------------------------
		AddNpc(6, 20059, "Lord's Guard", "c_orsha", 59.57713, 176.2658, 716.5414, 14, "C_ORSHA_SOLDIER_01", "", "");
		
		// [Sadhu Master]{nl}Agota Hanska
		//-------------------------------------------------------------------------
		AddNpc(109, 57226, "[Sadhu Master]{nl}Agota Hanska", "c_orsha", 1130.38, 21.82, 361.98, 93, "JOB_2_SADHU_NPC", "", "");
		
		// [Swordman Submaster]{nl}Codill
		//-------------------------------------------------------------------------
		AddNpc(100, 155062, "[Swordman Submaster]{nl}Codill", "c_orsha", 236.57, 176.41, 648.6, 1, "JOB_2_SWORDMAN_NPC", "", "");
		AddNpc(111, 47242, "Flameholder", "c_orsha", -603.11, 368.12, 641.37, 78, "", "", "");
		
		// Statue of Goddess Ausrine
		//-------------------------------------------------------------------------
		AddNpc(115, 154063, "Statue of Goddess Ausrine", "c_orsha", 103.14, 176.14, 322.95, -46, "WARP_C_ORSHA", "STOUP_CAMP", "STOUP_CAMP");
		
		// [Wizard Submaster]{nl}Dejamis
		//-------------------------------------------------------------------------
		AddNpc(116, 155069, "[Wizard Submaster]{nl}Dejamis", "c_orsha", -274.29, 177.5, -758.49, 90, "JOB_2_WIZARD_MASTER", "", "");
		
		// [Pyromancer Submaster]{nl}Cathy Naimos
		//-------------------------------------------------------------------------
		AddNpc(117, 155070, "[Pyromancer Submaster]{nl}Cathy Naimos", "c_orsha", -198.66, 177.43, -899.4, 90, "JOB_2_PYROMANCER_MASTER", "", "");
		
		// [Cryomancer Submaster]{nl}Octavia Iflynn
		//-------------------------------------------------------------------------
		AddNpc(118, 155071, "[Cryomancer Submaster]{nl}Octavia Iflynn", "c_orsha", 1035.62, 73.98, 79.04, 0, "JOB_2_CRYOMANCER_MASTER", "", "");
		
		// [Psychokino Master]{nl}Ili Terid
		//-------------------------------------------------------------------------
		AddNpc(119, 147328, "[Psychokino Master]{nl}Ili Terid", "c_orsha", -859.85, 500.61, 586.16, 0, "JOB_2_PSYCHOKINO_MASTER", "", "");
		
		// [Linker Master]{nl}Winona Ende
		//-------------------------------------------------------------------------
		AddNpc(120, 57230, "[Linker Master]{nl}Winona Ende", "c_orsha", -115.2998, 176.11, 240.2178, 84, "JOB_2_LINKER_MASTER", "", "");
		
		// [Thaumaturge Submaster]{nl}Diemer Fallon
		//-------------------------------------------------------------------------
		AddNpc(121, 155074, "[Thaumaturge Submaster]{nl}Diemer Fallon", "c_orsha", 235.47, 176.68, -827.3, 0, "JOB_2_THAUMATURGE_MASTER", "", "");
		
		// [Elementalist Master]{nl}Wican Celestic
		//-------------------------------------------------------------------------
		AddNpc(122, 147442, "[Elementalist Master]{nl}Wican Celestic", "c_orsha", -647.75, 317.8, 289.48, 45, "JOB_2_ELEMENTALIST_MASTER", "", "");
		
		// [Archer Submaster]{nl}Gunnison
		//-------------------------------------------------------------------------
		AddNpc(123, 155076, "[Archer Submaster]{nl}Gunnison", "c_orsha", -182.95, 176.24, 658.06, 0, "JOB_2_ARCHER_MASTER", "", "");
		
		// [Ranger Submaster]{nl}Sheba
		//-------------------------------------------------------------------------
		AddNpc(124, 155077, "[Ranger Submaster]{nl}Sheba", "c_orsha", 691.07, 177.47, -197.58, 90, "JOB_2_RANGER_MASTER", "", "");
		
		// [Quarrel Shooter Submaster]{nl}Shorris
		//-------------------------------------------------------------------------
		AddNpc(125, 155078, "[Quarrel Shooter Submaster]{nl}Shorris", "c_orsha", 752.0132, 176.1127, -41.47662, -84, "JOB_2_QUARRELSHOOTER_MASTER", "", "");
		
		// [Sapper Submaster]{nl}Zubin Katal
		//-------------------------------------------------------------------------
		AddNpc(126, 155079, "[Sapper Submaster]{nl}Zubin Katal", "c_orsha", 50.1228, 175.9837, -332.2393, 90, "JOB_2_SAPPER_MASTER", "", "");
		
		// [Hunter Submaster]{nl}Belkin Vellon
		//-------------------------------------------------------------------------
		AddNpc(127, 155080, "[Hunter Submaster]{nl}Belkin Vellon", "c_orsha", -1098.89, 177.96, -648.37, 90, "JOB_2_HUNTER_MASTER", "", "");
		
		// [Wugushi Master]{nl}Wor Pat
		//-------------------------------------------------------------------------
		AddNpc(128, 57233, "[Wugushi Master]{nl}Wor Pat", "c_orsha", -89.38, 177.22, -755.54, 0, "JOB_2_WUGUSHI_MASTER", "", "");
		
		// [Scout Submaster]{nl}Suina
		//-------------------------------------------------------------------------
		AddNpc(129, 155082, "[Scout Submaster]{nl}Suina", "c_orsha", -967.44, 177.67, -562.9, 0, "JOB_2_SCOUT_MASTER", "", "");
		
		// [Companion Trader]{nl}Toras
		//-------------------------------------------------------------------------
		AddNpc(130, 20058, "[Companion Trader]{nl}Toras", "c_orsha", -109.365, 176.2911, 362.765, 104, "ORSHA_PETSHOP", "ORSHA_HIDDENQ2_IN_TRIGGER", "");
		
		// Velheider
		//-------------------------------------------------------------------------
		AddNpc(131, 47521, "Velheider", "c_orsha", -126.3985, 176.3578, 394.7018, 95, "PETSHOP_KLAIPE_PET", "", "");
		
		// [Market Manager]{nl}Tilliana
		//-------------------------------------------------------------------------
		AddNpc(132, 156008, "[Market Manager]{nl}Tilliana", "c_orsha", 213.9646, 175.8581, -12.91508, 4, "ORSHA_MARKET", "TUTO_MARKET_NPC", "");
		
		// [Storage Keeper]{nl}Aisa
		//-------------------------------------------------------------------------
		AddNpc(133, 20067, "[Storage Keeper]{nl}Aisa", "c_orsha", 320.2166, 175.8852, 69.16746, 90, "ORSHA_WAREHOUSE", "TUTO_STORAGE_NPC", "");
		
		// [Orsha's Magic Association]{nl}Florianna
		//-------------------------------------------------------------------------
		AddNpc(134, 155102, "[Orsha's Magic Association]{nl}Florianna", "c_orsha", -985.9471, 500.6083, 415.8152, 90, "ORSHA_COLLECTION_SHOP", "", "");
		
		// [Wings of Vaivora]{nl}Rosia
		//-------------------------------------------------------------------------
		AddNpc(135, 155103, "[Wings of Vaivora]{nl}Rosia", "c_orsha", -451.5142, 324.6042, -89.63361, 90, "ORSHA_JOURNEY_SHOP", "TUTO_JOURNAL_NPC", "");
		
		// [TP Trader]{nl}Leticia
		//-------------------------------------------------------------------------
		AddNpc(136, 20068, "[TP Trader]{nl}Leticia", "c_orsha", 47.92036, 175.9995, 36.85776, 90, "TP_NPC", "TUTO_TPSHOP_NPC", "");
		
		// Girl Settler
		//-------------------------------------------------------------------------
		AddNpc(137, 20062, "Girl Settler", "c_orsha", -42, 176, 207, 90, "ORSHA_NPC01", "", "");
		
		// Young Settler
		//-------------------------------------------------------------------------
		AddNpc(138, 20064, "Young Settler", "c_orsha", -203, 176, 537, 90, "ORSHA_NPC02", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(142, 147466, " ", "c_orsha", -143.0727, 175.9837, -203.0902, 112, "ORSHA_BOOK01", "", "");
		AddNpc(143, 147311, " ", "c_orsha", -167.7551, 181.3739, -212.6962, 203, "", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(149, 151067, " ", "c_orsha", -100.2094, 181.6477, -203.3136, 90, "ORSHA_BOOK02", "", "");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(150, 147392, "Lv1 Treasure Chest", "c_orsha", -461.54, 505.13, -277, -45, "TREASUREBOX_LV_C_ORSHA150", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(151, 151128, " ", "c_orsha", 113.8782, 176.6798, -1352.281, 90, "HIDDEN_MIKO_JUROTA", "", "", 1);
		AddNpc(1002, 20040, "", "c_orsha", 45.6758, 175.9837, -24.42037, 90, "", "", "");
		
		// Matador Notice Board
		//-------------------------------------------------------------------------
		AddNpc(1004, 40070, "Matador Notice Board", "c_orsha", -217.2029, 215.4168, -37.60239, 67, "ORSHA_CHAR119_MSTEP1", "", "");
		
		// [Kedora Alliance]{nl}Geraldason
		//-------------------------------------------------------------------------
		AddNpc(5171, 157057, "[Kedora Alliance]{nl}Geraldason", "c_orsha", 389.446, 176.2009, 454.3311, 0, "NPC_JUNK_SHOP_FEDIMIAN_ORSHA", "", "");
		AddNpc(5203, 20026, " ", "c_orsha", -87.89307, 176.2951, 657.7053, -4, "", "", "");
		
		// Sentry Viola
		//-------------------------------------------------------------------------
		AddNpc(5204, 147415, "Sentry Viola", "c_orsha", 356.3264, 176.421, 611.3615, 7, "INSTANCE_DUNGEON", "", "");
		AddNpc(5207, 40095, " ", "c_orsha", 268.1279, 176.2111, 456.4837, 0, "", "", "");
		
		// Neringa
		//-------------------------------------------------------------------------
		AddNpc(5209, 154102, "Neringa", "c_orsha", 54.93348, 176.3144, 686.3074, 115, "EP12_PRELUDE_NERINGA_ORSHA1", "", "", 1);
		
		// Housing Helper Kupole
		//-------------------------------------------------------------------------
		AddNpc(5208, 154125, "Housing Helper Kupole", "c_orsha", 606.5975, 176.3566, 601.6386, -8, "NPC_PERSONAL_HOUSING_MANAGER", "", "");
		
		// [Event] Goddess Roulette
		//-------------------------------------------------------------------------
		AddNpc(5214, 20040, "[Event] Goddess Roulette", "c_orsha", 140, 175, 200, 45, "EVENT_POPO_ROULETTE_NPC", "", "");
		
		// [Demon God's Temptation]{nl}Illusion of Demon God Ragana
		//-------------------------------------------------------------------------
		AddNpc(5231, 154130, "[Demon God's Temptation]{nl}Illusion of Demon God Ragana", "c_orsha", 289.2979, 175.887, -5.8213, 90, "SHOP_NPC_RAGANA_CITY_1", "", "");
		AddNpc(5233, 150004, "", "c_orsha", 640.5706, 146.9372, 300.8319, 90, "", "", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(5234, 150008, "", "c_orsha", 666.1104, 176.2464, 82.24618, 5, "KLAPEDA_FISHING_BOARD", "", "");
		
		// [Fishing Shop]{nl}Joha's Tackle Box
		//-------------------------------------------------------------------------
		AddNpc(5238, 154119, "[Fishing Shop]{nl}Joha's Tackle Box", "c_orsha", 617.4446, 176.0635, 77.70792, 5, "FISHING_SUB_ORSHA_NPC", "", "");
		
		// [Kingdom Reconstruction] Orsha Officer
		//-------------------------------------------------------------------------
		AddNpc(5243, 151093, "[Kingdom Reconstruction] Orsha Officer", "c_orsha", -957.3541, 500.6083, 262.489, -34, "EP13_WEEK_REPUTATION_01", "", "");
		
		// [Clown Master]{nl}Jorick Show
		//-------------------------------------------------------------------------
		AddNpc(5246, 160054, "[Clown Master]{nl}Jorick Show", "c_orsha", -858.8137, 500.5984, -118.8935, 75, "CLO_MASTER", "", "");
		
		// [Arquebusier Master]{nl}Rudmila
		//-------------------------------------------------------------------------
		AddNpc(5247, 160053, "[Arquebusier Master]{nl}Rudmila", "c_orsha", -476.0047, 368.1776, 632.4641, 267, "ARQ_MASTER", "", "");
		
		// [Sage Master]{nl}Rhupas Kehel
		//-------------------------------------------------------------------------
		AddNpc(5249, 153171, "[Sage Master]{nl}Rhupas Kehel", "c_orsha", -947.8719, 500.6083, 46.73744, 90, "SAGE_MASTER", "", "");
		
		// Rimantas
		//-------------------------------------------------------------------------
		AddNpc(5250, 20063, "Rimantas", "c_orsha", -973, 489, -227, 45, "CHAR119_MSTEP3_3_1_NPC", "", "", 1);
		
		// [Professional Alchemist]{nl}Heecia
		//-------------------------------------------------------------------------
		AddNpc(5253, 20190, "[Professional Alchemist]{nl}Heecia", "c_orsha", 541.2324, 175.9735, -4.147208, -1, "ALCHEIST_EXPERT_NPC_ORSHA", "", "");
		
		// [Kingdom Reconstruction] Notice Board
		//-------------------------------------------------------------------------
		AddNpc(5254, 157106, "[Kingdom Reconstruction] Notice Board", "c_orsha", -1006.898, 500.6083, 134.1435, 103, "REPUTATION_QUEST_BOARD_01", "", "");
		
		// Nervous Lady
		//-------------------------------------------------------------------------
		AddNpc(152, 151080, "Nervous Lady", "c_orsha", -651.4844, 445.8481, -167.9132, 91, "THREECMLAKE_84_HIDDEN_MADAM", "", "");
		
		// Unknown Sanctuary Gate
		//-------------------------------------------------------------------------
		AddNpc(5271, 155174, "Unknown Sanctuary Gate", "c_orsha", 295.3502, 175.9791, 353.3213, 34, "UNKNOWN_SANTUARY_GATE_GUILD", "", "");
		
		// [Bounty Hunt]{nl}Wanted Board
		//-------------------------------------------------------------------------
		AddNpc(5272, 9000001, "[Bounty Hunt]{nl}Wanted Board", "c_orsha", -916.4008, 500.6083, 192.9173, -34, "BOUNTY_HUNT_START", "", "");
		
		// Goddess Ingredient Exchange Helper 
		//-------------------------------------------------------------------------
		AddNpc(5273, 151042, "Goddess Ingredient Exchange Helper ", "c_orsha", -249.7329, 214.9407, 415.7246, 90, "EP13CARE_TRADE", "", "");
		
		// [Event]{nl}Ghost Maiden
		//-------------------------------------------------------------------------
		AddNpc(5277, 160103, "[Event]{nl}Ghost Maiden", "c_orsha", 34.38, 176.033, 101.664, 90, "CITY_EVENT_2110_NPC", "", "");
		
		// [Event]{nl}Pumpkin Stew Cauldron
		//-------------------------------------------------------------------------
		AddNpc(5278, 160104, "[Event]{nl}Pumpkin Stew Cauldron", "c_orsha", 27.97806, 176.0097, 72.78047, 90, "EVENT_2110_POT_NPC", "", "");
		
		// [Event]{nl}Fallen City Refugee
		//-------------------------------------------------------------------------
		AddNpc(5282, 160105, "[Event]{nl}Fallen City Refugee", "c_orsha", 143.3891, 175.9138, 139.7511, 90, "CITY_EVENT_2110_NPC2", "", "");
		
		// [Hwarang Master]{nl}Saraham
		//-------------------------------------------------------------------------
		AddNpc(5284, 150291, "[Hwarang Master]{nl}Saraham", "c_orsha", 1301.351, 21.81653, 381.7126, -18, "MASTER_HWARANG_NPC", "", "");
		
		// Illusion of the Girl
		//-------------------------------------------------------------------------
		AddNpc(5286, 150238, "Illusion of the Girl", "c_orsha", 1409.725, 21.81653, 351.7238, 90, "EP14_MULIA_NPC_3", "", "", 1);
		
		// Orsha Port Entry Officer
		//-------------------------------------------------------------------------
		AddNpc(5288, 151078, "Orsha Port Entry Officer", "c_orsha", 1352.843, 21.81653, 331.6997, 98, "EP14_F_CORAL_RAID_1_NPC_1", "", "", 1);
		
		// Goddess' Blessing
		//-------------------------------------------------------------------------
		AddNpc(5289, 160121, "Goddess' Blessing", "c_orsha", 156.9937, 175.8475, -4.809603, 200, "BLESSED_CUBE", "", "");
		
		// [Skill Transmutation Helper]{nl}Kupole
		//-------------------------------------------------------------------------
		AddNpc(5295, 160088, "[Skill Transmutation Helper]{nl}Kupole", "c_orsha", 549.3414, 176.3394, 576.8683, -25, "DUCTILITY_NPC", "", "");
		
		// [Equipment Transmutation Helper] Kupole
		//-------------------------------------------------------------------------
		AddNpc(5295, 160088, "[Equipment Transmutation Helper] Kupole", "c_orsha", 549.3414, 176.3394, 576.8683, -25, "DUCTILITY_NPC", "", "");
		
		// TOS Coin Helper
		//-------------------------------------------------------------------------
		AddNpc(5500, 160157, "TOS Coin Helper", "c_orsha", 184, 175, 246, 90, "EVENT_TOS_WHOLE_NPC", "", "");
		
		// [Engineer Master]{nl}Margaret Ineija
		//-------------------------------------------------------------------------
		AddNpc(5502, 160170, "[Engineer Master]{nl}Margaret Ineija", "c_orsha", -1381, 177, -780, 90, "MASTER_ENG_NPC", "", "");
		
		// [Previous Goddess Token Shop]{nl}Kupole
		//-------------------------------------------------------------------------
		AddNpc(5503, 160178, "[Previous Goddess Token Shop]{nl}Kupole", "c_orsha", -41.21173, 175.9837, -8.236629, 101, "PREVIOUS_COIN_SHOP", "", "");
		
		// [Black Market]{nl}Auctioneer
		//-------------------------------------------------------------------------
		AddNpc(5504, 20140, "[Black Market]{nl}Auctioneer", "c_orsha", 38, 176, -187, 90, "BLACK_MARKET", "", "");
		
		// [Snigo's Memory]{nl}Little Glacia
		//-------------------------------------------------------------------------
		AddNpc(5505, 160193, "[Snigo's Memory]{nl}Little Glacia", "c_orsha", 190.03, 176.29, 413.03, 45, "LITTLE_GLACIER", "", "");
		
		// [Winged Hussar Master]{nl}Jan Karolas
		//-------------------------------------------------------------------------
		AddNpc(5506, 160198, "[Winged Hussar Master]{nl}Jan Karolas", "c_orsha", -193.6049, 177.4209, -760.5928, 90, "NPC_WINGEDHUSSAR", "", "");
		
		// [Event]{nl}New Year's Helper Cuvid
		//-------------------------------------------------------------------------
		AddNpc(5507, 160204, "[Event]{nl}New Year's Helper Cuvid", "c_orsha", 234, 175, 246, 45, "EVENT_NEWYEAR_ASSIST", "", "");
	}
}
