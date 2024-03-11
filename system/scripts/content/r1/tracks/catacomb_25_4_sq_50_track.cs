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

[TrackScript("CATACOMB_25_4_SQ_50_TRACK")]
public class CATACOMB254SQ50TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CATACOMB_25_4_SQ_50_TRACK");
		//SetMap("id_catacomb_25_4");
		//CenterPos(-1478.31,-86.59,613.37);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-1504.194f, -85.56981f, 593.2047f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 155106, "UnvisibleName", "id_catacomb_25_4", -1690.1, -84.38, 641.39, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 155044, "", "id_catacomb_25_4", -1686.89, -84.38171, 675.4084, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 58501, "", "id_catacomb_25_4", -1802.098, -85.56981, 500.9449, 55);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 58501, "", "id_catacomb_25_4", -1951.145, -85.56981, 558.0422, 77.77778);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 58501, "", "id_catacomb_25_4", -1618.902, -85.56981, 417.0358, 80);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 58501, "", "id_catacomb_25_4", -1695.125, -85.56981, 417.1425, 51.11111);
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
			case 5:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_out003_darkblue", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_light055_blue", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke011_blue", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke130_blue_loop", "BOT");
				break;
			case 21:
				//DRT_ACTOR_ATTACH_EFFECT("F_hit003_light_dark_blue", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_ground011_blue", "BOT");
				//DRT_ACTOR_PLAY_EFT("F_explosion011_blue", "MID", 0);
				//DRT_ACTOR_ATTACH_EFFECT("F_ground079_light", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup007_blue", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke046_levitation", "BOT");
				//DRT_ACTOR_PLAY_EFT("E_soul", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke122_blue", "MID");
				break;
			case 30:
				break;
			case 41:
				//DRT_PLAY_MGAME("CATACOMB_25_4_SQ_40_MINI");
				break;
			case 43:
				Send.ZC_NORMAL.SetupCutscene(character, false, false, true);
				break;
			case 44:
				character.AddonMessage("NOTICE_Dm_scroll", "Monsters have started to attack as soon as Jaonus disappeared after tinkering with something on the altar!", 7);
				break;
			case 49:
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
