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

[TrackScript("ABBEY22_4_SQ5_TRACK")]
public class ABBEY224SQ5TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ABBEY22_4_SQ5_TRACK");
		//SetMap("d_abbey_22_4");
		//CenterPos(29.27,61.09,835.85);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(29.26646f, 61.08946f, 835.848f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 155045, "", "d_abbey_22_4", 31.23275, 72.40394, 804.1517, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 57827, "", "d_abbey_22_4", 572.6158, 89.2355, 687.8725, 0.5405405);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 58736, "", "d_abbey_22_4", 574.3215, 89.2355, 560.9736, 367.6923);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 155104, "", "d_abbey_22_4", 638.0875, 89.2355, 586.7449, 161);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 155104, "", "d_abbey_22_4", 636.2348, 89.2355, 739.8838, 180);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 155104, "", "d_abbey_22_4", 738.5375, 89.2355, 662.9561, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 153187, "", "d_abbey_22_4", 646.549, 89.2355, 667.9436, 27.5);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 155044, "Monk", "d_abbey_22_4", 738.9248, 89.2355, 665.7908, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 155043, "Monk", "d_abbey_22_4", 635.1509, 89.2355, 588.3104, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 155043, "Monk", "d_abbey_22_4", 635.2932, 89.2355, 740.3496, 3);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 58857, "", "d_abbey_22_4", 780.2122, 89.2355, 654.6958, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 58857, "", "d_abbey_22_4", 636.338, 89.2355, 547.2512, 0);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 58857, "", "d_abbey_22_4", 637.7449, 89.2355, 774.6623, 0);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 58862, "", "d_abbey_22_4", 483.0732, 89.2355, 643.8516, 0);
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		var mob14 = Shortcuts.AddMonster(0, 58862, "", "d_abbey_22_4", 477.3798, 89.2355, 717.6, 0);
		mob14.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob14.AddEffect(new ScriptInvisibleEffect());
		mob14.Layer = character.Layer;
		actors.Add(mob14);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 2:
				//DRT_ACTOR_ATTACH_EFFECT("F_bg_light011_red", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_bg_light011_red", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_bg_light011_red", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_bg_light011_red", "BOT");
				break;
			case 14:
				await track.Dialog.Msg("ABBEY22_4_SUBQ5_MSG1");
				break;
			case 26:
				await track.Dialog.Msg("ABBEY22_4_SUBQ5_MSG2");
				break;
			case 46:
				//DRT_ACTOR_PLAY_EFT("I_smoke045_spread_in_red", "BOT", 0);
				break;
			case 48:
				//DRT_ACTOR_PLAY_EFT("I_smoke045_spread_in_red", "BOT", 0);
				break;
			case 51:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force003_green", "arrow_cast", "None", "arrow_blow", "SLOW", 100, 1, 0, 5, 10, 0);
				break;
			case 53:
				await track.Dialog.Msg("ABBEY22_4_SUBQ5_MSG3");
				//DRT_PLAY_FORCE(0, 1, 2, "I_force003_green", "arrow_cast", "None", "arrow_blow", "SLOW", 100, 1, 0, 5, 10, 0);
				break;
			case 70:
				await track.Dialog.Msg("ABBEY22_4_SUBQ5_MSG4");
				break;
			case 79:
				//TRACK_BASICLAYER_MOVE();
				break;
			case 125:
				//DRT_ACTOR_PLAY_EFT("I_smoke045_spread_in_red", "BOT", 0);
				break;
			case 130:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force003_green", "arrow_cast", "I_explosion002_green", "arrow_blow", "SLOW", 50, 1, 0, 5, 10, 0);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
