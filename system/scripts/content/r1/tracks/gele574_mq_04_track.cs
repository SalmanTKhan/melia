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

[TrackScript("GELE574_MQ_04_TRACK")]
public class GELE574MQ04TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("GELE574_MQ_04_TRACK");
		//SetMap("f_gele_57_4");
		//CenterPos(2287.69,102.65,-772.75);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 57015, "", "f_gele_57_4", 2314.189, 102.6496, -722.3721, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(2295.411f, 102.6496f, -771.7048f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 5:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_out022_fire", "BOT");
				break;
			case 6:
				//DRT_ACTOR_ATTACH_EFFECT("F_pc_standthrow_fire", "BOT");
				break;
			case 11:
				//DRT_ACTOR_ATTACH_EFFECT("F_pc_standthrow_fire", "BOT");
				break;
			case 34:
				//DRT_ACTOR_PLAY_EFT("E_warrior_whirlwind_shot", "BOT", 0);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
