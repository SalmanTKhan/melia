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

[TrackScript("THORN22_ADD_SUB_02_TRACK")]
public class THORN22ADDSUB02TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("THORN22_ADD_SUB_02_TRACK");
		//SetMap("d_thorn_22");
		//CenterPos(-2171.02,444.03,-1253.78);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-2186.875f, 444.0274f, -1238.846f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 41285, "", "d_thorn_22", -2123.168, 444.0275, -863.7813, 31.5);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 41285, "", "d_thorn_22", -2224.172, 444.0275, -913.0206, 7870);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 41285, "", "d_thorn_22", -2035.048, 444.0275, -925.0735, 8400);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 41285, "", "d_thorn_22", -2011.302, 444.0275, -1016.784, 8225);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 41285, "", "d_thorn_22", -2293.949, 444.0273, -1060.454, 8020);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 41285, "", "d_thorn_22", -2124.427, 444.0275, -979.881, 8365);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 41285, "", "d_thorn_22", -1961.995, 444.0275, -1222.91, 9150);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 10032, "", "d_thorn_22", -2209, 444, -1218, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 40070, "", "d_thorn_22", -2102, 440, -1347, 1.923077);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 2:
				break;
			case 3:
				//DRT_ACTOR_ATTACH_EFFECT("E_poata_skl", "BOT");
				break;
			case 4:
				//DRT_ACTOR_ATTACH_EFFECT("E_poata_skl", "BOT");
				break;
			case 5:
				//DRT_ACTOR_ATTACH_EFFECT("E_poata_skl", "BOT");
				break;
			case 7:
				break;
			case 8:
				//DRT_ACTOR_ATTACH_EFFECT("E_poata_skl", "BOT");
				break;
			case 10:
				break;
			case 11:
				//DRT_ACTOR_ATTACH_EFFECT("E_poata_skl", "BOT");
				break;
			case 12:
				break;
			case 13:
				//DRT_ACTOR_ATTACH_EFFECT("E_poata_skl", "BOT");
				break;
			case 14:
				//DRT_ACTOR_ATTACH_EFFECT("E_poata_skl", "BOT");
				break;
			case 19:
				//TRACK_SETTENDENCY();
				//TRACK_MON_LOOKAT();
				CreateBattleBoxInLayer(character, track);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
