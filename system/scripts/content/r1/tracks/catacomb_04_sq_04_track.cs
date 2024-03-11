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

[TrackScript("CATACOMB_04_SQ_04_TRACK")]
public class CATACOMB04SQ04TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CATACOMB_04_SQ_04_TRACK");
		//SetMap("id_catacomb_04");
		//CenterPos(593.94,285.28,1199.27);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 147413, "Barrier Stone", "id_catacomb_04", 617, 286, 1192, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 147374, "", "id_catacomb_04", 256.0799, 265.6605, 1205.092, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 20026, "", "id_catacomb_04", 294.6297, 265.6605, 1181.486, 117);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 151054, "UnvisibleName", "id_catacomb_04", 1011.235, 265.3084, 1186.625, 0, "Monster");
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.Level = 191;
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 151054, "UnvisibleName", "id_catacomb_04", 1225.936, 265.3084, 1189.841, 0, "Monster");
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.Level = 191;
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 151054, "UnvisibleName", "id_catacomb_04", 1466.81, 265.3084, 1186.129, 0, "Monster");
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.Level = 191;
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 151058, "", "id_catacomb_04", 1589, 266, 861, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		character.Movement.MoveTo(new Position(552.8274f, 285.2842f, 1186.877f));
		actors.Add(character);

		var mob7 = Shortcuts.AddMonster(0, 57648, "", "id_catacomb_04", 1370.156, 265.3084, 1158.174, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 401423, "", "id_catacomb_04", 889.1348, 285.2842, 1219.051, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 401423, "", "id_catacomb_04", 924.676, 285.2842, 1168.091, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 57320, "", "id_catacomb_04", 1153.063, 265.3084, 1211.295, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 57320, "", "id_catacomb_04", 1111.134, 265.3084, 1147.961, 0);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 1:
				//DRT_ACTOR_PLAY_EFT("I_circle_dead_mash", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion005_violet", "BOT", 0);
				break;
			case 5:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup007_smoke", "BOT");
				break;
			case 10:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup007_smoke", "BOT");
				break;
			case 15:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup007_smoke", "BOT");
				break;
			case 20:
				break;
			case 24:
				CreateBattleBoxInLayer(character, track);
				character.AddonMessage("NOTICE_Dm_!", "Avoid the Black Chaser pursuing you and obtain the Spatial Magic Gem!", 10);
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
