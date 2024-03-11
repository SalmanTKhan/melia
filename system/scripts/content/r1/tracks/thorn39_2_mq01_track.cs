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

[TrackScript("THORN39_2_MQ01_TRACK")]
public class THORN392MQ01TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("THORN39_2_MQ01_TRACK");
		//SetMap("d_thorn_39_2");
		//CenterPos(-1981.71,-235.03,-1424.06);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-1916.331f, -235.0298f, -1086.781f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 41452, "UnVisibleName", "d_thorn_39_2", -1924.217, -235.0298, -1079.219, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 147405, "UnVisibleName", "d_thorn_39_2", -1793.687, -235.0298, -849.5304, 71.66666);
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
			case 5:
				//DRT_ACTOR_ATTACH_EFFECT("I_emo_exclamation", "TOP");
				//DRT_ACTOR_PLAY_EFT("F_spread_in008_green", "BOT", 1);
				break;
			case 12:
				break;
			case 24:
				//DRT_ACTOR_ATTACH_EFFECT("I_emo_exclamation", "TOP");
				break;
			case 37:
				//DRT_ACTOR_PLAY_EFT("F_cleric_ausirine_shot_light", "BOT", 0);
				break;
			case 46:
				await track.Dialog.Msg("THORN39_2_MQ_01_1");
				break;
			case 47:
				await track.Dialog.Msg("THORN39_2_MQ_01_2");
				break;
			case 60:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
