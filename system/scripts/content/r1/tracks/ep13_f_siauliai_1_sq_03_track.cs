using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.Scripting;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.Effects;
using Melia.Zone.World.Tracks;
using Yggdrasil.Logging;

[TrackScript("EP13_F_SIAULIAI_1_SQ_03_TRACK")]
public class EP13FSIAULIAI1SQ03TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP13_F_SIAULIAI_1_SQ_03_TRACK");
		//SetMap("ep13_f_siauliai_1");
		//CenterPos(987.81,25.35,114.30);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(967.7497f, 25.3504f, 106.628f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 59579, "", "ep13_f_siauliai_1", 898.345, 25.3504, 191.542, 61.875);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 59579, "", "ep13_f_siauliai_1", 890.6968, 25.3504, 106.8294, 36.42857);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 59579, "", "ep13_f_siauliai_1", 929.2361, 25.3504, 17.88043, 60.83333);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 59578, "", "ep13_f_siauliai_1", 871.1783, 25.3504, -58.33393, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 59578, "", "ep13_f_siauliai_1", 773.3705, 25.3504, 167.8599, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 59578, "", "ep13_f_siauliai_1", 777.5842, 25.3504, 55.74393, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 154120, "", "ep13_f_siauliai_1", 1301.571, 25.3504, 138.2912, 100);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 5:
				break;
			case 6:
				break;
			case 7:
				break;
			case 9:
				break;
			case 10:
				break;
			case 11:
				//DRT_PLAY_FORCE(0, 1, 2, "I_arrow013_mash_yellow_Archer01_3", "arrow_cast", "I_explosion002_green", "arrow_blow", "SLOW", 300, 1, 0, 5, 150, 0);
				break;
			case 14:
				break;
			case 19:
				await track.Dialog.Msg("EP13_F_SIAULIAI_1_SQ_03_T_1");
				break;
			case 22:
				//DRT_PLAY_FORCE(0, 1, 2, "I_arrow013_mash_yellow_Archer01_3", "arrow_cast", "I_explosion002_green", "arrow_blow", "SLOW", 300, 1, 0, 5, 150, 0);
				break;
			case 25:
				//DRT_PLAY_FORCE(0, 1, 2, "I_arrow013_mash_yellow_Archer01_3", "arrow_cast", "I_explosion002_green", "arrow_blow", "SLOW", 300, 1, 0, 5, 150, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_arrow013_mash_yellow_Archer01_3", "arrow_cast", "I_explosion002_green", "arrow_blow", "SLOW", 300, 1, 0, 5, 150, 0);
				break;
			case 28:
				//DRT_PLAY_FORCE(0, 1, 2, "I_arrow013_mash_yellow_Archer01_3", "arrow_cast", "I_explosion002_green", "arrow_blow", "SLOW", 300, 1, 0, 5, 150, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_arrow013_mash_yellow_Archer01_3", "arrow_cast", "I_explosion002_green", "arrow_blow", "SLOW", 300, 1, 0, 5, 150, 0);
				break;
			case 31:
				await track.Dialog.Msg("EP13_F_SIAULIAI_1_SQ_03_T_2");
				break;
			case 32:
				character.AddSessionObject(PropertyName.EP13_F_SIAULIAI_1_SQ_03, 1);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
