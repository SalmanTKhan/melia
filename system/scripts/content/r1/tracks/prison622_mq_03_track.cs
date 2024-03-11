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

[TrackScript("PRISON622_MQ_03_TRACK")]
public class PRISON622MQ03TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("PRISON622_MQ_03_TRACK");
		//SetMap("d_prison_62_2");
		//CenterPos(-1861.52,418.56,-1207.09);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-1925.964f, 418.5555f, -1141.807f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 156006, "", "d_prison_62_2", -1904.567, 418.5555, -1204.554, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 58071, "", "d_prison_62_2", -1624.9, 423.5667, -946.1411, 6.382979);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 58000, "", "d_prison_62_2", -1679.395, 423.5667, -1020.624, 0);
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
			case 15:
				break;
			case 18:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke068_dark", "BOT");
				break;
			case 34:
				await track.Dialog.Msg("PRISON622_MQ_03_TRACK_DLG_1");
				break;
			case 48:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground028_rize", "BOT");
				break;
			case 49:
				//DRT_ACTOR_PLAY_EFT("F_burstup030_fire", "BOT", 0);
				break;
			case 60:
				await track.Dialog.Msg("PRISON622_MQ_03_TRACK_DLG_2");
				break;
			case 71:
				//TRACK_MON_LOOKAT();
				break;
			case 76:
				character.AddonMessage("NOTICE_Dm_!", "Defeat Fire Lord!", 3);
				break;
			case 81:
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
