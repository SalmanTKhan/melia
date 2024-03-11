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

[TrackScript("F_3CMLAKE_86_MQ_06_TRACK")]
public class F3CMLAKE86MQ06TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_3CMLAKE_86_MQ_06_TRACK");
		//SetMap("f_3cmlake_86");
		//CenterPos(-182.76,40.89,-676.08);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-182.763f, 40.89014f, -676.0773f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 155008, "UnvisibleName", "f_3cmlake_86", 108.34, 40.89014, -1214.546, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 155008, "UnvisibleName", "f_3cmlake_86", 128.2536, 40.89014, -1179.043, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 155008, "", "f_3cmlake_86", 106.6315, 40.89014, -894.2963, 1.470588);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 155008, "", "f_3cmlake_86", 104.519, 40.89014, -939.0168, 1.813725);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 155008, "", "f_3cmlake_86", -365.5609, 40.89014, -990.496, 5);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 155008, "", "f_3cmlake_86", -345.7822, 40.89014, -1029.204, 3.823529);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 155008, "UnvisibleName", "f_3cmlake_86", -341.8253, 40.89014, -1190.288, 16.25);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 155008, "UnvisibleName", "f_3cmlake_86", -352.9627, 40.89014, -1225.995, 37.5);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 156125, "", "f_3cmlake_86", -102.1717, 40.89014, -855.6233, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 156117, "Resistance Soldier", "f_3cmlake_86", -123.3625, 40.89014, -870.2379, 0, "Our_Forces");
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 59074, "", "f_3cmlake_86", -274.2952, 40.89014, -1198.99, 43.57143);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 59074, "", "f_3cmlake_86", -255.546, 40.89014, -1230.168, 27.77778);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 59074, "", "f_3cmlake_86", -5.767006, 40.89014, -1211.456, 32.5);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 59074, "", "f_3cmlake_86", -12.6294, 40.89014, -1164.702, 28.33333);
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		var mob14 = Shortcuts.AddMonster(0, 59074, "", "f_3cmlake_86", -52.60789, 40.89014, -1186.256, 25.5);
		mob14.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob14.AddEffect(new ScriptInvisibleEffect());
		mob14.Layer = character.Layer;
		actors.Add(mob14);

		var mob15 = Shortcuts.AddMonster(0, 156135, "", "f_3cmlake_86", -170.6236, 40.89014, -1278.46, 23.42105);
		mob15.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob15.AddEffect(new ScriptInvisibleEffect());
		mob15.Layer = character.Layer;
		actors.Add(mob15);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case -1:
				break;
			case 1:
				//DRT_ACTOR_ATTACH_EFFECT("F_bg_fire001_1", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_bg_fire001_1", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_bg_fire001_1", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_bg_fire001_1", "BOT");
				break;
			case 19:
				await track.Dialog.Msg("F_3CMLAKE_86_MQ_06_DLG1");
				break;
			case 30:
				break;
			case 36:
				break;
			case 52:
				await track.Dialog.Msg("F_3CMLAKE_86_MQ_06_DLG2");
				break;
			case 69:
				//DRT_PLAY_MGAME("F_3CMLAKE_86_MQ_06_MINI");
				//TRACK_SETTENDENCY();
				//CREATE_BATTLE_BOX_INLAYER(0);
				character.AddonMessage("NOTICE_Dm_scroll", "Protect the resistance soldiers and the supplies from the demons!", 8);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
