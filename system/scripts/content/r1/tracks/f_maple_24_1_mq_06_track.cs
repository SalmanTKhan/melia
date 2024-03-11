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

[TrackScript("F_MAPLE_24_1_MQ_06_TRACK")]
public class FMAPLE241MQ06TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_MAPLE_24_1_MQ_06_TRACK");
		//SetMap("f_maple_24_1");
		//CenterPos(620.60,35.54,-139.46);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(620.605f, 35.5449f, -139.4642f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 154011, "", "f_maple_24_1", 583.9473, 35.5449, -146.5883, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 154012, "", "f_maple_24_1", 420.1238, 43.33722, 147.5277, 0);
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
			case 1:
				await track.Dialog.Msg("F_MAPLE_241_06_TRACK_DLG_01");
				break;
			case 16:
				await track.Dialog.Msg("F_MAPLE_241_06_TRACK_DLG_02");
				break;
			case 18:
				await track.Dialog.Msg("F_MAPLE_241_06_TRACK_DLG_03");
				break;
			case 37:
				await track.Dialog.Msg("F_MAPLE_241_06_TRACK_DLG_04");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
