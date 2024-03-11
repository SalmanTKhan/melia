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

[TrackScript("PILGRIM41_5_SQ04_TRACK")]
public class PILGRIM415SQ04TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("PILGRIM41_5_SQ04_TRACK");
		//SetMap("f_pilgrimroad_41_5");
		//CenterPos(-1298.98,-61.47,429.58);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-1298.985f, -61.46691f, 429.5812f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 155126, "", "f_pilgrimroad_41_5", -1518.02, -51.91, 681.98, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 155046, "", "f_pilgrimroad_41_5", -1256.863, -70.69379, 442.1338, 70.5);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 6:
				//DRT_ACTOR_ATTACH_EFFECT("I_emo_exclamation", "TOP");
				break;
			case 16:
				//DRT_ACTOR_ATTACH_EFFECT("I_emo_exclamation", "TOP");
				break;
			case 31:
				await track.Dialog.Msg("PILGRIM415_SQ_04_track1");
				break;
			case 33:
				await track.Dialog.Msg("PILGRIM415_SQ_04_track2");
				break;
			case 35:
				await track.Dialog.Msg("PILGRIM415_SQ_04_track3");
				break;
			case 37:
				await track.Dialog.Msg("PILGRIM415_SQ_04_track4");
				break;
			case 39:
				await track.Dialog.Msg("PILGRIM415_SQ_04_track5");
				break;
			case 41:
				await track.Dialog.Msg("PILGRIM415_SQ_04_track6");
				break;
			case 43:
				await track.Dialog.Msg("PILGRIM415_SQ_04_track7");
				break;
			case 45:
				await track.Dialog.Msg("PILGRIM415_SQ_04_track8");
				break;
			case 57:
				Send.ZC_NORMAL.SetupCutscene(character, false, false, true);
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
