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

[TrackScript("THORN23_Q_16_TRACK")]
public class THORN23Q16TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("THORN23_Q_16_TRACK");
		//SetMap("d_thorn_23");
		//CenterPos(350.95,459.82,352.86);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 48004, "", "d_thorn_23", 390, 459, 312, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 10021, "", "d_thorn_23", 647.1426, 516.5838, 704.4369, 6.111111);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 10021, "", "d_thorn_23", 515.6859, 516.5839, 592.4529, 62.5);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 10021, "", "d_thorn_23", 613.3633, 514.5397, 568.0104, 62.72727);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 41220, "", "d_thorn_23", 678.6155, 516.5839, 770.7239, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 20020, "Soldier", "d_thorn_23", 766.5696, 516.5839, 771.6415, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 20020, "", "d_thorn_23", 571.3647, 516.5839, 780.0766, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 20024, "", "d_thorn_23", 673.5159, 516.5838, 704.5649, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 20020, "", "d_thorn_23", 528.9516, 516.5839, 726.4173, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 10021, "", "d_thorn_23", 587.5331, 516.5839, 534.47, 65);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 10021, "", "d_thorn_23", 832.5317, 516.5839, 810.2338, 63.125);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 1:
				await track.Dialog.Msg("THORN23_Q_16_prog");
				break;
			case 3:
				break;
			case 4:
				break;
			case 19:
				break;
			case 21:
				break;
			case 25:
				break;
			case 32:
				//DRT_ACTOR_ATTACH_EFFECT("F_wizard_fireball_hit_full_explosion", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_fire_spread", "BOT");
				break;
			case 34:
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_fire_spread", "BOT");
				break;
			case 36:
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_fire_spread", "BOT");
				break;
			case 38:
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_fire_spread", "BOT");
				break;
			case 40:
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_fire_spread", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_ground120_fire", "BOT");
				break;
			case 44:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground119_fire", "BOT");
				break;
			case 52:
				//TRACK_BASICLAYER_MOVE();
				//DRT_FUNC_ACT("THORN23_Q_16_TRACK_END_FUNC");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
