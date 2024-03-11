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

[TrackScript("CASTLE102_MQ_04_TRACK")]
public class CASTLE102MQ04TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CASTLE102_MQ_04_TRACK");
		//SetMap("f_castle_102");
		//CenterPos(-1079.47,52.90,597.62);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 150215, "", "f_castle_102", -1090.85, 52.90469, 669.7462, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(-1079.474f, 52.90468f, 597.619f));
		actors.Add(character);

		var mob1 = Shortcuts.AddMonster(0, 20042, "UnvisibleName", "f_castle_102", -1178.185, 52.90469, 488.4471, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 20042, "UnvisibleName", "f_castle_102", -1055.732, 52.90468, 462.3493, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 20042, "UnvisibleName", "f_castle_102", -970.3571, 52.90469, 528.9345, 0);
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
			case 2:
				//DRT_ACTOR_ATTACH_EFFECT("I_harfsphere002_blue_loop", "BOT");
				break;
			case 9:
				await track.Dialog.Msg("CASTLE102_MQ_04_DLG02");
				break;
			case 13:
				//DRT_ACTOR_PLAY_EFT("F_bubble005_white", "BOT", 0);
				break;
			case 19:
				//DRT_ACTOR_PLAY_EFT("F_lineup020_blue_mint", "BOT", 0);
				break;
			case 26:
				break;
			case 31:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup004_dark_loop", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup004_dark_loop", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup004_dark_loop", "BOT");
				break;
			case 50:
				await track.Dialog.Msg("CASTLE102_MQ_04_DLG03");
				break;
			case 52:
				//DRT_ACTOR_PLAY_EFT("F_burstup001_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_burstup001_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_burstup001_dark", "BOT", 0);
				break;
			case 61:
				//DRT_PLAY_MGAME("CASTLE102_MQ_04_MINI");
				CreateBattleBoxInLayer(character, track);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
