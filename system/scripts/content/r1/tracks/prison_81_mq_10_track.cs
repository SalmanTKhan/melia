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

[TrackScript("PRISON_81_MQ_10_TRACK")]
public class PRISON81MQ10TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("PRISON_81_MQ_10_TRACK");
		//SetMap("d_prison_81");
		//CenterPos(610.48,184.00,37.64);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "d_prison_81", 584, 184.0003, -168, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 151107, "", "d_prison_81", 615.37, 184, -53.87839, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		character.Movement.MoveTo(new Position(613.6171f, 183.9995f, 24.91784f));
		actors.Add(character);

		var mob2 = Shortcuts.AddMonster(0, 147382, "", "d_prison_81", 572.0372, 184.0008, -385.4356, 21.66667);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

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
				await track.Dialog.Msg("PRISON_81_MQ_10_TRACK_dlg1");
				break;
			case 49:
				character.AddonMessage("NOTICE_Dm_Clear", "Disabled the demon barrier with Dominance Magic.", 5);
				break;
			case 51:
				//DRT_ACTOR_PLAY_EFT("F_levitation005_dark_blue2", "BOT", 0);
				break;
			case 66:
				break;
			case 79:
				await track.Dialog.Msg("PRISON_81_MQ_10_BLACKMAN_01");
				break;
			case 89:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
