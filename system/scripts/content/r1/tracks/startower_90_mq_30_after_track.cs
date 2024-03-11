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

[TrackScript("STARTOWER_90_MQ_30_AFTER_TRACK")]
public class STARTOWER90MQ30AFTERTRACK : TrackScript
{
	protected override void Load()
	{
		SetId("STARTOWER_90_MQ_30_AFTER_TRACK");
		//SetMap("d_startower_90");
		//CenterPos(-699.30,-6.99,-1501.96);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 153137, "", "d_startower_90", -722, -6, -1499, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(-699.3016f, -6.986293f, -1501.964f));
		actors.Add(character);

		var mob1 = Shortcuts.AddMonster(0, 47236, "", "d_startower_90", -815, -6, -1580, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 154065, "", "d_startower_90", -815, -6, -1580, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 147469, "", "d_startower_90", -720.58, -6.986304, -1291.731, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 4:
				//DRT_ACTOR_ATTACH_EFFECT("I_rize010_orange##1", "MID");
				break;
			case 6:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line", "BOT", 0);
				break;
			case 7:
				break;
			case 62:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line", "BOT", 0);
				break;
			case 68:
				character.AddonMessage("NOTICE_Dm_Clear", "The Mysterious Girl pointed towards somewhere and disappeared.{nl}Return to Byle and talk to him about what to do next.", 3);
				break;
			case 69:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
