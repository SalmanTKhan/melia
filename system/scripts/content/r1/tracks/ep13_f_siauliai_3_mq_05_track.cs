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

[TrackScript("EP13_F_SIAULIAI_3_MQ_05_TRACK")]
public class EP13FSIAULIAI3MQ05TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP13_F_SIAULIAI_3_MQ_05_TRACK");
		//SetMap("ep13_f_siauliai_3");
		//CenterPos(596.93,209.72,704.00);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(605.0018f, 209.7152f, 707.0746f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 150210, "", "ep13_f_siauliai_3", 555.8925, 209.7152, 708.8471, 85);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 150210, "", "ep13_f_siauliai_3", 644.0471, 209.7152, 712.3597, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 151020, "", "ep13_f_siauliai_3", 645.5356, 209.7152, 711.1401, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 151020, "", "ep13_f_siauliai_3", 599.0588, 209.7152, 708.0462, 0);
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
			case 20:
				//DRT_ACTOR_PLAY_EFT("F_smoke029_violet", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_light139_2", "BOT", 0);
				break;
			case 21:
				//DRT_ACTOR_PLAY_EFT("F_explosion037_violet", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_smoke072_sviolet", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_light139_2", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("I_dash001_violet", "MID", 0);
				break;
			case 35:
				await track.Dialog.Msg("EP13_F_SIAULIAI_3_MQ_05_DLG_T1");
				break;
			case 40:
				//DRT_ACTOR_PLAY_EFT("F_light139_2", "BOT", 0);
				break;
			case 42:
				//DRT_ACTOR_PLAY_EFT("F_light139_2", "BOT", 0);
				break;
			case 44:
				//DRT_ACTOR_PLAY_EFT("F_light139_2", "BOT", 0);
				break;
			case 46:
				//DRT_ACTOR_PLAY_EFT("F_light139_2", "BOT", 0);
				break;
			case 48:
				//DRT_ACTOR_PLAY_EFT("F_light139_2", "BOT", 0);
				break;
			case 50:
				//DRT_ACTOR_PLAY_EFT("F_light139_2", "BOT", 0);
				break;
			case 54:
				//TRACK_BASICLAYER_MOVE();
				Send.ZC_NORMAL.Notice(character, "EP13_F_SIAULIAI_3_MQ_05_DLG_T2", 5);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
