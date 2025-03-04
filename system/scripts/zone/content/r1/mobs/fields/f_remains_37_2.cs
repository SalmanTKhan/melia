//--- Melia Script -----------------------------------------------------------
// Namu Temple Ruins Spawns
//--- Description -----------------------------------------------------------
// Sets up monster spawners for 'f_remains_37_2'.
//---------------------------------------------------------------------------

using System;
using Melia.Zone.Scripting;
using Melia.Shared.Game.Const;
using static Melia.Zone.Scripting.Shortcuts;

public class FRemains372MobScript : GeneralScript
{
	protected override void Load()
	{
		// Monster Spawners ---------------------------------

		AddSpawner("f_remains_37_2.Id1", MonsterId.Rootcrystal_04, min: 30, max: 40, respawn: Minutes(1), tendency: TendencyType.Peaceful);
		AddSpawner("f_remains_37_2.Id2", MonsterId.Lizardman_Mage, min: 15, max: 20, tendency: TendencyType.Aggressive);
		AddSpawner("f_remains_37_2.Id3", MonsterId.Minos, min: 68, max: 90, tendency: TendencyType.Aggressive);
		AddSpawner("f_remains_37_2.Id4", MonsterId.Minos_Bow, min: 12, max: 15, tendency: TendencyType.Aggressive);
		AddSpawner("f_remains_37_2.Id5", MonsterId.Minos, min: 15, max: 20, tendency: TendencyType.Aggressive);

		// Monster Spawn Points -----------------------------

		// 'Rootcrystal_04' GenType 3 Spawn Points
		AddSpawnPoint("f_remains_37_2.Id1", "f_remains_37_2", Rectangle(1757, -451, 40));
		AddSpawnPoint("f_remains_37_2.Id1", "f_remains_37_2", Rectangle(1552, -419, 40));
		AddSpawnPoint("f_remains_37_2.Id1", "f_remains_37_2", Rectangle(1245, -432, 40));
		AddSpawnPoint("f_remains_37_2.Id1", "f_remains_37_2", Rectangle(970, -301, 40));
		AddSpawnPoint("f_remains_37_2.Id1", "f_remains_37_2", Rectangle(868, -453, 40));
		AddSpawnPoint("f_remains_37_2.Id1", "f_remains_37_2", Rectangle(880, -1, 40));
		AddSpawnPoint("f_remains_37_2.Id1", "f_remains_37_2", Rectangle(856, -701, 40));
		AddSpawnPoint("f_remains_37_2.Id1", "f_remains_37_2", Rectangle(849, -1148, 40));
		AddSpawnPoint("f_remains_37_2.Id1", "f_remains_37_2", Rectangle(1247, -1202, 40));
		AddSpawnPoint("f_remains_37_2.Id1", "f_remains_37_2", Rectangle(872, 272, 40));
		AddSpawnPoint("f_remains_37_2.Id1", "f_remains_37_2", Rectangle(982, 714, 40));
		AddSpawnPoint("f_remains_37_2.Id1", "f_remains_37_2", Rectangle(685, 838, 40));
		AddSpawnPoint("f_remains_37_2.Id1", "f_remains_37_2", Rectangle(728, 1338, 40));
		AddSpawnPoint("f_remains_37_2.Id1", "f_remains_37_2", Rectangle(754, 1860, 40));
		AddSpawnPoint("f_remains_37_2.Id1", "f_remains_37_2", Rectangle(1126, 221, 40));
		AddSpawnPoint("f_remains_37_2.Id1", "f_remains_37_2", Rectangle(371, 257, 40));
		AddSpawnPoint("f_remains_37_2.Id1", "f_remains_37_2", Rectangle(16, 246, 40));
		AddSpawnPoint("f_remains_37_2.Id1", "f_remains_37_2", Rectangle(-289, 267, 40));
		AddSpawnPoint("f_remains_37_2.Id1", "f_remains_37_2", Rectangle(-603, 271, 40));
		AddSpawnPoint("f_remains_37_2.Id1", "f_remains_37_2", Rectangle(-890, 269, 40));
		AddSpawnPoint("f_remains_37_2.Id1", "f_remains_37_2", Rectangle(-1358, 273, 40));
		AddSpawnPoint("f_remains_37_2.Id1", "f_remains_37_2", Rectangle(-1642, 32, 40));
		AddSpawnPoint("f_remains_37_2.Id1", "f_remains_37_2", Rectangle(80, -258, 40));
		AddSpawnPoint("f_remains_37_2.Id1", "f_remains_37_2", Rectangle(30, -659, 40));
		AddSpawnPoint("f_remains_37_2.Id1", "f_remains_37_2", Rectangle(-149, -918, 40));
		AddSpawnPoint("f_remains_37_2.Id1", "f_remains_37_2", Rectangle(-48, -1200, 40));
		AddSpawnPoint("f_remains_37_2.Id1", "f_remains_37_2", Rectangle(100, -1492, 40));
		AddSpawnPoint("f_remains_37_2.Id1", "f_remains_37_2", Rectangle(-507, -812, 40));
		AddSpawnPoint("f_remains_37_2.Id1", "f_remains_37_2", Rectangle(-1059, -799, 40));
		AddSpawnPoint("f_remains_37_2.Id1", "f_remains_37_2", Rectangle(-764, 555, 40));
		AddSpawnPoint("f_remains_37_2.Id1", "f_remains_37_2", Rectangle(-775, 896, 40));
		AddSpawnPoint("f_remains_37_2.Id1", "f_remains_37_2", Rectangle(-240, 945, 40));
		AddSpawnPoint("f_remains_37_2.Id1", "f_remains_37_2", Rectangle(84, 813, 40));
		AddSpawnPoint("f_remains_37_2.Id1", "f_remains_37_2", Rectangle(-1059, 994, 40));
		AddSpawnPoint("f_remains_37_2.Id1", "f_remains_37_2", Rectangle(-1377, 919, 40));
		AddSpawnPoint("f_remains_37_2.Id1", "f_remains_37_2", Rectangle(-1515, 1248, 40));
		AddSpawnPoint("f_remains_37_2.Id1", "f_remains_37_2", Rectangle(-1358, 1470, 40));
		AddSpawnPoint("f_remains_37_2.Id1", "f_remains_37_2", Rectangle(-1422, 686, 40));
		AddSpawnPoint("f_remains_37_2.Id1", "f_remains_37_2", Rectangle(-789, 1408, 40));

		// 'Lizardman_Mage' GenType 23 Spawn Points
		AddSpawnPoint("f_remains_37_2.Id2", "f_remains_37_2", Rectangle(-1114, -926, 25));
		AddSpawnPoint("f_remains_37_2.Id2", "f_remains_37_2", Rectangle(-994, -780, 25));
		AddSpawnPoint("f_remains_37_2.Id2", "f_remains_37_2", Rectangle(-871, -923, 25));
		AddSpawnPoint("f_remains_37_2.Id2", "f_remains_37_2", Rectangle(-317, -748, 25));
		AddSpawnPoint("f_remains_37_2.Id2", "f_remains_37_2", Rectangle(-111, -553, 25));
		AddSpawnPoint("f_remains_37_2.Id2", "f_remains_37_2", Rectangle(123, -754, 25));
		AddSpawnPoint("f_remains_37_2.Id2", "f_remains_37_2", Rectangle(-89, -779, 25));
		AddSpawnPoint("f_remains_37_2.Id2", "f_remains_37_2", Rectangle(-133, -1329, 25));
		AddSpawnPoint("f_remains_37_2.Id2", "f_remains_37_2", Rectangle(-89, -1531, 25));
		AddSpawnPoint("f_remains_37_2.Id2", "f_remains_37_2", Rectangle(174, -1421, 25));
		AddSpawnPoint("f_remains_37_2.Id2", "f_remains_37_2", Rectangle(0, -1417, 25));
		AddSpawnPoint("f_remains_37_2.Id2", "f_remains_37_2", Rectangle(893, -1222, 25));
		AddSpawnPoint("f_remains_37_2.Id2", "f_remains_37_2", Rectangle(1007, -1078, 25));
		AddSpawnPoint("f_remains_37_2.Id2", "f_remains_37_2", Rectangle(1120, -1353, 25));
		AddSpawnPoint("f_remains_37_2.Id2", "f_remains_37_2", Rectangle(1298, -1140, 25));
		AddSpawnPoint("f_remains_37_2.Id2", "f_remains_37_2", Rectangle(1141, -1197, 25));
		AddSpawnPoint("f_remains_37_2.Id2", "f_remains_37_2", Rectangle(942, -472, 25));
		AddSpawnPoint("f_remains_37_2.Id2", "f_remains_37_2", Rectangle(1088, -178, 25));
		AddSpawnPoint("f_remains_37_2.Id2", "f_remains_37_2", Rectangle(61, -1290, 25));
		AddSpawnPoint("f_remains_37_2.Id2", "f_remains_37_2", Rectangle(-74, -982, 25));
		AddSpawnPoint("f_remains_37_2.Id2", "f_remains_37_2", Rectangle(-789, -781, 25));
		AddSpawnPoint("f_remains_37_2.Id2", "f_remains_37_2", Rectangle(-1256, -726, 25));
		AddSpawnPoint("f_remains_37_2.Id2", "f_remains_37_2", Rectangle(1320, -1319, 25));
		AddSpawnPoint("f_remains_37_2.Id2", "f_remains_37_2", Rectangle(1156, -1004, 25));
		AddSpawnPoint("f_remains_37_2.Id2", "f_remains_37_2", Rectangle(145, -568, 25));
		AddSpawnPoint("f_remains_37_2.Id2", "f_remains_37_2", Rectangle(-239, -928, 25));

		// 'Minos' GenType 24 Spawn Points
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(997, -227, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(699, -192, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(1134, -529, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(1193, -332, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(682, 804, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(929, 904, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(931, 695, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(784, 600, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(609, 1695, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(786, 1792, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(823, 1510, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-1500, 1163, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-1304, 929, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-240, 1086, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(965, 1893, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-1777, 252, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-1508, 213, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-69, 414, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-9, 242, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(888, -327, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(582, 1452, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(114, 846, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-1450, 859, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(791, 1304, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(1036, 1592, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(1229, 564, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-1485, 637, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-1342, -58, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-1398, 1501, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-1247, 1238, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-86, 883, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-256, 251, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(1136, 748, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(541, 1979, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(793, -409, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-110, -804, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-269, -977, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(24, -897, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-273, -666, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-118, -628, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(105, -753, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-1045, -935, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-1098, -731, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-856, -715, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-922, -916, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-972, -831, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-160, 354, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(215, 239, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-1581, 987, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-1591, 44, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-82, -1458, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(77, -1501, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(100, -1389, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(187, -1333, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-30, -1261, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-100, -1219, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-125, -1404, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-50, -1349, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(26, -1354, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(4, -1576, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-159, -973, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-17, -974, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(99, -945, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(116, -861, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(178, -792, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(179, -699, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(69, -607, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(90, -680, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-7, -592, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-63, -577, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(111, -512, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(36, -509, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-51, -495, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-179, -527, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-191, -641, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-244, -733, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-251, -804, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-251, -862, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-262, -1055, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-45, -1041, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-798, -871, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-889, -850, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-888, -790, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-953, -740, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-1012, -683, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-1117, -669, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-1196, -693, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-1224, -795, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-1155, -805, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-1078, -842, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-1019, -1015, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-942, -1013, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-806, -985, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-1164, -749, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-1182, -629, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-1703, 231, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-1643, 322, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-1584, 263, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-1706, 59, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-1653, 132, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-1497, 126, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-1478, 41, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-1405, -27, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-1388, 117, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-1422, 221, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-1287, 184, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-1177, 143, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-1212, 42, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-1194, -34, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-1281, -91, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-1430, 718, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-1319, 779, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-1353, 590, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-1280, 565, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-1242, 684, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-1235, 830, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-1456, 955, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-1353, 1027, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-1530, 865, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-1643, 1027, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-1674, 1123, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-1523, 1234, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-1410, 1283, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-1354, 1281, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-1232, 1360, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-1285, 1457, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-1394, 1596, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-1476, 1575, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-1507, 1453, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-1158, 1219, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-316, 858, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-324, 1045, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-361, 1142, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-211, 1009, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-139, 1157, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-82, 1088, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-79, 984, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(23, 969, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(137, 945, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(209, 874, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-14, 812, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(178, 713, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(53, 894, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(213, 783, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(90, 1047, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-330, 262, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-250, 312, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-393, 234, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-371, 364, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(-107, 210, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(1213, -1115, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(1239, -1228, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(1313, -1210, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(1247, -1321, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(1167, -1394, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(1096, -1249, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(982, -1235, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(1074, -1172, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(1052, -985, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(915, -1109, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(762, -1165, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(847, -1153, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(893, -959, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(1247, -1040, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(1383, -1178, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(969, -1164, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(1066, -1394, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(985, -1369, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(1028, -1307, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(1180, -1300, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(981, -564, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(1083, -588, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(1220, -587, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(1235, -458, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(1269, -318, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(1135, -447, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(1106, -302, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(1049, -392, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(1006, -310, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(967, -394, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(976, -143, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(850, -134, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(804, -234, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(677, -434, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(717, -387, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(636, -290, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(644, -206, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(720, -270, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(791, -168, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(902, -221, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(726, 685, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(821, 700, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(1040, 591, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(1111, 515, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(1228, 654, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(1075, 674, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(1006, 804, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(1018, 942, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(871, 794, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(783, 868, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(681, 884, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(773, 761, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(650, 687, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(857, 876, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(701, 602, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(903, 624, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(1007, 704, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(1146, 597, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(1205, 477, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(1021, 510, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(719, 1271, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(644, 1350, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(732, 1413, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(899, 1374, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(953, 1514, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(968, 1638, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(920, 1770, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(771, 1701, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(676, 1799, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(461, 1629, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(506, 1548, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(466, 1721, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(510, 1846, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(623, 1985, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(730, 1990, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(758, 1853, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(870, 1830, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(1088, 1862, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(897, 1700, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(810, 1600, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(713, 1566, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(877, 1443, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(805, 1384, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(639, 1486, 40));
		AddSpawnPoint("f_remains_37_2.Id3", "f_remains_37_2", Rectangle(600, 1594, 40));

		// 'Minos_Bow' GenType 25 Spawn Points
		AddSpawnPoint("f_remains_37_2.Id4", "f_remains_37_2", Rectangle(-203, 268, 40));
		AddSpawnPoint("f_remains_37_2.Id4", "f_remains_37_2", Rectangle(-1593, 1178, 40));
		AddSpawnPoint("f_remains_37_2.Id4", "f_remains_37_2", Rectangle(-1567, 85, 40));
		AddSpawnPoint("f_remains_37_2.Id4", "f_remains_37_2", Rectangle(-1301, 76, 40));
		AddSpawnPoint("f_remains_37_2.Id4", "f_remains_37_2", Rectangle(-121, 927, 40));
		AddSpawnPoint("f_remains_37_2.Id4", "f_remains_37_2", Rectangle(-407, 1000, 40));
		AddSpawnPoint("f_remains_37_2.Id4", "f_remains_37_2", Rectangle(-7, 1057, 40));
		AddSpawnPoint("f_remains_37_2.Id4", "f_remains_37_2", Rectangle(-1373, 670, 40));
		AddSpawnPoint("f_remains_37_2.Id4", "f_remains_37_2", Rectangle(-1620, 923, 40));
		AddSpawnPoint("f_remains_37_2.Id4", "f_remains_37_2", Rectangle(-1261, 1243, 40));
		AddSpawnPoint("f_remains_37_2.Id4", "f_remains_37_2", Rectangle(97, 250, 40));
		AddSpawnPoint("f_remains_37_2.Id4", "f_remains_37_2", Rectangle(-1503, 329, 40));
		AddSpawnPoint("f_remains_37_2.Id4", "f_remains_37_2", Rectangle(-1340, 1529, 40));

		// 'Minos' GenType 31 Spawn Points
		AddSpawnPoint("f_remains_37_2.Id5", "f_remains_37_2", Rectangle(-156, 929, 9999));
	}
}
