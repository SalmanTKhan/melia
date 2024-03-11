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

[TrackScript("VASILISSA_BORN_TRACK")]
public class VASILISSABORNTRACK : TrackScript
{
	protected override void Load()
	{
		SetId("VASILISSA_BORN_TRACK");
		//SetMap("None");
		//CenterPos(10.63,10.46,-10.63);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 59451, "", "None", 11.93202, 10.46349, -11.80268, 10.52632);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 147469, "", "None", 10.50374, 10.46349, -10.48452, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 147469, "", "None", 23.63962, 10.46349, -45.12913, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 147469, "", "None", 48.50604, 10.46349, -25.52934, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 147469, "", "None", -11.2535, 10.46349, -21.41856, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 147469, "", "None", 24.87046, 10.46349, 2.042862, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 2:
				//DRT_ACTOR_PLAY_EFT("F_ground115_water", "BOT", 0);
				break;
			case 4:
				//DRT_ACTOR_PLAY_EFT("F_ground115_water", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_pc_jump_water", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_pc_jump_water", "BOT", 0);
				break;
			case 5:
				//DRT_ACTOR_PLAY_EFT("F_pc_jump_water", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_pc_jump_water", "BOT", 0);
				break;
			case 6:
				//DRT_ACTOR_PLAY_EFT("I_ground008_water", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground115_water", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_pc_jump_water", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_pc_jump_water", "BOT", 0);
				break;
			case 7:
				//DRT_ACTOR_PLAY_EFT("F_pc_jump_water", "BOT", 0);
				break;
			case 8:
				//DRT_ACTOR_PLAY_EFT("F_ground115_water", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_pc_jump_water", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_pc_jump_water", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_pc_jump_water", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_pc_jump_water", "BOT", 0);
				break;
			case 9:
				//DRT_ACTOR_PLAY_EFT("F_pc_jump_water", "BOT", 0);
				break;
			case 10:
				//DRT_ACTOR_PLAY_EFT("F_ground115_water", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_pc_jump_water", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_pc_jump_water", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_pc_jump_water", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_pc_jump_water", "BOT", 0);
				break;
			case 11:
				//DRT_ACTOR_PLAY_EFT("F_pc_jump_water", "BOT", 0);
				break;
			case 24:
				//DRT_ACTOR_PLAY_EFT("F_spread_in030_air", "TOP", 0);
				break;
			case 25:
				Send.ZC_NORMAL.Notice(character, "Goddess_Raid_Vasilissa_Track_Bolloon_1", 2);
				break;
			case 26:
				//DRT_ACTOR_PLAY_EFT("F_spread_in030_ice4", "TOP", 0);
				break;
			case 29:
				//DRT_ACTOR_PLAY_EFT("F_spread_out032_2", "BOT", 0);
				break;
			case 34:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
