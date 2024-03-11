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

[TrackScript("PILGRIM312_SQ_05_TRACK")]
public class PILGRIM312SQ05TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("PILGRIM312_SQ_05_TRACK");
		//SetMap("None");
		//CenterPos(794.33,264.41,806.49);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(835.5787f, 264.4149f, 759.4026f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 47251, "", "None", 797, 265, 804, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 57840, "", "None", 748.6697, 264.4149, 589.6252, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 57840, "", "None", 790.0847, 264.4149, 763.1686, 75);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 20025, "", "None", 790.08, 264.41, 763.17, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 58146, "", "None", 1054.111, 264.4149, 705.1531, 65);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 58146, "", "None", 1026.679, 264.4149, 574.0004, 93);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 20025, "", "None", 798.4567, 264.4149, 805.9423, 32.85714);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 6:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke017_red", "MID");
				break;
			case 20:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke013_dark", "TOP");
				break;
			case 27:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_out004_dark", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup005_dark", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke143_dark_red_loop", "BOT");
				break;
			case 28:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke143_dark_red_loop", "BOT");
				break;
			case 29:
				break;
			case 34:
				character.AddonMessage("NOTICE_Dm_!", "Protect Demon Lord Hauberk while he's reunifying!", 3);
				//DRT_PLAY_MGAME("PILGRIM312_SQ_05_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
