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

[TrackScript("F_MAPLE_24_3_MQ_10_TRACK")]
public class FMAPLE243MQ10TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_MAPLE_24_3_MQ_10_TRACK");
		//SetMap("f_maple_24_3");
		//CenterPos(-851.49,0.70,-37.48);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-851.7173f, 0.6999971f, -37.76207f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 154013, "", "f_maple_24_3", -895.0863, 0.6999969, -45.55529, 81.66667);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 59269, "", "f_maple_24_3", -996.249, 0.6999969, -234.9432, 0);
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
			case 4:
				break;
			case 24:
				character.AddonMessage("NOTICE_Dm_scroll", "Defeat the Demon Lord Tantalizer who has been released from his binding!", 5);
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
