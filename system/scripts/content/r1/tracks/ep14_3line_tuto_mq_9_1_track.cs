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

[TrackScript("EP14_3LINE_TUTO_MQ_9_1_TRACk")]
public class EP143LINETUTOMQ91TRACk : TrackScript
{
	protected override void Load()
	{
		SetId("EP14_3LINE_TUTO_MQ_9_1_TRACk");
		//SetMap("c_klaipe_castle");
		//CenterPos(3776.05,1.00,550.96);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(3775.008f, 1f, 557.7786f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 57185, "숨어든", "c_klaipe_castle", 3782.198, 1, 623.5275, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.Journal = false;
		mob0.Level = 440;
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 153109, "", "c_klaipe_castle", 3773.285, 1, 624.8038, 0);
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
			case 9:
				await track.Dialog.Msg("EP14_3LINE_TUTO_MQ_9_1_TRACK_DLG_1");
				break;
			case 16:
				//DRT_ACTOR_PLAY_EFT("F_rize007", "BOT", 0);
				break;
			case 17:
				//DRT_ACTOR_PLAY_EFT("F_rize007", "BOT", 0);
				break;
			case 24:
				CreateBattleBoxInLayer(character, track);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
