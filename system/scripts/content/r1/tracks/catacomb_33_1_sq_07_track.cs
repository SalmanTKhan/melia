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

[TrackScript("CATACOMB_33_1_SQ_07_TRACK")]
public class CATACOMB331SQ07TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CATACOMB_33_1_SQ_07_TRACK");
		//SetMap("id_catacomb_33_1");
		//CenterPos(-113.03,186.44,170.32);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-113.0274f, 186.438f, 170.3154f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 152008, "", "id_catacomb_33_1", -202.1948, 186.438, 155.7829, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 156002, "", "id_catacomb_33_1", -29.52946, 168.3275, 331.3815, 245);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 58154, "", "id_catacomb_33_1", -202.0076, 186.438, 154.5136, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 7:
				await track.Dialog.Msg("CATACOMB_33_1_SQ_07_TRACK_01");
				break;
			case 15:
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation006_loop", "BOT");
				break;
			case 18:
				await track.Dialog.Msg("CATACOMB_33_1_SQ_07_TRACK_02");
				break;
			case 23:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line##10", "BOT", 0);
				break;
			case 24:
				character.AddonMessage("NOTICE_Dm_!", "The holy relic starts to fluctuate after hearing the sound of Juta's prayer!", 3);
				break;
			case 25:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in004_darkblue", "BOT");
				break;
			case 34:
				//DRT_ACTOR_PLAY_EFT("F_explosion079_blood", "BOT", 0);
				break;
			case 35:
				//DRT_ACTOR_PLAY_EFT("pilgrim_shrine_dead", "BOT", 0);
				break;
			case 45:
				//TRACK_SETTENDENCY();
				break;
			case 46:
				CreateBattleBoxInLayer(character, track);
				break;
			case 49:
				character.AddonMessage("NOTICE_Dm_!", "Defeat Abomination!", 3);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
