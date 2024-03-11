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

[TrackScript("EP12_2_D_DCAPITAL_108_MQ07_TRACK")]
public class EP122DDCAPITAL108MQ07TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP12_2_D_DCAPITAL_108_MQ07_TRACK");
		//SetMap("d_dcapital_108");
		//CenterPos(-488.65,24.74,-580.08);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 153042, "", "d_dcapital_108", -511.8672, 24.74463, -649.0376, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 150240, "Mulia", "d_dcapital_108", -472.9582, 24.74463, -612.7344, 65);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 150212, "", "d_dcapital_108", -500.311, 24.74463, -608.4357, 110);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		character.Movement.MoveTo(new Position(-464.2013f, 24.74463f, -650.9686f));
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
				//DRT_RUN_FUNCTION("EP12_2_F_CASTLE_101_MQ_HEADONICON_02");
				//DRT_ACTOR_PLAY_EFT("F_buff_basic058_violet_debuff", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("I_smoke001_dark", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("I_smoke008_red_noloop", "BOT", 0);
				break;
			case 14:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in032_dark_loop2_violet", "BOT");
				break;
			case 19:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground043_lineup", "BOT");
				break;
			case 31:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground004_violet", "BOT");
				break;
			case 32:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground009", "BOT");
				break;
			case 33:
				//DRT_ACTOR_ATTACH_EFFECT("I_force018_trail_black3", "BOT");
				break;
			case 57:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ07_TRACK_DLG_01");
				break;
			case 64:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ07_TRACK_DLG_02");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
