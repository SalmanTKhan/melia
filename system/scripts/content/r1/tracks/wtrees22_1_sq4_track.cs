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

[TrackScript("WTREES22_1_SQ4_TRACK")]
public class WTREES221SQ4TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("WTREES22_1_SQ4_TRACK");
		//SetMap("f_whitetrees_22_1");
		//CenterPos(2090.72,9.03,-283.79);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 153185, "", "f_whitetrees_22_1", 2129.23, 9.02, -194.98, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 155126, "", "f_whitetrees_22_1", 2079.55, 9.02, -255.77, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		character.Movement.MoveTo(new Position(2091.077f, 9.026839f, -283.4264f));
		actors.Add(character);

		var mob2 = Shortcuts.AddMonster(0, 154065, "하얀", "f_whitetrees_22_1", 2136.594, 9.026838, -284.3267, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 20024, "", "f_whitetrees_22_1", 2092.827, 9.026833, -246.1556, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 2:
				//DRT_ACTOR_PLAY_EFT("I_smoke_red", "BOT", 0);
				break;
			case 5:
				//DRT_FUNC_ACT("WTREES22_1_SUBQ4_EVT_MSG_FUNC");
				break;
			case 25:
				break;
			case 29:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line_2", "BOT", 0);
				break;
			case 31:
				//DRT_ACTOR_ATTACH_EFFECT("I_force015_white", "MID");
				break;
			case 34:
				character.AddonMessage("NOTICE_Dm_scroll", "A white apple has come out.{nl}Let's pick up the white apple.", 3);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
