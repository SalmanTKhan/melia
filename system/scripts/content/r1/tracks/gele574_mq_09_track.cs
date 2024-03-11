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

[TrackScript("GELE574_MQ_09_TRACK")]
public class GELE574MQ09TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("GELE574_MQ_09_TRACK");
		//SetMap("f_gele_57_4");
		//CenterPos(930.17,-80.05,1150.12);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(942.3259f, -80.049f, 1144.876f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 147371, "", "f_gele_57_4", 1255.231, -79.95387, 1401.719, 32.27273);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 147353, "", "f_gele_57_4", 1300.312, -79.64884, 1502.048, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 41382, "", "f_gele_57_4", 1271.945, -79.6485, 2136.562, 48.92857);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 11281, "", "f_gele_57_4", 949.264, -80.049, 1187.924, 44.52703);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 147371, "", "f_gele_57_4", 1304.156, -79.6485, 1999.782, 31.19048);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 19:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke013_dark3", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke008_red", "BOT");
				break;
			case 41:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke008_red", "BOT");
				break;
			case 42:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke120_dark", "BOT");
				break;
			case 44:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup018_dark", "BOT");
				break;
			case 52:
				break;
			case 74:
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
