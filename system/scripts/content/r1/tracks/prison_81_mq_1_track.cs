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

[TrackScript("PRISON_81_MQ_1_TRACK")]
public class PRISON81MQ1TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("PRISON_81_MQ_1_TRACK");
		//SetMap("d_prison_81");
		//CenterPos(-1245.21,168.67,-994.11);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 151107, "", "d_prison_81", -1171, 168.6681, -1044, 65);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(-1208.518f, 168.668f, -1025.399f));
		actors.Add(character);

		var mob1 = Shortcuts.AddMonster(0, 147455, "UnvisibleName", "d_prison_81", -607, 168.6678, -734, 0);
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
			case 19:
				break;
			case 20:
				//DRT_ACTOR_PLAY_EFT("F_pattern008_violet", "BOT", 0);
				break;
			case 27:
				//DRT_ACTOR_PLAY_EFT("F_levitation004_violet_ride", "BOT", 0);
				break;
			case 29:
				//DRT_ACTOR_PLAY_EFT("F_burstup023_smoke", "BOT", 0);
				break;
			case 30:
				//DRT_ACTOR_PLAY_EFT("F_smoke101_dark", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("F_ground_change_dark", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_pattern003_explosion_mash_violet", "BOT");
				break;
			case 42:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
