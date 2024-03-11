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

[TrackScript("EP16_1_ROKAS_36_1_MQ9_TRACK2")]
public class EP161ROKAS361MQ9TRACK2 : TrackScript
{
	protected override void Load()
	{
		SetId("EP16_1_ROKAS_36_1_MQ9_TRACK2");
		//SetMap("f_rokas_36_1");
		//CenterPos(809.54,7.65,744.49);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 59830, "", "f_rokas_36_1", 787.361, 7.654289, 807.5618, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(832.4242f, 7.654289f, 709.2123f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 10:
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion093_dark", "BOT");
				break;
			case 11:
				//DRT_RUN_FUNCTION("SCR_EP16_1_ROKAS_36_1_MQ9_PC_KNOCK_DOWN");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
