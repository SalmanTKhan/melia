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

[TrackScript("GELE571_MQ_05_TRACK")]
public class GELE571MQ05TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("GELE571_MQ_05_TRACK");
		//SetMap("f_gele_57_1");
		//CenterPos(811.41,368.01,-1364.17);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 57115, "", "f_gele_57_1", 792.6098, 368.0214, -1355.091, 71.66666);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 47203, "", "f_gele_57_1", 793, 368, -1362, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		character.Movement.MoveTo(new Position(782.3199f, 368.0114f, -1392.894f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 23:
				//DRT_ACTOR_PLAY_EFT("F_spread_out026_leaf", "BOT", 0);
				break;
			case 34:
				//TRACK_MON_LOOKAT();
				//TRACK_SETTENDENCY();
				//CREATE_BATTLE_BOX_INLAYER(0);
				character.AddonMessage("NOTICE_Dm_!", "Defeat Poata!", 3);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
