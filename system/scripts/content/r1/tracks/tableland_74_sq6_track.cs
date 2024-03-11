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

[TrackScript("TABLELAND_74_SQ6_TRACK")]
public class TABLELAND74SQ6TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("TABLELAND_74_SQ6_TRACK");
		//SetMap("f_tableland_74");
		//CenterPos(259.25,593.93,136.00);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 103037, "", "f_tableland_74", 274.54, 593.93, 176.79, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 10032, "", "f_tableland_74", 338.9796, 593.9312, 128.4059, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 20019, "Soldier", "f_tableland_74", 148.92, 593.78, 218.29, 81.15385);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 20019, "Soldier", "f_tableland_74", 433.587, 593.9312, -40.81256, 61.36364);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 20019, "Soldier", "f_tableland_74", 494.0669, 593.9312, -5.503662, 76);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var npc0 = Shortcuts.AddNpc(0, 20012, "Soldier", "f_tableland_74", 323.3638, 593.9312, -107.2562, 61.07143);
		npc0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc0.AddEffect(new ScriptInvisibleEffect());
		npc0.Layer = character.Layer;
		actors.Add(npc0);

		var mob5 = Shortcuts.AddMonster(0, 20012, "Soldier", "f_tableland_74", 217.2459, 593.9307, 209.9407, 72.5);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var npc1 = Shortcuts.AddNpc(0, 20012, "Soldier", "f_tableland_74", 271.6751, 593.9312, -129.8523, 69.375);
		npc1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc1.AddEffect(new ScriptInvisibleEffect());
		npc1.Layer = character.Layer;
		actors.Add(npc1);

		var mob6 = Shortcuts.AddMonster(0, 103041, "", "f_tableland_74", 378.5785, 801.851, 695.1477, 13.27586);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 57979, "", "f_tableland_74", 187.851, 593.9312, 108.7981, 9.204545);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 57904, "", "f_tableland_74", 150.1078, 593.9311, 138.5196, 8.181818);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 57904, "", "f_tableland_74", 246.4689, 593.9312, 135.7635, 5.795455);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 103041, "", "f_tableland_74", 196.4112, 593.9304, 181.362, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		character.Movement.MoveTo(new Position(269.1714f, 593.9312f, 144.496f));
		actors.Add(character);

		var npc2 = Shortcuts.AddNpc(0, 57709, "UnvisibleName", "f_tableland_74", 125.61, 592.34, 252.49, 0);
		npc2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc2.AddEffect(new ScriptInvisibleEffect());
		npc2.Layer = character.Layer;
		actors.Add(npc2);

		var npc3 = Shortcuts.AddNpc(0, 57709, "", "f_tableland_74", 140.17, 591.19, 257.34, 0);
		npc3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc3.AddEffect(new ScriptInvisibleEffect());
		npc3.Layer = character.Layer;
		actors.Add(npc3);

		var npc4 = Shortcuts.AddNpc(0, 57709, "", "f_tableland_74", 154.3, 589.97, 262.58, 0);
		npc4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc4.AddEffect(new ScriptInvisibleEffect());
		npc4.Layer = character.Layer;
		actors.Add(npc4);

		var npc5 = Shortcuts.AddNpc(0, 57709, "UnvisibleName", "f_tableland_74", 218.46, 593.93, 236.74, 0);
		npc5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc5.AddEffect(new ScriptInvisibleEffect());
		npc5.Layer = character.Layer;
		actors.Add(npc5);

		var npc6 = Shortcuts.AddNpc(0, 57709, "UnvisibleName", "f_tableland_74", 234.17, 593.93, 236.69, 0);
		npc6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc6.AddEffect(new ScriptInvisibleEffect());
		npc6.Layer = character.Layer;
		actors.Add(npc6);

		var npc7 = Shortcuts.AddNpc(0, 57709, "UnvisibleName", "f_tableland_74", 664.84, 593.41, -120.06, 0);
		npc7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc7.AddEffect(new ScriptInvisibleEffect());
		npc7.Layer = character.Layer;
		actors.Add(npc7);

		var npc8 = Shortcuts.AddNpc(0, 57709, "UnvisibleName", "f_tableland_74", 663.98, 593.44, -135.99, 0);
		npc8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc8.AddEffect(new ScriptInvisibleEffect());
		npc8.Layer = character.Layer;
		actors.Add(npc8);

		var npc9 = Shortcuts.AddNpc(0, 57709, "UnvisibleName", "f_tableland_74", 666.69, 591.27, -212.79, 0);
		npc9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc9.AddEffect(new ScriptInvisibleEffect());
		npc9.Layer = character.Layer;
		actors.Add(npc9);

		var npc10 = Shortcuts.AddNpc(0, 57709, "", "f_tableland_74", 669.1, 590.87, -198.44, 0);
		npc10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc10.AddEffect(new ScriptInvisibleEffect());
		npc10.Layer = character.Layer;
		actors.Add(npc10);

		var npc11 = Shortcuts.AddNpc(0, 57709, "UnvisibleName", "f_tableland_74", 672.89, 589.66, -182.86, 0);
		npc11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc11.AddEffect(new ScriptInvisibleEffect());
		npc11.Layer = character.Layer;
		actors.Add(npc11);

		var mob11 = Shortcuts.AddMonster(0, 151030, "", "f_tableland_74", 519.93, 593.93, 17.32, 0);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 151030, "", "f_tableland_74", 556.1, 593.93, 42.7, 0);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 151030, "", "f_tableland_74", 384.12, 593.93, 110.88, 0);
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		var mob14 = Shortcuts.AddMonster(0, 20024, "", "f_tableland_74", 378.58, 801.85, 695.15, 0);
		mob14.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob14.AddEffect(new ScriptInvisibleEffect());
		mob14.Layer = character.Layer;
		actors.Add(mob14);

		var mob15 = Shortcuts.AddMonster(0, 153158, "", "f_tableland_74", 145.7996, 586.7852, 357.881, 0);
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
			case 24:
				break;
			case 30:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke141_darkblue_spread_out_loop", "BOT");
				break;
			case 31:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in004_darkblue", "BOT");
				break;
			case 41:
				//DRT_ACTOR_ATTACH_EFFECT("F_circle011_dark", "BOT");
				break;
			case 46:
				break;
			case 51:
				//DRT_ACTOR_ATTACH_EFFECT("fence_dead", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("vine_std5_dead", "BOT");
				break;
			case 54:
				//DRT_ACTOR_ATTACH_EFFECT("F_circle011_dark", "BOT");
				break;
			case 57:
				character.AddonMessage("NOTICE_Dm_scroll", "Defeat the demons attacking the unit{nl}to allow the soldiers to retreat", 5);
				break;
			case 59:
				break;
			case 60:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground065_smoke", "BOT");
				break;
			case 61:
				break;
			case 64:
				//TRACK_SETTENDENCY();
				CreateBattleBoxInLayer(character, track);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
