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

[TrackScript("EP12_2_D_DCAPITAL_108_MQ10_TRACK")]
public class EP122DDCAPITAL108MQ10TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP12_2_D_DCAPITAL_108_MQ10_TRACK");
		//SetMap("d_dcapital_108");
		//CenterPos(1471.49,24.74,-603.26);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 150025, "", "d_dcapital_108", 1472.825, 24.74463, -656.0539, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 150240, "Mulia", "d_dcapital_108", 1483.164, 24.74463, -627.9187, 167.5);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 150212, "", "d_dcapital_108", 1495.105, 24.74463, -606.9205, 2.777778);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		character.Movement.MoveTo(new Position(1463.29f, 24.74463f, -590.267f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 5:
				//DRT_SETPOS();
				break;
			case 11:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ10_TRACK_DLG_01");
				break;
			case 12:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic058_violet_debuff", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("I_smoke001_dark", "MID", 0);
				//DRT_RUN_FUNCTION("EP12_2_F_CASTLE_101_MQ_HEADONICON_02");
				//DRT_ACTOR_PLAY_EFT("I_smoke008_red_noloop", "BOT", 0);
				break;
			case 26:
				//DRT_ACTOR_ATTACH_EFFECT("I_pattern007_explosion_mash_violet", "TOP");
				break;
			case 27:
				//DRT_ACTOR_ATTACH_EFFECT("F_light115_explosion_blue3", "MID");
				break;
			case 28:
				//DRT_ACTOR_ATTACH_EFFECT("F_light110_pink_ground_blood", "BOT");
				break;
			case 31:
				Send.ZC_NORMAL.Notice(character, "EP12_2_D_DCAPITAL_108_MQ10_TRACK_DLG_04", 2);
				break;
			case 32:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ10_TRACK_DLG_02");
				break;
			case 33:
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion106_dust", "BOT");
				break;
			case 44:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in030_black_loop", "MID");
				break;
			case 50:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_out061_darkred", "BOT");
				break;
			case 51:
				//DRT_ACTOR_ATTACH_EFFECT("F_blood002_dark", "MID");
				break;
			case 90:
				Send.ZC_NORMAL.Notice(character, "EP12_2_D_DCAPITAL_108_MQ10_TRACK_DLG_03", 3);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
