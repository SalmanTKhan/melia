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

[TrackScript("ZACHA3F_MQ_04_TRACK")]
public class ZACHA3FMQ04TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ZACHA3F_MQ_04_TRACK");
		//SetMap("d_zachariel_34");
		//CenterPos(-2737.02,296.89,241.56);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-2441.144f, 283.4423f, 218.511f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 57067, "Denoptic", "d_zachariel_34", -2843.117, 296.8857, 140.7566, 25);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 6:
				break;
			case 7:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke015_green", "BOT");
				break;
			case 8:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground004_green", "BOT");
				break;
			case 19:
				//TRACK_SETTENDENCY();
				CreateBattleBoxInLayer(character, track);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
