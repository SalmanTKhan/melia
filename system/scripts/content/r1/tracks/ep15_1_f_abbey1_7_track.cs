using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.Scripting;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.Effects;
using Melia.Zone.World.Tracks;
using Yggdrasil.Logging;

[TrackScript("EP15_1_F_ABBEY1_7_TRACK")]
public class EP151FABBEY17TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP15_1_F_ABBEY1_7_TRACK");
		//SetMap("None");
		//CenterPos(-930.58,48.10,1358.37);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 153119, "", "None", -897.1328, 48.09714, 1364.114, 28.88889);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 59657, "", "None", -838.4641, 48.09714, 1258.821, 43.75);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 12082, "", "None", -903.9329, 48.09714, 1323.121, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 4:
				await track.Dialog.Msg("EP15_1_F_ABBEY1_7_DLG2");
				break;
			case 7:
				await track.Dialog.Msg("EP15_1_F_ABBEY1_7_DLG3");
				break;
			case 10:
				await track.Dialog.Msg("EP15_1_F_ABBEY1_7_DLG4");
				break;
			case 17:
				break;
			case 25:
				await track.Dialog.Msg("EP15_1_F_ABBEY1_7_DLG5");
				break;
			case 30:
				await track.Dialog.Msg("EP15_1_F_ABBEY1_7_DLG6");
				break;
			case 34:
				await track.Dialog.Msg("EP15_1_F_ABBEY1_7_DLG7");
				break;
			case 35:
				break;
			case 45:
				await track.Dialog.Msg("EP15_1_F_ABBEY1_7_DLG8");
				break;
			case 60:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
