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

[TrackScript("EP12_2_D_DCAPITAL_108_MQ15_TRACK")]
public class EP122DDCAPITAL108MQ15TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP12_2_D_DCAPITAL_108_MQ15_TRACK");
		//SetMap("None");
		//CenterPos(2235.93,24.74,346.74);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 150212, "", "None", 2245.254, 24.74463, 368.3394, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 150240, "Mulia", "None", 2277.1, 24.74463, 351.7462, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 153188, "", "None", 2253.392, 24.74463, 333.2121, 44.5122);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 59508, "", "None", 2440.789, 24.74463, 145.2168, 111);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		character.Movement.MoveTo(new Position(2221.04f, 24.74463f, 360.3331f));
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
			case 8:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ15_TRACK_DLG_01");
				break;
			case 9:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic058_violet_debuff", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("I_smoke001_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("I_smoke008_red_noloop", "BOT", 0);
				//DRT_RUN_FUNCTION("EP12_2_F_CASTLE_101_MQ_HEADONICON_02");
				break;
			case 24:
				//DRT_ACTOR_ATTACH_EFFECT("F_pc_SummonRemove_mon", "BOT");
				break;
			case 27:
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion105_blood", "BOT");
				break;
			case 31:
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion132_white_black", "BOT");
				break;
			case 32:
				//DRT_ACTOR_ATTACH_EFFECT("I_cylinder010_light_dark", "BOT");
				break;
			case 33:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_out033_ground_light", "BOT");
				break;
			case 34:
				//DRT_ACTOR_ATTACH_EFFECT("I_pattern007_explosion_mash_violet", "BOT");
				break;
			case 39:
				//DRT_ACTOR_PLAY_EFT("F_explosion079_blood2", "MID", 0);
				break;
			case 40:
				//DRT_ACTOR_PLAY_EFT("F_blood009_red", "MID", 0);
				break;
			case 59:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ15_TRACK_DLG_02");
				break;
			case 66:
				break;
			case 71:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ15_TRACK_DLG_03");
				break;
			case 82:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ15_TRACK_DLG_04");
				break;
			case 149:
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
