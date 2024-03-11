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

[TrackScript("GELE572_MQ_01_TRACK")]
public class GELE572MQ01TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("GELE572_MQ_01_TRACK");
		//SetMap("f_gele_57_2");
		//CenterPos(-7.80,375.39,-986.98);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 57223, "", "f_gele_57_2", 30.06487, 375.3996, -751.5961, 20.88235, "Neutral");
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(15.29019f, 375.3996f, -1010.967f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 15:
				break;
			case 23:
				//DRT_ACTOR_ATTACH_EFFECT("I_cleric_oobe_loop_levitation1", "BOT");
				break;
			case 27:
				//DRT_ACTOR_ATTACH_EFFECT("I_cleric_oobe_loop_levitation1", "BOT");
				break;
			case 29:
				await track.Dialog.Msg("f_gele_57_2_dlg_1");
				break;
			case 39:
				await track.Dialog.Msg("f_gele_57_2_dlg_2");
				break;
			case 41:
				Send.ZC_NORMAL.Notice(character, "GELE572_MQ_01_BALL", 3);
				break;
			case 50:
				await track.Dialog.Msg("f_gele_57_2_dlg_3");
				break;
			case 59:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
