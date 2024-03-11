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

[TrackScript("CHATHEDRAL56_MQ04_TRACK")]
public class CHATHEDRAL56MQ04TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CHATHEDRAL56_MQ04_TRACK");
		//SetMap("None");
		//CenterPos(-1022.92,0.00,129.19);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 153018, "", "None", -1014.98, 0.49, 254.26, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 57370, "", "None", -1098.485, 0, 177.203, 64);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 57371, "", "None", -973.6, 0.4988, 231.877, 10.83333);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.Level = 2;
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 57370, "", "None", -1015.574, 0.4988, 187.8916, 1);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.Level = 2;
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 57371, "", "None", -1062.392, 0, 110.4535, 69.16666);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 57371, "", "None", -968.2583, 0, 121.8726, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 57370, "", "None", -1110.476, 0, 108.8419, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 57370, "", "None", -923.1945, 0, 117.221, 1.428571);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 57371, "", "None", -1046.01, 0.4988, 231.2903, 24.16667);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.Level = 2;
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 57371, "", "None", -960.7988, 0, 175.646, 28);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 57370, "", "None", -906.6688, 0, 186.426, 32);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 20025, "Key", "None", -1013.889, 0.4988, 248.4798, 30);
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
				//DRT_ACTOR_PLAY_EFT("F_hit_good", "MID", 0);
				break;
			case 8:
				//DRT_ACTOR_PLAY_EFT("F_hit_good", "MID", 0);
				break;
			case 10:
				//DRT_ACTOR_PLAY_EFT("F_hit_good", "MID", 0);
				break;
			case 11:
				//DRT_PLAY_FORCE(9999, 1, 3, "I_force002_blue", "arrow_cast", "F_explosion019_rize", "arrow_blow", "SLOW", 100, 1, 0, 5, 10, 0);
				//DRT_ACTOR_PLAY_EFT("F_archer_explosiontrap_shot_smoke", "BOT", 0);
				//DRT_PLAY_FORCE(9999, 1, 3, "I_force002_blue", "arrow_cast", "F_explosion019_rize", "arrow_blow", "SLOW", 100, 1, 0, 5, 10, 0);
				//DRT_PLAY_FORCE(9999, 1, 3, "I_force002_blue", "arrow_cast", "F_explosion019_rize", "arrow_blow", "SLOW", 100, 1, 0, 5, 10, 0);
				break;
			case 13:
				break;
			case 14:
				//DRT_ACTOR_PLAY_EFT("F_buff_Cleric_Limitation_Buff", "BOT", 0);
				break;
			case 19:
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
