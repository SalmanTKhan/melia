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

[TrackScript("ABBAY_64_1_MQ020_TRACK")]
public class ABBAY641MQ020TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ABBAY_64_1_MQ020_TRACK");
		//SetMap("d_abbey_64_1");
		//CenterPos(-206.04,109.51,-1147.44);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 155046, "", "d_abbey_64_1", -258.77, 80.6, -929.58, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 153119, "", "d_abbey_64_1", -160.9, 97.02, -1115.83, 47.85714);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 47106, "UnvisibleName", "d_abbey_64_1", -283.68, 80.75, -958.91, 0, "Monster");
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 151006, "UnvisibleName", "d_abbey_64_1", -258, 80.32, -972, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 103025, "", "d_abbey_64_1", -146.6196, 96.41736, -614.3508, 218.3333);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 103025, "", "d_abbey_64_1", -212.3304, 96.37568, -618.4649, 180);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 20046, "", "d_abbey_64_1", -251.6, 80.58, -933.42, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 47106, "UnvisibleName", "d_abbey_64_1", -220.91, 80.72, -911.2, 0, "Monster");
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 47106, "UnvisibleName", "d_abbey_64_1", -277.01, 80.95, -905.2, 0, "Monster");
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 47106, "UnvisibleName", "d_abbey_64_1", -225, 80.4, -961.24, 0, "Monster");
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		character.Movement.MoveTo(new Position(-168.8676f, 102.3447f, -1129.127f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 8:
				//DRT_ACTOR_PLAY_EFT("F_light081_ground_orange2", "BOT", 0);
				break;
			case 16:
				//DRT_ACTOR_PLAY_EFT("F_light081_ground_orange2", "BOT", 0);
				break;
			case 24:
				//DRT_ACTOR_PLAY_EFT("F_light081_ground_orange2", "BOT", 0);
				break;
			case 31:
				break;
			case 32:
				//DRT_ACTOR_PLAY_EFT("F_light081_ground_orange2", "BOT", 0);
				break;
			case 39:
				//DRT_ACTOR_PLAY_EFT("F_light081_ground_orange2", "BOT", 0);
				break;
			case 46:
				//DRT_ACTOR_PLAY_EFT("F_light081_ground_orange2", "BOT", 0);
				break;
			case 48:
				character.AddonMessage("NOTICE_Dm_!", "Destroy the restrainment devices attached to Monk Goss!", 3);
				break;
			case 49:
				//DRT_PLAY_MGAME("ABBAY_64_1_MQ020_MINI");
				//TRACK_SETTENDENCY();
				CreateBattleBoxInLayer(character, track);
				break;
			case 55:
				//DRT_ACTOR_PLAY_EFT("F_light081_ground_orange2", "BOT", 0);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
