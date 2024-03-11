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

[TrackScript("ASSISTOR_TUTO_TRACK_01")]
public class ASSISTORTUTOTRACK01 : TrackScript
{
	protected override void Load()
	{
		SetId("ASSISTOR_TUTO_TRACK_01");
		//SetMap("f_siauliai_50_1");
		//CenterPos(-641.00,0.21,-1454.60);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-641.0048f, 0.2092896f, -1454.598f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 59467, "", "f_siauliai_50_1", -797.2874, 0.2092896, -1323.515, 32.72727);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 59466, "", "f_siauliai_50_1", -1337.525, 0.2092896, -1542.315, 120.5);
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
			case 20:
				break;
			case 38:
				//DRT_ACTOR_PLAY_EFT("F_burstup001_smoke2", "BOT", 0);
				break;
			case 51:
				break;
			case 104:
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
