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

[TrackScript("PRISON_79_MQ_10_TRACK")]
public class PRISON79MQ10TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("PRISON_79_MQ_10_TRACK");
		//SetMap("d_prison_79");
		//CenterPos(2136.05,337.76,2515.33);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "d_prison_79", 2102, 336.9768, 2315, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 151107, "", "d_prison_79", 2141.415, 336.9768, 2405.549, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		character.Movement.MoveTo(new Position(2134.906f, 338.7059f, 2513.826f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 5:
				//DRT_ACTOR_PLAY_EFT("F_lineup020_blue_mint", "BOT", 0);
				break;
			case 17:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground117_loop", "BOT");
				break;
			case 20:
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup004", "BOT");
				break;
			case 39:
				//DRT_ACTOR_PLAY_EFT("F_light061", "BOT", 0);
				break;
			case 40:
				//DRT_ACTOR_ATTACH_EFFECT("F_pattern013_ground_white", "BOT");
				break;
			case 48:
				await track.Dialog.Msg("PRISON_79_MQ_10_TRACK_dlg1");
				break;
			case 49:
				//TRACK_BASICLAYER_MOVE();
				character.AddonMessage("NOTICE_Dm_Clear", "Disabled the demon barrier with Dominance Magic.", 5);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
