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

[TrackScript("TABLELAND_11_1_SQ_08_TRACK")]
public class TABLELAND111SQ08TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("TABLELAND_11_1_SQ_08_TRACK");
		//SetMap("f_tableland_11_1");
		//CenterPos(-76.38,56.16,455.31);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-76.37556f, 56.15952f, 455.3054f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 156019, "", "f_tableland_11_1", 20.96467, 56.15952, 595.6443, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 156021, "", "f_tableland_11_1", 25.84035, 56.15952, 650.2529, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 20025, "UnvisibleName", "f_tableland_11_1", 24.51203, 56.15952, 621.5686, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 156022, "", "f_tableland_11_1", -168.2254, 56.15952, 711.4156, 19.28572);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 156020, "", "f_tableland_11_1", -96.10724, 56.15952, 436.5489, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 58295, "", "f_tableland_11_1", -124.587, 56.15952, 663.2802, 72);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 14:
				await track.Dialog.Msg("TABLELAND_11_1_SQ_08_TRACK01");
				break;
			case 18:
				CreateBattleBoxInLayer(character, track);
				break;
			case 24:
				break;
			case 33:
				//DRT_ACTOR_PLAY_EFT("F_ground092_red", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("F_ground12_red", "BOT");
				break;
			case 37:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force029_red", "arrow_cast", "None", "arrow_blow", "SLOW", 50, 1, 0, 5, 10, 0);
				break;
			case 38:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force029_red", "arrow_cast", "None", "arrow_blow", "SLOW", 50, 1, 0, 5, 10, 0);
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke019_dark", "BOT");
				break;
			case 39:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force029_red", "arrow_cast", "F_explosion099_red", "arrow_blow", "SLOW", 50, 1, 0, 5, 10, 0);
				break;
			case 44:
				break;
			case 46:
				character.AddonMessage("NOTICE_Dm_!", "Faustas mutated the corpse of Adomas into a monster!", 3);
				break;
			case 47:
				//DRT_ACTOR_PLAY_EFT("F_burstup031_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_levitation027_dark_red", "BOT", 0);
				break;
			case 48:
				await track.Dialog.Msg("TABLELAND_11_1_SQ_08_TRACK_02");
				//DRT_ACTOR_ATTACH_EFFECT("F_light096_red_loop2", "MID");
				break;
			case 52:
				character.AddonMessage("NOTICE_Dm_scroll", "It seems that a confrontation is inevitable{nl}Defeat the mutated Adomas!", 5);
				//TRACK_SETTENDENCY();
				break;
			case 53:
				//DRT_ACTOR_PLAY_EFT("F_levitation027_dark_red", "BOT", 0);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
