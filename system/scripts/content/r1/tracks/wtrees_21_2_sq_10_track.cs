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

[TrackScript("WTREES_21_2_SQ_10_TRACK")]
public class WTREES212SQ10TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("WTREES_21_2_SQ_10_TRACK");
		//SetMap("None");
		//CenterPos(-1023.45,54.09,241.35);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-778.1708f, 45.48363f, 99.41592f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 107020, "", "None", -1087.662, 47.1094, 500.3029, 40.33333);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 20024, "", "None", -1087.66, 47.11, 500.3, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 20024, "", "None", -1161.579, 48.76341, 462.841, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 20024, "", "None", -1010.923, 49.04672, 541.6923, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 20024, "", "None", -1120.604, 47.1094, 559.9553, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 20024, "", "None", -1024.006, 49.04667, 437.3778, 0);
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
			case 8:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground132_dark_green2_loop", "BOT");
				break;
			case 14:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground132_dark_green2_loop", "BOT");
				break;
			case 19:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground036_green", "BOT");
				break;
			case 27:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke005_dark", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion001_dark", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_circle011_dark", "BOT");
				break;
			case 38:
				character.AddonMessage("NOTICE_Dm_scroll", "A Grim Reaper has appeared, surrounded by a strong evil aura.{nl}Defeat the Grim Reaper.", 7);
				break;
			case 39:
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
