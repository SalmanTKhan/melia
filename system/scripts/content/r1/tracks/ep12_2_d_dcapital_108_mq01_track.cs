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

[TrackScript("EP12_2_D_DCAPITAL_108_MQ01_TRACK")]
public class EP122DDCAPITAL108MQ01TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP12_2_D_DCAPITAL_108_MQ01_TRACK");
		//SetMap("d_dcapital_108");
		//CenterPos(486.38,24.74,-1601.47);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 150212, "", "d_dcapital_108", 448.1626, 24.74463, -1588.242, 15.51724);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 150230, "Mulia", "d_dcapital_108", 449.3752, 24.74463, -1613.744, 10.24096);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 59527, "", "d_dcapital_108", 682.7691, 27.58763, -1346.504, 31.93182);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 59527, "", "d_dcapital_108", 682.4967, 27.58763, -1453.79, 32.5);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 59527, "", "d_dcapital_108", 152.9338, 27.58763, -1340.997, 31.47727);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 59527, "", "d_dcapital_108", 167.0346, 27.58763, -1452.733, 23.97727);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 59527, "", "d_dcapital_108", 209.7676, 27.58763, -1402.193, 13.97727);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 59527, "", "d_dcapital_108", 109.121, 27.58763, -1392.135, 26.36364);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 59527, "", "d_dcapital_108", 62.19912, 22.36256, -1382.461, 24.20454);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 59527, "", "d_dcapital_108", 60.07495, 22.36256, -1336.307, 23.75);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 59527, "", "d_dcapital_108", 17.32133, 22.36256, -1379.05, 47.38636);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 59527, "", "d_dcapital_108", 11.35864, 22.36256, -1335.116, 44.20454);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 59527, "", "d_dcapital_108", 754.5703, 27.58763, -1454.583, 63.75);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 59527, "", "d_dcapital_108", 748.3526, 27.58763, -1352.172, 62.61364);
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		character.Movement.MoveTo(new Position(482.7838f, 24.74463f, -1608.651f));
		actors.Add(character);

		var mob14 = Shortcuts.AddMonster(0, 59508, "", "d_dcapital_108", 845.5154, 27.58763, -1362.627, 15.69444);
		mob14.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob14.AddEffect(new ScriptInvisibleEffect());
		mob14.Layer = character.Layer;
		actors.Add(mob14);

		var mob15 = Shortcuts.AddMonster(0, 20026, "", "d_dcapital_108", 280.892, 27.58763, -1392.949, 0);
		mob15.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob15.AddEffect(new ScriptInvisibleEffect());
		mob15.Layer = character.Layer;
		actors.Add(mob15);

		var mob16 = Shortcuts.AddMonster(0, 47269, "UnvisibleName", "d_dcapital_108", 281.9857, 27.58763, -1394.915, 0);
		mob16.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob16.AddEffect(new ScriptInvisibleEffect());
		mob16.Layer = character.Layer;
		actors.Add(mob16);

		var mob17 = Shortcuts.AddMonster(0, 20026, "", "d_dcapital_108", 483.5867, 24.74463, -1620.082, 2.727273);
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
			case 37:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ01_TRACK_DLG_01");
				break;
			case 38:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ01_TRACK_DLG_02");
				break;
			case 39:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ01_TRACK_DLG_03");
				break;
			case 40:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ01_TRACK_DLG_04");
				break;
			case 41:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ01_TRACK_DLG_05");
				break;
			case 44:
				//DRT_ACTOR_ATTACH_EFFECT("I_change_ground_mash", "BOT");
				break;
			case 46:
				//DRT_ACTOR_ATTACH_EFFECT("I_change_ground_mash", "BOT");
				break;
			case 48:
				//DRT_ACTOR_ATTACH_EFFECT("I_change_ground_mash", "BOT");
				break;
			case 70:
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
