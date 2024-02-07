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

[TrackScript("EP14_2_DCASTLE2_MQ_10_TRACK")]
public class EP142DCASTLE2MQ10TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP14_2_DCASTLE2_MQ_10_TRACK");
		//SetMap("ep14_2_d_castle_2");
		//CenterPos(-373.18,68.03,644.12);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-352.6453f, 68.03178f, 635.6619f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 59657, "", "ep14_2_d_castle_2", 34.58098, 68.03178, 633.0087, 1.097561);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 157115, "", "ep14_2_d_castle_2", -404.5669, 68.03178, 662.9742, 98.66666);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 150287, "", "ep14_2_d_castle_2", -401.1383, 68.03178, 603.5173, 94);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 59755, "", "ep14_2_d_castle_2", 110.5414, 68.03178, 622.7532, 15.78947);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 19:
				break;
			case 21:
				await track.Dialog.Msg("EP14_2_DCASTLE2_MQ_10_DLG1");
				break;
			case 27:
				//DRT_SETPOS();
				break;
			case 29:
				await track.Dialog.Msg("EP14_2_DCASTLE2_MQ_10_DLG2");
				break;
			case 35:
				break;
			case 47:
				await track.Dialog.Msg("EP14_2_DCASTLE2_MQ_10_DLG3");
				break;
			case 74:
				//DRT_PLAY_MGAME("EP14_2_DCASTLE2_MQ_10_MINI");
				CreateBattleBoxInLayer(character, track);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
