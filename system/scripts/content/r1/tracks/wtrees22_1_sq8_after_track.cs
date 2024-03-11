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

[TrackScript("WTREES22_1_SQ8_AFTER_TRACK")]
public class WTREES221SQ8AFTERTRACK : TrackScript
{
	protected override void Load()
	{
		SetId("WTREES22_1_SQ8_AFTER_TRACK");
		//SetMap("f_whitetrees_22_1");
		//CenterPos(-745.15,139.78,431.42);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 153185, "", "f_whitetrees_22_1", -798.41, 139.77, 537.53, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 155126, "", "f_whitetrees_22_1", -766.02, 139.77, 446.4, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		character.Movement.MoveTo(new Position(-743.6339f, 139.7786f, 432.3914f));
		actors.Add(character);

		var mob2 = Shortcuts.AddMonster(0, 20025, "파란", "f_whitetrees_22_1", -733.9258, 139.7787, 502.0206, 15290);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 47192, "Gravestone", "f_whitetrees_22_1", -705.57, 139.77, 531.64, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 155004, "", "f_whitetrees_22_1", -651.59, 139.77, 449.31, 0);
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
			case 6:
				//DRT_FUNC_ACT("WTREES22_1_SUBQ91_EVT_MSG_FUNC");
				break;
			case 19:
				break;
			case 23:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line", "BOT", 0);
				break;
			case 25:
				//DRT_ACTOR_ATTACH_EFFECT("I_force015_blue", "MID");
				break;
			case 28:
				character.AddonMessage("NOTICE_Dm_scroll", "A blue apple has come out.{nl}Let's pick up the blue apple.", 3);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
