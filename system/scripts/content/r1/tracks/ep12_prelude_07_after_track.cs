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

[TrackScript("EP12_PRELUDE_07_AFTER_TRACK")]
public class EP12PRELUDE07AFTERTRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP12_PRELUDE_07_AFTER_TRACK");
		//SetMap("f_dcapital_106");
		//CenterPos(-44.12,68.06,456.47);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-44.12151f, 68.06305f, 456.4679f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 20026, "UnvisibleName", "f_dcapital_106", -283.9639, 0.2153931, 92.98106, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 59100, "", "f_dcapital_106", 247.5661, 89.40117, 526.5242, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 59100, "", "f_dcapital_106", 263.9603, 89.40117, 471.6039, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 59100, "", "f_dcapital_106", 332.6384, 89.40114, 457.5093, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 59100, "", "f_dcapital_106", 328.3713, 89.40113, 518.0809, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 59100, "", "f_dcapital_106", 342.9366, 89.40112, 556.586, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 59096, "", "f_dcapital_106", 402.8046, 89.4011, 478.0497, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 59100, "", "f_dcapital_106", 382.0345, 89.40112, 460.9463, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 34:
				//DRT_ACTOR_PLAY_EFT("F_spread_in002_blue", "MID", 0);
				break;
			case 43:
				//DRT_ACTOR_PLAY_EFT("F_spread_in002_blue", "MID", 0);
				break;
			case 57:
				//DRT_ACTOR_PLAY_EFT("F_spread_out032", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_out032_3", "BOT", 0);
				break;
			case 65:
				//DRT_ACTOR_PLAY_EFT("I_spread_in011_2", "BOT", 0);
				break;
			case 69:
				//DRT_ACTOR_PLAY_EFT("I_spread_in011_2", "BOT", 0);
				break;
			case 73:
				//DRT_ACTOR_PLAY_EFT("I_spread_in011_2", "BOT", 0);
				break;
			case 77:
				//DRT_ACTOR_PLAY_EFT("I_spread_in011_2", "BOT", 0);
				break;
			case 81:
				//DRT_ACTOR_PLAY_EFT("I_spread_in011_2", "BOT", 0);
				break;
			case 93:
				//DRT_ACTOR_PLAY_EFT("F_explosion004_yellow1", "BOT", 0);
				break;
			case 118:
				character.AddonMessage("NOTICE_Dm_Clear", "[Creeping Darkness(7)]{nl}Completed!", 10);
				break;
			case 119:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
