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

[TrackScript("LIMESTONE_52_5_MQ_7_TRACK")]
public class LIMESTONE525MQ7TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("LIMESTONE_52_5_MQ_7_TRACK");
		//SetMap("d_limestonecave_52_5");
		//CenterPos(1354.12,716.60,1059.67);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 152075, "", "d_limestonecave_52_5", 1343.897, 719.4183, 1070.961, 30);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 57581, "", "d_limestonecave_52_5", 1349.951, 719.4183, 1013.206, 2.083333);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		character.Movement.MoveTo(new Position(1376.925f, 716.8932f, 1038.611f));
		actors.Add(character);

		var mob2 = Shortcuts.AddMonster(0, 107016, "", "d_limestonecave_52_5", 1392.943, 716.6125, 1019.955, 4.411765);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 20025, "", "d_limestonecave_52_5", 1392.449, 716.6125, 1022.623, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 20025, "", "d_limestonecave_52_5", 1333.195, 727.3881, 1079.089, 0);
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
			case 5:
				await track.Dialog.Msg("LIMESTONE_52_5_MQ_7_TRACK_1");
				break;
			case 7:
				//DRT_ACTOR_ATTACH_EFFECT("F_light096_red_loop", "BOT");
				break;
			case 9:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup007_dark", "BOT");
				break;
			case 14:
				await track.Dialog.Msg("LIMESTONE_52_5_MQ_7_TRACK_2");
				break;
			case 24:
				//DRT_ACTOR_PLAY_EFT("F_explosion102_red_event", "BOT", 0);
				break;
			case 27:
				await track.Dialog.Msg("LIMESTONE_52_5_MQ_7_TRACK_3");
				break;
			case 28:
				//CREATE_BATTLE_BOX_INLAYER(0);
				character.AddonMessage("NOTICE_Dm_scroll", "Gesti is enraged to see you{nl}Prepare for battle!", 8);
				break;
			case 29:
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
