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

[TrackScript("FARM49_3_MQ04_TRACK")]
public class FARM493MQ04TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("FARM49_3_MQ04_TRACK");
		//SetMap("None");
		//CenterPos(624.11,299.12,27.36);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(685.8134f, 293.2046f, -12.6964f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 155016, "", "None", 629.939, 293.2046, 2.383118, 78.33333);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 155021, "", "None", 648.0612, 293.2046, 53.52522, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 155018, "", "None", 573.4592, 293.2046, -103.4292, 18.57143);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 20125, "", "None", 769.04, 293.2, 117.15, 21.32353);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 10033, "", "None", 572.8802, 293.2046, -213.2293, 87.5);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 10033, "", "None", 880.5389, 293.2046, -247.1349, 124.1667);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 10033, "", "None", 959.1063, 293.2046, -94.47887, 124.1667);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 57341, "", "None", 717.8982, 293.2046, -84.7516, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 57341, "", "None", 715.1201, 293.2046, -131.5827, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 57341, "", "None", 764.1993, 293.2046, -80.04472, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 57341, "", "None", 753.9267, 293.2046, -119.9376, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 12082, "", "None", 734.6758, 293.2046, -99.49123, 2.272727);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 12082, "", "None", 734.68, 293.2, -99.49, 0);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 8:
				//DRT_ACTOR_PLAY_EFT("I_force079_yellow", "BOT", 0);
				break;
			case 9:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground004_loop", "BOT");
				break;
			case 15:
				//DRT_ACTOR_PLAY_EFT("I_emo_exclamation", "TOP", 0);
				break;
			case 16:
				//DRT_ACTOR_PLAY_EFT("I_emo_exclamation", "TOP", 1);
				break;
			case 23:
				//DRT_ACTOR_PLAY_EFT("I_emo_exclamation", "TOP", 1);
				break;
			case 25:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in011_yellow", "MID");
				break;
			case 38:
				break;
			case 39:
				//DRT_ACTOR_ATTACH_EFFECT("F_cleric_ShapeShifting_ground", "BOT");
				break;
			case 42:
				//SetFixAnim("SitGrope_ready");
				break;
			case 49:
				break;
			case 55:
				//TRACK_SETTENDENCY();
				//DRT_PLAY_MGAME("FARM49_3_MQ04_MINI");
				//CREATE_BATTLE_BOX_INLAYER(0);
				//DRT_SETHOOKMSGOWNER(0, 1);
				//DRT_SETHOOKMSGOWNER(0, 1);
				//DRT_SETHOOKMSGOWNER(0, 1);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
