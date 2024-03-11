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

[TrackScript("ORCHARD_342_MQ_03_TRACK")]
public class ORCHARD342MQ03TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ORCHARD_342_MQ_03_TRACK");
		//SetMap("f_orchard_34_2");
		//CenterPos(-412.74,-69.99,-723.75);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-412.7426f, -69.98535f, -723.7533f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 47236, "", "f_orchard_34_2", -455.0662, -69.98535, -777.1076, 87);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 57850, "", "f_orchard_34_2", -667.603, -69.98535, -810.4183, 3.75);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 57850, "", "f_orchard_34_2", -630.7045, -69.98535, -858.9835, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 57851, "", "f_orchard_34_2", -582.7802, -69.98535, -778.255, 155);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 58087, "", "f_orchard_34_2", -587.9973, -69.98535, -785.7087, 1.923077);
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
			case 2:
				break;
			case 4:
				break;
			case 9:
				break;
			case 19:
				//DRT_ACTOR_ATTACH_EFFECT("F_light058_blue", "MID");
				break;
			case 21:
				break;
			case 32:
				//SetFixAnim("EVENT_LOOP");
				break;
			case 35:
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation032_red", "BOT");
				break;
			case 36:
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation032_red_loop", "BOT");
				break;
			case 43:
				await track.Dialog.Msg("ORCHARD_342_MQ_03_track_01");
				break;
			case 57:
				await track.Dialog.Msg("ORCHARD_342_MQ_03_track_02");
				break;
			case 67:
				character.AddonMessage("NOTICE_Dm_!", "Demon Lord Zaura disappeared with the girl! Eliminate the horde of ferrets!", 3);
				break;
			case 68:
				//TRACK_SETTENDENCY();
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			case 69:
				//DRT_PLAY_MGAME("ORCHARD_342_MQ_03_MINI");
				//DRT_PLAY_MGAME("ORCHARD_342_MQ_03_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
