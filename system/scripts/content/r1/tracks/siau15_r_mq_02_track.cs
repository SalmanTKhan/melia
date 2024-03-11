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

[TrackScript("SIAU15_R_MQ_02_TRACK")]
public class SIAU15RMQ02TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("SIAU15_R_MQ_02_TRACK");
		//SetMap("f_siauliai_15_re");
		//CenterPos(1494.64,878.17,95.47);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(1476.182f, 878.1819f, 56.89225f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 20118, "", "f_siauliai_15_re", 1442, 877, 64, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 20125, "", "f_siauliai_15_re", 1465, 877, 84, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 10033, "", "f_siauliai_15_re", 1722.32, 878.1721, 84.81309, 0, "Neutral");
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 10033, "", "f_siauliai_15_re", 1721.796, 878.1721, 45.85444, 0, "Neutral");
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 41252, "", "f_siauliai_15_re", 1718.917, 878.1821, 68.12887, 0, "Neutral");
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
			case 14:
				await track.Dialog.Msg("f_siauliai_15_re_dlg_8");
				break;
			case 35:
				await track.Dialog.Msg("f_siauliai_15_re_dlg_9");
				break;
			case 45:
				await track.Dialog.Msg("f_siauliai_15_re_dlg_10");
				break;
			case 46:
				await track.Dialog.Msg("f_siauliai_15_re_dlg_11");
				break;
			case 50:
				await track.Dialog.Msg("f_siauliai_15_re_dlg_12");
				break;
			case 65:
				await track.Dialog.Msg("f_siauliai_15_re_dlg_13");
				break;
			case 67:
				character.AddSessionObject(PropertyName.SIAU15_R_MQ_02, 1);
				break;
			case 68:
				//DRT_FUNC_ACT("SIAU15_R_MQ_02_RUNNPC");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
