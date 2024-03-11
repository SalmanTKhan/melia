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

[TrackScript("D_CASTLE_19_1_MQ_05_TRACK")]
public class DCASTLE191MQ05TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("D_CASTLE_19_1_MQ_05_TRACK");
		//SetMap("d_castle_19_1");
		//CenterPos(-1005.18,-4.55,-522.17);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-998.3268f, -4.553869f, -519.8334f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 59351, "", "d_castle_19_1", -528.7474, 19.42841, -553.6968, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 59351, "", "d_castle_19_1", -570.1927, 19.42841, -560.6613, 207.8571);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 59363, "", "d_castle_19_1", -542.0192, 21.19389, -418.2434, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 59363, "", "d_castle_19_1", -498.7896, 21.18546, -405.0925, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 59362, "", "d_castle_19_1", -502.9851, 20.27451, -446.9254, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 59351, "", "d_castle_19_1", -551.516, 19.42841, -527.1334, 9.75);
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
			case 1:
				//DRT_ACTOR_PLAY_EFT("F_ground139_light_orange", "BOT", 0);
				break;
			case 18:
				//DRT_ACTOR_PLAY_EFT("I_emo_exclamation", "TOP", 0);
				break;
			case 19:
				//DRT_ACTOR_PLAY_EFT("I_emo_exclamation", "TOP", 0);
				//DRT_ACTOR_PLAY_EFT("I_emo_exclamation", "TOP", 0);
				break;
			case 20:
				//DRT_ACTOR_PLAY_EFT("I_emo_exclamation", "TOP", 0);
				//DRT_ACTOR_PLAY_EFT("I_emo_exclamation", "TOP", 0);
				break;
			case 21:
				//DRT_ACTOR_PLAY_EFT("I_emo_exclamation", "TOP", 0);
				break;
			case 34:
				//DRT_PLAY_MGAME("D_CASTLE_19_1_MQ_05_MINI");
				CreateBattleBoxInLayer(character, track);
				character.AddonMessage("NOTICE_Dm_scroll", "Defeat at least 20 demons in time!", 7);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
