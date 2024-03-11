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

[TrackScript("F_3CMLAKE_85_MQ_07_TRACK")]
public class F3CMLAKE85MQ07TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_3CMLAKE_85_MQ_07_TRACK");
		//SetMap("f_3cmlake_85");
		//CenterPos(-1265.92,163.68,361.97);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-1265.392f, 163.679f, 362.6588f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 156132, "Resistance Soldier", "f_3cmlake_85", -1306.955, 163.679, 376.3055, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 47236, "", "f_3cmlake_85", -1273.881, 163.679, 278.1191, 33.5);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 147469, "", "f_3cmlake_85", -1279.296, 163.3745, 434.3185, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 147469, "", "f_3cmlake_85", -1281.082, 163.3745, 513.3046, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 147469, "", "f_3cmlake_85", -1200.732, 163.3745, 515.0385, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 147469, "", "f_3cmlake_85", -1202.072, 158.4738, 594.8524, 0.5263158);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 147469, "", "f_3cmlake_85", -1202.633, 163.1637, 674.4403, 0.2631579);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 147469, "", "f_3cmlake_85", -1123.699, 161.1494, 673.7576, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 147469, "", "f_3cmlake_85", -1122.499, 158.1299, 595.5895, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 147469, "", "f_3cmlake_85", -1044.138, 158.3591, 595.8401, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 147469, "", "f_3cmlake_85", -1042.619, 158.4126, 518.8068, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 147469, "", "f_3cmlake_85", -1121.568, 158.1818, 516.7046, 0);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 147469, "", "f_3cmlake_85", -1123.331, 162.5566, 437.1458, 1.875);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 147469, "", "f_3cmlake_85", -1200.044, 162.5566, 434.6712, 3.75);
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		var mob14 = Shortcuts.AddMonster(0, 156100, "", "f_3cmlake_85", -1377.203, 157.1073, 629.1155, 0);
		mob14.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob14.AddEffect(new ScriptInvisibleEffect());
		mob14.Layer = character.Layer;
		actors.Add(mob14);

		var mob15 = Shortcuts.AddMonster(0, 156102, "", "f_3cmlake_85", -1174.549, 164.8682, 345.2112, 0);
		mob15.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob15.AddEffect(new ScriptInvisibleEffect());
		mob15.Layer = character.Layer;
		actors.Add(mob15);

		var mob16 = Shortcuts.AddMonster(0, 156102, "", "f_3cmlake_85", -979.0346, 164.8682, 346.0343, 0);
		mob16.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob16.AddEffect(new ScriptInvisibleEffect());
		mob16.Layer = character.Layer;
		actors.Add(mob16);

		var mob17 = Shortcuts.AddMonster(0, 156102, "", "f_3cmlake_85", -1076.492, 164.8682, 344.5012, 0);
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
				//SetFixAnim("on_loop");
				//DRT_RUN_FUNCTION("SCR_F_3CMLAKE_85_MQ_07_BASIN_EFFECT");
				//SetFixAnim("on_loop");
				//SetFixAnim("on_loop");
				//SetFixAnim("on_loop");
				break;
			case 31:
				//DRT_PLAY_MGAME("F_3CMLAKE_85_MQ_07_MINI");
				break;
			case 87:
				break;
			case 98:
				break;
			case 100:
				//DRT_ACTOR_PLAY_EFT("F_light107_violet", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_light069_white", "BOT", 0);
				break;
			case 101:
				//DRT_ACTOR_PLAY_EFT("F_light119_yellow", "BOT", 0);
				break;
			case 102:
				//DRT_ACTOR_PLAY_EFT("F_light119_yellow", "BOT", 0);
				break;
			case 103:
				//DRT_ACTOR_PLAY_EFT("F_light119_yellow", "BOT", 0);
				break;
			case 104:
				//DRT_ACTOR_PLAY_EFT("F_light119_yellow", "BOT", 0);
				break;
			case 105:
				//DRT_ACTOR_PLAY_EFT("F_light119_yellow", "BOT", 0);
				break;
			case 106:
				//DRT_ACTOR_PLAY_EFT("F_light119_yellow", "BOT", 0);
				break;
			case 107:
				//DRT_ACTOR_PLAY_EFT("F_light119_yellow", "BOT", 0);
				break;
			case 108:
				//DRT_ACTOR_PLAY_EFT("F_light119_yellow", "BOT", 0);
				break;
			case 109:
				//DRT_ACTOR_PLAY_EFT("F_light119_yellow", "BOT", 0);
				break;
			case 110:
				//DRT_ACTOR_PLAY_EFT("F_light119_yellow", "BOT", 0);
				break;
			case 111:
				//DRT_ACTOR_PLAY_EFT("F_light119_yellow", "BOT", 0);
				break;
			case 112:
				//DRT_ACTOR_PLAY_EFT("F_light119_yellow", "BOT", 0);
				break;
			case 138:
				await track.Dialog.Msg("F_3CMLAKE_85_MQ_07_DLG1");
				break;
			case 139:
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
