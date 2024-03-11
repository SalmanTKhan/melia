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

[TrackScript("PILGRIM46_SQ_080_TRACK")]
public class PILGRIM46SQ080TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("PILGRIM46_SQ_080_TRACK");
		//SetMap("f_pilgrimroad_46");
		//CenterPos(630.32,121.17,1155.91);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 57296, "", "f_pilgrimroad_46", 935.0209, 121.0563, 1553.427, 74.44444);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 155027, "썩은", "f_pilgrimroad_46", 659.47, 121.17, 1154.19, 90.45454);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		character.Movement.MoveTo(new Position(714.1313f, 121.1726f, 1134.875f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 3:
				character.AddonMessage("NOTICE_Dm_!", "You touched the rotten meat, and a Reaverpede appeared!", 3);
				break;
			case 12:
				//DRT_PLAY_MGAME("PILGRIM46_SQ_080_MINI");
				break;
			case 34:
				//TRACK_SETTENDENCY();
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
