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

[TrackScript("CORAL_44_1_SQ_90_TRACK")]
public class CORAL441SQ90TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CORAL_44_1_SQ_90_TRACK");
		//SetMap("f_coral_44_1");
		//CenterPos(1535.56,20.33,-280.07);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(1515.338f, 20.32962f, -278.2371f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 151024, "UnvisibleName", "f_coral_44_1", 1580.31, 20.32, -280.51, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 155042, "", "f_coral_44_1", 1543.14, 20.32, -314.5, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 155044, "", "f_coral_44_1", 1548.31, 20.32, -245.17, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 9:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground163_blue_loop", "BOT");
				break;
			case 14:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground135", "BOT");
				break;
			case 19:
				await track.Dialog.Msg("CORAL_44_1_SQ_90_JURATE");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
