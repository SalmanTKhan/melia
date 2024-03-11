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

[TrackScript("SHADOWMANCER_RAID_TRACK03")]
public class SHADOWMANCERRAIDTRACK03 : TrackScript
{
	protected override void Load()
	{
		SetId("SHADOWMANCER_RAID_TRACK03");
		//SetMap("shadow_raid_main");
		//CenterPos(2621.67,30.24,-1060.43);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 59290, "", "shadow_raid_main", 2515.328, 33.81323, -966.7471, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 153195, "", "shadow_raid_main", 2630.978, 30.24194, -1076.377, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 59272, "", "shadow_raid_main", 2784.344, 28.50928, -1221.781, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 59272, "", "shadow_raid_main", 2236.672, 28.50928, -1248.604, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 59272, "", "shadow_raid_main", 2281.002, 28.50928, -742.1038, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 59272, "", "shadow_raid_main", 2761.48, 28.51, -723.38, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		character.Movement.MoveTo(new Position(2664.303f, 28.50928f, -1105.862f));
		actors.Add(character);

		var mob6 = Shortcuts.AddMonster(0, 154067, "", "shadow_raid_main", 2761.48, 28.51, -723.38, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 154067, "", "shadow_raid_main", 2281, 28.51, -742.1, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 154067, "", "shadow_raid_main", 2236.67, 28.5, -1248.6, 342.5);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 154067, "", "shadow_raid_main", 2784.344, 28.50928, -1221.781, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 40095, "", "shadow_raid_main", 2630.98, 30.24, -1076.38, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 40095, "", "shadow_raid_main", 2515.33, 33.81, -966.75, 0);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 59291, "", "shadow_raid_main", 2515.33, 33.81, -966.75, 0, "Neutral");
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 151018, "", "shadow_raid_main", 2521.363, 33.81323, -966.7628, 0);
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 1:
				//DRT_ACTOR_PLAY_EFT("F_wizard_ShadowPool_cast", "BOT", 0);
				break;
			case 5:
				//DRT_ACTOR_PLAY_EFT("F_wizard_ShadowPool_end", "BOT", 0);
				break;
			case 6:
				//DRT_ACTOR_PLAY_EFT("I_cylinder_003", "MID", 0);
				break;
			case 14:
				//DRT_ACTOR_PLAY_EFT("F_burstup001_violet", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_burstup001_violet", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_burstup001_violet", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_burstup001_violet", "BOT", 0);
				break;
			case 15:
				//DRT_ACTOR_PLAY_EFT("F_burstup001_dark", "BOT", 0);
				break;
			case 16:
				//DisableBornAni();
				break;
			case 17:
				//DRT_ACTOR_PLAY_EFT("F_pose_magical2_light01", "MID", 0);
				break;
			case 25:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup040_blue", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup040_blue", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup040_blue", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup040_blue", "BOT");
				break;
			case 29:
				//DRT_ACTOR_PLAY_EFT("I_cylinder009_light_ice", "TOP", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion078_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_light115_explosion_blue", "TOP", 0);
				//DRT_ACTOR_PLAY_EFT("F_light103_white_line", "TOP", 0);
				//DRT_ACTOR_PLAY_EFT("F_wizard_SummonServant_buff", "MID", 0);
				break;
			case 40:
				break;
			case 41:
				//DRT_ACTOR_PLAY_EFT("F_wizard_ShadowCondensation_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_wizard_ShadowCondensation_dark", "BOT", 0);
				break;
			case 49:
				//DRT_ACTOR_PLAY_EFT("E_pc_darksmoke", "BOT", 0);
				break;
			case 53:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic032_blue_line", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_buff_basic032_blue_line", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_buff_basic032_blue_line", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_buff_basic032_blue_line", "BOT", 0);
				break;
			case 55:
				//DRT_ACTOR_PLAY_EFT("F_burstup001_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_wizard_ShadowThorn_ground_dark2", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_wizard_Mastema_shot_ground_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_wizard_ShadowThorn_ground_dark", "BOT", 0);
				break;
			case 58:
				//DRT_ACTOR_PLAY_EFT("F_wizard_Mastema_shot_ground_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_wizard_ShadowThorn_ground_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_burstup001_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_wizard_ShadowThorn_ground_dark2", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_burstup001_dark", "BOT", 0);
				break;
			case 74:
				//TRACK_BASICLAYER_MOVE();
				character.Tracks.End(this.TrackId);
				character.Tracks.End(this.TrackId);
				character.Tracks.End(this.TrackId);
				character.Tracks.End(this.TrackId);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
