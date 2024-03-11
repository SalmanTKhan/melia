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

[TrackScript("SIAULIAI_46_2_MQ_04_TRACK")]
public class SIAULIAI462MQ04TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("SIAULIAI_46_2_MQ_04_TRACK");
		//SetMap("None");
		//CenterPos(1042.55,-73.23,4788.78);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 147414, "Seal Tower", "None", 1079, -73, 4705, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 151041, "", "None", 1070, -73, 4905, 0);
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
			case 1:
				//DRT_ACTOR_PLAY_EFT("F_explosion027_blue", "BOT", 0);
				break;
			case 15:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line", "BOT", 0);
				//SetFixAnim("astd");
				break;
			case 16:
				//DRT_ACTOR_PLAY_EFT("F_light018_yellow", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_light003_yellow", "MID", 0);
				break;
			case 29:
				//TRACK_BASICLAYER_MOVE();
				character.AddonMessage("NOTICE_Dm_Clear", "Goddess Austeja has appeared.{nl}Talk to Goddess Austeja.", 3);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
