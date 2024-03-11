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

[TrackScript("F_NICOPOLIS_81_1_SQ_01_TRACK")]
public class FNICOPOLIS811SQ01TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_NICOPOLIS_81_1_SQ_01_TRACK");
		//SetMap("f_nicopolis_81_1");
		//CenterPos(1174.66,-26.75,-991.13);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(1170.098f, -26.75383f, -990.2448f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 153241, "조형물", "f_nicopolis_81_1", 1153.01, -26.75, -980.36, 26.25);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 59156, "", "f_nicopolis_81_1", 1361.984, -17.56047, -843.0363, 81.66667);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 59156, "", "f_nicopolis_81_1", 960.0452, -15.8652, -1196.109, 81.36363);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 59156, "", "f_nicopolis_81_1", 809.0115, -3.345772, -908.416, 86.92308);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 59159, "", "f_nicopolis_81_1", 846.8439, -9.957638, -709.493, 102.8571);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 59156, "", "f_nicopolis_81_1", 1338.925, -17.56047, -813.8466, 73.18182);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 59159, "", "f_nicopolis_81_1", 1279.437, 2.633377, -776.7421, 80.5);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 59156, "", "f_nicopolis_81_1", 874.2822, -15.86515, -1195.313, 83.92857);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 59159, "", "f_nicopolis_81_1", 848.5195, -15.86516, -1134.536, 75);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 59156, "", "f_nicopolis_81_1", 778.6307, 18.8211, -912.7473, 65.33334);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 59156, "", "f_nicopolis_81_1", 821.8146, 17.70056, -671.2708, 100);
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
			case 10:
				//DRT_ACTOR_PLAY_EFT("F_spread_out036_ground_circle_rainbow", "BOT", 0);
				break;
			case 19:
				break;
			case 20:
				character.AddonMessage("NOTICE_Dm_scroll", "Touching the sculpture alerted nearby monsters.{nl}Defeat them and use the Magic Block on the sculpture.", 5);
				break;
			case 29:
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
