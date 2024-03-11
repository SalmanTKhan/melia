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

[TrackScript("GELE573_MQ_09_AFTER")]
public class GELE573MQ09AFTER : TrackScript
{
	protected override void Load()
	{
		SetId("GELE573_MQ_09_AFTER");
		//SetMap("f_gele_57_3");
		//CenterPos(63.69,350.07,-104.08);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 57223, "", "f_gele_57_3", 62, 350, -135, 0, "Neutral");
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.Level = 27;
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var npc0 = Shortcuts.AddNpc(0, 147373, "", "f_gele_57_3", 66.50705, 350.0658, -153.7191, 0);
		npc0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc0.AddEffect(new ScriptInvisibleEffect());
		npc0.Layer = character.Layer;
		actors.Add(npc0);

		var mob1 = Shortcuts.AddMonster(0, 147371, "", "f_gele_57_3", 50.21964, 350.0658, -256.3456, 2.083333);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		character.Movement.MoveTo(new Position(103.5662f, 350.0658f, -155.2244f));
		actors.Add(character);

		var mob2 = Shortcuts.AddMonster(0, 20025, "", "f_gele_57_3", 50.22, 350.07, -256.35, 1.25);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 20024, "", "f_gele_57_3", 52.46235, 350.0658, -288.262, 16.57609);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 20024, "", "f_gele_57_3", 77.4062, 350.0658, -90.20612, 5.806451);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 3:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke145_dark_ground_loop", "BOT");
				break;
			case 22:
				break;
			case 26:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground065_smoke", "BOT");
				break;
			case 32:
				await track.Dialog.Msg("f_gele_57_3_gesti_5");
				break;
			case 34:
				//DRT_ACTOR_ATTACH_EFFECT("I_cleric_oobe_loop_levitation1", "BOT");
				break;
			case 45:
				//DRT_UNALPHA_OBJ(1, 1, "std", 255, 255, 255, 255, 0, 20);
				break;
			case 47:
				//DRT_ACTOR_ATTACH_EFFECT("F_light068_yellow_loop", "MID");
				break;
			case 49:
				//DRT_ACTOR_ATTACH_EFFECT("E_event_gesti", "BOT");
				break;
			case 58:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_out029_red", "BOT");
				break;
			case 61:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_out029_red", "BOT");
				break;
			case 64:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_out029_red", "BOT");
				break;
			case 67:
				//DRT_ACTOR_ATTACH_EFFECT("F_circle011_dark", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke076", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_out029_red", "BOT");
				break;
			case 68:
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion096_violet", "MID");
				break;
			case 69:
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion101_dark", "BOT");
				break;
			case 77:
				await track.Dialog.Msg("f_gele_57_3_gesti_1");
				break;
			case 78:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke145_dark_ground2", "BOT");
				break;
			case 82:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke107", "BOT");
				break;
			case 105:
				character.AddSessionObject(PropertyName.GELE573_MQ_08, 1);
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
