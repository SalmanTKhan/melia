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

[TrackScript("FLASH59_SQ_01_TRACK")]
public class FLASH59SQ01TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("FLASH59_SQ_01_TRACK");
		//SetMap("f_flash_59");
		//CenterPos(-420.21,109.42,854.65);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-420.2074f, 109.4169f, 854.6464f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 10033, "Security Guard", "f_flash_59", -386.4639, 109.4169, 767.59, 0, "Neutral");
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 10033, "Security Guard", "f_flash_59", -329.512, 109.4169, 821.145, 0, "Neutral");
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 10033, "Security Guard", "f_flash_59", -324.2984, 109.4169, 596.141, 0, "Neutral");
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 10033, "Security Guard", "f_flash_59", -267.8415, 109.4169, 821.6758, 31.25, "Neutral");
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 10033, "Security Guard", "f_flash_59", -396.0644, 109.4169, 696.2037, 0, "Neutral");
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 10033, "Security Guard", "f_flash_59", -109.3422, 109.4169, 791.2173, 0, "Neutral");
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 10033, "Security Guard", "f_flash_59", -363.8604, 109.4169, 600.4835, 1.287879, "Neutral");
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 10033, "Security Guard", "f_flash_59", -341.549, 109.4169, 635.0461, 1.818182, "Neutral");
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 10033, "Security Guard", "f_flash_59", -180.2719, 109.4169, 874.7927, 0.6060606, "Neutral");
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 10033, "Security Guard", "f_flash_59", -189.143, 109.4169, 846.8835, 0.9090909, "Neutral");
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 147416, "", "f_flash_59", -200.24, 109.32, 725.95, 35.625);
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
			case 24:
				await track.Dialog.Msg("f_flash_59_track_dlg_1");
				break;
			case 31:
				await track.Dialog.Msg("f_flash_59_track_dlg_2");
				break;
			case 35:
				await track.Dialog.Msg("f_flash_59_track_dlg_3");
				break;
			case 54:
				character.AddSessionObject(PropertyName.FLASH59_SQ_01, 1);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
