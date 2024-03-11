using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Melia.Shared.Game.Const;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.Scripting;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.Effects;
using Melia.Zone.World.Tracks;
using Yggdrasil.Logging;

[TrackScript("FLASH_29_1_SQ_010_TRACK")]
public class FLASH291SQ010TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("FLASH_29_1_SQ_010_TRACK");
		//SetMap("f_flash_29_1");
		//CenterPos(-978.88,0.20,-557.21);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-1878.154f, -0.0002f, -88.08903f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 152051, "", "f_flash_29_1", -2049.433, -0.0001795588, -113.5077, 42.85714);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 154025, "", "f_flash_29_1", -1839.59, 0, -21.01, 1);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 147374, "", "f_flash_29_1", -1030.091, 0.1475465, -637.0035, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 20026, "", "f_flash_29_1", -692.7229, 43.08315, -356.7361, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 152053, "UnvisibleName", "f_flash_29_1", -1467.123, -0.0001, -240.9489, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 152053, "UnvisibleName", "f_flash_29_1", -1269.276, 0.2467, -439.0552, 8.75);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 152053, "UnvisibleName", "f_flash_29_1", -840.6624, 43.07289, -366.6385, 21.66667);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 152067, "UnvisibleName", "f_flash_29_1", -1606.343, -0.0002, -37.7097, 0, "Monster");
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 152067, "UnvisibleName", "f_flash_29_1", -1625.644, -0.0001739593, -84.54354, 20, "Monster");
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 152067, "UnvisibleName", "f_flash_29_1", -1644.439, -0.0001587363, -116.5159, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 152067, "UnvisibleName", "f_flash_29_1", -1386.032, 0.2230071, -403.9285, 0, "Monster");
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 152067, "UnvisibleName", "f_flash_29_1", -1387.651, 0.03979036, -300.905, 0, "Monster");
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 152067, "UnvisibleName", "f_flash_29_1", -1374.113, 0.1024213, -334.6573, 158.75, "Monster");
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 152067, "UnvisibleName", "f_flash_29_1", -1059.138, 0.2467, -450.4502, 0, "Monster");
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		var mob14 = Shortcuts.AddMonster(0, 152067, "UnvisibleName", "f_flash_29_1", -1049.824, 0.2467, -485.6912, 0, "Monster");
		mob14.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob14.AddEffect(new ScriptInvisibleEffect());
		mob14.Layer = character.Layer;
		actors.Add(mob14);

		var mob15 = Shortcuts.AddMonster(0, 152067, "UnvisibleName", "f_flash_29_1", -1026.021, 0.2141352, -512.2792, 0, "Monster");
		mob15.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob15.AddEffect(new ScriptInvisibleEffect());
		mob15.Layer = character.Layer;
		actors.Add(mob15);

		var mob16 = Shortcuts.AddMonster(0, 152067, "UnvisibleName", "f_flash_29_1", -1020.533, 0.1909349, -538.9329, 0, "Monster");
		mob16.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob16.AddEffect(new ScriptInvisibleEffect());
		mob16.Layer = character.Layer;
		actors.Add(mob16);

		var mob17 = Shortcuts.AddMonster(0, 152067, "UnvisibleName", "f_flash_29_1", -1033.899, 0.244914, -438.521, 0, "Monster");
		mob17.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob17.AddEffect(new ScriptInvisibleEffect());
		mob17.Layer = character.Layer;
		actors.Add(mob17);

		var mob18 = Shortcuts.AddMonster(0, 152067, "UnvisibleName", "f_flash_29_1", -1048.412, 0.2376615, -396.9553, 0, "Monster");
		mob18.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob18.AddEffect(new ScriptInvisibleEffect());
		mob18.Layer = character.Layer;
		actors.Add(mob18);

		var mob19 = Shortcuts.AddMonster(0, 57886, "", "f_flash_29_1", -1993.197, -0.0002, -63.10557, 23.33333);
		mob19.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob19.AddEffect(new ScriptInvisibleEffect());
		mob19.Layer = character.Layer;
		actors.Add(mob19);

		var mob20 = Shortcuts.AddMonster(0, 57886, "", "f_flash_29_1", -1972.896, -0.0002, -106.052, 29);
		mob20.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob20.AddEffect(new ScriptInvisibleEffect());
		mob20.Layer = character.Layer;
		actors.Add(mob20);

		var mob21 = Shortcuts.AddMonster(0, 57886, "", "f_flash_29_1", -1966.724, -0.0002, -146.9353, 30.71429);
		mob21.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob21.AddEffect(new ScriptInvisibleEffect());
		mob21.Layer = character.Layer;
		actors.Add(mob21);

		var mob22 = Shortcuts.AddMonster(0, 152053, "UnvisibleName", "f_flash_29_1", -1433.619, -0.0001, -217.279, 0);
		mob22.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob22.AddEffect(new ScriptInvisibleEffect());
		mob22.Layer = character.Layer;
		actors.Add(mob22);

		var mob23 = Shortcuts.AddMonster(0, 152053, "UnvisibleName", "f_flash_29_1", -1311.732, 0.2467, -460.7325, 0);
		mob23.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob23.AddEffect(new ScriptInvisibleEffect());
		mob23.Layer = character.Layer;
		actors.Add(mob23);

		var mob24 = Shortcuts.AddMonster(0, 152054, "UnvisibleName", "f_flash_29_1", -1690.872, -0.0001571797, -127.049, 0);
		mob24.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob24.AddEffect(new ScriptInvisibleEffect());
		mob24.Layer = character.Layer;
		actors.Add(mob24);

		var mob25 = Shortcuts.AddMonster(0, 152054, "UnvisibleName", "f_flash_29_1", -1409.181, 0.2043911, -403.3568, 0);
		mob25.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob25.AddEffect(new ScriptInvisibleEffect());
		mob25.Layer = character.Layer;
		actors.Add(mob25);

		var mob26 = Shortcuts.AddMonster(0, 152054, "UnvisibleName", "f_flash_29_1", -1194.054, 0.2467, -587.8999, 0);
		mob26.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob26.AddEffect(new ScriptInvisibleEffect());
		mob26.Layer = character.Layer;
		actors.Add(mob26);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 6:
				//DRT_SETRENDER(1);
				break;
			case 7:
				//DRT_SETRENDER(1);
				break;
			case 8:
				//DRT_SETRENDER(1);
				break;
			case 11:
				break;
			case 12:
				break;
			case 13:
				break;
			case 14:
				break;
			case 15:
				break;
			case 17:
				break;
			case 25:
				break;
			case 28:
				character.AddonMessage("NOTICE_Dm_!", "The Petrifying Frost has started to blow.{nl}Move to a safe place!", 5);
				//DRT_PLAY_MGAME("FLASH_29_1_SQ_010_MINI");
				break;
			case 29:
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			case 52:
				character.AddonMessage("NOTICE_Dm_!", "The Petrifying Frost has started to blow.{nl}Move to a safe place!", 5);
				//DRT_PLAY_MGAME("FLASH_29_1_SQ_010_MINI");
				break;
			case 53:
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
