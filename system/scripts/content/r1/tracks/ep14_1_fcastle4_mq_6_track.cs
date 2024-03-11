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

[TrackScript("EP14_1_FCASTLE4_MQ_6_TRACK")]
public class EP141FCASTLE4MQ6TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP14_1_FCASTLE4_MQ_6_TRACK");
		//SetMap("ep14_1_f_castle_4");
		//CenterPos(259.02,24.50,561.72);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(258.9771f, 24.64005f, 561.3359f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 157116, "", "ep14_1_f_castle_4", 258.7879, 15.80441, 586.9322, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 150288, "", "ep14_1_f_castle_4", 263.1472, 16.42422, 583.6097, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", 260.2168, 58.83531, -442.7585, 67.5);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", 26.87448, 58.83531, -598.7703, 92.72727);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", 108.5621, 58.83531, -498.4072, 45.83333);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", -22.13983, 58.83531, -428.6796, 32.72727);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", -94.54747, 58.83531, -368.8116, 55);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", -110.8931, 58.83531, -546.3092, 93.18182);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", -130.0612, 58.83531, -110.4465, 33.33333);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", -174.7048, 58.83531, -252.2832, 44.16666);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", 443.1013, 58.83531, -438.3738, 34.16666);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", -7.168671, 58.83531, -517.7698, 49.16666);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", -286.7329, 58.83531, -198.7819, 81.66666);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", -307.0822, 58.83531, -72.98683, 75);
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		var mob14 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", 470.1471, 58.83531, -392.0331, 41.66666);
		mob14.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob14.AddEffect(new ScriptInvisibleEffect());
		mob14.Layer = character.Layer;
		actors.Add(mob14);

		var mob15 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", 337.4671, 58.83531, -467.515, 52.5);
		mob15.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob15.AddEffect(new ScriptInvisibleEffect());
		mob15.Layer = character.Layer;
		actors.Add(mob15);

		var mob16 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", -232.5099, 58.83531, -130.1048, 49.16666);
		mob16.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob16.AddEffect(new ScriptInvisibleEffect());
		mob16.Layer = character.Layer;
		actors.Add(mob16);

		var mob17 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", 692.4243, -29.19576, 822.503, 13.52941);
		mob17.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob17.AddEffect(new ScriptInvisibleEffect());
		mob17.Layer = character.Layer;
		actors.Add(mob17);

		var mob18 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", -66.45214, -29.19577, 1042.773, 40);
		mob18.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob18.AddEffect(new ScriptInvisibleEffect());
		mob18.Layer = character.Layer;
		actors.Add(mob18);

		var mob19 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", 591.6086, -29.19576, 1114.53, 41.17647);
		mob19.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob19.AddEffect(new ScriptInvisibleEffect());
		mob19.Layer = character.Layer;
		actors.Add(mob19);

		var mob20 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", 741.8498, -29.19576, 957.2384, 22.05882);
		mob20.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob20.AddEffect(new ScriptInvisibleEffect());
		mob20.Layer = character.Layer;
		actors.Add(mob20);

		var mob21 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", 781.9271, -29.19576, 876.9073, 16.47059);
		mob21.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob21.AddEffect(new ScriptInvisibleEffect());
		mob21.Layer = character.Layer;
		actors.Add(mob21);

		var mob22 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", 819.0419, -29.19576, 1116.849, 35.58823);
		mob22.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob22.AddEffect(new ScriptInvisibleEffect());
		mob22.Layer = character.Layer;
		actors.Add(mob22);

		var mob23 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", -16.63298, -29.19576, 1112.493, 35);
		mob23.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob23.AddEffect(new ScriptInvisibleEffect());
		mob23.Layer = character.Layer;
		actors.Add(mob23);

		var mob24 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", 603.0233, -29.19576, 922.5802, 16.17647);
		mob24.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob24.AddEffect(new ScriptInvisibleEffect());
		mob24.Layer = character.Layer;
		actors.Add(mob24);

		var mob25 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", -51.76346, -29.19577, 968.6918, 25.58823);
		mob25.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob25.AddEffect(new ScriptInvisibleEffect());
		mob25.Layer = character.Layer;
		actors.Add(mob25);

		var mob26 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", 136.8326, -29.19576, 1277.129, 61.17647);
		mob26.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob26.AddEffect(new ScriptInvisibleEffect());
		mob26.Layer = character.Layer;
		actors.Add(mob26);

		var mob27 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", 673.7533, -29.19576, 1065.311, 26.76471);
		mob27.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob27.AddEffect(new ScriptInvisibleEffect());
		mob27.Layer = character.Layer;
		actors.Add(mob27);

		var mob28 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", 839.6514, -29.19576, 919.1021, 17.64706);
		mob28.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob28.AddEffect(new ScriptInvisibleEffect());
		mob28.Layer = character.Layer;
		actors.Add(mob28);

		var mob29 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", 603.5308, -29.19576, 1268.537, 37.94117);
		mob29.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob29.AddEffect(new ScriptInvisibleEffect());
		mob29.Layer = character.Layer;
		actors.Add(mob29);

		var mob30 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", 97.85449, -29.19576, 1174.463, 40.58823);
		mob30.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob30.AddEffect(new ScriptInvisibleEffect());
		mob30.Layer = character.Layer;
		actors.Add(mob30);

		var mob31 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", 120.2219, -29.19576, 1076.639, 30.58823);
		mob31.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob31.AddEffect(new ScriptInvisibleEffect());
		mob31.Layer = character.Layer;
		actors.Add(mob31);

		var mob32 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", -74.55415, -29.19576, 1192.985, 43.23529);
		mob32.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob32.AddEffect(new ScriptInvisibleEffect());
		mob32.Layer = character.Layer;
		actors.Add(mob32);

		var mob33 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", 558.9888, -29.19576, 1262.732, 40.88235);
		mob33.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob33.AddEffect(new ScriptInvisibleEffect());
		mob33.Layer = character.Layer;
		actors.Add(mob33);

		var mob34 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", -50.22873, -29.19576, 1274.644, 69.41177);
		mob34.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob34.AddEffect(new ScriptInvisibleEffect());
		mob34.Layer = character.Layer;
		actors.Add(mob34);

		var mob35 = Shortcuts.AddMonster(0, 59702, "", "ep14_1_f_castle_4", -174.1904, -26.77088, 1093.67, 42.05882);
		mob35.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob35.AddEffect(new ScriptInvisibleEffect());
		mob35.Layer = character.Layer;
		actors.Add(mob35);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 27:
				//TRACK_MON_LOOKAT();
				break;
			case 31:
				//DRT_RUN_FUNCTION("SCR_EP14_1_FCASTLE4_MQ_6_TRACK_SCRIPT_1");
				break;
			case 32:
				//TRACK_MON_LOOKAT();
				break;
			case 33:
				//DRT_FUNC_ACT("SCR_EP14_1_FCASTLE4_MQ_6_TRACK_MON_BUFF");
				break;
			case 39:
				//DRT_ACTOR_PLAY_EFT("F_smoke186_dark", "BOT", 0);
				break;
			case 40:
				//DRT_JUMP_TO_POS(0.2, 200);
				//DRT_ACTOR_PLAY_EFT("F_smoke186_dark", "MID", 0);
				break;
			case 41:
				//DRT_ACTOR_PLAY_EFT("F_smoke186_dark", "TOP", 0);
				break;
			case 42:
				//DRT_ACTOR_ATTACH_EFFECT("F_circle032_dark_loop", "BOT");
				break;
			case 45:
				//DRT_ACTOR_PLAY_EFT("I_smoke035_dark", "MID", 0);
				break;
			case 67:
				await track.Dialog.Msg("EP14_1_FCASTLE4_MQ_6_TRACK_DLG1");
				break;
			case 71:
				//DRT_RUN_FUNCTION("SCR_EP14_1_FCASTLE4_MQ_6_TRACK_SCRIPT_3");
				break;
			case 72:
				//DRT_ACTOR_PLAY_EFT("F_smoke186_dark", "BOT", 0);
				break;
			case 73:
				//DRT_ACTOR_PLAY_EFT("F_smoke186_dark", "MID", 0);
				break;
			case 74:
				//DRT_ACTOR_PLAY_EFT("F_smoke186_dark", "TOP", 0);
				break;
			case 76:
				//DRT_FUNC_ACT("SCR_EP14_1_FCASTLE4_MQ_6_TRACK_SCRIPT_2");
				break;
			case 94:
				//TRACK_BASICLAYER_MOVE();
				//DRT_RUN_FUNCTION("SCR_EP14_1_FCASTLE4_MQ_6_CLEARDAYLIGHY");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
