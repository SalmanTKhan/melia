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

[TrackScript("F_3CMLAKE_87_MQ_09_TRACK")]
public class F3CMLAKE87MQ09TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_3CMLAKE_87_MQ_09_TRACK");
		//SetMap("f_3cmlake_87");
		//CenterPos(347.80,162.19,1396.65);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(348.6905f, 162.1949f, 1394.942f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 156101, "", "f_3cmlake_87", 324.361, 162.1949, 1341.981, 51.25);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 147405, "", "f_3cmlake_87", 328.8966, 162.1949, 1313.845, 55.71429);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 47236, "", "f_3cmlake_87", 246.625, 161.3899, 1167.982, 49.66667);
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
			case 8:
				break;
			case 54:
				await track.Dialog.Msg("F_3CMLAKE_87_MQ_09_DLG1");
				break;
			case 55:
				await track.Dialog.Msg("F_3CMLAKE_87_MQ_09_DLG2");
				break;
			case 58:
				await track.Dialog.Msg("F_3CMLAKE_87_MQ_09_DLG3");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
