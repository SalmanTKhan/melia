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

[TrackScript("PRISON621_MQ_01_TRACK")]
public class PRISON621MQ01TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("PRISON621_MQ_01_TRACK");
		//SetMap("d_prison_62_1");
		//CenterPos(-536.33,326.26,-752.14);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-477.5736f, 325.8502f, -807.0664f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 155044, "", "d_prison_62_1", -506.9951, 328.728, -625.6407, 86.875);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 147403, "", "d_prison_62_1", -523.5743, 327.3906, -694.0842, 95.3125);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 147406, "", "d_prison_62_1", -467.2511, 327.4988, -688.5387, 75.625);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 40071, "UnvisibleName", "d_prison_62_1", -506.0144, 331.4503, -486.641, 0);
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
			case 11:
				//DRT_ACTOR_PLAY_EFT("F_spread_out004_dark", "BOT", 0);
				break;
			case 12:
				//DRT_ACTOR_PLAY_EFT("F_spread_out004_dark", "BOT", 0);
				break;
			case 16:
				//DRT_ACTOR_PLAY_EFT("F_light018_yellow", "MID", 0);
				break;
			case 54:
				character.AddSessionObject(PropertyName.PRISON621_MQ_01, 1);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
