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

[TrackScript("THORN19_MQ13_TRACK")]
public class THORN19MQ13TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("THORN19_MQ13_TRACK");
		//SetMap("d_thorn_19");
		//CenterPos(2071.98,461.38,1640.87);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 46213, "", "d_thorn_19", 2040, 461, 1670, 0);
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
				//SetFixAnim("ON_G");
				break;
			case 3:
				character.AddonMessage("NOTICE_Dm_!", "While purifying the Magic Crystal, defeat the monsters that are rushing in!", 3);
				break;
			case 12:
				CreateBattleBoxInLayer(character, track);
				break;
			case 14:
				//DRT_PLAY_MGAME("THORN19_MQ13_TRACK");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
