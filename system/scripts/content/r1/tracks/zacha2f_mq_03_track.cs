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

[TrackScript("ZACHA2F_MQ_03_TRACK")]
public class ZACHA2FMQ03TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ZACHA2F_MQ_03_TRACK");
		//SetMap("d_zachariel_33");
		//CenterPos(-222.91,644.20,-617.87);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-143.6012f, 648.1195f, -1061.226f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 47253, "", "d_zachariel_33", 4.617016, 648.1295, -722.3488, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 47253, "", "d_zachariel_33", -377.1419, 648.1295, -726.5339, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 47253, "", "d_zachariel_33", -208.5829, 648.1295, -882.6558, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 47253, "", "d_zachariel_33", -207.5794, 648.1295, -570.201, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 41229, "", "d_zachariel_33", -209.3065, 616.8641, -724.5276, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 47413, "", "d_zachariel_33", -206.5274, 616.8641, -727.6045, 24.27083);
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
			case 11:
				break;
			case 27:
				//DRT_ACTOR_ATTACH_EFFECT("F_rize001_green", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_rize001_green", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_rize001_green", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_rize001_green", "BOT");
				break;
			case 54:
				character.AddSessionObject(PropertyName.ZACHA2F_MQ_03, 1);
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
