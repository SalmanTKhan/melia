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

[TrackScript("F_CASTLE_97_MQ_04_TRACK")]
public class FCASTLE97MQ04TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_CASTLE_97_MQ_04_TRACK");
		//SetMap("f_castle_97");
		//CenterPos(731.71,188.66,66.64);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(731.7118f, 188.6566f, 66.64443f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 105029, "", "f_castle_97", 1015.357, 188.6565, 88.44541, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "f_castle_97", 997.9086, 188.6565, 89.84912, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 150210, "", "f_castle_97", 1098.128, 188.6565, 96.49709, 0);
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
			case 15:
				await track.Dialog.Msg("F_CASTLE_97_MQ_04_TRACK_DLG1");
				break;
			case 16:
				//DRT_ACTOR_PLAY_EFT("F_levitation005_dark_violet1", "BOT", 0);
				break;
			case 25:
				//DRT_ACTOR_PLAY_EFT("F_ground171_dark", "BOT", 0);
				break;
			case 28:
				break;
			case 29:
				//DRT_ACTOR_PLAY_EFT("F_ground129", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion042_smoke2", "BOT", 0);
				break;
			case 37:
				await track.Dialog.Msg("F_CASTLE_97_MQ_04_TRACK_DLG2");
				break;
			case 54:
				//CREATE_BATTLE_BOX_INLAYER(0);
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
