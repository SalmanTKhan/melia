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

[TrackScript("CASTLE65_3_MQ02_TRACK")]
public class CASTLE653MQ02TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CASTLE65_3_MQ02_TRACK");
		//SetMap("None");
		//CenterPos(-837.12,163.46,1492.89);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-1237.227f, 164.0689f, 1026.926f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 155094, "", "None", -1285.78, 164.3651, 1027.014, 71);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 47106, "UnVisibleName", "None", -1035.45, 166.69, 1239.05, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 47106, "UnVisibleName", "None", -894.03, 166.69, 1380.47, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 47106, "UnVisibleName", "None", -1035.45, 166.69, 1039.05, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 47106, "UnVisibleName", "None", -894.03, 166.69, 897.63, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 47106, "UnVisibleName", "None", -694.03, 166.69, 897.63, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 47106, "UnVisibleName", "None", -552.61, 166.69, 1039.05, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 47106, "UnVisibleName", "None", -552.61, 166.69, 1239.05, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 47106, "UnVisibleName", "None", -694.03, 166.69, 1380.47, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 20049, "", "None", -964.74, 166.69, 1309.76, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 20049, "", "None", -1035.45, 166.69, 1139.05, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 20049, "", "None", -964.74, 166.69, 968.34, 0);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 20049, "", "None", -794.03, 166.69, 897.63, 0);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 20049, "", "None", -623.32, 166.69, 968.34, 0);
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		var mob14 = Shortcuts.AddMonster(0, 20049, "", "None", -552.61, 166.69, 1139.05, 0);
		mob14.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob14.AddEffect(new ScriptInvisibleEffect());
		mob14.Layer = character.Layer;
		actors.Add(mob14);

		var mob15 = Shortcuts.AddMonster(0, 20049, "", "None", -623.32, 166.69, 1309.76, 0);
		mob15.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob15.AddEffect(new ScriptInvisibleEffect());
		mob15.Layer = character.Layer;
		actors.Add(mob15);

		var mob16 = Shortcuts.AddMonster(0, 20049, "", "None", -794.03, 166.69, 1380.47, 0);
		mob16.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob16.AddEffect(new ScriptInvisibleEffect());
		mob16.Layer = character.Layer;
		actors.Add(mob16);

		var mob17 = Shortcuts.AddMonster(0, 20026, "", "None", -792.4075, 166.6898, 1139.851, 0);
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
			case 23:
				//DRT_ACTOR_ATTACH_EFFECT("F_bg_light008_yellow2##10", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_rize002", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_rize002", "MID");
				break;
			case 25:
				//DRT_ACTOR_ATTACH_EFFECT("F_rize002", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_rize002", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_bg_light008_yellow2##10", "BOT");
				break;
			case 27:
				//DRT_ACTOR_ATTACH_EFFECT("F_rize002", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_bg_light008_yellow2##10", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_rize002", "BOT");
				break;
			case 29:
				//DRT_ACTOR_ATTACH_EFFECT("F_bg_light008_yellow2##10", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_rize002", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_rize002", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_rize002", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_bg_light008_yellow2##10", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_rize002", "BOT");
				break;
			case 30:
				//DRT_ACTOR_PLAY_EFT("I_emo_exclamation", "TOP", 1);
				//DRT_ACTOR_PLAY_EFT("I_emo_exclamation", "TOP", 1);
				break;
			case 31:
				//DRT_ACTOR_ATTACH_EFFECT("F_rize002", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_bg_light008_yellow2##10", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_rize002", "BOT");
				break;
			case 33:
				//DRT_ACTOR_ATTACH_EFFECT("F_rize002", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_bg_light008_yellow2##10", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_rize002", "BOT");
				break;
			case 35:
				//DRT_ACTOR_ATTACH_EFFECT("F_rize002", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_bg_light008_yellow2##10", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_rize002", "BOT");
				break;
			case 37:
				//SCR_SAME_LAYER_SETPOS_FADEOUT_RUN(-10, 10);
				break;
			case 44:
				await track.Dialog.Msg("CASTLE653_MQ_02_prog");
				break;
			case 49:
				CreateBattleBoxInLayer(character, track);
				//DRT_PLAY_MGAME("CASTLE65_3_MQ02_MINI");
				Send.ZC_NORMAL.SetupCutscene(character, false, false, true);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
