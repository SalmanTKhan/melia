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

[TrackScript("ABBEY22_5_SQ14_TRACK")]
public class ABBEY225SQ14TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ABBEY22_5_SQ14_TRACK");
		//SetMap("d_abbey_22_5");
		//CenterPos(-726.73,209.27,-699.44);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-726.7279f, 209.2684f, -699.438f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 57840, "", "d_abbey_22_5", 1677.401, -33.07492, 705.9463, 60.71429);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 155045, "", "d_abbey_22_5", 2002.217, -33.07492, 972.9421, 45.25);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 153188, "", "d_abbey_22_5", 1950.13, -33.07, 863.86, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 57840, "", "d_abbey_22_5", 1678.7, -33.07492, 851.5989, 8.81356);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 57840, "", "d_abbey_22_5", 1809.523, -33.07492, 730.2936, 25.87719);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 152078, "UnvisibleName", "d_abbey_22_5", 1985.593, -33.07492, 821.6328, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 154087, "아가일라", "d_abbey_22_5", 1844.868, -33.07492, 873.67, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 103051, "", "d_abbey_22_5", 1678.7, -33.07, 851.6, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 20025, "UnvisibleName", "d_abbey_22_5", 1683.08, -33.07492, 795.1177, 10);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 20025, "UnvisibleName", "d_abbey_22_5", 1736.218, -33.07492, 762.9016, 15);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 20024, "", "d_abbey_22_5", 1677.74, -33.07492, 707.6631, 94.28571);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 47250, "", "d_abbey_22_5", -722.51, 209.26, -837.65, 6.935484);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 153017, "", "d_abbey_22_5", -672.96, 209.26, -795.34, 0);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 153017, "", "d_abbey_22_5", -676.67, 209.26, -893.21, 0);
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		var mob14 = Shortcuts.AddMonster(0, 47459, "", "d_abbey_22_5", -869.7316, 209.2686, -738.8768, 0);
		mob14.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob14.AddEffect(new ScriptInvisibleEffect());
		mob14.Layer = character.Layer;
		actors.Add(mob14);

		var mob15 = Shortcuts.AddMonster(0, 152078, "", "d_abbey_22_5", -718.4889, 209.2684, -698.0988, 0);
		mob15.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob15.AddEffect(new ScriptInvisibleEffect());
		mob15.Layer = character.Layer;
		actors.Add(mob15);

		var mob16 = Shortcuts.AddMonster(0, 12082, "", "d_abbey_22_5", 1698.35, -33.07492, 786.9921, 11.61017);
		mob16.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob16.AddEffect(new ScriptInvisibleEffect());
		mob16.Layer = character.Layer;
		actors.Add(mob16);

		var mob17 = Shortcuts.AddMonster(0, 20025, "", "d_abbey_22_5", 1801.203, -33.07492, 738.9265, 112.1429);
		mob17.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob17.AddEffect(new ScriptInvisibleEffect());
		mob17.Layer = character.Layer;
		actors.Add(mob17);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case -58:
				break;
			case 1:
				break;
			case 13:
				await track.Dialog.Msg("ABBEY22_5_SUBQ14_DLG1");
				break;
			case 19:
				//DRT_ACTOR_PLAY_EFT("F_explosion102_violet_event", "BOT", 0);
				break;
			case 26:
				await track.Dialog.Msg("ABBEY22_5_SUBQ14_DLG2");
				break;
			case 30:
				await track.Dialog.Msg("ABBEY22_5_SUBQ14_DLG3");
				break;
			case 33:
				//DRT_ACTOR_ATTACH_EFFECT("I_force098_dark", "TOP");
				//DRT_ACTOR_ATTACH_EFFECT("I_force098_red", "TOP");
				break;
			case 44:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in032_dark2", "BOT");
				break;
			case 50:
				//DRT_ACTOR_PLAY_EFT("F_levitation009_violet", "BOT", 0);
				break;
			case 51:
				//DRT_ACTOR_PLAY_EFT("F_spread_out002_violet", "BOT", 1);
				break;
			case 53:
				//DRT_ADDBUFF("ABBEY22_5_SUBQ14_BUFF1", 1, 0, 0, 1);
				//DRT_ADDBUFF("ABBEY22_5_SUBQ14_BUFF2", 1, 0, 0, 1);
				break;
			case 57:
				await track.Dialog.Msg("ABBEY22_5_SUBQ14_DLG4");
				break;
			case 59:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic045", "BOT", 0);
				break;
			case 61:
				await track.Dialog.Msg("ABBEY22_5_SUBQ14_DLG5");
				break;
			case 63:
				await track.Dialog.Msg("ABBEY22_5_SUBQ14_DLG6");
				break;
			case 65:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic046", "BOT", 0);
				break;
			case 69:
				CreateBattleBoxInLayer(character, track);
				//TRACK_SETTENDENCY();
				//DRT_ADDBUFF("ABBEY22_5_SUBQ14_BUFF4", 1, 0, 0, 1);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
