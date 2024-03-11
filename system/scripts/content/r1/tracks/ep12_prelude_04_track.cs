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

[TrackScript("EP12_PRELUDE_04_TRACK")]
public class EP12PRELUDE04TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP12_PRELUDE_04_TRACK");
		//SetMap("f_dcapital_105");
		//CenterPos(-1183.64,164.35,994.22);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-1183.642f, 164.3527f, 994.2151f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 150207, "", "f_dcapital_105", -1277, 164, 1093, 0, "Our_Forces");
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 150207, "", "f_dcapital_105", -1277, 164, 893, 0, "Our_Forces");
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 150207, "", "f_dcapital_105", -1077, 164, 893, 0, "Our_Forces");
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 150207, "", "f_dcapital_105", -1077, 164, 1093, 0, "Our_Forces");
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 59092, "", "f_dcapital_105", -1279.526, 164.3527, 1039.471, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 59092, "", "f_dcapital_105", -1225.303, 164.3527, 1087.655, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 59092, "", "f_dcapital_105", -1129.624, 164.3527, 897.694, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 59092, "", "f_dcapital_105", -1080.591, 164.3527, 942.4709, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 59092, "", "f_dcapital_105", -1092.041, 164.3527, 1064.813, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 59092, "", "f_dcapital_105", -1252.557, 164.3527, 916.6359, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 40095, "", "f_dcapital_105", -1279.186, 164.3527, 1037.278, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 40095, "", "f_dcapital_105", -1257.666, 164.3527, 916.9539, 0);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 40095, "", "f_dcapital_105", -1122.78, 164.3527, 898.989, 0);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 40095, "", "f_dcapital_105", -1076.116, 164.3527, 937.4828, 0);
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		var mob14 = Shortcuts.AddMonster(0, 40095, "", "f_dcapital_105", -1094.654, 164.3527, 1066.938, 0);
		mob14.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob14.AddEffect(new ScriptInvisibleEffect());
		mob14.Layer = character.Layer;
		actors.Add(mob14);

		var mob15 = Shortcuts.AddMonster(0, 40095, "", "f_dcapital_105", -1229.972, 164.3527, 1089.765, 0);
		mob15.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob15.AddEffect(new ScriptInvisibleEffect());
		mob15.Layer = character.Layer;
		actors.Add(mob15);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 2:
				break;
			case 11:
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup019", "BOT");
				break;
			case 15:
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup019", "BOT");
				break;
			case 19:
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup019", "BOT");
				break;
			case 23:
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup019", "BOT");
				break;
			case 27:
				break;
			case 31:
				//DRT_ACTOR_PLAY_EFT("I_smoke013_whiteDark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("I_smoke013_whiteDark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("I_smoke013_whiteDark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("I_smoke013_whiteDark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("I_smoke013_whiteDark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("I_smoke013_whiteDark", "BOT", 0);
				break;
			case 36:
				break;
			case 44:
				character.AddonMessage("NOTICE_Dm_scroll", "The demons are drawn by the divine power and are trying to destroy Namott!{nl}Protect the Namott from the demons until their power is restored!", 7);
				break;
			case 45:
				//DRT_PLAY_MGAME("EP12_PRELUDE_04_MINI");
				break;
			case 46:
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
