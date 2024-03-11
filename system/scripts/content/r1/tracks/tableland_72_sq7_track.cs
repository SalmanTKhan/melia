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

[TrackScript("TABLELAND_72_SQ7_TRACK")]
public class TABLELAND72SQ7TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("TABLELAND_72_SQ7_TRACK");
		//SetMap("f_tableland_72");
		//CenterPos(179.76,384.93,-138.22);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(179.7611f, 384.9295f, -138.2222f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 155046, "마을", "f_tableland_72", 818.3815, 374.2991, -96.69832, 101.3636);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 57975, "", "f_tableland_72", 984.8538, 333.5025, 24.41687, 56.34616);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 57975, "", "f_tableland_72", 1012.815, 326.8108, -25.92053, 53.2);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 57942, "", "f_tableland_72", 924.8068, 357.5352, -9.372003, 57.30769);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 57942, "", "f_tableland_72", 948.2444, 347.0602, 31.90698, 51.53846);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 57942, "", "f_tableland_72", 979.634, 337.1787, -7.322182, 58.51852);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 57942, "", "f_tableland_72", 685.6608, 374.3105, -76.45856, 6.136364);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 20026, "", "f_tableland_72", 660.1177, 374.3105, -100.1556, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 20026, "", "f_tableland_72", 621.0496, 374.3105, -139.5366, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 20026, "", "f_tableland_72", 551.7543, 374.3105, -22.28822, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 20026, "", "f_tableland_72", 613.3839, 374.3105, -123.4459, 187.5);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 20026, "", "f_tableland_72", 565.0844, 374.3105, -97.15354, 0);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 20026, "", "f_tableland_72", 832.7699, 374.3105, -70.23544, 0);
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
			case 1:
				//DRT_PLAY_FORCE(0, 1, 2, "I_smoke037_yellow", "arrow_cast", "I_explosion004_yellow", "arrow_blow", "SLOW", 200, 1, 0, 5, 10, 0);
				break;
			case 2:
				//DRT_PLAY_FORCE(0, 1, 2, "I_smoke037_yellow", "arrow_cast", "I_explosion004_yellow", "arrow_blow", "SLOW", 200, 1, 0, 5, 10, 0);
				break;
			case 4:
				//DRT_PLAY_FORCE(0, 1, 2, "I_smoke037_yellow", "arrow_cast", "I_explosion004_yellow", "arrow_blow", "SLOW", 200, 1, 0, 5, 10, 0);
				break;
			case 6:
				//DRT_PLAY_FORCE(0, 1, 2, "I_smoke037_yellow", "arrow_cast", "I_explosion004_yellow", "arrow_blow", "SLOW", 200, 1, 0, 5, 10, 0);
				break;
			case 7:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke061", "BOT");
				break;
			case 8:
				//DRT_ACTOR_ATTACH_EFFECT("F_stone003", "BOT");
				break;
			case 11:
				break;
			case 24:
				character.AddonMessage("NOTICE_Dm_scroll", "Defeat the demons that are chasing Arntas", 3);
				break;
			case 28:
				//TRACK_SETTENDENCY();
				CreateBattleBoxInLayer(character, track);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
