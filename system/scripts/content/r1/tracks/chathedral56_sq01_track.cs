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

[TrackScript("CHATHEDRAL56_SQ01_TRACK")]
public class CHATHEDRAL56SQ01TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CHATHEDRAL56_SQ01_TRACK");
		//SetMap("d_cathedral_56");
		//CenterPos(-1545.46,0.00,398.99);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 41351, "", "d_cathedral_56", -1535.551, 0.4988, 64.64057, 264);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 153012, "UnvisibleName", "d_cathedral_56", -1527.7, 0.49, 469.5, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		character.Movement.MoveTo(new Position(-1536.97f, 0.4988f, 336.3737f));
		actors.Add(character);

		var mob2 = Shortcuts.AddMonster(0, 20025, "", "d_cathedral_56", -1704.891, 0.4988, 111.5086, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 20025, "", "d_cathedral_56", -1406.616, 0.4988, 4.622916, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 20025, "", "d_cathedral_56", -1407.838, 0.4988, 67.00253, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 20025, "", "d_cathedral_56", -1524.567, 0.4988, 119.5459, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 20025, "", "d_cathedral_56", -1552.675, 0.4988, -148.9452, 7.727273);
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
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke144_white", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke144_white", "BOT");
				break;
			case 7:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke144_white", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke144_white", "BOT");
				break;
			case 8:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke144_white2", "BOT");
				break;
			case 10:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke144_white", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke144_white", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke144_white", "BOT");
				break;
			case 14:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke144_white", "BOT");
				break;
			case 15:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke144_white", "BOT");
				break;
			case 22:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke144_white", "BOT");
				break;
			case 24:
				CreateBattleBoxInLayer(character, track);
				break;
			case 26:
				break;
			case 27:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke144_white", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke144_white2", "BOT");
				break;
			case 35:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke144_white2", "BOT");
				break;
			case 40:
				await track.Dialog.Msg("CHATHEDRAL56_SQ01_DLG");
				break;
			case 42:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke144_white2", "BOT");
				break;
			case 49:
				//TRACK_SETTENDENCY();
				break;
			case 61:
				//DRT_MOVETOTGT(50);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
