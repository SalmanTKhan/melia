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

[TrackScript("ABBEY_35_3_SQ_2_TRACK")]
public class ABBEY353SQ2TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ABBEY_35_3_SQ_2_TRACK");
		//SetMap("d_abbey_35_3");
		//CenterPos(-170.87,-0.00,864.65);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-170.0187f, -1.214699E-05f, 863.4955f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 156000, "", "d_abbey_35_3", -264.5572, -7.629395E-06, 919.6736, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 20149, "마을", "d_abbey_35_3", -142.8185, -1.004341E-05, 907.2228, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 20138, "마을", "d_abbey_35_3", -99.66983, -7.847242E-06, 935.2516, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 20154, "마을", "d_abbey_35_3", -101.9046, -9.791731E-06, 867.4629, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 20024, "", "d_abbey_35_3", -193.7405, -7.629395E-06, 913.1795, 0);
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
			case 1:
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation008_alpha", "BOT");
				break;
			case 4:
				//DRT_ACTOR_PLAY_EFT("F_smoke120_dark", "TOP", 0);
				break;
			case 11:
				await track.Dialog.Msg("ABBEY_35_3_SQ_2_TRACK_1");
				break;
			case 12:
				//DRT_ACTOR_PLAY_EFT("I_smoke013_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("I_smoke013_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("I_smoke013_dark", "BOT", 0);
				break;
			case 16:
				await track.Dialog.Msg("ABBEY_35_3_SQ_2_TRACK_2");
				//DRT_ACTOR_PLAY_EFT("F_smoke120_dark", "TOP", 0);
				break;
			case 17:
				//DRT_ACTOR_PLAY_EFT("I_smoke013_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("I_smoke013_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("I_smoke013_dark", "BOT", 0);
				break;
			case 22:
				await track.Dialog.Msg("ABBEY_35_3_SQ_2_TRACK_3");
				//DRT_ACTOR_PLAY_EFT("F_smoke120_dark", "TOP", 0);
				break;
			case 24:
				//DRT_ACTOR_PLAY_EFT("I_smoke013_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("I_smoke013_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("I_smoke013_dark", "BOT", 0);
				break;
			case 29:
				//DRT_ACTOR_ATTACH_EFFECT("F_fade_out_dark_fast", "BOT");
				break;
			case 30:
				character.AddSessionObject(PropertyName.ABBEY_35_3_SQ_2, 1);
				//DRT_ACTOR_ATTACH_EFFECT("F_light091_dark_loop", "BOT");
				break;
			case 31:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
