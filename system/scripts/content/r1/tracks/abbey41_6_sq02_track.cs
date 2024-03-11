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

[TrackScript("ABBEY41_6_SQ02_TRACK")]
public class ABBEY416SQ02TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ABBEY41_6_SQ02_TRACK");
		//SetMap("d_abbey_41_6");
		//CenterPos(-727.92,-122.86,-1326.36);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-681.519f, -122.8583f, -1277.406f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 155126, "", "d_abbey_41_6", -888.2653, -122.8583, -1451.557, 71.05264);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 155123, "", "d_abbey_41_6", -681, -122.86, -1248, 0);
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
			case 29:
				//DRT_ACTOR_ATTACH_EFFECT("F_bg_light010_yellow_long2", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_basic025_white_line", "BOT");
				break;
			case 39:
				//TRACK_BASICLAYER_MOVE();
				Send.ZC_NORMAL.SetupCutscene(character, false, false, true);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
