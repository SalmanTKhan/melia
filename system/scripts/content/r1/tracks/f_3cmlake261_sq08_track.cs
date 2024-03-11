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

[TrackScript("F_3CMLAKE261_SQ08_TRACK")]
public class F3CMLAKE261SQ08TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_3CMLAKE261_SQ08_TRACK");
		//SetMap("f_3cmlake_26_1");
		//CenterPos(77.56,-122.03,-1073.88);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 147382, "", "f_3cmlake_26_1", 79, -122, -1054, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 105000, "", "f_3cmlake_26_1", -26.66165, -122.0254, -1070.578, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		character.Movement.MoveTo(new Position(77.45147f, -122.0254f, -1079.948f));
		actors.Add(character);

		var mob2 = Shortcuts.AddMonster(0, 20042, "", "f_3cmlake_26_1", -33.23584, -122.0254, -1061.918, 0);
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
			case 10:
				//DRT_ACTOR_ATTACH_EFFECT("I_levitation001_dark_mint", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_item_drop_line_loop_green", "TOP");
				break;
			case 27:
				//DRT_ACTOR_PLAY_EFT("I_smoke053_mint_loop", "MID", 0);
				break;
			case 28:
				//DRT_ACTOR_PLAY_EFT("I_smoke045_spread_in_loop", "MID", 0);
				break;
			case 30:
				//DRT_ACTOR_PLAY_EFT("F_explosion98_rize_green", "BOT", 0);
				break;
			case 31:
				//DRT_ACTOR_PLAY_EFT("F_lineup017_mintdark", "BOT", 0);
				break;
			case 32:
				break;
			case 33:
				//DRT_ACTOR_PLAY_EFT("F_lineup017_mintdark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_out045_green", "BOT", 0);
				break;
			case 44:
				await track.Dialog.Msg("3CMLAKE261_SQ08_DLG03");
				break;
			case 48:
				await track.Dialog.Msg("3CMLAKE261_SQ08_DLG04");
				break;
			case 52:
				await track.Dialog.Msg("3CMLAKE261_SQ08_DLG05");
				break;
			case 85:
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_basic045_red", "MID");
				break;
			case 86:
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_basic046_red", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("I_spread_out011_dark", "MID");
				break;
			case 118:
				//DRT_ACTOR_PLAY_EFT("F_spread_out045_green", "MID", 0);
				break;
			case 119:
				//DRT_ACTOR_PLAY_EFT("F_spread_out045_green", "MID", 0);
				break;
			case 124:
				//TRACK_SETTENDENCY();
				//CREATE_BATTLE_BOX_INLAYER(20);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
