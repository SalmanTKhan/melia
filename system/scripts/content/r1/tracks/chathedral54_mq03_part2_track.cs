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

[TrackScript("CHATHEDRAL54_MQ03_PART2_TRACK")]
public class CHATHEDRAL54MQ03PART2TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CHATHEDRAL54_MQ03_PART2_TRACK");
		//SetMap("d_cathedral_54");
		//CenterPos(-1182.92,3.85,980.58);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 47254, "", "d_cathedral_54", -882.8424, 3.8508, 991.8637, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 57367, "", "d_cathedral_54", -808.8524, 3.8508, 996.8213, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 57367, "", "d_cathedral_54", -922.6278, 3.8508, 978.3957, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.Level = 2;
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 57367, "", "d_cathedral_54", -906.2122, 3.8508, 1040.016, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.Level = 2;
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 57367, "", "d_cathedral_54", -895.9624, 3.8508, 886.4529, 15.94595);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 57367, "", "d_cathedral_54", -1010.592, 3.8508, 964.9673, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 57367, "", "d_cathedral_54", -895.7023, 3.8508, 936.8381, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 57367, "", "d_cathedral_54", -981.7784, 3.8508, 899.5442, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 57367, "", "d_cathedral_54", -817.133, 3.8508, 908.2076, 19.59459);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 57367, "", "d_cathedral_54", -953.483, 3.8508, 1024.262, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		character.Movement.MoveTo(new Position(-1211.576f, 3.8508f, 955.8149f));
		actors.Add(character);

		var mob10 = Shortcuts.AddMonster(0, 151001, "", "d_cathedral_54", -877.7582, 3.8508, 992.093, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 151033, "", "d_cathedral_54", -1198.61, 3.85, 998.62, 0);
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
			case 3:
				break;
			case 4:
				break;
			case 5:
				break;
			case 8:
				break;
			case 9:
				break;
			case 10:
				//DRT_ACTOR_PLAY_EFT("F_archer_explosiontrap_shot_smoke", "BOT", 0);
				break;
			case 12:
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup020_blue_mint", "BOT");
				break;
			case 13:
				//DRT_PLAY_FORCE(99999, 4, 3, "I_force002_blue", "arrow_cast", "F_explosion019_rize", "arrow_blow", "SLOW", 100, 1, 0, 5, 10, 0);
				break;
			case 14:
				//DRT_PLAY_FORCE(99999, 4, 3, "I_force002_blue", "arrow_cast", "F_explosion019_rize", "arrow_blow", "SLOW", 100, 1, 0, 5, 10, 0);
				break;
			case 18:
				//DRT_ACTOR_ATTACH_EFFECT("F_cleric_energy_blast_cast", "BOT");
				break;
			case 29:
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
