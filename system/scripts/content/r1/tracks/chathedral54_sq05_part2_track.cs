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

[TrackScript("CHATHEDRAL54_SQ05_PART2_TRACK")]
public class CHATHEDRAL54SQ05PART2TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CHATHEDRAL54_SQ05_PART2_TRACK");
		//SetMap("d_cathedral_54");
		//CenterPos(826.20,13.98,1159.77);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 47254, "", "d_cathedral_54", 826.33, 13.98, 1200.75, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 57311, "", "d_cathedral_54", 820.87, 13.98, 1240.55, 37.5);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 57367, "", "d_cathedral_54", 813.6727, 3.0948, 996.8972, 36.53846);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 57367, "", "d_cathedral_54", 840.7991, 3.0948, 963.6375, 35);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 57367, "", "d_cathedral_54", 460.5764, 3.0948, 1205.438, 52.5);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 20024, "", "d_cathedral_54", 822.5982, 13.9838, 1220.213, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 20024, "", "d_cathedral_54", 829.0292, 3.095253, 1401.216, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		character.Movement.MoveTo(new Position(825.2827f, 13.9838f, 1183.324f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 3:
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_basic008_blue", "BOT");
				break;
			case 4:
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_basic008_blue", "BOT");
				break;
			case 5:
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_basic008_blue", "BOT");
				break;
			case 6:
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_basic008_blue", "BOT");
				break;
			case 7:
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_basic008_blue", "BOT");
				break;
			case 8:
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_basic008_blue", "BOT");
				break;
			case 9:
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_basic008_blue", "BOT");
				break;
			case 14:
				//DRT_ACTOR_ATTACH_EFFECT("I_riteris_sword_mash", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("E_riteris_sword", "BOT");
				break;
			case 17:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke066", "BOT");
				break;
			case 20:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup001_dark", "BOT");
				break;
			case 21:
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion098_dark_blue", "BOT");
				break;
			case 22:
				break;
			case 23:
				//DRT_ACTOR_ATTACH_EFFECT("F_warrior_ninja_shot_smoke2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_warrior_ninja_shot_smoke2", "BOT");
				break;
			case 24:
				character.AddonMessage("NOTICE_Dm_!", "Naktis' servants have rushed in!", 3);
				break;
			case 31:
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
