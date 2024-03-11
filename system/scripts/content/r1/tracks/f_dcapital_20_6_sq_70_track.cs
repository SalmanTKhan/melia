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

[TrackScript("F_DCAPITAL_20_6_SQ_70_TRACK")]
public class FDCAPITAL206SQ70TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_DCAPITAL_20_6_SQ_70_TRACK");
		//SetMap("None");
		//CenterPos(254.24,16.47,1278.07);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(36.6868f, 48.86349f, 1447.301f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 155137, "UnvisibleName", "None", 394.8056, 16.4679, 1195.454, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 155137, "UnvisibleName", "None", -65.45587, 48.86349, 1648.473, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 155136, "UnvisibleName", "None", -51.5684, 48.86349, 1317.682, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 155136, "UnvisibleName", "None", 399.5352, 16.4679, 1481.776, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 155136, "UnvisibleName", "None", 204.7617, 16.4679, 1349.354, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 58627, "Diena", "None", -110.49, 48.86, 1452.1, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 41229, "", "None", -160.6308, 48.86349, 1471.633, 22.14286);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 20026, "", "None", -110.49, 48.86, 1452.1, 8.333333);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 20026, "", "None", -129.1168, 48.86349, 1457.125, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var npc0 = Shortcuts.AddNpc(0, 107019, "Diena", "None", -110.49, 48.86, 1452.1, 0);
		npc0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc0.AddEffect(new ScriptInvisibleEffect());
		npc0.Layer = character.Layer;
		actors.Add(npc0);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 1:
				//DRT_ACTOR_PLAY_EFT("F_bg_light009_yellow2", "BOT", 0);
				break;
			case 5:
				await track.Dialog.Msg("F_DCAPITAL_20_6_SQ_70_BOSS");
				break;
			case 6:
				//DRT_FUNC_ACT("SCR_DCAPITAL_20_6_SQ_60_TRACK1");
				//DRT_ACTOR_ATTACH_EFFECT("F_light082_line_red", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_light082_line_red", "BOT");
				break;
			case 7:
				//DRT_ACTOR_ATTACH_EFFECT("I_explosion003_pink", "MID");
				break;
			case 8:
				break;
			case 10:
				//DRT_ACTOR_ATTACH_EFFECT("F_magic_prison_circle", "BOT");
				break;
			case 17:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke013_dark", "MID");
				break;
			case 28:
				await track.Dialog.Msg("F_DCAPITAL_20_6_SQ_70_BOSS2");
				break;
			case 32:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in002_red", "BOT");
				break;
			case 36:
				//DRT_ACTOR_ATTACH_EFFECT("F_light082_line_red", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_light082_line_red", "BOT");
				break;
			case 44:
				//DRT_FUNC_ACT("SCR_DCAPITAL_20_6_SQ_60_TRACK2");
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
