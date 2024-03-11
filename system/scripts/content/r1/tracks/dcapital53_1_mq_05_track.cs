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

[TrackScript("DCAPITAL53_1_MQ_05_TRACK")]
public class DCAPITAL531MQ05TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("DCAPITAL53_1_MQ_05_TRACK");
		//SetMap("f_desolated_capital_53_1");
		//CenterPos(982.22,230.15,3114.23);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 47150, "", "f_desolated_capital_53_1", 1172, 207, 3246, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(982.2195f, 230.1453f, 3114.226f));
		actors.Add(character);

		var mob1 = Shortcuts.AddMonster(0, 20041, "", "f_desolated_capital_53_1", 1122.75, 207.5137, 3197.107, 36.42857);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 105031, "", "f_desolated_capital_53_1", 1107.719, 207.5137, 3240.618, 0);
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
			case 20:
				//DRT_ACTOR_PLAY_EFT("F_smoke071_stone", "BOT", 0);
				break;
			case 22:
				//DRT_ACTOR_PLAY_EFT("F_stone005", "BOT", 0);
				break;
			case 24:
				//DRT_ACTOR_PLAY_EFT("F_smoke071_stone", "BOT", 0);
				break;
			case 26:
				//DRT_ACTOR_PLAY_EFT("F_smoke129_spreadout", "BOT", 0);
				break;
			case 27:
				break;
			case 29:
				//DRT_ACTOR_PLAY_EFT("F_smoke129_spreadout", "BOT", 0);
				break;
			case 30:
				//DRT_ACTOR_PLAY_EFT("F_spread_out014_smoke", "BOT", 0);
				break;
			case 37:
				//DRT_ACTOR_PLAY_EFT("F_spread_out013_smoke", "BOT", 0);
				break;
			case 42:
				//DRT_RUN_FUNCTION("SCR_DCAPITAL_53_1_MQ_05_BOSS_SET");
				break;
			case 46:
				character.AddonMessage("NOTICE_Dm_!", "Commander Wooden Centurion has appeared in your way!{nl}Defeat Commander Wooden Centurion to destroy the idol!", 5);
				break;
			case 49:
				//TRACK_SETTENDENCY();
				CreateBattleBoxInLayer(character, track);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
