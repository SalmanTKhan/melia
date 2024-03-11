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

[TrackScript("WHITETREES23_1_SQ03_TRACK")]
public class WHITETREES231SQ03TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("WHITETREES23_1_SQ03_TRACK");
		//SetMap("f_whitetrees_23_1");
		//CenterPos(17.22,11.36,1368.48);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(591.8516f, 11.3621f, 1270.692f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 155142, "", "f_whitetrees_23_1", -39.27395, -4.487332, 1235.661, 82);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 155151, "", "f_whitetrees_23_1", 64.74, 11.36, 1380.39, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 34:
				await track.Dialog.Msg("WHITETREES231_SQ_03_track1");
				break;
			case 43:
				//DRT_FUNC_ACT("SCR_WHITETREES231_SQ_03_RUN");
				break;
			case 49:
				//DRT_FUNC_ACT("WHITETREES231_SQ3_TRACK_MSG");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
