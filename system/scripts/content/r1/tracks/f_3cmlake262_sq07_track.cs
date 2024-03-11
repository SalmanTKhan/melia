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

[TrackScript("F_3CMLAKE262_SQ07_TRACK")]
public class F3CMLAKE262SQ07TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_3CMLAKE262_SQ07_TRACK");
		//SetMap("f_3cmlake_26_2");
		//CenterPos(-1328.21,119.97,-830.35);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 105001, "", "f_3cmlake_26_2", -1380, 118, -823, 8.571428);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 147382, "", "f_3cmlake_26_2", -1184.724, 119.4137, -827.0545, 85);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 20040, "", "f_3cmlake_26_2", -1185, 119, -828, 11.66667);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		character.Movement.MoveTo(new Position(-1328.301f, 119.9547f, -830.913f));
		actors.Add(character);

		var mob3 = Shortcuts.AddMonster(0, 147455, "UnvisibleName", "f_3cmlake_26_2", -922.0533, 118.6792, -606.9658, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 147455, "UnvisibleName", "f_3cmlake_26_2", -908.5651, 77.77727, -911.9817, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 147455, "UnvisibleName", "f_3cmlake_26_2", -922.5598, 100.0298, -774.5535, 0);
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
			case 1:
				//DRT_RUN_FUNCTION("SCR_3CMLAKE_262_SQ07_SOLCOMM");
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_basic046_red", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_spread_out011_dark", "BOT");
				break;
			case 66:
				//DRT_ACTOR_ATTACH_EFFECT("I_sphere010_white", "MID");
				break;
			case 68:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground065_smoke", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_ground016_light", "MID");
				break;
			case 114:
				//DRT_ACTOR_PLAY_EFT("F_levitation025_red", "MID", 0);
				break;
			case 156:
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_basic045_red", "BOT");
				break;
			case 157:
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_basic046_red", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_spread_out011_dark", "BOT");
				break;
			case 194:
				//TRACK_SETTENDENCY();
				//TRACK_MON_LOOKAT();
				//CREATE_BATTLE_BOX_INLAYER(-10);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
