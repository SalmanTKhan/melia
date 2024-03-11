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

[TrackScript("FLASH_58_SQ_040_TRACK")]
public class FLASH58SQ040TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("FLASH_58_SQ_040_TRACK");
		//SetMap("f_flash_58");
		//CenterPos(-133.32,407.19,-1506.31);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-166.1225f, 407.1871f, -1490.604f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 152056, "UnvisibleName", "f_flash_58", -100.3, 407.19, -1454.95, 0);
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
				//DRT_PLAY_MGAME("FLASH_58_SQ_040_MINI");
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
