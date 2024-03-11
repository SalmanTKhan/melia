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

[TrackScript("EP13_F_SIAULIAI_5_MQ_02_TRACK")]
public class EP13FSIAULIAI5MQ02TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP13_F_SIAULIAI_5_MQ_02_TRACK");
		//SetMap("ep13_f_siauliai_5");
		//CenterPos(-255.90,15.98,-802.34);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-318.001f, 15.98207f, -792.8199f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 147374, "", "ep13_f_siauliai_5", 385.9908, 16.61477, -804.8874, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 20045, "", "ep13_f_siauliai_5", 28.21797, 15.98207, -539.3731, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 20045, "", "ep13_f_siauliai_5", -1140.96, 15.98207, -462.5196, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 20045, "", "ep13_f_siauliai_5", -732.3672, 15.98207, 529.0586, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 40001, "UnvisibleName", "ep13_f_siauliai_5", -322.3908, 15.98207, -775.9434, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 40001, "UnvisibleName", "ep13_f_siauliai_5", -641.2955, 15.98207, -644.4202, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 40001, "UnvisibleName", "ep13_f_siauliai_5", -743.6295, 15.98207, -176.8885, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 151020, "UnvisibleName", "ep13_f_siauliai_5", -741.0656, 15.98207, -46.77813, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 147382, "", "ep13_f_siauliai_5", -15.32494, 15.98207, -856.9889, 8.888889);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 151018, "UnvisibleName", "ep13_f_siauliai_5", -710.8954, 15.98207, -451.3079, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 151018, "UnvisibleName", "ep13_f_siauliai_5", -528.9988, 15.98207, -657.0941, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 151018, "UnvisibleName", "ep13_f_siauliai_5", -740.7803, 15.98207, -220.9822, 0);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 147374, "", "ep13_f_siauliai_5", 85.56097, 15.98207, -528.4764, 0);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 147374, "", "ep13_f_siauliai_5", 375.3902, 15.98207, -762.3335, 0);
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		var mob14 = Shortcuts.AddMonster(0, 147374, "", "ep13_f_siauliai_5", -772.8116, 15.98207, 533.7557, 0);
		mob14.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob14.AddEffect(new ScriptInvisibleEffect());
		mob14.Layer = character.Layer;
		actors.Add(mob14);

		var mob15 = Shortcuts.AddMonster(0, 20044, "", "ep13_f_siauliai_5", 430.0851, 24.56323, -766.8518, 0);
		mob15.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob15.AddEffect(new ScriptInvisibleEffect());
		mob15.Layer = character.Layer;
		actors.Add(mob15);

		var mob16 = Shortcuts.AddMonster(0, 151020, "UnvisibleName", "ep13_f_siauliai_5", -56.16702, 15.98207, -861.0854, 0);
		mob16.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob16.AddEffect(new ScriptInvisibleEffect());
		mob16.Layer = character.Layer;
		actors.Add(mob16);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 9:
				await track.Dialog.Msg("EP13_F_SIAULIAI_5_MQ02_TRACK_DLG");
				break;
			case 10:
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion105_blood", "MID");
				break;
			case 11:
				//DRT_ACTOR_ATTACH_EFFECT("I_force018_trail_fire_whiteball", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke017_violet_loop", "MID");
				break;
			case 55:
				//DRT_ACTOR_PLAY_EFT("I_question_arrow_mash", "TOP", 0);
				break;
			case 58:
				Send.ZC_NORMAL.Notice(character, "EP13_F_SIAULIAI_5_MQ02_WARNING", 3);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
