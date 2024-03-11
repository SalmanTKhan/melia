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

[TrackScript("VPRISON514_MQ_05_AFTER")]
public class VPRISON514MQ05AFTER : TrackScript
{
	protected override void Load()
	{
		SetId("VPRISON514_MQ_05_AFTER");
		//SetMap("d_velniasprison_51_4");
		//CenterPos(-2538.16,415.42,759.60);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 57840, "", "d_velniasprison_51_4", -2470.979, 408.6438, 833.2174, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(-2539.691f, 415.4192f, 758.0646f));
		actors.Add(character);

		var mob1 = Shortcuts.AddMonster(0, 57581, "", "d_velniasprison_51_4", -2558.092, 415.4193, 726.6635, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 20024, "", "d_velniasprison_51_4", -2470.98, 408.64, 833.22, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 20024, "", "d_velniasprison_51_4", -2531.146, 410.3586, 770.7399, 30);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 7:
				//DRT_ACTOR_ATTACH_EFFECT("I_sys_caution_UI", "TOP");
				break;
			case 8:
				//DRT_ACTOR_PLAY_EFT("F_burstup025_dark", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation015_dark", "BOT");
				break;
			case 10:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke019_dark_loop", "MID");
				break;
			case 12:
				//DRT_ACTOR_ATTACH_EFFECT("F_rize004_dark", "BOT");
				break;
			case 13:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke005_dark", "BOT");
				break;
			case 15:
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation020_dark", "MID");
				break;
			case 32:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground009", "BOT");
				//DRT_ACTOR_PLAY_EFT("F_explosion078_dark", "BOT", 0);
				break;
			case 36:
				await track.Dialog.Msg("VPRISON514_MQ_05_AFTER_01");
				break;
			case 38:
				//DRT_ACTOR_ATTACH_EFFECT("F_light055_black", "TOP");
				break;
			case 41:
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion098_dark_blue", "MID");
				break;
			case 53:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_out004_dark", "MID");
				break;
			case 64:
				//TRACK_BASICLAYER_MOVE();
				character.AddonMessage("NOTICE_Dm_Clear", "Tell Goddess Vakarine about Hauberk's escape!", 5);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
