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

[TrackScript("THORN22_Q_16_TRACK")]
public class THORN22Q16TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("THORN22_Q_16_TRACK");
		//SetMap("d_thorn_22");
		//CenterPos(-1294.84,553.84,-198.28);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 41285, "", "d_thorn_22", -1265.213, 553.8387, 177.6702, 62.70833);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 41285, "", "d_thorn_22", -1158.776, 553.8387, 123.4705, 52.29166);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 41285, "", "d_thorn_22", -1247.559, 553.8387, 119.5786, 55.83333);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 41290, "", "d_thorn_22", -1264.04, 553.8387, 197.2265, 68.75);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 41290, "", "d_thorn_22", -1186.457, 553.8387, 178.3722, 57.08333);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 20013, "", "d_thorn_22", -1258.917, 553.8387, 41.97642, 54);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 48002, "정착한", "d_thorn_22", -1425, 553, -155, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		character.Movement.MoveTo(new Position(-1294.557f, 553.8387f, -207.4911f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 12:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke015", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke015", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke015", "BOT");
				break;
			case 19:
				Send.ZC_NORMAL.SetupCutscene(character, false, false, true);
				break;
			case 23:
				//TRACK_SETTENDENCY();
				CreateBattleBoxInLayer(character, track);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
