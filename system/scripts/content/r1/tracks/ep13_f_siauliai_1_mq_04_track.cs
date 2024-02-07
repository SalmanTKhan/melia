using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.Scripting;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.Effects;
using Melia.Zone.World.Tracks;
using Yggdrasil.Logging;

[TrackScript("EP13_F_SIAULIAI_1_MQ_04_TRACK")]
public class EP13FSIAULIAI1MQ04TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP13_F_SIAULIAI_1_MQ_04_TRACK");
		//SetMap("ep13_f_siauliai_1");
		//CenterPos(166.61,79.77,1219.46);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(204.265f, 79.7736f, 946.1735f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 59578, "", "ep13_f_siauliai_1", 64.74303, 79.7736, 1236.192, 81.15385);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 59577, "", "ep13_f_siauliai_1", 230.9398, 79.7736, 1304.428, 98.57143);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 59577, "", "ep13_f_siauliai_1", 98.78304, 79.7736, 1275.466, 102.5);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 59578, "", "ep13_f_siauliai_1", 208.5766, 79.7736, 1257.254, 82.69231);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 59577, "", "ep13_f_siauliai_1", 152.6689, 79.7736, 1281.667, 68.66666);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 59577, "", "ep13_f_siauliai_1", 122.1596, 79.7736, 1231.817, 87.72727);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 150242, "", "ep13_f_siauliai_1", 196.2018, 79.7736, 925.6906, 1);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 151019, "UnvisibleName", "ep13_f_siauliai_1", 195.6957, 79.7736, 924.0571, 55);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 18:
				//DRT_ACTOR_PLAY_EFT("I_smoke062_fire_yellow", "TOP", 0);
				//DRT_ACTOR_PLAY_EFT("F_burstup057_yellow", "BOT", 0);
				break;
			case 19:
				//DRT_ACTOR_PLAY_EFT("F_light033_circle", "MID", 0);
				break;
			case 21:
				break;
			case 22:
				break;
			case 23:
				break;
			case 31:
				//DRT_ACTOR_PLAY_EFT("F_rize015_1_yellow_drop", "BOT", 0);
				break;
			case 32:
				//DRT_ACTOR_PLAY_EFT("F_rize015_1_yellow_drop", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_rize015_1_yellow_drop", "BOT", 0);
				break;
			case 33:
				//DRT_ACTOR_PLAY_EFT("F_rize015_1_yellow_drop", "BOT", 0);
				break;
			case 34:
				//DRT_ACTOR_PLAY_EFT("F_rize015_1_yellow_drop", "BOT", 0);
				break;
			case 35:
				//DRT_ACTOR_PLAY_EFT("F_rize015_1_yellow_drop", "BOT", 0);
				break;
			case 37:
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation005_yellow2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation005_yellow2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation005_yellow2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation005_yellow2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation005_yellow2", "BOT");
				break;
			case 45:
				await track.Dialog.Msg("EP13_F_SIAULIAI_1_MQ_04_DLG_T1");
				break;
			case 49:
				CreateBattleBoxInLayer(character, track);
				//DRT_PLAY_MGAME("EP13_F_SIAULIAI_1_MQ_04_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
