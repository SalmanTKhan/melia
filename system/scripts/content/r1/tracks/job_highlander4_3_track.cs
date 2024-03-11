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

[TrackScript("JOB_HIGHLANDER4_3_TRACK")]
public class JOBHIGHLANDER43TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("JOB_HIGHLANDER4_3_TRACK");
		//SetMap("d_cmine_01");
		//CenterPos(1326.92,32.72,-851.65);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 20117, "", "d_cmine_01", 1273.717, 3.59993, 260.7528, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 57156, "", "d_cmine_01", 1344.593, 3.599899, 594.6438, 62.85714);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 2:
				await track.Dialog.Msg("d_cmine_01_dlg_1");
				break;
			case 11:
				await track.Dialog.Msg("d_cmine_01_dlg_2");
				break;
			case 14:
				await track.Dialog.Msg("d_cmine_01_dlg_3");
				break;
			case 17:
				break;
			case 44:
				character.AddonMessage("NOTICE_Dm_!", "Defeat Bearkaras!", 3);
				break;
			case 49:
				//TRACK_SETTENDENCY();
				//CREATE_BATTLE_BOX_INLAYER(0);
				//TRACK_MON_LOOKAT();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
