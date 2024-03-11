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

[TrackScript("DCAPITAL105_SQ_1_TRACK")]
public class DCAPITAL105SQ1TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("DCAPITAL105_SQ_1_TRACK");
		//SetMap("f_dcapital_105");
		//CenterPos(-349.48,111.02,-384.86);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-269.9238f, 111.4015f, -583.5789f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 154016, "", "f_dcapital_105", -369.6208, 111.0152, -406.7239, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 154011, "", "f_dcapital_105", -314.3967, 111.0152, -377.5551, 1);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 59092, "", "f_dcapital_105", -455.2619, 111.1448, -433.8494, 28.88889, "Neutral");
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 59092, "", "f_dcapital_105", -275.1791, 111.0152, -437.2527, 28.88889, "Neutral");
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 59092, "", "f_dcapital_105", -377.951, 111.0152, -491.4912, 24.44444, "Neutral");
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 59092, "", "f_dcapital_105", -276.0941, 111.0152, -377.9659, 35, "Neutral");
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
			case 19:
				break;
			case 27:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in001_orange", "BOT");
				break;
			case 34:
				//DRT_ACTOR_PLAY_EFT("F_explosion004_yellow2", "BOT", 0);
				break;
			case 52:
				//DRT_ACTOR_ATTACH_EFFECT("F_bg_light010_yellow_long2", "MID");
				break;
			case 54:
				character.AddonMessage("NOTICE_Dm_Clear", "Talk to Kupole Grisia", 8);
				break;
			case 57:
				character.AddSessionObject(PropertyName.DCAPITAL105_SQ_1, 1);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
