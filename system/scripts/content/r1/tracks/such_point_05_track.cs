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

[TrackScript("SUCH_POINT_05_TRACK")]
public class SUCHPOINT05TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("SUCH_POINT_05_TRACK");
		//SetMap("f_katyn_7");
		//CenterPos(-1121.74,418.98,-2304.47);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 103003, "", "f_katyn_7", -1142.981, 418.8653, -2465.563, 38.63636);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var npc0 = Shortcuts.AddNpc(0, 46011, "", "f_katyn_7", -1066, 419, -2319, 1);
		npc0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc0.AddEffect(new ScriptInvisibleEffect());
		npc0.Layer = character.Layer;
		actors.Add(npc0);

		character.Movement.MoveTo(new Position(-1067.142f, 419.0639f, -2299.545f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 14:
				break;
			case 34:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup001_smoke1", "BOT");
				break;
			case 35:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground004_yellow", "BOT");
				break;
			case 39:
				CreateBattleBoxInLayer(character, track);
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
