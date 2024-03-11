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

[TrackScript("EP12_2_D_DCAPITAL_108_MQ03_TRACK")]
public class EP122DDCAPITAL108MQ03TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP12_2_D_DCAPITAL_108_MQ03_TRACK");
		//SetMap("d_dcapital_108");
		//CenterPos(-439.79,24.74,-616.08);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 150240, "Mulia", "d_dcapital_108", -480.3764, 24.74463, -615.8408, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 153042, "", "d_dcapital_108", -510.9339, 24.74463, -649.8421, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 150212, "", "d_dcapital_108", -445.834, 24.74463, -647.9184, 27.85714);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		character.Movement.MoveTo(new Position(-439.6078f, 24.74463f, -616.3605f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 11:
				//DRT_SETPOS();
				break;
			case 13:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ03_TRACK_DLG_03");
				break;
			case 14:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ03_TRACK_DLG_04");
				break;
			case 15:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ03_TRACK_DLG_05");
				break;
			case 16:
				//DRT_RUN_FUNCTION("EP12_2_F_CASTLE_101_MQ_HEADONICON_02");
				//DRT_ACTOR_PLAY_EFT("F_buff_basic058_violet_debuff", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("I_smoke001_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("I_smoke008_red_noloop", "BOT", 0);
				break;
			case 21:
				//DRT_ACTOR_ATTACH_EFFECT("F_wizard_HoleOfDarkness", "BOT");
				break;
			case 26:
				//DRT_ACTOR_ATTACH_EFFECT("F_pc_SummonRemove_mon", "BOT");
				break;
			case 30:
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion105_blood", "BOT");
				break;
			case 33:
				//DRT_ACTOR_ATTACH_EFFECT("I_spread_in001_dark2", "BOT");
				break;
			case 34:
				//DRT_ACTOR_ATTACH_EFFECT("E_archer_DetonateTraps_explosion", "BOT");
				break;
			case 38:
				//DRT_ACTOR_ATTACH_EFFECT("F_wizard_RaiseSkullarcher_shot", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_light110_pink_ground_blood", "BOT");
				break;
			case 39:
				//DRT_ACTOR_ATTACH_EFFECT("I_emo_bleed", "BOT");
				break;
			case 43:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ03_TRACK_DLG_01");
				break;
			case 44:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ03_TRACK_DLG_02");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
