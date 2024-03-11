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

[TrackScript("CHAPLE_57_6_HQ_01_TRACK_RE")]
public class CHAPLE576HQ01TRACKRE : TrackScript
{
	protected override void Load()
	{
		SetId("CHAPLE_57_6_HQ_01_TRACK_RE");
		//SetMap("f_gele_57_3");
		//CenterPos(-302.31,289.56,696.54);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-304.6475f, 289.5554f, 691.3585f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 59306, "", "f_gele_57_3", -404.291, 289.5554, 497.9502, 0);
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
			case 7:
				//DRT_ACTOR_PLAY_EFT("F_burstup056", "BOT", 0);
				break;
			case 19:
				//TRACK_SETTENDENCY();
				CreateBattleBoxInLayer(character, track);
				character.AddonMessage("NOTICE_Dm_scroll", "Defeat Chapparition!", 3);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
