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

[TrackScript("PILGRIM47_SQ_030_TRACK")]
public class PILGRIM47SQ030TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("PILGRIM47_SQ_030_TRACK");
		//SetMap("None");
		//CenterPos(-1655.62,195.32,76.13);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 155031, "나태의", "None", -1742, 195.31, 141.47, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 147312, "", "None", -1692.04, 195.32, 119.21, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		character.Movement.MoveTo(new Position(-1706.77f, 195.3145f, 164.17f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 1:
				//DRT_ACTOR_ATTACH_EFFECT("I_bomb005_dark", "BOT");
				break;
			case 2:
				//DRT_ACTOR_ATTACH_EFFECT("F_bg_fire003", "BOT");
				break;
			case 3:
				//DRT_PLAY_MGAME("PILGRIM47_SQ_030_MINI");
				break;
			case 4:
				//CREATE_BATTLE_BOX_INLAYER(0);
				character.AddonMessage("NOTICE_Dm_!", "The fire started, but it seems that it will be extinguished soon.{nl}Make a bigger fire by obtaining kindling from Kowaks!", 5);
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
