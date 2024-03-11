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

[TrackScript("GR_boss_SWORDBALISTA")]
public class GRbossSWORDBALISTA : TrackScript
{
	protected override void Load()
	{
		SetId("GR_boss_SWORDBALISTA");
		//SetMap("f_rokas_28");
		//CenterPos(1527.91,1159.90,2079.34);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 740017, "", "f_rokas_28", 1601.461, 1160.444, 2119.459, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 20024, "", "f_rokas_28", 1070.594, 1038.58, 2358.097, 122);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 20024, "", "f_rokas_28", 1601.46, 1160.44, 2119.46, 16);
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
			case 9:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke056", "TOP");
				break;
			case 10:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke056", "TOP");
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup020_smoke", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke117", "BOT");
				break;
			case 16:
				//DRT_ACTOR_ATTACH_EFFECT("F_spin007_3", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_spin037", "BOT");
				break;
			case 19:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke056", "TOP");
				//DRT_ACTOR_ATTACH_EFFECT("F_spin037", "BOT");
				break;
			case 24:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke056", "BOT");
				break;
			case 25:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke056", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_spin037", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_spin037", "BOT");
				break;
			case 29:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke090", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion042_smoke_TOP", "MID");
				break;
			case 30:
				//DRT_ACTOR_ATTACH_EFFECT("F_spin011", "MID");
				break;
			case 31:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke038", "BOT");
				break;
			case 35:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup003_1", "BOT");
				break;
			case 40:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground083_smoke", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke003", "BOT");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
