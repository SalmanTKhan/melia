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

[TrackScript("EP16_1_F_NICOPOLIS_81_1_MQ_TRACK")]
public class EP161FNICOPOLIS811MQTRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP16_1_F_NICOPOLIS_81_1_MQ_TRACK");
		//SetMap("f_nicopolis_81_1");
		//CenterPos(1727.21,184.18,1365.49);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 150210, "", "f_nicopolis_81_1", 1690.079, 184.1819, 1343.137, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 156121, "", "f_nicopolis_81_1", 1688.89, 184.1819, 1416.957, 0.8333334);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 160046, "", "f_nicopolis_81_1", 1752.184, 184.1819, 1410.93, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 150206, "", "f_nicopolis_81_1", 1750.309, 184.1819, 1354.333, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 154120, "", "f_nicopolis_81_1", 1640.112, 184.1819, 1518.397, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 1:
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup022_dark#npc_Baiga", "BOT");
				break;
			case 5:
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup017_violet#npc_kartas", "BOT");
				break;
			case 9:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground043_lineup#npc_baubas", "BOT");
				break;
			case 13:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground158_light_red2#Bip01#1", "BOT");
				break;
			case 16:
				//DRT_RUN_FUNCTION("SCR_EP16_1_F_NICO_81_1_MQ_1_BAIGA_DLG");
				break;
			case 20:
				//DRT_RUN_FUNCTION("SCR_EP16_1_F_NICO_81_1_MQ_1_KARTAS_DLG");
				break;
			case 24:
				//DRT_RUN_FUNCTION("SCR_EP16_1_F_NICO_81_1_MQ_1_RAGANA_DLG");
				break;
			case 28:
				//DRT_RUN_FUNCTION("SCR_EP16_1_F_NICO_81_1_MQ_1_BAUBAS_DLG");
				break;
			case 32:
				//DRT_RUN_FUNCTION("SCR_EP16_1_F_NICO_81_1_MQ_1_RAGANA_DLG");
				break;
			case 36:
				//DRT_RUN_FUNCTION("SCR_EP16_1_F_NICO_81_1_MQ_1_BAUBAS_DLG");
				break;
			case 40:
				//DRT_RUN_FUNCTION("SCR_EP16_1_F_NICO_81_1_MQ_1_RAGANA_DLG");
				break;
			case 44:
				//DRT_RUN_FUNCTION("SCR_EP16_1_F_NICO_81_1_MQ_1_BAUBAS_DLG");
				break;
			case 48:
				//DRT_RUN_FUNCTION("SCR_EP16_1_F_NICO_81_1_MQ_1_RAGANA_DLG");
				break;
			case 52:
				//DRT_RUN_FUNCTION("SCR_EP16_1_F_NICO_81_1_MQ_1_BAUBAS_DLG");
				break;
			case 56:
				//DRT_RUN_FUNCTION("SCR_EP16_1_F_NICO_81_1_MQ_1_RAGANA_DLG");
				break;
			case 78:
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_basic025_white_line_2#npc_pajauta#1", "BOT");
				break;
			case 94:
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup022_dark_blue2#npc_Baiga", "BOT");
				break;
			case 99:
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup022_dark_blue2#npc_kartas", "BOT");
				break;
			case 104:
				//DRT_ACTOR_PLAY_EFT("F_lineup022_dark_blue2#npc_baubas", "BOT", 0);
				break;
			case 109:
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup022_dark_blue2#Dummy_root", "BOT");
				break;
			case 113:
				//DRT_RUN_FUNCTION("SCR_EP16_1_F_NICO_81_1_MQ_1_PAJAUTA_DLG");
				break;
			case 119:
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_basic025_white_line_2#npc_pajauta#1", "BOT");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
