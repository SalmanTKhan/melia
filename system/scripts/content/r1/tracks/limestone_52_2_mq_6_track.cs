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

[TrackScript("LIMESTONE_52_2_MQ_6_TRACK")]
public class LIMESTONE522MQ6TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("LIMESTONE_52_2_MQ_6_TRACK");
		//SetMap("d_limestonecave_52_2");
		//CenterPos(-344.22,-853.60,71.56);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 152056, "UnvisibleName", "d_limestonecave_52_2", -348.2706, -853.5803, 110.3906, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(-344.2268f, -853.5803f, 71.56557f));
		actors.Add(character);

		var mob1 = Shortcuts.AddMonster(0, 57581, "", "d_limestonecave_52_2", -311.839, -853.5803, 103.9481, 305);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 20025, "", "d_limestonecave_52_2", -348.5191, -853.5803, 108.9096, 0);
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
			case 7:
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			case 13:
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_basic023_red_fire", "BOT");
				break;
			case 18:
				//TRACK_SETTENDENCY();
				break;
			case 19:
				//DRT_PLAY_MGAME("LIMESTONE_52_2_MQ_6_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
