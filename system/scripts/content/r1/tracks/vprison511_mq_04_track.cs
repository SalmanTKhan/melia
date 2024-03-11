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

[TrackScript("VPRISON511_MQ_04_TRACK")]
public class VPRISON511MQ04TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("VPRISON511_MQ_04_TRACK");
		//SetMap("d_velniasprison_51_1");
		//CenterPos(-1773.42,346.41,472.87);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 41327, "", "d_velniasprison_51_1", -1831.107, 351.3505, 510.367, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(-1791.079f, 351.3505f, 510.8273f));
		actors.Add(character);

		var mob1 = Shortcuts.AddMonster(0, 57840, "", "d_velniasprison_51_1", -1888.739, 351.3505, 498.8466, 0);
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
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke005_dark", "BOT");
				break;
			case 2:
				//DRT_ACTOR_ATTACH_EFFECT("F_pattern008_violet_loop", "BOT");
				break;
			case 3:
				//SetFixAnim("ON_P");
				break;
			case 6:
				//DRT_ACTOR_ATTACH_EFFECT("F_cleric_AustrasKoks_shot_light", "BOT");
				//DRT_PLAY_FORCE(0, 1, 2, "I_force042_violet", "arrow_cast", "E_pc_full_charge_violet_ride", "arrow_blow", "SLOW", 50, 1, 0, 5, 10, 0);
				break;
			case 18:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force042_violet", "arrow_cast", "E_pc_full_charge_violet_ride", "arrow_blow", "SLOW", 50, 1, 0, 5, 10, 0);
				//DRT_ACTOR_ATTACH_EFFECT("F_cleric_AustrasKoks_shot_light", "BOT");
				break;
			case 19:
				character.AddonMessage("NOTICE_Dm_!", "Protect Hauberk while he absorbs power of the altar!", 3);
				break;
			case 24:
				//DRT_PLAY_MGAME("VPRISON511_MQ_04_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
