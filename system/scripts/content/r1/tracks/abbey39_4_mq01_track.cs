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

[TrackScript("ABBEY39_4_MQ01_TRACK")]
public class ABBEY394MQ01TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ABBEY39_4_MQ01_TRACK");
		//SetMap("None");
		//CenterPos(1288.89,72.82,-741.68);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 155042, "UnVisibleName", "None", 1330.995, 72.82, -707.3923, 84.6875);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 155046, "UnVisibleName", "None", 1334.303, 72.81781, -773.6115, 54.64286);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 155043, "UnVisibleName", "None", 1429.355, 72.82001, -794.395, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 147405, "UnVisibleName", "None", 1458.198, 72.82, -632.04, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 57037, "UnVisibleName", "None", 1485.274, 72.82, -634.1956, 0, "Neutral");
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 20045, "", "None", 1012.94, 144.72, -769.5075, 20.27273);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 155045, "UnVisibleName", "None", 1432.663, 72.8178, -752.5841, 71.02941);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 155043, "UnVisibleName", "None", 1374.795, 72.81781, -715.1709, 71.94444);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 155044, "UnVisibleName", "None", 1316.09, 72.82, -764.46, 67.30769);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 155044, "UnVisibleName", "None", 1484.484, 72.8178, -741.5314, 88.28125);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 147404, "UnVisibleName", "None", 1412.932, 72.8178, -749.8325, 97.14286);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 147406, "UnVisibleName", "None", 1417.244, 72.8178, -751.1912, 71.94444);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		character.Movement.MoveTo(new Position(1324.575f, 72.81781f, -730.2578f));
		actors.Add(character);

		var mob12 = Shortcuts.AddMonster(0, 47521, "UnVisibleName", "None", 1447.372, 72.8178, -761.1937, 78.06452, "Neutral");
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 57037, "UnVisibleName", "None", 1454.763, 72.8178, -767.254, 75.83334, "Neutral");
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		var mob14 = Shortcuts.AddMonster(0, 147353, "UnVisibleName", "None", 752.2054, 144.7219, -1220.616, 0);
		mob14.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob14.AddEffect(new ScriptInvisibleEffect());
		mob14.Layer = character.Layer;
		actors.Add(mob14);

		var mob15 = Shortcuts.AddMonster(0, 20026, "", "None", 981.3485, 144.8543, 311.0909, 0);
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
			case 2:
				break;
			case 5:
				//DRT_ACTOR_PLAY_EFT("F_light073_yellow", "MID", 1);
				break;
			case 10:
				//DRT_ACTOR_PLAY_EFT("F_light073_yellow", "MID", 1);
				break;
			case 11:
				break;
			case 13:
				break;
			case 14:
				break;
			case 15:
				//DRT_ACTOR_PLAY_EFT("F_light073_yellow", "MID", 1);
				break;
			case 16:
				//DRT_ACTOR_PLAY_EFT("F_light003_yellow", "MID", 0);
				break;
			case 17:
				//DRT_ACTOR_PLAY_EFT("F_light012_1", "BOT", 0);
				break;
			case 22:
				//DRT_ACTOR_PLAY_EFT("F_light061", "BOT", 0);
				break;
			case 27:
				break;
			case 30:
				break;
			case 32:
				break;
			case 41:
				break;
			case 69:
				//DRT_PLAY_MGAME("ABBEY39_4_MQ01_MINI");
				CreateBattleBoxInLayer(character, track);
				Send.ZC_NORMAL.SetupCutscene(character, false, false, true);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
