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

[TrackScript("PILGRIM47_SQ_010_TRACK")]
public class PILGRIM47SQ010TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("PILGRIM47_SQ_010_TRACK");
		//SetMap("None");
		//CenterPos(-1968.66,44.52,-1680.19);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 155031, "나태의", "None", -2226.251, 44.5155, -1563.95, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 151002, "Tree Root", "None", -2269.828, 44.51548, -1706.076, 0, "Monster");
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 151002, "Tree Root", "None", -2110.814, 44.5154, -1660.391, 60, "Monster");
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 151002, "Tree Root", "None", -2093.348, 44.5154, -1557.831, 0, "Monster");
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 2:
				//DRT_ACTOR_ATTACH_EFFECT("I_bomb003_dark", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_fire018_purple", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_pattern007_dark_loop", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_out013_loop", "BOT");
				break;
			case 5:
				//DRT_ACTOR_ATTACH_EFFECT("I_bomb003_dark", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_fire018_purple", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_pattern007_dark_loop", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_out013_loop", "BOT");
				break;
			case 8:
				//DRT_ACTOR_ATTACH_EFFECT("I_bomb003_dark", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_fire018_purple", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_pattern007_dark_loop", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_out013_loop", "BOT");
				break;
			case 9:
				character.AddonMessage("NOTICE_Dm_!", "The stone protecting the Tree Root Crystals of Laziness has appeared!{nl}Destroy all the stones!", 5);
				break;
			case 10:
				//DRT_PLAY_MGAME("PILGRIM47_SQ_010_MINI");
				break;
			case 14:
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
