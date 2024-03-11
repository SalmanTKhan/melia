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

[TrackScript("TABLELAND_73_SQ5_TRACK")]
public class TABLELAND73SQ5TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("TABLELAND_73_SQ5_TRACK");
		//SetMap("f_tableland_73");
		//CenterPos(1217.22,677.64,1433.95);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 153155, "", "f_tableland_73", 1207.06, 677.64, 1461.72, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 103040, "", "f_tableland_73", 1246.49, 677.64, 1269.14, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 20024, "UnvisibleName", "f_tableland_73", 1246.49, 677.64, 1269.14, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		character.Movement.MoveTo(new Position(1223.317f, 677.6448f, 1398.797f));
		actors.Add(character);

		var mob3 = Shortcuts.AddMonster(0, 20024, "", "f_tableland_73", 1246.49, 677.64, 1269.14, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var npc0 = Shortcuts.AddNpc(0, 46011, "Firewood", "f_tableland_73", 1277.57, 677.64, 1446.58, 0, "TABLE73_SUBQ5_WOOD");
		npc0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc0.AddEffect(new ScriptInvisibleEffect());
		npc0.Layer = character.Layer;
		actors.Add(npc0);

		var npc1 = Shortcuts.AddNpc(0, 46011, "Firewood", "f_tableland_73", 1358.31, 693.24, 1551.44, 0, "TABLE73_SUBQ5_WOOD");
		npc1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc1.AddEffect(new ScriptInvisibleEffect());
		npc1.Layer = character.Layer;
		actors.Add(npc1);

		var npc2 = Shortcuts.AddNpc(0, 46011, "Firewood", "f_tableland_73", 1016.53, 677.64, 1362.66, 0, "TABLE73_SUBQ5_WOOD");
		npc2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc2.AddEffect(new ScriptInvisibleEffect());
		npc2.Layer = character.Layer;
		actors.Add(npc2);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 4:
				//DRT_ACTOR_ATTACH_EFFECT("F_fire003_violet", "BOT");
				break;
			case 7:
				//DRT_PLAY_FORCE(0, 2, 6, "I_force075#Dummy_effect_light", "arrow_cast", "F_explosion074_violet", "arrow_blow", "SLOW", 150, 1, 0, 5, 10, 0);
				break;
			case 11:
				character.AddonMessage("NOTICE_Dm_scroll", "A Lavenzard appeared{nl}as you try to destroy the scultpure", 3);
				break;
			case 14:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground009", "BOT");
				break;
			case 15:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke019_dark_loop", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_pattern008_violet_loop", "BOT");
				break;
			case 19:
				break;
			case 27:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup001_dark", "BOT");
				break;
			case 43:
				//TRACK_SETTENDENCY();
				break;
			case 44:
				//DRT_PLAY_MGAME("TABLELAND_73_SUBQ5_ICE");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke005_dark", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke072_sviolet2", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_ground083_smoke", "BOT");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
