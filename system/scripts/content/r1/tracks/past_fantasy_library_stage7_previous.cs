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

[TrackScript("PAST_FANTASY_LIBRARY_STAGE7_PREVIOUS")]
public class PASTFANTASYLIBRARYSTAGE7PREVIOUS : TrackScript
{
	protected override void Load()
	{
		SetId("PAST_FANTASY_LIBRARY_STAGE7_PREVIOUS");
		//SetMap("mission_fantasylibrary_1");
		//CenterPos(-200.72,37.25,734.28);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-198.9948f, 37.72691f, 732.7977f));
		actors.Add(character);

		var npc0 = Shortcuts.AddNpc(0, 58567, "", "mission_fantasylibrary_1", -582.4919, 14.4972, 682.5551, 0);
		npc0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc0.AddEffect(new ScriptInvisibleEffect());
		npc0.Layer = character.Layer;
		actors.Add(npc0);

		var mob0 = Shortcuts.AddMonster(0, 58585, "", "mission_fantasylibrary_1", -1024.903, 13.91987, 466.4917, 0, "Neutral");
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
			case 17:
				break;
			case 56:
				break;
			case 60:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground071_fire", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_fantasylibrary_brickfloor_dead", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke126", "BOT");
				break;
			case 65:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground064_fire", "BOT");
				break;
			case 74:
				//DRT_RUN_FUNCTION("SCR_STAGE7_PREVIOUS_DIRECTION_END");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
