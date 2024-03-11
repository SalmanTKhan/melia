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

[TrackScript("ASSISTOR_TUTO_TRACK_01_01")]
public class ASSISTORTUTOTRACK0101 : TrackScript
{
	protected override void Load()
	{
		SetId("ASSISTOR_TUTO_TRACK_01_01");
		//SetMap("f_siauliai_50_1");
		//CenterPos(-817.61,0.21,-1472.53);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-817.6123f, 0.2092896f, -1472.525f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 59466, "", "f_siauliai_50_1", -972.7382, 0.2092896, -1457.558, 12);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 59467, "", "f_siauliai_50_1", -886.6166, 0.2092896, -1427.544, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 147469, "", "f_siauliai_50_1", -971.468, 0.2092896, -1457.495, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 10:
				//DRT_ACTOR_PLAY_EFT("I_explosion003_pink", "MID", 0);
				break;
			case 12:
				//DRT_ACTOR_PLAY_EFT("I_explosion003_pink", "MID", 0);
				break;
			case 14:
				//DRT_ACTOR_PLAY_EFT("I_explosion003_pink", "MID", 0);
				break;
			case 16:
				//DRT_ACTOR_PLAY_EFT("I_explosion003_pink", "MID", 0);
				break;
			case 36:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic019_pink", "BOT", 0);
				break;
			case 38:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic019_pink", "BOT", 0);
				break;
			case 40:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic019_pink", "BOT", 0);
				break;
			case 42:
				//DRT_ACTOR_PLAY_EFT("F_wizard_SummonDemon2_cast_ground", "BOT", 0);
				break;
			case 43:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic026_pink_line", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_burstup006_pink", "BOT", 0);
				break;
			case 49:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
