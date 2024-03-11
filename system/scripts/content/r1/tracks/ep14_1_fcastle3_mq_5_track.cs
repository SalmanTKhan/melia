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

[TrackScript("EP14_1_FCASTLE3_MQ_5_TRACK")]
public class EP141FCASTLE3MQ5TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP14_1_FCASTLE3_MQ_5_TRACK");
		//SetMap("ep14_1_f_castle_3");
		//CenterPos(-1764.07,93.08,848.94);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-1764.067f, 93.07774f, 848.937f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 157115, "", "ep14_1_f_castle_3", -1728.974, 93.07773, 920.595, 42.72727, "Our_Forces");
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 59698, "", "ep14_1_f_castle_3", -1796.781, 93.07771, 791.4861, 71);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 59698, "", "ep14_1_f_castle_3", -1878.702, 93.07767, 699.0175, 59.5);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 59698, "", "ep14_1_f_castle_3", -1632.564, 93.0777, 839.2554, 96);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 59700, "", "ep14_1_f_castle_3", -1699.94, 93.07767, 773.301, 68.5);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 59700, "", "ep14_1_f_castle_3", -1660.207, 93.07768, 1038.39, 71.5);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 150274, "UnvisibleName", "ep14_1_f_castle_3", -1996.968, 93.07767, 945.0352, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 59698, "", "ep14_1_f_castle_3", -1968.74, 93.07767, 995.5701, 1.071429);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 59698, "", "ep14_1_f_castle_3", -1954.825, 93.07767, 1033.082, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 8:
				//DRT_PLAY_FORCE(0, 1, 2, "I_arrow008", "arrow_cast", "F_spark013", "arrow_blow", "FAST", 300, 0.5, 0, 0, 0, 0);
				break;
			case 9:
				//DRT_ACTOR_PLAY_EFT("I_emo_exclamation", "TOP", 0);
				//DRT_ACTOR_PLAY_EFT("I_emo_exclamation", "TOP", 0);
				break;
			case 11:
				//DRT_PLAY_FORCE(0, 1, 2, "I_arrow008", "arrow_cast", "F_spark013", "arrow_blow", "FAST", 300, 0.5, 0, 0, 0, 0);
				break;
			case 33:
				break;
			case 59:
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_smoke068_dark", "MID", 0);
				break;
			case 65:
				await track.Dialog.Msg("EP14_1_FCASTLE3_MQ_5_TRACK_DLG1");
				break;
			case 74:
				CreateBattleBoxInLayer(character, track);
				//TRACK_SETTENDENCY();
				//DRT_PLAY_MGAME("EP14_1_FCASTLE3_MQ_5_MGAME");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
