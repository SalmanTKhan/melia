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

[TrackScript("TABLELAND_72_SQ8_TRACK")]
public class TABLELAND72SQ8TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("TABLELAND_72_SQ8_TRACK");
		//SetMap("f_tableland_72");
		//CenterPos(-1279.05,411.22,479.14);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 147417, "UnvisibleName", "f_tableland_72", -1374.12, 411.21, 474.91, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 155043, "마을", "f_tableland_72", -1323.048, 411.2191, 470.2683, 46.66666);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		character.Movement.MoveTo(new Position(-1300.427f, 411.2191f, 469.4554f));
		actors.Add(character);

		var mob2 = Shortcuts.AddMonster(0, 57942, "", "f_tableland_72", -1057.651, 411.2191, 457.6819, 81.66666);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 57942, "", "f_tableland_72", -1099.863, 411.2191, 375.5727, 75.83333);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 57942, "", "f_tableland_72", -1082.391, 411.2191, 579.0475, 71.66666);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 5:
				//DRT_ACTOR_PLAY_EFT("F_lineup022_blue", "BOT", 0);
				break;
			case 8:
				break;
			case 9:
				break;
			case 10:
				//DRT_ACTOR_PLAY_EFT("F_lineup022_blue", "BOT", 0);
				break;
			case 12:
				//DRT_PLAY_MGAME("TABLEL72_SUBQ8_MINI");
				break;
			case 13:
				character.AddonMessage("NOTICE_Dm_scroll", "Protect Kahleims until the Purification Orb is complete", 5);
				break;
			case 14:
				CreateBattleBoxInLayer(character, track);
				//TRACK_SETTENDENCY();
				break;
			case 15:
				//DRT_ACTOR_PLAY_EFT("F_lineup022_blue", "BOT", 0);
				break;
			case 20:
				//DRT_ACTOR_PLAY_EFT("F_lineup022_blue", "BOT", 0);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
