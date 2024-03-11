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

[TrackScript("ZACHA5_SPIRIT_TRACK")]
public class ZACHA5SPIRITTRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ZACHA5_SPIRIT_TRACK");
		//SetMap("d_zachariel_36");
		//CenterPos(-3021.61,448.93,466.85);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 20025, "UnvisibleName", "d_zachariel_36", -2658.367, 453.2031, 492.2348, 0.3846154);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(-3017.638f, 448.9292f, 455.8824f));
		actors.Add(character);

		var mob1 = Shortcuts.AddMonster(0, 154040, "", "d_zachariel_36", -2657.975, 453.2031, 490.9146, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 47234, "", "d_zachariel_36", -2657.98, 453.2, 490.91, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 153032, "", "d_zachariel_36", -3014.899, 448.9292, 494.2025, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 12082, "", "d_zachariel_36", -2952.673, 448.9292, 572.0002, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 12082, "", "d_zachariel_36", -3080.787, 448.9292, 560.5624, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 12082, "", "d_zachariel_36", -2950.17, 448.9292, 415.5064, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 12082, "", "d_zachariel_36", -3074.865, 448.9292, 404.7559, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 153024, "", "d_zachariel_36", -3018.783, 448.9292, 493.3185, 5.277778);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 20025, "", "d_zachariel_36", -2657.33, 453.2031, 492.7849, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 20025, "", "d_zachariel_36", -2280.709, 407.7412, 657.6486, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 20025, "", "d_zachariel_36", -2515.559, 384.2692, 47.85114, 0);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 20025, "", "d_zachariel_36", -2962.513, 403.7351, 663.7818, 0);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 20025, "", "d_zachariel_36", -2911.614, 407.4971, 228.4072, 0);
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 23:
				break;
			case 33:
				await track.Dialog.Msg("ZACHA5F_SPIRIT");
				break;
			case 34:
				break;
			case 36:
				//DRT_ACTOR_ATTACH_EFFECT("F_line022_yellow", "BOT");
				break;
			case 37:
				//DRT_ACTOR_ATTACH_EFFECT("F_bg_light003_yellow", "MID");
				break;
			case 39:
				//DRT_ACTOR_ATTACH_EFFECT("F_line022_yellow", "TOP");
				break;
			case 41:
				//DRT_ACTOR_ATTACH_EFFECT("F_line022_yellow", "TOP");
				break;
			case 45:
				//DRT_ACTOR_ATTACH_EFFECT("F_line022_yellow", "TOP");
				break;
			case 54:
				//DRT_ACTOR_ATTACH_EFFECT("F_light078_holy_yellow_loop", "BOT");
				break;
			case 63:
				await track.Dialog.Msg("ZACHA5F_SPIRIT_DLG01");
				break;
			case 66:
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup004", "BOT");
				break;
			case 74:
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup015_blue", "BOT");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
