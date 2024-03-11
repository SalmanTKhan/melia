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

[TrackScript("F_3CMLAKE_27_3_SQ_7_TRACK1")]
public class F3CMLAKE273SQ7TRACK1 : TrackScript
{
	protected override void Load()
	{
		SetId("F_3CMLAKE_27_3_SQ_7_TRACK1");
		//SetMap("f_3cmlake_27_3");
		//CenterPos(894.77,-28.42,-506.25);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(904.8668f, -27.00928f, -497.9572f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 150179, "", "f_3cmlake_27_3", 878.8221, -29.97475, -732.3794, 28.54167);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 59265, "", "f_3cmlake_27_3", 1098.666, -26.7606, -859.6268, 6.32653);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 13:
				await track.Dialog.Msg("F_3CMLAKE_27_3_TRACK_DLG1");
				break;
			case 42:
				//DRT_ACTOR_PLAY_EFT("F_hit_good", "BOT", 0);
				break;
			case 64:
				//DRT_ACTOR_PLAY_EFT("F_hit_poison_hit_green", "MID", 0);
				break;
			case 82:
				//DRT_ACTOR_PLAY_EFT("F_hit_good", "MID", 0);
				break;
			case 113:
				//DRT_ACTOR_PLAY_EFT("I_emo_exclamation", "MID", 0);
				break;
			case 115:
				//DRT_ACTOR_PLAY_EFT("I_emo_exclamation", "MID", 0);
				break;
			case 132:
				await track.Dialog.Msg("F_3CMLAKE_27_3_TRACK_DLG2");
				break;
			case 169:
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
