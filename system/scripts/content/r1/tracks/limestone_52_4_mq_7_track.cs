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

[TrackScript("LIMESTONE_52_4_MQ_7_TRACK")]
public class LIMESTONE524MQ7TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("LIMESTONE_52_4_MQ_7_TRACK");
		//SetMap("d_limestonecave_52_4");
		//CenterPos(-510.78,253.20,-414.43);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-510.7831f, 253.2034f, -414.4288f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 57581, "", "d_limestonecave_52_4", -455.931, 242.4968, -457.4969, 61.25);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 107014, "", "d_limestonecave_52_4", -698.3618, 229.5104, -255.1788, 24);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 107015, "", "d_limestonecave_52_4", -656.8958, 234.3409, -188.8085, 0);
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
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup001_red", "BOT");
				break;
			case 19:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup043_water_blue", "BOT");
				break;
			case 20:
				await track.Dialog.Msg("LIMESTONE_52_4_MQ_7_TRACK_1");
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup003_1", "BOT");
				break;
			case 21:
				character.AddonMessage("NOTICE_Dm_scroll", "Defeat the demon that has kidnapped Goddess Dalia!", 6);
				break;
			case 23:
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			case 24:
				//TRACK_SETTENDENCY();
				//InsertHate(999);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
