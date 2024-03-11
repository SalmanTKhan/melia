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

[TrackScript("EP15_1_F_ABBEY3_5_1_TRACK")]
public class EP151FABBEY351TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP15_1_F_ABBEY3_5_1_TRACK");
		//SetMap("ep15_1_f_abbey_3");
		//CenterPos(754.12,5.92,-599.06);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(748.2551f, 5.917992f, -590.3834f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 160144, "", "ep15_1_f_abbey_3", 780.2173, 5.917992, -579.6066, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 12082, "", "ep15_1_f_abbey_3", 783.4212, 5.917992, -584.2032, 0);
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
			case 20:
				//DRT_FUNC_ACT("SCR_EP15_1_F_ABBEY3_MQ05_TRACK_DLG1");
				break;
			case 22:
				await track.Dialog.Msg("EP15_1_F_ABBEY_3_5_DLG2");
				break;
			case 23:
				break;
			case 40:
				await track.Dialog.Msg("EP15_1_F_ABBEY3_5_DLG3");
				break;
			case 43:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
