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

[TrackScript("TABLELAND_71_SQ1_TRACK")]
public class TABLELAND71SQ1TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("TABLELAND_71_SQ1_TRACK");
		//SetMap("f_tableland_71");
		//CenterPos(-1107.47,345.37,693.33);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 103039, "", "f_tableland_71", -371.4434, 402.8819, 860.3498, 18.125);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 155034, "Jamelhan", "f_tableland_71", -1137.12, 345.37, 703.93, 0.6756757);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 155069, "", "f_tableland_71", -1140.02, 345.37, 512.59, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 147484, "", "f_tableland_71", -1299.44, 345.34, 476.93, 52);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 147486, "", "f_tableland_71", -1257.49, 345.24, 486.4, 160);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 20158, "", "f_tableland_71", -1290.99, 345.37, 545.61, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 153131, "UnvisibleName", "f_tableland_71", -1115.83, 345.41, 515.7, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var npc0 = Shortcuts.AddNpc(0, 152040, "UnvisibleName", "f_tableland_71", -1125.72, 345.48, 489.72, 0);
		npc0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc0.AddEffect(new ScriptInvisibleEffect());
		npc0.Layer = character.Layer;
		actors.Add(npc0);

		character.Movement.MoveTo(new Position(-1144.26f, 345.3745f, 614.9402f));
		actors.Add(character);

		var mob7 = Shortcuts.AddMonster(0, 155055, "", "f_tableland_71", -978.79, 344.69, 398.47, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 147484, "", "f_tableland_71", -1246.09, 345.35, 545.53, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 46011, "", "f_tableland_71", -1274.8, 345.27, 475.97, 0, "Neutral");
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 46011, "", "f_tableland_71", -1268.28, 345.37, 535.5, 0, "Neutral");
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 57415, "", "f_tableland_71", 15.77442, 562.9731, 942.5916, 117.1429);
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
			case 6:
				break;
			case 11:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_out007_circle", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup001_blue", "BOT");
				break;
			case 18:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground065_smoke", "BOT");
				break;
			case 19:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup029_smoke", "BOT");
				break;
			case 26:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke025_blue_2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_ground077_smoke", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_ground037_smoke", "BOT");
				break;
			case 30:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup001_white", "BOT");
				break;
			case 31:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground079_smoke", "BOT");
				break;
			case 34:
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
