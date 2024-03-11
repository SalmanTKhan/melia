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

[TrackScript("ORCHARD_324_MQ_01_TRACK")]
public class ORCHARD324MQ01TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ORCHARD_324_MQ_01_TRACK");
		//SetMap("f_orchard_32_4");
		//CenterPos(-34.88,0.81,794.77);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-34.87933f, 0.8066463f, 794.7744f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 156043, "", "f_orchard_32_4", -46.734, 0.8066463, 870.8473, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 20054, "UnvisibleName", "f_orchard_32_4", -47.86039, 0.8066463, 869.7211, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 155024, "", "f_orchard_32_4", -46.97593, 0.8066463, 813.6766, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 155024, "", "f_orchard_32_4", -91.37969, 0.8066463, 897.446, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 155024, "", "f_orchard_32_4", 1.99358, 0.8066463, 897.5681, 6.95122);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 58087, "", "f_orchard_32_4", -46.05304, -2.146455, 569.5743, 71);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "f_orchard_32_4", -48.2416, -2.146459, 576.0105, 0);
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
			case 10:
				break;
			case 11:
				//DRT_ADDBUFF("SoulDuel_DEF", 1, 0, 0, 1);
				break;
			case 20:
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion072_fire", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_fire011", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup045", "BOT");
				break;
			case 25:
				//DRT_ACTOR_ATTACH_EFFECT("F_bg_fire001_2##10", "MID");
				break;
			case 26:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground071_fire", "BOT");
				break;
			case 30:
				await track.Dialog.Msg("ORCHARD_324_MQ_01_track_01");
				break;
			case 33:
				await track.Dialog.Msg("ORCHARD_324_MQ_01_track_02");
				break;
			case 34:
				//CREATE_BATTLE_BOX_INLAYER(0);
				//TRACK_SETTENDENCY();
				character.AddonMessage("NOTICE_Dm_!", "Fight against Demon Lord Zaura who imprisoned Goddess Lada", 3);
				//DRT_RUN_FUNCTION("ORCHARD324_CLEAR_BUFF");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
