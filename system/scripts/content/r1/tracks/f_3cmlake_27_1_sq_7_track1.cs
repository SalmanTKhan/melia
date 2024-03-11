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

[TrackScript("F_3CMLAKE_27_1_SQ_7_TRACK1")]
public class F3CMLAKE271SQ7TRACK1 : TrackScript
{
	protected override void Load()
	{
		SetId("F_3CMLAKE_27_1_SQ_7_TRACK1");
		//SetMap("None");
		//CenterPos(-1064.62,1.08,-191.35);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-1036.187f, 1.24775f, -226.9578f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 155163, "", "None", -1395.737, 38.1707, -439.5255, 74.41177);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 59216, "", "None", -1459.795, 45.73342, -385.9619, 88.21429);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 59216, "", "None", -1672.687, 46.66467, -623.5449, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 59216, "", "None", -1735.403, 46.66467, -613.8435, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 59216, "", "None", -1859.121, 46.66467, -401.6691, 24.0625);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 59216, "", "None", -1901.359, 46.66465, -483.2258, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 59216, "", "None", -1535.115, 46.66467, -364.3857, 79.25);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 59216, "", "None", -1469.553, 45.91168, -608.0662, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 59216, "", "None", -1554.57, 46.66467, -434.8939, 96);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 59216, "", "None", -1539.716, 46.66467, -402.9454, 95.3125);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 155003, "", "None", -1577.381, 46.66467, -480.2246, 0.9036145);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 155003, "", "None", -1581.989, 46.66467, -394.9931, 1.09589);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 155003, "", "None", -1446.279, 45.18258, -427.4358, 0);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 59229, "", "None", -1531.913, 46.6596, -486.1443, 0);
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		var mob14 = Shortcuts.AddMonster(0, 59229, "", "None", -1518.566, 46.43219, -455.0628, 0);
		mob14.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob14.AddEffect(new ScriptInvisibleEffect());
		mob14.Layer = character.Layer;
		actors.Add(mob14);

		var mob15 = Shortcuts.AddMonster(0, 59229, "", "None", -1510.757, 46.31231, -424.6575, 0);
		mob15.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob15.AddEffect(new ScriptInvisibleEffect());
		mob15.Layer = character.Layer;
		actors.Add(mob15);

		var mob16 = Shortcuts.AddMonster(0, 59229, "", "None", -1501.417, 46.23316, -396.0045, 0);
		mob16.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob16.AddEffect(new ScriptInvisibleEffect());
		mob16.Layer = character.Layer;
		actors.Add(mob16);

		var mob17 = Shortcuts.AddMonster(0, 59229, "", "None", -1504.99, 46.4134, -363.036, 0);
		mob17.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob17.AddEffect(new ScriptInvisibleEffect());
		mob17.Layer = character.Layer;
		actors.Add(mob17);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 1:
				break;
			case 30:
				//DRT_ACTOR_PLAY_EFT("F_hit_good", "MID", 0);
				break;
			case 60:
				//DRT_ACTOR_PLAY_EFT("F_ground180_boom", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_cleric_explosion_seedboom", "BOT", 0);
				break;
			case 67:
				//DRT_ACTOR_PLAY_EFT("F_ground180_boom", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_cleric_explosion_seedboom", "BOT", 0);
				break;
			case 69:
				//DRT_ACTOR_PLAY_EFT("F_hit_good", "MID", 0);
				break;
			case 77:
				//DRT_ACTOR_PLAY_EFT("F_hit_good", "MID", 0);
				break;
			case 81:
				//DRT_ACTOR_PLAY_EFT("F_cleric_explosion_seedboom", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground180_boom", "BOT", 0);
				break;
			case 88:
				break;
			case 89:
				break;
			case 95:
				break;
			case 109:
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
