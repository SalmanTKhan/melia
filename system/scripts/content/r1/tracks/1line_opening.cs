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

[TrackScript("1line_opening")]
public class onelineopening : TrackScript
{
	protected override void Load()
	{
		SetId("1line_opening");
		//SetMap("opening_zone_1");
		//CenterPos(-1802.19,1108.62,-25.46);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var npc0 = Shortcuts.AddNpc(0, 155091, "", "opening_zone_1", -1877.242, 1423.789, -60.93858, 0);
		npc0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc0.AddEffect(new ScriptInvisibleEffect());
		npc0.Layer = character.Layer;
		actors.Add(npc0);

		var npc1 = Shortcuts.AddNpc(0, 155091, "", "opening_zone_1", -1400.849, 1099.611, 564.5783, 0);
		npc1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc1.AddEffect(new ScriptInvisibleEffect());
		npc1.Layer = character.Layer;
		actors.Add(npc1);

		var npc2 = Shortcuts.AddNpc(0, 155092, "", "opening_zone_1", -1483.941, 1033.602, 706.5407, 0);
		npc2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc2.AddEffect(new ScriptInvisibleEffect());
		npc2.Layer = character.Layer;
		actors.Add(npc2);

		var npc3 = Shortcuts.AddNpc(0, 155092, "", "opening_zone_1", -1427.562, 1026.594, 781.6284, 0);
		npc3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc3.AddEffect(new ScriptInvisibleEffect());
		npc3.Layer = character.Layer;
		actors.Add(npc3);

		var npc4 = Shortcuts.AddNpc(0, 155091, "", "opening_zone_1", -1473.211, 1031.429, 738.8459, 0);
		npc4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc4.AddEffect(new ScriptInvisibleEffect());
		npc4.Layer = character.Layer;
		actors.Add(npc4);

		var npc5 = Shortcuts.AddNpc(0, 155091, "", "opening_zone_1", -1335.328, 1095.611, 709.9069, 0);
		npc5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc5.AddEffect(new ScriptInvisibleEffect());
		npc5.Layer = character.Layer;
		actors.Add(npc5);

		var npc6 = Shortcuts.AddNpc(0, 20025, "", "opening_zone_1", -1551.733, 1069.903, 728.713, 0);
		npc6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc6.AddEffect(new ScriptInvisibleEffect());
		npc6.Layer = character.Layer;
		actors.Add(npc6);

		var npc7 = Shortcuts.AddNpc(0, 20025, "", "opening_zone_1", -1427.168, 1019.239, 756.9363, 0);
		npc7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc7.AddEffect(new ScriptInvisibleEffect());
		npc7.Layer = character.Layer;
		actors.Add(npc7);

		var npc8 = Shortcuts.AddNpc(0, 153121, "", "opening_zone_1", -2340.995, 177.4418, -3640.413, 0);
		npc8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc8.AddEffect(new ScriptInvisibleEffect());
		npc8.Layer = character.Layer;
		actors.Add(npc8);

		var npc9 = Shortcuts.AddNpc(0, 153122, "", "opening_zone_1", -2357.834, 177.4583, -3524.211, 0);
		npc9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc9.AddEffect(new ScriptInvisibleEffect());
		npc9.Layer = character.Layer;
		actors.Add(npc9);

		var npc10 = Shortcuts.AddNpc(0, 153125, "", "opening_zone_1", -2304.273, 177.4034, -3468.292, 0);
		npc10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc10.AddEffect(new ScriptInvisibleEffect());
		npc10.Layer = character.Layer;
		actors.Add(npc10);

		var npc11 = Shortcuts.AddNpc(0, 153126, "", "opening_zone_1", -2203.917, 177.1777, -3541.207, 0);
		npc11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc11.AddEffect(new ScriptInvisibleEffect());
		npc11.Layer = character.Layer;
		actors.Add(npc11);

		var npc12 = Shortcuts.AddNpc(0, 20060, "", "opening_zone_1", -2297.437, 177.3966, -3483.012, 28.125);
		npc12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc12.AddEffect(new ScriptInvisibleEffect());
		npc12.Layer = character.Layer;
		actors.Add(npc12);

		var npc13 = Shortcuts.AddNpc(0, 20060, "", "opening_zone_1", -2367.208, 177.4679, -3537.666, 55);
		npc13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc13.AddEffect(new ScriptInvisibleEffect());
		npc13.Layer = character.Layer;
		actors.Add(npc13);

		var npc14 = Shortcuts.AddNpc(0, 20060, "", "opening_zone_1", -2363.136, 177.4636, -3475.749, 53.18182);
		npc14.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc14.AddEffect(new ScriptInvisibleEffect());
		npc14.Layer = character.Layer;
		actors.Add(npc14);

		var npc15 = Shortcuts.AddNpc(0, 20060, "", "opening_zone_1", -2325.64, 177.4255, -3599.938, 0);
		npc15.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc15.AddEffect(new ScriptInvisibleEffect());
		npc15.Layer = character.Layer;
		actors.Add(npc15);

		var npc16 = Shortcuts.AddNpc(0, 153123, "", "opening_zone_1", -2013.363, 176.6798, -3236.999, 0);
		npc16.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc16.AddEffect(new ScriptInvisibleEffect());
		npc16.Layer = character.Layer;
		actors.Add(npc16);

		var npc17 = Shortcuts.AddNpc(0, 153122, "", "opening_zone_1", -2029.072, 176.6798, -3489.309, 0);
		npc17.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc17.AddEffect(new ScriptInvisibleEffect());
		npc17.Layer = character.Layer;
		actors.Add(npc17);

		var npc18 = Shortcuts.AddNpc(0, 153122, "", "opening_zone_1", -2030.754, 176.6838, -3384.552, 0);
		npc18.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc18.AddEffect(new ScriptInvisibleEffect());
		npc18.Layer = character.Layer;
		actors.Add(npc18);

		var npc19 = Shortcuts.AddNpc(0, 151081, "", "opening_zone_1", -2055.825, 176.7626, -3269.947, 69.70588);
		npc19.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc19.AddEffect(new ScriptInvisibleEffect());
		npc19.Layer = character.Layer;
		actors.Add(npc19);

		var npc20 = Shortcuts.AddNpc(0, 153111, "", "opening_zone_1", -2036.556, 176.7058, -3265.074, 62.22223);
		npc20.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc20.AddEffect(new ScriptInvisibleEffect());
		npc20.Layer = character.Layer;
		actors.Add(npc20);

		var npc21 = Shortcuts.AddNpc(0, 153127, "", "opening_zone_1", 2903.967, 482.2431, 813.9182, 0);
		npc21.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc21.AddEffect(new ScriptInvisibleEffect());
		npc21.Layer = character.Layer;
		actors.Add(npc21);

		var npc22 = Shortcuts.AddNpc(0, 20025, "", "opening_zone_1", 948.3818, 233.7885, -2074.459, 0);
		npc22.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc22.AddEffect(new ScriptInvisibleEffect());
		npc22.Layer = character.Layer;
		actors.Add(npc22);

		var npc23 = Shortcuts.AddNpc(0, 152013, "", "opening_zone_1", 930.6141, 233.7885, -2046.32, 0);
		npc23.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc23.AddEffect(new ScriptInvisibleEffect());
		npc23.Layer = character.Layer;
		actors.Add(npc23);

		var npc24 = Shortcuts.AddNpc(0, 154040, "", "opening_zone_1", 980.736, 233.7885, -2101.827, 0);
		npc24.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc24.AddEffect(new ScriptInvisibleEffect());
		npc24.Layer = character.Layer;
		actors.Add(npc24);

		character.Movement.MoveTo(new Position(2805.733f, 17.94865f, -2152.467f));
		actors.Add(character);

		var npc25 = Shortcuts.AddNpc(0, 20063, "", "opening_zone_1", 2852.545, 482.2431, 825.3535, 35.71429);
		npc25.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc25.AddEffect(new ScriptInvisibleEffect());
		npc25.Layer = character.Layer;
		actors.Add(npc25);

		var npc26 = Shortcuts.AddNpc(0, 20064, "", "opening_zone_1", 2810.292, 482.2431, 837.4166, 45.71429);
		npc26.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc26.AddEffect(new ScriptInvisibleEffect());
		npc26.Layer = character.Layer;
		actors.Add(npc26);

		var npc27 = Shortcuts.AddNpc(0, 20061, "", "opening_zone_1", 2797.582, 487.1063, 818.1893, 47.38095);
		npc27.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc27.AddEffect(new ScriptInvisibleEffect());
		npc27.Layer = character.Layer;
		actors.Add(npc27);

		var npc28 = Shortcuts.AddNpc(0, 20155, "", "opening_zone_1", 2563.333, 578.6465, 832.3403, 54);
		npc28.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc28.AddEffect(new ScriptInvisibleEffect());
		npc28.Layer = character.Layer;
		actors.Add(npc28);

		var npc29 = Shortcuts.AddNpc(0, 20154, "", "opening_zone_1", 2888.798, 482.2431, 834.1485, 0);
		npc29.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc29.AddEffect(new ScriptInvisibleEffect());
		npc29.Layer = character.Layer;
		actors.Add(npc29);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 1:
				break;
			case 33:
				break;
			case 35:
				break;
			case 40:
				//DRT_ACTOR_ATTACH_EFFECT("I_ground009_water", "BOT");
				break;
			case 52:
				//DRT_ACTOR_ATTACH_EFFECT("I_hawk_event001_mash", "BOT");
				break;
			case 54:
				//DRT_ACTOR_ATTACH_EFFECT("I_hawk_event002_mash", "BOT");
				break;
			case 63:
				break;
			case 64:
				break;
			case 66:
				break;
			case 71:
				break;
			case 78:
				break;
			case 89:
				break;
			case 91:
				//DRT_SETRENDER(1);
				break;
			case 94:
				break;
			case 95:
				break;
			case 96:
				//DRT_SETRENDER(1);
				break;
			case 112:
				break;
			case 115:
				break;
			case 116:
				break;
			case 117:
				break;
			case 118:
				break;
			case 137:
				//DRT_ACTOR_ATTACH_EFFECT("F_bg_light001_green", "BOT");
				break;
			case 141:
				//DRT_ACTOR_ATTACH_EFFECT("F_bg_fog001", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_bg_light001_green", "BOT");
				break;
			case 146:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_out033_ground_light", "BOT");
				break;
			case 165:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground051_loop3", "BOT");
				break;
			case 166:
				//DRT_ACTOR_ATTACH_EFFECT("F_light039_yellow", "BOT");
				break;
			case 167:
				break;
			case 195:
				await track.Dialog.Msg("1line_opening_1");
				break;
			case 207:
				break;
			case 208:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_out033_ground_light", "BOT");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
