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

[TrackScript("ZACHA5F_MQ_05_AFTER_TRACK")]
public class ZACHA5FMQ05AFTERTRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ZACHA5F_MQ_05_AFTER_TRACK");
		//SetMap("d_zachariel_36");
		//CenterPos(-2712.94,408.60,487.05);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-2711.986f, 408.601f, 488.0027f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 147382, "", "d_zachariel_36", -2693.198, 397.7008, 298.2204, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 2:
				await track.Dialog.Msg("ZACHA5F_MQ_05_01");
				break;
			case 3:
				//DRT_ACTOR_PLAY_EFT("F_smoke019_dark", "BOT", 0);
				break;
			case 11:
				await track.Dialog.Msg("ZACHA5F_MQ_05_02");
				break;
			case 13:
				//DRT_ACTOR_PLAY_EFT("F_smoke019_dark", "BOT", 0);
				break;
			case 17:
				//DRT_ACTOR_PLAY_EFT("F_levitation044_dark_TOP", "BOT", 0);
				break;
			case 24:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
