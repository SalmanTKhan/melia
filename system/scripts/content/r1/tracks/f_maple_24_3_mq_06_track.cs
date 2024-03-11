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

[TrackScript("F_MAPLE_24_3_MQ_06_TRACK")]
public class FMAPLE243MQ06TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_MAPLE_24_3_MQ_06_TRACK");
		//SetMap("f_maple_24_3");
		//CenterPos(505.70,128.77,-1236.80);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(532.5586f, 128.7652f, -1247.064f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 154013, "", "f_maple_24_3", 538.7006, 128.7652, -1205.763, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 156160, "", "f_maple_24_3", 613.196, 128.7652, -1157.982, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 59269, "", "f_maple_24_3", 856.4241, 128.7652, -1262.895, 0);
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
			case 5:
				await track.Dialog.Msg("F_MAPLE_24_3_MQ_06_DLG1");
				break;
			case 71:
				await track.Dialog.Msg("F_MAPLE_24_3_MQ_06_DLG2");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
