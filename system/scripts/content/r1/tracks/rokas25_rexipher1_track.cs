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

[TrackScript("ROKAS25_REXIPHER1_TRACK")]
public class ROKAS25REXIPHER1TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ROKAS25_REXIPHER1_TRACK");
		//SetMap("f_rokas_25");
		//CenterPos(-1890.13,511.23,987.48);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 47102, "", "f_rokas_25", -1941, 511, 912, 0);
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
			case 11:
				//DRT_PLAY_MGAME("ROKAS25_REXIPHER1_MINI");
				break;
			case 12:
				Send.ZC_NORMAL.SetupCutscene(character, false, false, true);
				break;
			case 13:
				character.AddonMessage("NOTICE_Dm_!", "As you were trying to unleash the seal, the monsters rushed in!", 3);
				break;
			case 14:
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
