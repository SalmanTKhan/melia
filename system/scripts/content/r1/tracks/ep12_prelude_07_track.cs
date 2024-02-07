using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.Scripting;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.Effects;
using Melia.Zone.World.Tracks;
using Yggdrasil.Logging;

[TrackScript("EP12_PRELUDE_07_TRACK")]
public class EP12PRELUDE07TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP12_PRELUDE_07_TRACK");
		//SetMap("f_dcapital_106");
		//CenterPos(1425.21,89.99,501.17);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(1425.21f, 89.99439f, 501.1702f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 154102, "", "f_dcapital_106", 1404, 89, 497, 0);
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
			case 17:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line", "BOT", 0);
				break;
			case 22:
				character.AddonMessage("NOTICE_Dm_Clear", "Take the orb to the place Neringa told you!", 5);
				break;
			case 23:
				//DRT_PLAY_MGAME("EP12_PRELUDE_07_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
