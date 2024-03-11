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

[TrackScript("GR_CHAPEL_1_S7_RN_TRACK")]
public class GRCHAPEL1S7RNTRACK : TrackScript
{
	protected override void Load()
	{
		SetId("GR_CHAPEL_1_S7_RN_TRACK");
		//SetMap("None");
		//CenterPos(-176.79,35.92,19.95);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var npc0 = Shortcuts.AddNpc(0, 58226, "", "None", -25.29702, 48.55574, -141.6724, 0);
		npc0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc0.AddEffect(new ScriptInvisibleEffect());
		npc0.Layer = character.Layer;
		actors.Add(npc0);

		var mob0 = Shortcuts.AddMonster(0, 154005, "", "None", -26.16333, 48.55574, -140.0405, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 20025, "", "None", -23.85729, 48.55574, -141.7445, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 20025, "", "None", -80.64751, 39.92953, -211.5813, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 20025, "", "None", -33.37882, 35.91736, -237.5268, 172.5);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 20025, "", "None", 38.30759, 35.91735, -211.2036, 170);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 20025, "", "None", 67.18948, 37.16287, -135.8797, 262.5);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 20025, "", "None", -52.52024, 48.55573, -128.3929, 24.375);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 20025, "", "None", -24.4103, 48.55574, -140.8437, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 20025, "", "None", -116.3366, 38.50875, -135.2794, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 20025, "", "None", 29.95033, 36.42184, -63.97669, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 20025, "", "None", -35.99657, 35.91726, -44.31671, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 20025, "", "None", -95.09677, 35.91728, -71.91911, 0);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 1:
				//DRT_ACTOR_ATTACH_EFFECT("F_archer_BombardmentOrdeads_Puple", "BOT");
				break;
			case 3:
				break;
			case 4:
				//DRT_ACTOR_ATTACH_EFFECT("F_pattern013_ground_violet", "BOT");
				break;
			case 10:
				//DRT_ACTOR_ATTACH_EFFECT("F_bg_rize002_violet##5", "BOT");
				break;
			case 11:
				//DRT_ACTOR_PLAY_EFT("I_smoke001_dark_3", "BOT", 0);
				break;
			case 17:
				//DRT_ACTOR_ATTACH_EFFECT("F_cleric_ogouveve_ground", "BOT");
				break;
			case 22:
				//DRT_ACTOR_ATTACH_EFFECT("F_rize013_violet", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_rize013_violet", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_rize013_violet", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_rize013_violet", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_swordtrail042_yellow_reverse", "TOP");
				//DRT_ACTOR_ATTACH_EFFECT("F_rize013_violet", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("None", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_rize013_violet", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_rize013_violet", "BOT");
				break;
			case 32:
				//DRT_FACTIONCHANGE("Monster");
				break;
			case 34:
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
