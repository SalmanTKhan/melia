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

[TrackScript("F_3CMLAKE_87_MQ_10_TRACK_AFTER")]
public class F3CMLAKE87MQ10TRACKAFTER : TrackScript
{
	protected override void Load()
	{
		SetId("F_3CMLAKE_87_MQ_10_TRACK_AFTER");
		//SetMap("f_3cmlake_87");
		//CenterPos(905.22,151.53,1197.83);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(905.2202f, 151.534f, 1197.83f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 58696, "", "f_3cmlake_87", 931.9445, 151.534, 1138.452, 71.66666);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 147405, "", "f_3cmlake_87", 262.6072, 162.1949, 1321.805, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 156101, "", "f_3cmlake_87", 346.032, 162.1949, 1305.885, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 155003, "", "f_3cmlake_87", 133.5065, 158.3137, 1221.342, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 155003, "", "f_3cmlake_87", 95.26511, 158.3137, 1183.797, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 155003, "", "f_3cmlake_87", 105.8886, 158.3137, 1128.961, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 5:
				//DRT_ADDBUFF("HPLock", 100, 0, 0, 1);
				break;
			case 9:
				break;
			case 55:
				//DRT_ACTOR_PLAY_EFT("F_spark017_ice2", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("F_spark017_ice2", "MID", 0);
				break;
			case 76:
				//DRT_ACTOR_PLAY_EFT("F_ground116_green", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion009_green2", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground116_green", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion009_green2", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground116_green", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion009_green2", "BOT", 0);
				break;
			case 89:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
