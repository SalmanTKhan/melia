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

[TrackScript("WTREES_21_1_SQ_11_TRACK")]
public class WTREES211SQ11TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("WTREES_21_1_SQ_11_TRACK");
		//SetMap("f_whitetrees_21_1");
		//CenterPos(1520.48,-105.10,-590.92);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 151136, "", "f_whitetrees_21_1", 1529, -105.1, -617, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 151024, "", "f_whitetrees_21_1", 1529, -105.1, -617, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		character.Movement.MoveTo(new Position(1514.826f, -105.0982f, -586.9591f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 1:
				//DRT_ACTOR_PLAY_EFT("F_spread_in002_yellow1", "BOT", 0);
				break;
			case 6:
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup014_yellow", "BOT");
				break;
			case 8:
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation005_yellow", "BOT");
				break;
			case 21:
				await track.Dialog.Msg("WTREES_21_1_SQ_11_TRACK_dlg1");
				break;
			case 23:
				break;
			case 29:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
