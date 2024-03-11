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

[TrackScript("PRISON_82_MQ_1_TRACK")]
public class PRISON82MQ1TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("PRISON_82_MQ_1_TRACK");
		//SetMap("d_prison_82");
		//CenterPos(-1205.21,561.59,-101.42);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 151107, "", "d_prison_82", -1152, 559.5569, -70, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(-1142.41f, 559.5572f, -95.18836f));
		actors.Add(character);

		var mob1 = Shortcuts.AddMonster(0, 58412, "", "d_prison_82", -1632.189, 494.365, -150.2164, 0);
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
			case 12:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_out003_darkblue", "MID");
				break;
			case 35:
				//DRT_ACTOR_PLAY_EFT("F_ground086_violet", "BOT", 0);
				break;
			case 45:
				await track.Dialog.Msg("PRISON_82_MQ_1_TRACK_dlg1");
				break;
			case 50:
				//DRT_ACTOR_PLAY_EFT("F_pc_warp_light", "TOP", 0);
				//DRT_ACTOR_PLAY_EFT("F_pc_warp_circle", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_pc_warp_circle", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_pc_warp_light", "TOP", 0);
				break;
			case 64:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
