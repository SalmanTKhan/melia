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

[TrackScript("ORCHARD_323_MQ_04_TRACK")]
public class ORCHARD323MQ04TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ORCHARD_323_MQ_04_TRACK");
		//SetMap("f_orchard_32_3");
		//CenterPos(-560.15,0.87,-17.08);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 47236, "", "f_orchard_32_3", -505.5252, 0.8661499, 167.5642, 220);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(-560.148f, 0.8661499f, -17.07723f));
		actors.Add(character);

		var mob1 = Shortcuts.AddMonster(0, 147407, "", "f_orchard_32_3", -524.2166, 0.8661499, 177.4906, 7.777778);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 57853, "", "f_orchard_32_3", -617.0496, 0.8661499, 118.9411, 28.125);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 57854, "", "f_orchard_32_3", -517.2364, 0.8661499, 98.94209, 30);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 57852, "", "f_orchard_32_3", -439.8492, 0.8661499, 159.5374, 22.14286);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 58043, "", "f_orchard_32_3", -452.241, 0.8661499, 233.5722, 21.25);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 4:
				//SetFixAnim("event_idle2");
				break;
			case 26:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_burstup001_yellow", "BOT", 0);
				break;
			case 28:
				//DRT_ACTOR_PLAY_EFT("F_circle020_light", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_circle020_light", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_circle020_light", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_circle020_light", "BOT", 0);
				break;
			case 36:
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_basic025_white_line", "BOT");
				break;
			case 39:
				await track.Dialog.Msg("ORCHARD_323_MQ_04_track_01");
				break;
			case 54:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
