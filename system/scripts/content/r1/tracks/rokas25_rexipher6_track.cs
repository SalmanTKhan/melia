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

[TrackScript("ROKAS25_REXIPHER6_TRACK")]
public class ROKAS25REXIPHER6TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ROKAS25_REXIPHER6_TRACK");
		//SetMap("f_rokas_25");
		//CenterPos(1654.62,71.80,-1060.70);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 47102, "", "f_rokas_25", 1612, 71, -1072, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 41213, "", "f_rokas_25", 2176.825, 71.8022, -872.9876, 131.1765);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 401401, "", "f_rokas_25", 1487.37, 71.81226, -926.2224, 39.23077);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 401401, "", "f_rokas_25", 1796.977, 71.8122, -1179.57, 44.23077);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		character.Movement.MoveTo(new Position(1719.307f, 71.8022f, -1042.891f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 1:
				//DRT_RUN_FUNCTION("SCR_ROKAS25_REXIPHER4_SEAL1_TEXT_PLAY");
				break;
			case 2:
				break;
			case 7:
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion004_yellow", "BOT");
				break;
			case 10:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke004#Dummy_effect", "BOT");
				break;
			case 18:
				//DRT_PLAY_MGAME("ROKAS25_REXIPHER6_MINI");
				break;
			case 20:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground083_smoke#Dummy_effect", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_ground071_smoke#Dummy_effect", "BOT");
				break;
			case 23:
				//TRACK_SETTENDENCY();
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
