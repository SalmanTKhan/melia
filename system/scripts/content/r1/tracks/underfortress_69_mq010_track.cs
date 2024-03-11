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

[TrackScript("UNDERFORTRESS_69_MQ010_TRACK")]
public class UNDERFORTRESS69MQ010TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("UNDERFORTRESS_69_MQ010_TRACK");
		//SetMap("d_underfortress_69");
		//CenterPos(2131.53,566.03,-21.17);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 153040, "", "d_underfortress_69", 2101.223, 566.8198, 34.96815, 70.625);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(2192.388f, 566.3848f, 16.01715f));
		actors.Add(character);

		var mob1 = Shortcuts.AddMonster(0, 153139, "", "d_underfortress_69", 1768.252, 582.4187, -90.75654, 19.75);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 57018, "", "d_underfortress_69", 1781.922, 551.8799, -150.2328, 29.18919);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 26:
				//DisableBornAni();
				break;
			case 32:
				//DRT_ACTOR_PLAY_EFT("F_smoke120_dark", "BOT", 0);
				break;
			case 49:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
