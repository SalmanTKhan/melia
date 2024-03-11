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

[TrackScript("SIAU15RE_SQ_05_TRACK")]
public class SIAU15RESQ05TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("SIAU15RE_SQ_05_TRACK");
		//SetMap("f_siauliai_15_re");
		//CenterPos(-1151.35,922.76,1232.70);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-1149.842f, 922.763f, 1278.089f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 103034, "UnvisibleName", "f_siauliai_15_re", -1159.159, 922.7631, 1301.426, 0, "Neutral");
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 47204, "UnvisibleName", "f_siauliai_15_re", -1135.919, 922.7631, 1290.125, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 47204, "UnvisibleName", "f_siauliai_15_re", -1186.545, 922.763, 1299.603, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 47204, "UnvisibleName", "f_siauliai_15_re", -1181.755, 922.763, 1323.285, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 47204, "UnvisibleName", "f_siauliai_15_re", -1132.398, 922.763, 1350.076, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 57996, "", "f_siauliai_15_re", -1139.273, 922.763, 1310.14, 41.875);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 47204, "UnvisibleName", "f_siauliai_15_re", -1101.167, 922.763, 1328.398, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 47204, "UnvisibleName", "f_siauliai_15_re", -1064.643, 922.763, 1283.656, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 47204, "UnvisibleName", "f_siauliai_15_re", -1054.506, 922.763, 1322.532, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 47204, "UnvisibleName", "f_siauliai_15_re", -1107.336, 922.763, 1354.486, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 103034, "UnvisibleName", "f_siauliai_15_re", -1150.476, 922.7631, 1313.667, 0, "Neutral");
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 103034, "UnvisibleName", "f_siauliai_15_re", -1165.309, 922.763, 1333.461, 0, "Neutral");
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 103034, "UnvisibleName", "f_siauliai_15_re", -1132.748, 922.763, 1310.936, 0, "Neutral");
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
			case 13:
				//DRT_ACTOR_ATTACH_EFFECT("E_pc_standthrow_fire", "BOT");
				break;
			case 16:
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_fire_spread", "BOT");
				break;
			case 34:
				break;
			case 37:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_out014_smoke", "BOT");
				break;
			case 45:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke129_spreadout", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_out008_smoke", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_out007_circle", "BOT");
				break;
			case 55:
				//CREATE_BATTLE_BOX_INLAYER(0);
				//TRACK_SETTENDENCY();
				character.AddonMessage("NOTICE_Dm_!", "Chafer, the owner of the nest is attacking! ", 3);
				//TRACK_MON_LOOKAT();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
