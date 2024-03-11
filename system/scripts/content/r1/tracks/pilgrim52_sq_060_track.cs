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

[TrackScript("PILGRIM52_SQ_060_TRACK")]
public class PILGRIM52SQ060TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("PILGRIM52_SQ_060_TRACK");
		//SetMap("f_pilgrimroad_52");
		//CenterPos(-1245.84,156.58,-113.34);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 147417, "Tombstone", "f_pilgrimroad_52", -1309.266, 156.583, -62.16837, 0);
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
			case 4:
				//DRT_PLAY_MGAME("PILGRIM52_SQ_060_MINI");
				break;
			case 7:
				character.AddonMessage("NOTICE_Dm_!", "You've found a small portrait!{nl}Defeat the monsters that are rushing in and get out from there!", 3);
				break;
			case 9:
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
