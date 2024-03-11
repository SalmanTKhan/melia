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

[TrackScript("LIMESTONE_52_4_MQ_4_TRACK")]
public class LIMESTONE524MQ4TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("LIMESTONE_52_4_MQ_4_TRACK");
		//SetMap("d_limestonecave_52_4");
		//CenterPos(2419.57,-98.62,-191.46);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(2419.57f, -98.62036f, -191.4574f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 57579, "", "d_limestonecave_52_4", 2413.442, -98.62036, -158.1717, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 154014, "", "d_limestonecave_52_4", 2396.944, -98.62036, -181.3909, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 20025, "UnvisibleName", "d_limestonecave_52_4", 2424.88, -98.62036, -175.5034, 0);
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
			case 4:
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup022_mint", "BOT");
				break;
			case 5:
				//DRT_ACTOR_ATTACH_EFFECT("E_light001_circle", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_light104_yellow_loop", "BOT");
				break;
			case 6:
				character.AddonMessage("NOTICE_Dm_scroll", "Protect the Kupoles from the monsters!", 8);
				//DRT_ACTOR_ATTACH_EFFECT("I_sys_trigger_point_yellow_mash", "BOT");
				break;
			case 7:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in011_yellow_loop", "MID");
				break;
			case 8:
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			case 9:
				//DRT_PLAY_MGAME("LIMESTONE_52_4_MQ_4_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
