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

[TrackScript("ROKAS26_QUEST04_TRACK")]
public class ROKAS26QUEST04TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ROKAS26_QUEST04_TRACK");
		//SetMap("f_rokas_26");
		//CenterPos(-1220.94,2168.34,1351.02);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 47106, "Stone Pillar", "f_rokas_26", -1360.014, 2168.34, 1180.319, 0);
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
			case 1:
				//DRT_ACTOR_PLAY_EFT("F_wizard_enchantfire_shot_ground", "BOT", 0);
				break;
			case 2:
				//DRT_PLAY_MGAME("ROKAS26_QUEST04_MINI");
				character.AddonMessage("NOTICE_Dm_!", "As you touched on the stone pillar, the monsters nearby rushed in!", 3);
				break;
			case 7:
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
