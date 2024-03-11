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

[TrackScript("EP15_1_F_ABBEY1_2_TRACK")]
public class EP151FABBEY12TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP15_1_F_ABBEY1_2_TRACK");
		//SetMap("None");
		//CenterPos(88.09,7.40,48.15);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 150238, "", "None", 43.59443, 21.61584, -20.87431, 1.428571);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 47236, "", "None", 46.70646, 21.46089, 11.54414, 3.125);
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
			case 7:
				await track.Dialog.Msg("EP15_1_F_ABBEY1_2_DLG3");
				break;
			case 12:
				await track.Dialog.Msg("EP15_1_F_ABBEY1_2_DLG4");
				break;
			case 20:
				//TRACK_BASICLAYER_MOVE();
				//DRT_FUNC_ACT("EP15_1_ABBEY1_WARP2");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
