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

[TrackScript("F_MAPLE_24_1_MQ_02_TRACK")]
public class FMAPLE241MQ02TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_MAPLE_24_1_MQ_02_TRACK");
		//SetMap("f_maple_24_1");
		//CenterPos(418.87,1.03,1397.10);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(418.875f, 1.0349f, 1397.1f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 154011, "", "f_maple_24_1", 385.4157, 1.0349, 1393.367, 3.26087);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "f_maple_24_1", 488.5504, 1.0349, 1511.097, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 156158, "", "f_maple_24_1", 491.6804, 1.0349, 1510.158, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 156105, "마력이", "f_maple_24_1", 379.6719, 1.0349, 1362.789, 0);
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
				//DRT_ACTOR_PLAY_EFT("F_spread_in012_blue", "MID", 0);
				break;
			case 14:
				//DRT_ACTOR_PLAY_EFT("F_cleric_dodola_line", "BOT", 0);
				break;
			case 15:
				//DRT_ACTOR_PLAY_EFT("F_light039_yellow", "MID", 0);
				break;
			case 16:
				//DRT_ACTOR_ATTACH_EFFECT("F_light115_explosion_blue3", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_spin023", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_light066_yellow_loop", "BOT");
				break;
			case 17:
				//DRT_ACTOR_ATTACH_EFFECT("F_light078_holy_yellow_loop", "BOT");
				break;
			case 29:
				await track.Dialog.Msg("F_MAPLE_241_02_TRACK_DLG_01");
				break;
			case 31:
				await track.Dialog.Msg("F_MAPLE_241_02_TRACK_DLG_02");
				break;
			case 33:
				await track.Dialog.Msg("F_MAPLE_241_02_TRACK_DLG_03");
				break;
			case 37:
				//DRT_ACTOR_PLAY_EFT("F_light008_2", "BOT", 0);
				break;
			case 44:
				//DRT_FUNC_ACT("SCR_SSN_F_MAPLE_241_MQ_02_TRACK_AFTER_RUN");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
