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

[TrackScript("EP16_1_ROKAS_36_1_MQ9_TRACK")]
public class EP161ROKAS361MQ9TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP16_1_ROKAS_36_1_MQ9_TRACK");
		//SetMap("f_rokas_36_1");
		//CenterPos(788.91,7.65,765.36);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 160046, "", "f_rokas_36_1", 720, 7, 857, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 59830, "", "f_rokas_36_1", 819.21, 7.65, 777.06, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		character.Movement.MoveTo(new Position(866.9572f, 7.654289f, 694.8399f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 9:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup004_dark2", "BOT");
				break;
			case 16:
				break;
			case 18:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup007_smoke1", "BOT");
				break;
			case 30:
				//DRT_ACTOR_ATTACH_EFFECT("F_line029_dark", "BOT");
				break;
			case 34:
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup017_red3", "BOT");
				break;
			case 48:
				//DRT_PLAY_MGAME("EP16_1_ROKAS_36_1_MQ9_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
