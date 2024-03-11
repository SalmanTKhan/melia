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

[TrackScript("raid_f_rokas_24_TRACK")]
public class raidfrokas24TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("raid_f_rokas_24_TRACK");
		//SetMap("None");
		//CenterPos(-105.09,1079.98,-441.37);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 740004, "", "None", -472.2323, 1125.39, 99.90833, 63.14815, "Neutral");
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 740005, "", "None", -1047.502, 1125.39, -172.1582, 3.636364);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "None", -1063.657, 1125.39, -160.4596, 0);
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
			case 48:
				break;
			case 51:
				//DRT_ACTOR_ATTACH_EFFECT("F_archer_musket_smoke_white", "MID");
				break;
			case 57:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke052_white", "BOT");
				break;
			case 78:
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_fire_spread", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_wizard_BRIQUETTING_HARDENING_fire_dust", "BOT");
				//DRT_ACTOR_PLAY_EFT("I_breath008_circle_3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("I_breath008_circle_3", "BOT", 0);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
