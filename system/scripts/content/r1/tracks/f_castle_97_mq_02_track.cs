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

[TrackScript("F_CASTLE_97_MQ_02_TRACK")]
public class FCASTLE97MQ02TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_CASTLE_97_MQ_02_TRACK");
		//SetMap("f_castle_97");
		//CenterPos(-89.00,131.39,-643.36);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-100.1585f, 130.4319f, -636.2127f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 150210, "", "f_castle_97", 117.4391, 130.8587, -726.5541, 19);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 59325, "", "f_castle_97", -213.0964, 131.37, -705.2346, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 59325, "", "f_castle_97", -243.4096, 130.7509, -942.9863, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 59325, "", "f_castle_97", 4.777712, 131.2814, -736.967, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 59325, "", "f_castle_97", -29.02651, 130.7104, -957.5453, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 59364, "", "f_castle_97", -289.76, 131.0937, -810.6008, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 59364, "", "f_castle_97", 61.24167, 130.9718, -856.697, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "f_castle_97", 116.9875, 130.8616, -729.8416, 0);
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
			case 23:
				await track.Dialog.Msg("F_CASTLE_97_MQ_02_TRACK_DLG1");
				break;
			case 24:
				break;
			case 31:
				await track.Dialog.Msg("F_CASTLE_97_MQ_02_TRACK_DLG2");
				break;
			case 38:
				//DRT_ACTOR_PLAY_EFT("F_smoke068_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_smoke068_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_smoke068_dark", "BOT", 0);
				break;
			case 39:
				//DRT_ACTOR_PLAY_EFT("F_smoke068_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_smoke068_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_smoke068_dark", "BOT", 0);
				break;
			case 42:
				await track.Dialog.Msg("F_CASTLE_97_MQ_02_TRACK_DLG3");
				break;
			case 43:
				//DRT_ACTOR_PLAY_EFT("F_light139_2", "MID", 0);
				break;
			case 45:
				//DRT_ACTOR_PLAY_EFT("F_light139_2", "MID", 0);
				break;
			case 47:
				//DRT_ACTOR_PLAY_EFT("F_light139_2", "MID", 0);
				break;
			case 49:
				//DRT_ACTOR_PLAY_EFT("F_light139_2", "MID", 0);
				break;
			case 51:
				//DRT_ACTOR_PLAY_EFT("F_light139_2", "MID", 0);
				break;
			case 53:
				//DRT_ACTOR_PLAY_EFT("F_light139_3", "TOP", 0);
				break;
			case 57:
				//TRACK_SETTENDENCY();
				break;
			case 58:
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			case 59:
				//DRT_PLAY_MGAME("F_CASTLE_97_MQ_02_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
