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

[TrackScript("HUEVILLAGE_58_4_MQ08_TRACK")]
public class HUEVILLAGE584MQ08TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("HUEVILLAGE_58_4_MQ08_TRACK");
		//SetMap("f_huevillage_58_4");
		//CenterPos(22.35986,5.71,-453.49);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 147385, "", "f_huevillage_58_4", 21.4165, 34.20367, -186.0109, 21.25);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 147388, "", "f_huevillage_58_4", 107.0288, 34.20369, -203.0942, 55);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.Level = 42;
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 147387, "", "f_huevillage_58_4", -53.25879, 34.20368, -201.0888, 45);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.Level = 42;
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 155053, "UnVisibleName", "f_huevillage_58_4", 28.48047, 34.20367, -188.3998, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 47122, "", "f_huevillage_58_4", 20.91748, 34.20366, -183.1234, 0);
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
			case 6:
				//DRT_ACTOR_ATTACH_EFFECT("I_sphere011_mash", "BOT");
				break;
			case 10:
				//DRT_ACTOR_ATTACH_EFFECT("E_vine2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("E_vine2", "BOT");
				break;
			case 12:
				//DRT_ACTOR_ATTACH_EFFECT("I_sphere011_mash", "BOT");
				break;
			case 15:
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation032_red", "BOT");
				break;
			case 21:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_out004_dark", "BOT");
				//DRT_ACTOR_PLAY_EFT("F_spread_out004_dark", "BOT", 0);
				break;
			case 23:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke045_spread_in", "BOT");
				break;
			case 24:
				//DRT_ACTOR_ATTACH_EFFECT("F_light078_holy_yellow_loop", "BOT");
				break;
			case 33:
				//DRT_ACTOR_ATTACH_EFFECT("F_light061", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_light039_yellow", "BOT");
				break;
			case 38:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground012_light", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_spin022_blue1", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_light033_circle_blue", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_archer_circling_ground", "BOT");
				break;
			case 54:
				//CREATE_BATTLE_BOX_INLAYER(0);
				//TRACK_SETTENDENCY();
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
