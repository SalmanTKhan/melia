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

[TrackScript("STARTOWER_88_MQ_70_TRACK")]
public class STARTOWER88MQ70TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("STARTOWER_88_MQ_70_TRACK");
		//SetMap("None");
		//CenterPos(-228.38,266.75,2767.56);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 153137, "", "None", -245, 266, 2707, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 59119, "", "None", -379.3884, 266.7478, 2579.747, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 59115, "", "None", -419.0247, 266.7478, 2741.737, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 59119, "", "None", -284.4338, 266.7478, 2895.376, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 59115, "", "None", -119.1258, 266.7478, 2847.121, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 59119, "", "None", -77, 266.75, 2664.15, 5);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 59115, "", "None", -209.3392, 266.7478, 2527.792, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 20042, "", "None", -379.39, 266.75, 2579.75, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 20042, "", "None", -419.02, 266.75, 2741.74, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 20042, "", "None", -284.43, 266.75, 2895.38, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 20042, "", "None", -119.13, 266.75, 2847.12, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 20042, "", "None", -77, 266.75, 2664.15, 0);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 20042, "", "None", -209.34, 266.75, 2527.79, 0);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		character.Movement.MoveTo(new Position(-218.0959f, 266.7478f, 2686.318f));
		actors.Add(character);

		var mob13 = Shortcuts.AddMonster(0, 155107, "UnvisibleName", "None", -225.0062, 266.7478, 2691.325, 0);
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		var mob14 = Shortcuts.AddMonster(0, 152076, "", "None", 35.26817, 266.7478, 2725.008, 0);
		mob14.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob14.AddEffect(new ScriptInvisibleEffect());
		mob14.Layer = character.Layer;
		actors.Add(mob14);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 1:
				//DRT_ACTOR_PLAY_EFT("E_pc_shield_square", "BOT", 0);
				break;
			case 4:
				break;
			case 6:
				//DRT_ACTOR_PLAY_EFT("F_burstup024_dark", "BOT", 0);
				break;
			case 7:
				//DRT_ACTOR_PLAY_EFT("E_pc_shield_square", "BOT", 0);
				break;
			case 9:
				//DRT_ACTOR_PLAY_EFT("F_burstup024_dark", "BOT", 0);
				break;
			case 10:
				break;
			case 12:
				//DRT_ACTOR_PLAY_EFT("F_burstup024_dark", "BOT", 0);
				break;
			case 13:
				//DRT_ACTOR_PLAY_EFT("E_pc_shield_square", "BOT", 0);
				break;
			case 15:
				//DRT_ACTOR_PLAY_EFT("F_burstup024_dark", "BOT", 0);
				break;
			case 16:
				break;
			case 18:
				//DRT_ACTOR_PLAY_EFT("F_burstup024_dark", "BOT", 0);
				break;
			case 19:
				//DRT_ACTOR_PLAY_EFT("E_pc_shield_square", "BOT", 0);
				break;
			case 21:
				//DRT_ACTOR_PLAY_EFT("F_burstup024_dark", "BOT", 0);
				break;
			case 25:
				//DRT_ACTOR_PLAY_EFT("E_pc_shield_square", "BOT", 0);
				break;
			case 29:
				//TRACK_SETTENDENCY();
				CreateBattleBoxInLayer(character, track);
				//TRACK_MON_LOOKAT();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
