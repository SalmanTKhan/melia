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

[TrackScript("FARM47_3_SQ_080_TRACK")]
public class FARM473SQ080TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("FARM47_3_SQ_080_TRACK");
		//SetMap("None");
		//CenterPos(-1264.47,43.12,464.67);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var npc0 = Shortcuts.AddNpc(0, 153047, "UnvisibleName", "None", -1212.42, 43.12, 491.6, 0);
		npc0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc0.AddEffect(new ScriptInvisibleEffect());
		npc0.Layer = character.Layer;
		actors.Add(npc0);

		character.Movement.MoveTo(new Position(-1170.017f, 43.1216f, 496.2354f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 2:
				//DRT_PLAY_MGAME("FARM47_3_SQ_080_MINI");
				character.AddonMessage("NOTICE_Dm_!", "The monsters seem to have smelled the purifying liquid. They are attacking!", 5);
				break;
			case 4:
				//CREATE_BATTLE_BOX_INLAYER(0);
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
