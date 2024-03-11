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

[TrackScript("CASTLE102_MQ_01_TRACK")]
public class CASTLE102MQ01TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CASTLE102_MQ_01_TRACK");
		//SetMap("f_castle_102");
		//CenterPos(-1469.97,240.43,-1618.77);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-1467.456f, 240.429f, -1621.699f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 151041, "", "f_castle_102", -1506, 240, -1612, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 154066, "", "f_castle_102", -1479.95, 240.43, -1583.52, 4.583333);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 154102, "", "f_castle_102", -1479.95, 240.43, -1583.52, 0);
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
			case 7:
				await track.Dialog.Msg("CASTLE102_MQ_01_DLG02");
				break;
			case 11:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line_2", "BOT", 0);
				break;
			case 12:
				break;
			case 17:
				await track.Dialog.Msg("CASTLE102_MQ_01_DLG03");
				break;
			case 20:
				await track.Dialog.Msg("CASTLE102_MQ_01_DLG04");
				break;
			case 23:
				await track.Dialog.Msg("CASTLE102_MQ_01_DLG05");
				break;
			case 26:
				await track.Dialog.Msg("CASTLE102_MQ_01_DLG06");
				break;
			case 59:
				await track.Dialog.Msg("CASTLE102_MQ_01_DLG07");
				break;
			case 64:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line_2", "BOT", 0);
				break;
			case 74:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
