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

[TrackScript("STARTOWER_89_MQ_80_TRACK")]
public class STARTOWER89MQ80TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("STARTOWER_89_MQ_80_TRACK");
		//SetMap("d_startower_89");
		//CenterPos(-743.73,1079.77,-102.01);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-743.7305f, 1079.774f, -102.0119f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 156135, "", "d_startower_89", -574, 1079.77, -24.48, 532.5);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 156120, "", "d_startower_89", -798.701, 1079.774, -131.368, 70.52631);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 155165, "", "d_startower_89", -818.1178, 1079.774, -119.4052, 68.68421);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 150180, "", "d_startower_89", -804.6489, 1079.774, -157.8042, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 156117, "", "d_startower_89", -823.2097, 1079.774, -145.7095, 60.75);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 155164, "", "d_startower_89", -838.2985, 1079.774, -132.8085, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 156124, "", "d_startower_89", -827.7623, 1079.774, -171.5307, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 59083, "", "d_startower_89", -486.456, 1079.774, -403.0436, 31.8421);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 59083, "", "d_startower_89", -438.5544, 1079.774, -124.901, 51.36);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 59083, "", "d_startower_89", -887.6069, 1079.774, -190.3847, 36.01504);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 59082, "", "d_startower_89", -874.93, 1079.77, -151.11, 33.7594);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 59082, "", "d_startower_89", -669.73, 1079.77, -383.85, 35.6015);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 154067, "UnvisibleName", "d_startower_89", -438.55, 1079.77, -124.9, 0);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 154067, "UnvisibleName", "d_startower_89", -486.46, 1079.77, -403.04, 0);
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		var mob14 = Shortcuts.AddMonster(0, 154067, "UnvisibleName", "d_startower_89", -887.61, 1079.77, -190.38, 725);
		mob14.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob14.AddEffect(new ScriptInvisibleEffect());
		mob14.Layer = character.Layer;
		actors.Add(mob14);

		var mob15 = Shortcuts.AddMonster(0, 154067, "UnvisibleName", "d_startower_89", -874.93, 1079.77, -151.11, 0);
		mob15.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob15.AddEffect(new ScriptInvisibleEffect());
		mob15.Layer = character.Layer;
		actors.Add(mob15);

		var mob16 = Shortcuts.AddMonster(0, 154067, "UnvisibleName", "d_startower_89", -669.73, 1079.77, -383.85, 0);
		mob16.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob16.AddEffect(new ScriptInvisibleEffect());
		mob16.Layer = character.Layer;
		actors.Add(mob16);

		var mob17 = Shortcuts.AddMonster(0, 152076, "", "d_startower_89", -944.4637, 1068.801, -152.9218, 0);
		mob17.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob17.AddEffect(new ScriptInvisibleEffect());
		mob17.Layer = character.Layer;
		actors.Add(mob17);

		var mob18 = Shortcuts.AddMonster(0, 152076, "", "d_startower_89", -566.7819, 1079.774, -12.76696, 0);
		mob18.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob18.AddEffect(new ScriptInvisibleEffect());
		mob18.Layer = character.Layer;
		actors.Add(mob18);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 29:
				await track.Dialog.Msg("STARTOWER_89_MQ_80_TRACK_DLG1");
				break;
			case 32:
				await track.Dialog.Msg("STARTOWER_89_MQ_80_TRACK_DLG2");
				break;
			case 34:
				break;
			case 35:
				await track.Dialog.Msg("STARTOWER_89_MQ_80_TRACK_DLG3");
				break;
			case 39:
				await track.Dialog.Msg("STARTOWER_89_MQ_80_TRACK_DLG4");
				break;
			case 41:
				await track.Dialog.Msg("STARTOWER_89_MQ_80_TRACK_DLG5");
				break;
			case 43:
				await track.Dialog.Msg("STARTOWER_89_MQ_80_TRACK_DLG6");
				break;
			case 54:
				break;
			case 55:
				//DRT_ACTOR_PLAY_EFT("F_burstup025_dark", "BOT", 0);
				break;
			case 60:
				//DRT_ACTOR_PLAY_EFT("F_burstup025_dark", "BOT", 0);
				break;
			case 64:
				//DRT_ACTOR_PLAY_EFT("F_burstup025_dark", "BOT", 0);
				break;
			case 68:
				//DRT_ACTOR_PLAY_EFT("F_burstup025_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_burstup025_dark", "BOT", 0);
				break;
			case 99:
				await track.Dialog.Msg("STARTOWER_89_MQ_80_TRACK_DLG7");
				break;
			case 101:
				await track.Dialog.Msg("STARTOWER_89_MQ_80_TRACK_DLG8");
				break;
			case 124:
				await track.Dialog.Msg("STARTOWER_89_MQ_80_TRACK_DLG9");
				break;
			case 138:
				CreateBattleBoxInLayer(character, track);
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
