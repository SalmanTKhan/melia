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

[TrackScript("VPRISON512_MQ_05_TRACK")]
public class VPRISON512MQ05TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("VPRISON512_MQ_05_TRACK");
		//SetMap("d_velniasprison_51_2");
		//CenterPos(1048.28,254.14,-22.51);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 57412, "", "d_velniasprison_51_2", 538.7922, 395.4641, -1592.606, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 57581, "", "d_velniasprison_51_2", 989.9726, 254.1407, -58.18155, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		character.Movement.MoveTo(new Position(1018.324f, 254.1407f, -59.71761f));
		actors.Add(character);

		var mob2 = Shortcuts.AddMonster(0, 57827, "", "d_velniasprison_51_2", 750.72, 395.46, -1576.97, 31.25);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 57690, "", "d_velniasprison_51_2", 496.5847, 395.4641, -1527.197, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 57690, "", "d_velniasprison_51_2", 507.3969, 395.4641, -1649.043, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 57690, "", "d_velniasprison_51_2", 480.7652, 395.4641, -1611.501, 1.666667);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 12082, "", "d_velniasprison_51_2", 750.7246, 395.4641, -1576.973, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 20024, "", "d_velniasprison_51_2", 629.1019, 395.4641, -1574.278, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 57581, "", "d_velniasprison_51_2", 828.6518, 395.4641, -1567.962, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 57581, "", "d_velniasprison_51_2", 571.1213, 395.4641, -1612.646, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 2:
				//DRT_ACTOR_ATTACH_EFFECT("F_bg_light010_white_ornage_long2", "BOT");
				break;
			case 3:
				//DRT_ACTOR_ATTACH_EFFECT("F_bg_light010_white_ornage_long2", "BOT");
				break;
			case 6:
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_basic025_white_line", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_basic025_white_line", "BOT");
				break;
			case 7:
				//DRT_ACTOR_ATTACH_EFFECT("F_bg_light010_white_ornage_long2", "BOT");
				break;
			case 8:
				//DRT_ACTOR_ATTACH_EFFECT("F_bg_light010_white_ornage_long2", "BOT");
				break;
			case 9:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke138_white", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_basic025_white_line", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_basic025_white_line", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke138_white", "BOT");
				break;
			case 24:
				break;
			case 25:
				break;
			case 26:
				break;
			case 32:
				//DRT_ACTOR_ATTACH_EFFECT("F_light055_black", "TOP");
				break;
			case 36:
				break;
			case 40:
				//DRT_ACTOR_ATTACH_EFFECT("I_spread_in010_mintdark", "BOT");
				break;
			case 43:
				//DRT_SETHOOKMSGOWNER(0, 1);
				break;
			case 46:
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion098_dark_blue", "TOP");
				break;
			case 47:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke005_dark", "BOT");
				break;
			case 55:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke138_white", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_bg_light010_white_ornage_long2", "BOT");
				break;
			case 56:
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_basic025_white_line", "BOT");
				break;
			case 57:
				//DRT_SETHOOKMSGOWNER(0, 1);
				break;
			case 61:
				//DRT_ACTOR_ATTACH_EFFECT("F_light032_green", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_light033_circle_blue", "MID");
				break;
			case 62:
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion026_rize_red", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke023_dark", "MID");
				break;
			case 67:
				//TRACK_SETTENDENCY();
				break;
			case 69:
				character.AddonMessage("NOTICE_Dm_!", "Defeat Demon Lord Nuaele!", 3);
				//DRT_RUN_FUNCTION("VPRISON512_MQ_05_TRACK_PARTY_SETPOS");
				//InsertHate(999);
				//InsertHate(999);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
