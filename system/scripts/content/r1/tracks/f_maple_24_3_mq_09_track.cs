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

[TrackScript("F_MAPLE_24_3_MQ_09_TRACK")]
public class FMAPLE243MQ09TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_MAPLE_24_3_MQ_09_TRACK");
		//SetMap("f_maple_24_3");
		//CenterPos(-75.10,0.70,1196.33);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-100.3142f, 0.6999969f, 1222.143f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 154013, "", "f_maple_24_3", -118.2298, 0.6999969, 1196.537, 54);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 160163, "", "f_maple_24_3", 103.9116, 0.7000064, 991.1693, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 160163, "", "f_maple_24_3", 196.3951, 0.6999969, 1046.868, 150);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 160163, "", "f_maple_24_3", 93.33067, 0.6999969, 1098.499, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 12:
				await track.Dialog.Msg("F_MAPLE_24_3_MQ_09_TRACK_DLG1");
				break;
			case 35:
				await track.Dialog.Msg("F_MAPLE_24_3_MQ_09_TRACK_DLG2");
				break;
			case 44:
				//DRT_PLAY_MGAME("F_MAPLE_24_3_MQ_09_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
