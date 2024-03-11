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

[TrackScript("SIAU15_R_MQ_06_TRACK")]
public class SIAU15RMQ06TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("SIAU15_R_MQ_06_TRACK");
		//CenterPos(-498.92,1014.95,2576.54);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-482.0444f, 1014.947f, 2513.148f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 57119, "", "", -394.6209, 1014.957, 2244.825, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.Level = 55;
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 20118, "Herb Broker", "", -445.0405, 1014.957, 2383.383, 1.382979);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 10033, "브란", "", -526.913, 1014.957, 2533.051, 85, "Our_Forces");
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.Level = 36;
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 10033, "피트", "", -445.4047, 1014.957, 2516.154, 45, "Neutral");
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 41252, "", "", -484.1004, 1014.957, 2584.505, 107.5, "Neutral");
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
			case 1:
				//DRT_FUNC_ACT("RESET_SIAU15_R_MQ_06_RUNNPC");
				break;
			case 10:
				await track.Dialog.Msg("f_siauliai_15_re_dlg_14");
				break;
			case 24:
				break;
			case 68:
				//DRT_RUN_OBJ("SIAU15_R_MQ_06_3D");
				break;
			case 73:
				//TRACK_SETTENDENCY();
				break;
			case 77:
				//DRT_ACTOR_PLAY_EFT("F_ghostnpc_born", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("F_ghostnpc_born", "BOT");
				break;
			case 93:
				//InsertHate(999);
				//InsertHate(999);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
