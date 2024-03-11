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

[TrackScript("ROKAS24_QB_5_NEW_TRACK")]
public class ROKAS24QB5NEWTRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ROKAS24_QB_5_NEW_TRACK");
		//SetMap("None");
		//CenterPos(-1017.36,782.87,-3331.61);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 147425, "", "None", -985, 782, -3362, 0);
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
				await track.Dialog.Msg("ROKAS24_QB_5_Q");
				break;
			case 3:
				character.AddonMessage("NOTICE_Dm_!", "Protect Archivist Jonas from the monsters until his headache is gone!", 5);
				break;
			case 4:
				//TRACK_SETTENDENCY();
				//DRT_PLAY_MGAME("ROKAS24_QB_5_MINI");
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
