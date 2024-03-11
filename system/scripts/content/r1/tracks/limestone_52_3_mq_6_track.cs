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

[TrackScript("LIMESTONE_52_3_MQ_6_TRACK")]
public class LIMESTONE523MQ6TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("LIMESTONE_52_3_MQ_6_TRACK");
		//SetMap("d_limestonecave_52_3");
		//CenterPos(585.17,124.70,-1413.93);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 152075, "", "d_limestonecave_52_3", 700.3922, 124.7, -1401.51, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 154012, "", "d_limestonecave_52_3", 654.2192, 124.7, -1419.857, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 154014, "", "d_limestonecave_52_3", 713.7012, 124.7, -1452.288, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 154016, "", "d_limestonecave_52_3", 701.662, 124.7, -1345.762, 470);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		character.Movement.MoveTo(new Position(585.1725f, 124.7f, -1413.93f));
		actors.Add(character);

		var mob4 = Shortcuts.AddMonster(0, 20025, "", "d_limestonecave_52_3", 709.5801, 124.7245, -1412.461, 0);
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
			case 3:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke058_violet2_loop", "BOT");
				break;
			case 11:
				//DRT_ACTOR_ATTACH_EFFECT("F_light084_yellow", "BOT");
				break;
			case 14:
				//DRT_ACTOR_ATTACH_EFFECT("F_spin023", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_ground139_light_orange", "BOT");
				break;
			case 24:
				//DRT_ACTOR_ATTACH_EFFECT("F_light084_yellow2", "BOT");
				break;
			case 25:
				await track.Dialog.Msg("LIMESTONE_52_3_MQ_6_TRACK_01");
				break;
			case 31:
				//DRT_ACTOR_ATTACH_EFFECT("F_light078_holy_yellow_loop", "BOT");
				break;
			case 37:
				//DRT_ACTOR_PLAY_EFT("F_burstup025_dark", "BOT", 0);
				break;
			case 39:
				//DRT_ACTOR_PLAY_EFT("F_burstup025_dark", "BOT", 0);
				break;
			case 41:
				//DRT_ACTOR_PLAY_EFT("F_burstup025_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion004_yellow1", "BOT", 0);
				break;
			case 44:
				character.AddonMessage("NOTICE_Dm_Clear", "The dark energy that had been surrounding the goddess has disappeared!", 6);
				character.AddSessionObject(PropertyName.LIMESTONE_52_3_MQ_6, 1);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
