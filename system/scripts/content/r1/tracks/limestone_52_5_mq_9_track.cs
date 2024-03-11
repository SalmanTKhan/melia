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

[TrackScript("LIMESTONE_52_5_MQ_9_TRACK")]
public class LIMESTONE525MQ9TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("LIMESTONE_52_5_MQ_9_TRACK");
		//SetMap("d_limestonecave_52_5");
		//CenterPos(1312.47,716.60,1062.94);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 152075, "", "d_limestonecave_52_5", 1333.821, 727.2372, 1079.784, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 107016, "", "d_limestonecave_52_5", 1403.656, 716.6, 1009.331, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 20025, "", "d_limestonecave_52_5", 1336.151, 722.0546, 1077.373, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		character.Movement.MoveTo(new Position(1312.473f, 716.6f, 1062.944f));
		actors.Add(character);

		var mob3 = Shortcuts.AddMonster(0, 154011, "", "d_limestonecave_52_5", 1352.231, 716.6, 1013.694, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 154012, "", "d_limestonecave_52_5", 1402.919, 716.6, 1065.621, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 154014, "", "d_limestonecave_52_5", 1346.732, 719.4183, 976.3439, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 154015, "", "d_limestonecave_52_5", 1404.102, 716.6, 961.2811, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 154016, "", "d_limestonecave_52_5", 1459.907, 716.6, 1010.576, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 20025, "", "d_limestonecave_52_5", 1411.391, 716.6125, 1007.225, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 2:
				//DRT_ACTOR_ATTACH_EFFECT("I_spread_in008_red", "BOT");
				break;
			case 5:
				await track.Dialog.Msg("LIMESTONE_52_5_MQ_9_TRACK_1");
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation005_yellow", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in011_yellow_loop", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_light076_spread_in_blue_loop", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_light075_yellow_loop", "TOP");
				break;
			case 6:
				//DRT_ACTOR_PLAY_EFT("F_rize006_red", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion016_red", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_rize012_violet", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_rize012_violet", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_rize012_violet", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_rize012_violet", "BOT");
				break;
			case 7:
				//DRT_ACTOR_ATTACH_EFFECT("F_wizard_Kurdaitcha_ground_loop", "BOT");
				break;
			case 10:
				await track.Dialog.Msg("LIMESTONE_52_5_MQ_9_TRACK_2");
				break;
			case 14:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground093_dark", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation032_red_loop", "BOT");
				break;
			case 15:
				await track.Dialog.Msg("LIMESTONE_52_5_MQ_9_TRACK_3");
				break;
			case 18:
				//CREATE_BATTLE_BOX_INLAYER(0);
				character.AddonMessage("NOTICE_Dm_scroll", "Gesti has started to attack once more!", 6);
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion046_red", "TOP");
				break;
			case 19:
				//TRACK_SETTENDENCY();
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_basic029_red_line", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup001_dark", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_circle011_dark", "BOT");
				break;
			case 20:
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_basic004_red", "BOT");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
