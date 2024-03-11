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

[TrackScript("FLASH64_SQ_04_TRACK")]
public class FLASH64SQ04TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("FLASH64_SQ_04_TRACK");
		//SetMap("f_flash_64");
		//CenterPos(-454.54,688.45,-611.03);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 10033, "", "f_flash_64", -471.9688, 688.4476, -638.9266, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 57373, "", "f_flash_64", -461.4491, 688.4475, -650.8145, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		character.Movement.MoveTo(new Position(-460.9971f, 688.4476f, -623.225f));
		actors.Add(character);

		var mob2 = Shortcuts.AddMonster(0, 10033, "", "f_flash_64", -372.0282, 688.4476, -523.05, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 10033, "", "f_flash_64", -277.5619, 688.4476, -534.6408, 11.33333);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 10033, "", "f_flash_64", -189.7676, 688.4476, -577.5033, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 10033, "", "f_flash_64", -325.687, 688.4476, -642.5336, 0);
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
				break;
			case 9:
				//DRT_ACTOR_ATTACH_EFFECT("F_archer_scarecrow_shot_smoke", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion086_ice", "BOT");
				break;
			case 27:
				//DRT_ACTOR_ATTACH_EFFECT("F_archer_scarecrow_shot_smoke", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion086_ice", "BOT");
				break;
			case 41:
				//DRT_ACTOR_PLAY_EFT("F_cleric_OOBE_shot_explosion", "BOT", 0);
				break;
			case 42:
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion086_ice", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion086_ice", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion086_ice", "BOT");
				break;
			case 49:
				character.AddonMessage("NOTICE_Dm_!", "Defeat Devilglove!", 3);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
