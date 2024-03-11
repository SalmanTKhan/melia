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

[TrackScript("STARTOWER_91_MQ_40_TRACK")]
public class STARTOWER91MQ40TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("STARTOWER_91_MQ_40_TRACK");
		//SetMap("d_startower_91");
		//CenterPos(-27.32,928.63,-290.93);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 151109, "", "d_startower_91", -59, 928, -294, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(-27.3161f, 928.632f, -290.9304f));
		actors.Add(character);

		var mob1 = Shortcuts.AddMonster(0, 59116, "", "d_startower_91", -67.28957, 928.6318, -707.7214, 50.45454);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 59116, "", "d_startower_91", -85.10412, 928.6318, -737.4822, 7985);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 59090, "", "d_startower_91", -52.5481, 928.6319, -732.9886, 9950);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 59116, "", "d_startower_91", 286.6603, 928.6321, -162.3432, 9915);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 59116, "", "d_startower_91", 259.3254, 928.6321, -142.0299, 7535);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 59090, "", "d_startower_91", 285.0582, 928.6321, -125.5281, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 154066, "", "d_startower_91", 14.40869, 928.6319, -650.547, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 154066, "", "d_startower_91", 204.3516, 928.6321, -119.5036, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 154066, "", "d_startower_91", -63.2182, 928.6318, -646.5187, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 152076, "", "d_startower_91", 234.3444, 825.2015, -826.8848, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 1:
				//DRT_ACTOR_PLAY_EFT("E_pc_shield_square", "BOT", 0);
				break;
			case 7:
				//DRT_ACTOR_PLAY_EFT("E_pc_shield_square", "BOT", 0);
				break;
			case 13:
				//DRT_ACTOR_PLAY_EFT("E_pc_shield_square", "BOT", 0);
				break;
			case 19:
				//DRT_ACTOR_PLAY_EFT("E_pc_shield_square", "BOT", 0);
				break;
			case 23:
				//DRT_ACTOR_PLAY_EFT("E_pc_shield_square", "BOT", 0);
				break;
			case 29:
				//DRT_ACTOR_PLAY_EFT("E_pc_shield_square", "BOT", 0);
				break;
			case 34:
				//DRT_ACTOR_PLAY_EFT("E_pc_shield_square", "BOT", 0);
				break;
			case 37:
				//DRT_ACTOR_PLAY_EFT("E_pc_shield_square", "BOT", 0);
				break;
			case 42:
				character.AddonMessage("NOTICE_Dm_scroll", "The monsters carrying the power of the device barrier are ready to attack!{nl}Defeat all monsters nearby and weaken the power of the barrier!", 3);
				break;
			case 43:
				CreateBattleBoxInLayer(character, track);
				//TRACK_MON_LOOKAT();
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
