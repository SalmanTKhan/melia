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

[TrackScript("PILGRIM312_SQ_06_TRACK")]
public class PILGRIM312SQ06TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("PILGRIM312_SQ_06_TRACK");
		//SetMap("None");
		//CenterPos(-67.65,264.53,-1086.63);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 47110, "", "None", -79.78352, 264.5273, -1141.444, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(-91.94228f, 264.5273f, -1074.796f));
		actors.Add(character);

		var mob1 = Shortcuts.AddMonster(0, 57861, "", "None", -62.7786, 264.5273, -1157.417, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 57827, "", "None", -134.0567, 264.5273, -1011.397, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 57714, "", "None", -205.4058, 264.5273, -1066.925, 12.5, "Our_Forces");
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 57715, "", "None", -58.01228, 264.5273, -989.1448, 0, "Our_Forces");
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 57716, "", "None", -223.04, 264.53, -1135.58, 0, "Our_Forces");
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 57716, "", "None", -3.214455, 264.5273, -1010.503, 0, "Our_Forces");
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 20025, "", "None", -79.78, 264.53, -1141.44, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 20025, "", "None", -169.5445, 264.5273, -981.6272, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 20025, "", "None", -58.01, 264.53, -989.14, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 20025, "", "None", -3.209999, 264.53, -1010.5, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 20025, "", "None", -223.04, 264.53, -1135.58, 0);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 20025, "", "None", -205.41, 264.53, -1066.92, 0);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 9:
				break;
			case 14:
				break;
			case 26:
				//DRT_ACTOR_ATTACH_EFFECT("F_cleric_zaibas_shot_rize", "TOP");
				//DRT_ACTOR_ATTACH_EFFECT("F_cleric_zaibas_shot_rize", "TOP");
				break;
			case 27:
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion042_smoke_TOP", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke061_TOP", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_npc_rokas_7_deadparts2_mash", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion033_orange", "MID");
				break;
			case 29:
				break;
			case 30:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke127_violet", "MID");
				break;
			case 32:
				//DRT_SETHOOKMSGOWNER(0, 1);
				break;
			case 34:
				//InsertHate(999);
				break;
			case 38:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_out014_smoke", "BOT");
				break;
			case 41:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_out014_smoke", "BOT");
				break;
			case 42:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup029_smoke_dark2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup029_smoke_dark2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup029_smoke_dark2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup029_smoke_dark2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup029_smoke_dark2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup029_smoke_dark2", "BOT");
				break;
			case 43:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup002_dark", "BOT");
				break;
			case 45:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground092_dark", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_ground092_dark", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_ground092_dark", "BOT");
				break;
			case 49:
				character.AddonMessage("NOTICE_Dm_!", "Defeat Drapeliun by helping Hauberk!", 3);
				//InsertHate(10);
				//DRT_SETHOOKMSGOWNER(0, 1);
				//InsertHate(999);
				//DRT_SETHOOKMSGOWNER(0, 1);
				//InsertHate(999);
				//DRT_SETHOOKMSGOWNER(0, 1);
				//InsertHate(999);
				//DRT_SETHOOKMSGOWNER(0, 1);
				//InsertHate(999);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
