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

[TrackScript("PILGRIM50_SQ_060_TRACK")]
public class PILGRIM50SQ060TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("PILGRIM50_SQ_060_TRACK");
		//SetMap("None");
		//CenterPos(463.72,609.69,1651.86);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 155034, "", "None", 465.7244, 609.6888, 1693.972, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 1:
				//DRT_ACTOR_PLAY_EFT("F_explosion004_mint", "BOT", 0);
				break;
			case 14:
				//DRT_ACTOR_ATTACH_EFFECT("I_spread_in001_dark", "BOT");
				break;
			case 22:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_out004_dark", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_cleric_telepath_loop_connect", "BOT");
				break;
			case 26:
				character.AddonMessage("NOTICE_Dm_!", "Defeat all the monsters summoned by the spirit of a pilgrim!", 3);
				//DRT_PLAY_MGAME("PILGRIM50_SQ_060_MINI");
				break;
			case 29:
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
