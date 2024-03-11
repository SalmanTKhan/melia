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

[TrackScript("PILGRIM313_SQ_06_TRACK")]
public class PILGRIM313SQ06TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("PILGRIM313_SQ_06_TRACK");
		//SetMap("f_pilgrimroad_31_3");
		//CenterPos(-472.59,0.19,-783.97);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 47103, "", "f_pilgrimroad_31_3", -518, 0.19, -775, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(-472.5874f, 0.191899f, -783.9747f));
		actors.Add(character);

		var mob1 = Shortcuts.AddMonster(0, 154054, "", "f_pilgrimroad_31_3", -547.7644, 0.1919022, -674.5482, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 154055, "", "f_pilgrimroad_31_3", -508.1108, 0.1919022, -663.9642, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 154056, "", "f_pilgrimroad_31_3", -448.1737, 0.1919071, -703.3737, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 154053, "", "f_pilgrimroad_31_3", -510.3191, 0.1919057, -722.6631, 0, "Peaceful");
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 57862, "", "f_pilgrimroad_31_3", -271.035, 0.1919022, -790.3223, 56.42857);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 154041, "Blessing", "f_pilgrimroad_31_3", -513.4614, 0.1919034, -778.3576, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 57862, "", "f_pilgrimroad_31_3", -330.3469, 0.1919022, -783.2496, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 154054, "", "f_pilgrimroad_31_3", -567.2417, 0.1919089, -763.8806, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 154055, "", "f_pilgrimroad_31_3", -542.1754, 0.1919031, -818.0923, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 154056, "", "f_pilgrimroad_31_3", -475.3909, 0.1919011, -802.3446, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 1:
				//DRT_ACTOR_ATTACH_EFFECT("F_bg_light003_blue2", "BOT");
				break;
			case 6:
				//DRT_ACTOR_ATTACH_EFFECT("F_bg_light003_blue2", "BOT");
				break;
			case 10:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke122_blue", "BOT");
				break;
			case 11:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke122_blue", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke122_blue", "BOT");
				break;
			case 12:
				//DRT_ACTOR_ATTACH_EFFECT("F_bg_light003_blue2", "BOT");
				break;
			case 13:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in012_blue", "BOT");
				break;
			case 14:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke122_blue", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("E_TransmitPrana_loop", "BOT");
				break;
			case 15:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke122_blue", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("E_TransmitPrana_loop", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke122_blue", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("E_TransmitPrana_loop", "BOT");
				break;
			case 19:
				//DRT_ACTOR_ATTACH_EFFECT("F_bg_light003_blue2", "BOT");
				break;
			case 27:
				//DRT_ACTOR_PLAY_EFT("F_explosion041_smoke", "BOT", 0);
				break;
			case 28:
				//DRT_ACTOR_ATTACH_EFFECT("F_cleric_OOBE_shot_explosion", "BOT");
				break;
			case 34:
				break;
			case 48:
				character.AddonMessage("NOTICE_Dm_!", "Defeat Kartas Hunter!", 3);
				break;
			case 53:
				//InsertHate(1);
				break;
			case 54:
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
