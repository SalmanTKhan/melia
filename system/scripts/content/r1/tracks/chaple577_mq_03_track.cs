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

[TrackScript("CHAPLE577_MQ_03_TRACK")]
public class CHAPLE577MQ03TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CHAPLE577_MQ_03_TRACK");
		//SetMap("d_chapel_57_7");
		//CenterPos(72.35,164.86,-595.12);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(119.0823f, 164.8735f, -600.9674f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 147358, "스벤토베", "d_chapel_57_7", -27, 38, -137, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 147390, "", "d_chapel_57_7", 110, 165, -579, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 147352, "", "d_chapel_57_7", 134, 164, -576, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 147371, "", "d_chapel_57_7", -129.443, 35.9174, -139.3271, 31.11111);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 152003, "UnvisibleName", "d_chapel_57_7", 207.328, 164.8635, -582.6279, 0);
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
			case 12:
				await track.Dialog.Msg("d_chapel_57_7_dlg_1");
				break;
			case 24:
				//DRT_ACTOR_PLAY_EFT("F_spread_out004_dark", "BOT", 0);
				break;
			case 25:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in022_blue##0.5", "MID");
				break;
			case 28:
				//DRT_ACTOR_ATTACH_EFFECT("F_light046_blue", "MID");
				break;
			case 37:
				//DRT_PLAY_FORCE(0, 1, 0, "I_light015_3", "arrow_cast", "None", "arrow_blow", "SLOW", 30, 1, 18, 0, 0, 0);
				break;
			case 40:
				//DRT_RUN_FUNCTION("CHAPLE577_MQ_03_EFFKILL");
				break;
			case 45:
				await track.Dialog.Msg("f_gele_57_3_gesti_2");
				break;
			case 53:
				await track.Dialog.Msg("CHAPLE577_MQ_03_01_Q");
				break;
			case 54:
				character.AddSessionObject(PropertyName.CHAPLE577_MQ_03, 1);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
