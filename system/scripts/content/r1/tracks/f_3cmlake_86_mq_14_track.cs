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

[TrackScript("F_3CMLAKE_86_MQ_14_TRACK")]
public class F3CMLAKE86MQ14TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_3CMLAKE_86_MQ_14_TRACK");
		//SetMap("f_3cmlake_86");
		//CenterPos(2118.06,46.16,-450.53);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 156102, "", "f_3cmlake_86", 2110.039, 46.78818, -421.2886, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 156116, "Resistance Soldier", "f_3cmlake_86", 2087.72, 46.33827, -442.234, 3.571429);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "f_3cmlake_86", 2163.918, 38.82056, -310.6091, 50);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "f_3cmlake_86", 2165.44, 38.82056, -334.8028, 100);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		character.Movement.MoveTo(new Position(2119.004f, 46.18546f, -449.3142f));
		actors.Add(character);

		var mob4 = Shortcuts.AddMonster(0, 154040, "", "f_3cmlake_86", 2163.722, 38.82056, -310.7756, 0);
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
			case 1:
				//DRT_ACTOR_ATTACH_EFFECT("F_magic_prison_line_blue", "BOT");
				break;
			case 5:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground141_light_blue_loop", "BOT");
				break;
			case 7:
				//DRT_ACTOR_PLAY_EFT("F_full_charge_ground", "TOP", 0);
				break;
			case 8:
				//DRT_ACTOR_PLAY_EFT("F_light008_2", "TOP", 0);
				break;
			case 13:
				//DRT_ACTOR_ATTACH_EFFECT("F_light081_ground_orange_loop", "TOP");
				break;
			case 25:
				await track.Dialog.Msg("F_3CMLAKE_86_MQ_14_DLG1");
				break;
			case 33:
				break;
			case 34:
				//DRT_ACTOR_PLAY_EFT("F_spread_out033_ground_light", "TOP", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_out036_ground_circle_rainbow", "TOP", 1);
				//DRT_ACTOR_ATTACH_EFFECT("F_ground051_loop3", "TOP");
				//DRT_ACTOR_ATTACH_EFFECT("F_light075_yellow_loop", "TOP");
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in011_yellow_loop", "TOP");
				break;
			case 39:
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
