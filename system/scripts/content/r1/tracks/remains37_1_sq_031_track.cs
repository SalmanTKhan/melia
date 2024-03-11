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

[TrackScript("REMAINS37_1_SQ_031_TRACK")]
public class REMAINS371SQ031TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("REMAINS37_1_SQ_031_TRACK");
		//SetMap("f_remains_37_1");
		//CenterPos(-449.93,276.08,-365.07);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var npc0 = Shortcuts.AddNpc(0, 152030, "UnvisibleName", "f_remains_37_1", -474.23, 276.08, -406.61, 1);
		npc0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc0.AddEffect(new ScriptInvisibleEffect());
		npc0.Layer = character.Layer;
		actors.Add(npc0);

		var mob0 = Shortcuts.AddMonster(0, 155037, "", "f_remains_37_1", -469.88, 276.08, -380.42, 1);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(-447.5416f, 276.0817f, -360.0952f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 5:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke100_white", "BOT");
				break;
			case 7:
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation013_smoke", "BOT");
				break;
			case 10:
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation013_smoke", "BOT");
				break;
			case 13:
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation013_smoke", "BOT");
				break;
			case 16:
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation013_smoke", "BOT");
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
