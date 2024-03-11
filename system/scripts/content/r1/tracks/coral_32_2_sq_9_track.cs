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

[TrackScript("CORAL_32_2_SQ_9_TRACK")]
public class CORAL322SQ9TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CORAL_32_2_SQ_9_TRACK");
		//SetMap("f_coral_32_2");
		//CenterPos(-165.53,-61.08,1502.73);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-164.8383f, -61.0774f, 1512.142f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 151024, "UnvisibleName", "f_coral_32_2", -200.54, -61.07, 1448.77, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 155044, "", "f_coral_32_2", -216.51, -61.07, 1399.91, 38);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 156007, "", "f_coral_32_2", -180.65, -61.07, 1493.66, 14.0625);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 20025, "", "f_coral_32_2", -201.5745, -61.0774, 1447.414, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 32:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground163_blue_loop", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_ground163_blue_loop", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_ground135", "BOT");
				break;
			case 40:
				await track.Dialog.Msg("CORAL_32_2_SQ_9_JURATE");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
