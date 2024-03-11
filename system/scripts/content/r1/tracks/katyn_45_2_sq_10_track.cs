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

[TrackScript("KATYN_45_2_SQ_10_TRACK")]
public class KATYN452SQ10TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("KATYN_45_2_SQ_10_TRACK");
		//SetMap("None");
		//CenterPos(-95.47,244.83,924.09);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 151031, "", "None", -49.41, 244.81, 1047.55, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 151031, "", "None", -33.37, 244.81, 1056.72, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 151031, "", "None", -18.39, 244.82, 1065.179, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 151031, "", "None", 6.910004, 244.83, 1056.86, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 151031, "", "None", 19.03999, 244.83, 1042.57, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 47202, "UnvisibleName", "None", -18.68114, 244.8333, 968.9144, 35);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 156005, "", "None", -20.05, 244.81, 994.08, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		character.Movement.MoveTo(new Position(-27.48956f, 244.8333f, 941.3461f));
		actors.Add(character);

		var mob7 = Shortcuts.AddMonster(0, 400542, "", "None", -198.8684, 244.7651, 957.2158, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 400542, "", "None", -188.2525, 244.7584, 997.852, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 2:
				Send.ZC_NORMAL.SetupCutscene(character, false, false, true);
				break;
			case 5:
				//DRT_ACTOR_ATTACH_EFFECT("F_bg_smoke006", "MID");
				break;
			case 7:
				break;
			case 8:
				//DRT_PLAY_MGAME("KATYN_45_2_SQ_10_MINI");
				break;
			case 9:
				character.AddonMessage("NOTICE_Dm_scroll", "The scent seems to have attracted a lot of Blue Ridimeds", 3);
				break;
			case 10:
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
