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

[TrackScript("ZACHA3F_SQ_02_TRACK")]
public class ZACHA3FSQ02TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ZACHA3F_SQ_02_TRACK");
		//SetMap("d_zachariel_34");
		//CenterPos(-327.00,249.18,252.91);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 47253, "", "d_zachariel_34", -342, 247, 208, 0, "Monster");
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(-344.9317f, 249.182f, 184.2962f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 3:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_out014_smoke", "BOT");
				break;
			case 6:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup002_dark", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup001_dark", "BOT");
				break;
			case 7:
				//DRT_PLAY_MGAME("ZACHA3F_SQ_02_MINI");
				break;
			case 9:
				CreateBattleBoxInLayer(character, track);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
