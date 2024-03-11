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

[TrackScript("F_NICOPOLIS_81_1_SQ_03_TRACK")]
public class FNICOPOLIS811SQ03TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_NICOPOLIS_81_1_SQ_03_TRACK");
		//SetMap("f_nicopolis_81_1");
		//CenterPos(-37.04,84.15,631.43);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-34.76658f, 84.87753f, 633.2563f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 153223, "", "f_nicopolis_81_1", -32.19, 89.59, 651.94, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 153241, "", "f_nicopolis_81_1", -98.69, 79.95, 556.74, 11.66667);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 47106, "", "f_nicopolis_81_1", -153.351, 79.95302, 552.9326, 35);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 47106, "", "f_nicopolis_81_1", -53.76045, 79.95302, 511.9653, 10);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 47106, "", "f_nicopolis_81_1", -63.0303, 79.95302, 602.3678, 23);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 59156, "", "f_nicopolis_81_1", -430.2684, 84.24688, 271.8306, 58.95833);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 59160, "", "f_nicopolis_81_1", -393.1846, 79.95302, 220.8819, 52.6);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 59160, "", "f_nicopolis_81_1", 313.4869, 95.33761, 396.7073, 57.08333);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 59159, "", "f_nicopolis_81_1", 309.9294, 95.33761, 459.3788, 47.6);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 59156, "", "f_nicopolis_81_1", -356.187, 84.72417, 194.1192, 60.41666);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 8:
				break;
			case 15:
				//DRT_ACTOR_PLAY_EFT("F_spread_out036_ground_circle_rainbow", "BOT", 0);
				break;
			case 16:
				//DRT_ACTOR_PLAY_EFT("F_ground135_2", "BOT", 0);
				break;
			case 18:
				break;
			case 19:
				break;
			case 20:
				break;
			case 22:
				//DRT_ACTOR_PLAY_EFT("F_ground135_2", "BOT", 0);
				break;
			case 24:
				//DRT_FUNC_ACT("SCR_NICOPOLIS_811_SUBQ03");
				break;
			case 27:
				//DRT_ACTOR_PLAY_EFT("F_ground135_2", "BOT", 0);
				break;
			case 34:
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
