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

[TrackScript("GELE574_MQ_01_TRACK")]
public class GELE574MQ01TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("GELE574_MQ_01_TRACK");
		//SetMap("f_gele_57_4");
		//CenterPos(-999.86,-80.05,2026.81);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 400122, "", "f_gele_57_4", -1017, -79, 2085, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 57268, "", "f_gele_57_4", -910.8535, -80.049, 2417.02, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 1:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				break;
			case 4:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				break;
			case 7:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				break;
			case 10:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				break;
			case 13:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke017_spread_out", "BOT");
				break;
			case 18:
				character.AddonMessage("NOTICE_Dm_!", "Defeat Biteregina!", 3);
				break;
			case 19:
				//TRACK_MON_LOOKAT();
				//CREATE_BATTLE_BOX_INLAYER(0);
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
