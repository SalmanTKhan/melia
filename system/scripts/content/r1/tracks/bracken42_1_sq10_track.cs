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

[TrackScript("BRACKEN42_1_SQ10_TRACK")]
public class BRACKEN421SQ10TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("BRACKEN42_1_SQ10_TRACK");
		//SetMap("None");
		//CenterPos(-1414.52,0.10,-432.39);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-721.668f, 506.7902f, -293.7519f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 20107, "", "None", -721.0005, 500.4443, -260.8531, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 20125, "", "None", -657.0457, 479.5355, -202.6594, 49);
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
			case 5:
				break;
			case 11:
				await track.Dialog.Msg("BRACKEN421_SQ_10_track1");
				break;
			case 13:
				await track.Dialog.Msg("BRACKEN421_SQ_10_track2");
				break;
			case 15:
				await track.Dialog.Msg("BRACKEN421_SQ_10_track3");
				break;
			case 26:
				await track.Dialog.Msg("BRACKEN421_SQ_10_track4");
				break;
			case 27:
				Send.ZC_NORMAL.SetupCutscene(character, false, false, true);
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
