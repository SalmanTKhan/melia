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

[TrackScript("EP12_PRELUDE_09_TRACK")]
public class EP12PRELUDE09TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP12_PRELUDE_09_TRACK");
		//SetMap("f_dcapital_106");
		//CenterPos(-1195.46,0.22,-321.89);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-1195.46f, 0.2153931f, -321.8865f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 154102, "", "f_dcapital_106", -1400.155, 0.2153931, -258.9592, 50.37037);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 20040, "", "f_dcapital_106", -1404.74, 0.2153931, -254.6412, 101.8182);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 150206, "", "f_dcapital_106", -1622.415, 0.2153931, -214.4048, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 147382, "", "f_dcapital_106", -1588.16, 0.22, -159.63, 0);
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
			case 1:
				break;
			case 24:
				break;
			case 25:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line", "BOT", 0);
				break;
			case 27:
				break;
			case 40:
				await track.Dialog.Msg("EP12_PRELUDE_09_DLG02");
				break;
			case 47:
				break;
			case 55:
				//DRT_ACTOR_PLAY_EFT("F_light082_line_red", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_smoke023_red", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion046_red", "BOT", 0);
				break;
			case 60:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke_red2_loop", "MID");
				break;
			case 77:
				await track.Dialog.Msg("EP12_PRELUDE_09_DLG03");
				break;
			case 81:
				await track.Dialog.Msg("EP12_PRELUDE_09_DLG04");
				break;
			case 85:
				await track.Dialog.Msg("EP12_PRELUDE_09_DLG05");
				break;
			case 96:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic046_red", "BOT", 0);
				break;
			case 97:
				//DRT_ACTOR_ATTACH_EFFECT("E_magic_prison", "BOT");
				break;
			case 101:
				//DRT_ACTOR_PLAY_EFT("F_pattern015_white", "BOT", 0);
				break;
			case 109:
				//DRT_ACTOR_PLAY_EFT("F_archer_TripleArrow_hit_explosion", "BOT", 0);
				break;
			case 110:
				//DRT_ACTOR_PLAY_EFT("F_archer_Matross_CanisterShot_explosion", "BOT", 0);
				break;
			case 125:
				await track.Dialog.Msg("EP12_PRELUDE_09_DLG06");
				break;
			case 128:
				//DRT_ACTOR_PLAY_EFT("F_spread_in002_red", "BOT", 0);
				break;
			case 134:
				await track.Dialog.Msg("EP12_PRELUDE_09_DLG07");
				break;
			case 142:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic045_red", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_buff_basic046_red", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("I_spread_out011_dark", "BOT", 0);
				break;
			case 144:
				await track.Dialog.Msg("EP12_PRELUDE_09_DLG08");
				break;
			case 146:
				await track.Dialog.Msg("EP12_PRELUDE_09_DLG09");
				break;
			case 148:
				await track.Dialog.Msg("EP12_PRELUDE_09_DLG10");
				break;
			case 152:
				await track.Dialog.Msg("EP12_PRELUDE_09_DLG11");
				break;
			case 180:
				await track.Dialog.Msg("EP12_PRELUDE_09_DLG12");
				break;
			case 182:
				await track.Dialog.Msg("EP12_PRELUDE_09_DLG13");
				break;
			case 185:
				await track.Dialog.Msg("EP12_PRELUDE_09_DLG14");
				break;
			case 215:
				await track.Dialog.Msg("EP12_PRELUDE_09_DLG15");
				break;
			case 217:
				//DRT_ACTOR_PLAY_EFT("F_light082_line_red", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_smoke023_red", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion046_red", "BOT", 0);
				break;
			case 236:
				await track.Dialog.Msg("EP12_PRELUDE_09_DLG16");
				break;
			case 238:
				//DRT_ACTOR_PLAY_EFT("I_spread_out011_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_buff_basic045_red", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_buff_basic046_red", "BOT", 0);
				break;
			case 246:
				character.AddonMessage("NOTICE_Dm_Clear", "[Demon God Ragana(2)]{nl}Completed!", 10);
				break;
			case 248:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
