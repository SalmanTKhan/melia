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

[TrackScript("PILGRIM41_3_SQ01_TRACK")]
public class PILGRIM413SQ01TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("PILGRIM41_3_SQ01_TRACK");
		//SetMap("f_pilgrimroad_41_3");
		//CenterPos(-1270.84,62.02,702.37);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-1251.737f, 62.01555f, 691.5477f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 155126, "", "f_pilgrimroad_41_3", -996.3035, 62.01553, 341.1462, 39.16666);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 57921, "", "f_pilgrimroad_41_3", -1017.331, 62.01553, 330.2588, 45.35714);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 57921, "", "f_pilgrimroad_41_3", -961.5956, 62.01553, 313.8426, 46.42857);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 57921, "", "f_pilgrimroad_41_3", -1028.687, 62.01554, 773.8394, 66.42857);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 57924, "", "f_pilgrimroad_41_3", -1005.563, 62.01553, 281.7582, 43.57143);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 57924, "", "f_pilgrimroad_41_3", -952.3233, 62.01554, 770.1776, 64.28571);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 155126, "", "f_pilgrimroad_41_3", -730.64, 62.02, 563.07, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 40120, "", "f_pilgrimroad_41_3", -899.83, 62.02, 515.56, 0);
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
			case 4:
				//DRT_ACTOR_ATTACH_EFFECT("I_emo_exclamation", "TOP");
				break;
			case 10:
				break;
			case 24:
				//DRT_ACTOR_PLAY_EFT("I_emo_exclamation", "TOP", 1);
				//DRT_ACTOR_PLAY_EFT("I_emo_exclamation", "TOP", 1);
				//DRT_ACTOR_PLAY_EFT("I_emo_exclamation", "TOP", 1);
				//DRT_ACTOR_PLAY_EFT("I_emo_exclamation", "TOP", 1);
				//DRT_ACTOR_PLAY_EFT("I_emo_exclamation", "TOP", 1);
				break;
			case 27:
				break;
			case 30:
				Send.ZC_NORMAL.SetupCutscene(character, false, false, true);
				//CREATE_BATTLE_BOX_INLAYER(-120);
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
