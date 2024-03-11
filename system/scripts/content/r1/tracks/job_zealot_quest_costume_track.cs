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

[TrackScript("JOB_ZEALOT_QUEST_COSTUME_TRACK")]
public class JOBZEALOTQUESTCOSTUMETRACK : TrackScript
{
	protected override void Load()
	{
		SetId("JOB_ZEALOT_QUEST_COSTUME_TRACK");
		//SetMap("None");
		//CenterPos(-1810.83,-121.64,55.28);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-1922.438f, -121.6434f, 121.3255f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 155051, "", "None", -1942.8, -121.64, 123.29, 0);
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
			case 9:
				//CREATE_BATTLE_BOX_INLAYER(0);
				character.AddonMessage("NOTICE_Dm_scroll", "We've arrived where Zealot Master told us to go. Use the Zealot Crystal Necklace.", 5);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
