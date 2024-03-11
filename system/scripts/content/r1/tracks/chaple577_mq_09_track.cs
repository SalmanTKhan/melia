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

[TrackScript("CHAPLE577_MQ_09_TRACK")]
public class CHAPLE577MQ09TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CHAPLE577_MQ_09_TRACK");
		//SetMap("d_chapel_57_7");
		//CenterPos(113.50,164.86,-635.30);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(113.5008f, 164.8635f, -635.2974f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 147390, "", "d_chapel_57_7", 110, 165, -579, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 57055, "", "d_chapel_57_7", -29.07321, 48.7113, -137.3096, 2.857143);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 40071, "", "d_chapel_57_7", -232.5229, 35.9174, -57.02443, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 40071, "", "d_chapel_57_7", -234.8083, 35.9174, -226.7764, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 40071, "", "d_chapel_57_7", -117.6309, 35.9174, -311.7158, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 40071, "", "d_chapel_57_7", 76.76582, 35.9174, -312.6036, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 147352, "", "d_chapel_57_7", 134, 165, -576, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 147373, "", "d_chapel_57_7", 112.3607, 164.8635, -606.1251, 4.166667);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 152003, "UnvisibleName", "d_chapel_57_7", 207.1431, 164.8635, -582.6509, 0);
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
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup004", "BOT");
				break;
			case 3:
				await track.Dialog.Msg("d_chapel_57_7_dlg_11");
				break;
			case 25:
				//DRT_ACTOR_ATTACH_EFFECT("I_Plane_blue_mash", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_Plane_blue_mash", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_Plane_blue_mash", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_Plane_blue_mash", "BOT");
				break;
			case 28:
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation008_green", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation008_green", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation008_green", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation008_green", "BOT");
				break;
			case 30:
				character.AddonMessage("NOTICE_Dm_GetItem", "The Holy Utensil has been activated!", 3);
				character.AddonMessage("NOTICE_Dm_!", "Protect yourself from Gesti while the divine utensil is being activated!", 3);
				break;
			case 32:
				//TRACK_SETTENDENCY();
				break;
			case 38:
				character.AddonMessage("NOTICE_Dm_!", "Oppose Gesti until the divine utensil is activated!", 3);
				break;
			case 39:
				await track.Dialog.Msg("d_chapel_57_7_dlg_12");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
