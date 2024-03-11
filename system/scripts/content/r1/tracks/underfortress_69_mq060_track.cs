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

[TrackScript("UNDERFORTRESS_69_MQ060_TRACK")]
public class UNDERFORTRESS69MQ060TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("UNDERFORTRESS_69_MQ060_TRACK");
		//SetMap("d_underfortress_69");
		//CenterPos(-2390.06,751.50,45.05);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 47234, "", "d_underfortress_69", -2493.007, 753.7352, 45.84358, 135);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 153062, "", "d_underfortress_69", -2470.162, 753.7352, 45.23372, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		character.Movement.MoveTo(new Position(-2350.332f, 753.7352f, 42.20002f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 35:
				break;
			case 59:
				await track.Dialog.Msg("UNDER_69_MQ060_TRACK01");
				break;
			case 65:
				//DRT_PLAY_FORCE(0, 1, 2, "I_spread_out001_light", "arrow_cast", "F_cleric_ausirine_shot_light", "skl_holylight", "SLOW", 80, 1, 200, 1, 50, 0);
				break;
			case 74:
				//DRT_ACTOR_PLAY_EFT("F_cleric_ausirine_shot_light", "BOT", 0);
				break;
			case 78:
				//DRT_FUNC_ACT("SSN_UNDERFORTRESS_69_MQ060_AFTER");
				break;
			case 79:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
