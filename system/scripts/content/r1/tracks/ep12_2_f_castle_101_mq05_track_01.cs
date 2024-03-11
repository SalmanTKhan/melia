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

[TrackScript("EP12_2_F_CASTLE_101_MQ05_TRACK_01")]
public class EP122FCASTLE101MQ05TRACK01 : TrackScript
{
	protected override void Load()
	{
		SetId("EP12_2_F_CASTLE_101_MQ05_TRACK_01");
		//SetMap("f_castle_101");
		//CenterPos(-1067.13,52.93,-897.47);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-1067.133f, 52.92822f, -897.4721f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 150232, "", "f_castle_101", -1213.947, 52.92822, -751.3269, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 150230, "", "f_castle_101", -1040.583, 52.92822, -894.9716, 60);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 150212, "", "f_castle_101", -1037.987, 52.92822, -944.5194, 59.5);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 59523, "", "f_castle_101", -1082.191, 52.92822, -949.3666, 7.5);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 59523, "", "f_castle_101", -1140.72, 52.92822, -929.6404, 8.181818);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 59523, "", "f_castle_101", -1006.981, 52.92822, -879.3273, 8.409091);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 59523, "", "f_castle_101", -1024.768, 52.92822, -817.146, 5.227273);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 150216, "", "f_castle_101", -1115.736, 52.92822, -843.1074, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 15:
				//DRT_ACTOR_PLAY_EFT("I_burst_up_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("I_smoke013_dark", "MID", 0);
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke_red2_loop", "MID");
				break;
			case 22:
				break;
			case 24:
				await track.Dialog.Msg("EP12_2_F_CASTLE_101_MQ05_DLG_1");
				break;
			case 32:
				//DRT_ACTOR_PLAY_EFT("F_scout_barong_summons", "BOT", 0);
				break;
			case 39:
				//DRT_ACTOR_PLAY_EFT("F_scout_penyerapan001", "BOT", 0);
				break;
			case 50:
				//DRT_PLAY_MGAME("EP12_2_F_CASTLE_101_MQ05_MINI");
				break;
			case 54:
				CreateBattleBoxInLayer(character, track);
				//TRACK_SETTENDENCY();
				//DRT_RUN_FUNCTION("SCR_SUMMON_BARONG_02");
				//SetFixAnim("event_down");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
