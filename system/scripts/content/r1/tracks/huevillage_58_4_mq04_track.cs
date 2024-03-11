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

[TrackScript("HUEVILLAGE_58_4_MQ04_TRACK")]
public class HUEVILLAGE584MQ04TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("HUEVILLAGE_58_4_MQ04_TRACK");
		//SetMap("f_huevillage_58_4");
		//CenterPos(400.1802,-6.55,671.47);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 147417, "", "f_huevillage_58_4", 433.9258, -7.123497, 691.9702, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(419.7446f, -7.123497f, 672.9124f));
		actors.Add(character);

		var mob1 = Shortcuts.AddMonster(0, 47510, "", "f_huevillage_58_4", 426, -6, 705, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 57606, "", "f_huevillage_58_4", 301.5718, -6.463215, 706.8207, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 57606, "", "f_huevillage_58_4", 523.5879, -6.094409, 657.9331, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 57606, "", "f_huevillage_58_4", 435.9238, -6.500697, 824.3185, 0);
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
				break;
			case 9:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground083_smoke", "BOT");
				break;
			case 15:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground083_smoke", "BOT");
				break;
			case 21:
				break;
			case 23:
				break;
			case 24:
				break;
			case 29:
				//TRACK_SETTENDENCY();
				//TRACK_MON_LOOKAT();
				//CREATE_BATTLE_BOX_INLAYER(0);
				//DRT_MOVETOTGT(50);
				//DRT_MOVETOTGT(50);
				//DRT_MOVETOTGT(50);
				//DRT_MOVETOTGT(50);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
