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

[TrackScript("THORN39_2_SQ07_TRACK")]
public class THORN392SQ07TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("THORN39_2_SQ07_TRACK");
		//SetMap("d_thorn_39_2");
		//CenterPos(-303.87,-118.35,-285.16);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-303.8745f, -118.3517f, -285.1633f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 41452, "", "d_thorn_39_2", -303.3157, -118.3517, -258.5396, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 41197, "", "d_thorn_39_2", -270.3752, -118.3517, -564.582, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 41197, "", "d_thorn_39_2", -175.4106, -118.3517, -601.4752, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 41197, "", "d_thorn_39_2", -310.3753, -118.3517, -532.3787, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 41197, "", "d_thorn_39_2", -155.3268, -118.3517, -567.1258, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 57675, "", "d_thorn_39_2", -267.8475, -118.3517, -653.1095, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 57675, "", "d_thorn_39_2", -238.7829, -118.3517, -659.0311, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 3:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic021_green_fire", "BOT", 0);
				break;
			case 4:
				//DRT_ACTOR_ATTACH_EFFECT("F_light055_green", "MID");
				break;
			case 10:
				//DRT_ACTOR_PLAY_EFT("F_spread_out013_green", "BOT", 0);
				break;
			case 32:
				CreateBattleBoxInLayer(character, track);
				break;
			case 34:
				//DRT_PLAY_MGAME("THORN39_2_SQ07_TRACK_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
