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

[TrackScript("PILGRIM41_3_SQ08_TRACK")]
public class PILGRIM413SQ08TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("PILGRIM41_3_SQ08_TRACK");
		//SetMap("f_pilgrimroad_41_3");
		//CenterPos(1049.90,45.04,1058.43);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(1066.596f, 45.03738f, 1024.206f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 155126, "", "f_pilgrimroad_41_3", 988.65, 45.04, 1036.45, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 155044, "", "f_pilgrimroad_41_3", 919.921, 52.27792, 773.3334, 70.55556);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 155045, "", "f_pilgrimroad_41_3", 938.3297, 52.27791, 693.8635, 60.38462);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 155046, "", "f_pilgrimroad_41_3", 989.9574, 52.27792, 717.3199, 67.27273);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 11284, "", "f_pilgrimroad_41_3", 955.3979, 52.27792, 770.4385, 36.66667);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 58430, "Riteris", "f_pilgrimroad_41_3", 983.8, 52.28, 899.99, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.Level = 270;
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 155126, "", "f_pilgrimroad_41_3", 947.8743, 52.27792, 1360.344, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 20026, "", "f_pilgrimroad_41_3", 989.4254, 52.27792, 902.0302, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 20026, "", "f_pilgrimroad_41_3", 991.0081, 52.27792, 938.1769, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 20026, "", "f_pilgrimroad_41_3", 986.0264, 45.03738, 1032.952, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 4:
				//DRT_ACTOR_ATTACH_EFFECT("I_emo_exclamation", "TOP");
				break;
			case 47:
				break;
			case 67:
				await track.Dialog.Msg("PILGRIM413_SQ_08_track1");
				break;
			case 69:
				await track.Dialog.Msg("PILGRIM413_SQ_08_track2");
				break;
			case 73:
				//DRT_ACTOR_PLAY_EFT("F_pattern016_mirror_light", "TOP", 0);
				break;
			case 77:
				//DRT_ACTOR_PLAY_EFT("F_light059_2", "BOT", 0);
				break;
			case 78:
				//DRT_ACTOR_PLAY_EFT("F_light059_2", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke011_red_white", "BOT");
				break;
			case 84:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke011_red_white", "BOT");
				break;
			case 89:
				//DRT_ACTOR_PLAY_EFT("I_emo_exclamation", "TOP", 1);
				//DRT_ACTOR_PLAY_EFT("I_emo_exclamation", "TOP", 1);
				//DRT_ACTOR_PLAY_EFT("I_emo_exclamation", "TOP", 1);
				break;
			case 115:
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion042_smoke", "BOT");
				break;
			case 116:
				//DRT_ACTOR_PLAY_EFT("F_buff_Cleric_Bless_Buff", "MID", 1);
				//DRT_RUN_FUNCTION("SCR_PILGRIM413_SQ_08_RECOVERY");
				break;
			case 131:
				Send.ZC_NORMAL.SetupCutscene(character, false, false, true);
				//CREATE_BATTLE_BOX_INLAYER(-100);
				//TRACK_SETTENDENCY();
				break;
			case 140:
				//DRT_SETHOOKMSGOWNER(1, 1);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
