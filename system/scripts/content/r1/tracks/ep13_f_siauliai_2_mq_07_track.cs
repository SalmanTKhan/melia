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

[TrackScript("EP13_F_SIAULIAI_2_MQ_07_TRACK")]
public class EP13FSIAULIAI2MQ07TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP13_F_SIAULIAI_2_MQ_07_TRACK");
		//SetMap("None");
		//CenterPos(546.53,183.66,575.52);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(587.843f, 183.6621f, 481.0889f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 150247, "", "None", 486.5073, 183.6621, 572.1566, 1.532258);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var npc0 = Shortcuts.AddNpc(0, 161025, "UnvisibleName", "None", 488.9363, 183.6621, 572.6686, 0);
		npc0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc0.AddEffect(new ScriptInvisibleEffect());
		npc0.Layer = character.Layer;
		actors.Add(npc0);

		var mob1 = Shortcuts.AddMonster(0, 59580, "", "None", 866.5079, 183.6621, 422.7538, 65.27778);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 59581, "", "None", 782.806, 183.6621, 332.0399, 72.8125);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 59582, "", "None", 896.7042, 183.6621, 335.4173, 71.11111);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 59581, "", "None", 895.0026, 183.6621, 257.4801, 71.33334);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 59580, "", "None", 999.8335, 183.6621, 333.6724, 75.58823);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 150242, "", "None", 546.6674, 183.6621, 618.2938, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 151019, "UnvisibleName", "None", 546.3075, 183.6621, 617.9784, 0);
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
				//DRT_ACTOR_PLAY_EFT("I_smoke012_dark", "TOP", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark013", "MID", 0);
				break;
			case 16:
				//DRT_ACTOR_PLAY_EFT("I_smoke012_dark", "TOP", 0);
				break;
			case 17:
				//DRT_ACTOR_PLAY_EFT("I_smoke012_dark", "TOP", 0);
				break;
			case 18:
				//DRT_ACTOR_PLAY_EFT("I_smoke012_dark", "TOP", 0);
				break;
			case 19:
				//DRT_ACTOR_PLAY_EFT("I_smoke012_dark", "TOP", 0);
				break;
			case 20:
				//DRT_ACTOR_PLAY_EFT("I_smoke012_dark", "TOP", 0);
				break;
			case 21:
				//DRT_ACTOR_PLAY_EFT("I_smoke012_dark", "TOP", 0);
				break;
			case 22:
				//DRT_ACTOR_PLAY_EFT("I_smoke012_dark", "TOP", 0);
				break;
			case 23:
				//DRT_ACTOR_PLAY_EFT("I_smoke012_dark", "TOP", 0);
				break;
			case 30:
				//DRT_ACTOR_PLAY_EFT("F_explosion099_dark", "TOP", 0);
				break;
			case 33:
				character.AddonMessage("NOTICE_Dm_scroll", "The Black Crystal is going crazy!", 3);
				break;
			case 40:
				break;
			case 61:
				//DRT_ACTOR_PLAY_EFT("I_smoke062_fire_yellow", "TOP", 0);
				//DRT_ACTOR_PLAY_EFT("F_burstup057_yellow", "BOT", 0);
				break;
			case 62:
				break;
			case 66:
				await track.Dialog.Msg("EP13_F_SIAULIAI_2_MQ_07_DLG_T1");
				break;
			case 71:
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation005_yellow2", "BOT");
				break;
			case 76:
				//DRT_ACTOR_ATTACH_EFFECT("F_light166_white_loop", "TOP");
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation006_loop", "TOP");
				break;
			case 79:
				CreateBattleBoxInLayer(character, track);
				//TRACK_SETTENDENCY();
				//DRT_PLAY_MGAME("EP13_F_SIAULIAI_2_MQ_07_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
