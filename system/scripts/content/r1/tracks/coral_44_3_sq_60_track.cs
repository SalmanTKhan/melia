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

[TrackScript("CORAL_44_3_SQ_60_TRACK")]
public class CORAL443SQ60TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CORAL_44_3_SQ_60_TRACK");
		//SetMap("f_coral_44_3");
		//CenterPos(901.07,-107.74,-536.55);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(901.6138f, -107.7407f, -522.7075f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 157044, "UnvisibleName", "f_coral_44_3", 1578.73, -107.74, -386.38, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 107027, "", "f_coral_44_3", 1377.92, -107.74, -478.74, 310);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 155042, "", "f_coral_44_3", 904.3277, -107.7407, -559.4099, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 155044, "", "f_coral_44_3", 965.9756, -107.7407, -500.946, 8);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 155094, "", "f_coral_44_3", 876.1119, -107.7407, -561.908, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 58829, "", "f_coral_44_3", 994.8649, -107.7407, -483.4071, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 58829, "", "f_coral_44_3", 657.4217, -107.7407, -562.5127, 70.625);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 58829, "", "f_coral_44_3", 647.5903, -107.7407, -664.0149, 81.66667);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 20025, "", "f_coral_44_3", 1377.923, -107.7407, -478.7408, 0);
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
			case 11:
				break;
			case 33:
				//DRT_FUNC_ACT("SCR_CORAL_44_3_SQ_60_FADEOUT2");
				break;
			case 35:
				break;
			case 44:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground147_water_bubble", "BOT");
				break;
			case 45:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground035_violet", "BOT");
				break;
			case 53:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground009_2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_out034_violet_ice", "BOT");
				break;
			case 55:
				break;
			case 59:
				//TRACK_SETTENDENCY();
				character.AddonMessage("NOTICE_Dm_scroll", "A Varle King has appeared to protect the Massive Kruvina.", 5);
				CreateBattleBoxInLayer(character, track);
				break;
			case 60:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground127_water", "BOT");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
