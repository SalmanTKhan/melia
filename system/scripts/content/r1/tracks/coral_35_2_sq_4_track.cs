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

[TrackScript("CORAL_35_2_SQ_4_TRACK")]
public class CORAL352SQ4TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CORAL_35_2_SQ_4_TRACK");
		//SetMap("f_coral_35_2");
		//CenterPos(225.36,231.62,346.79);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(225.3623f, 231.6155f, 346.787f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 156030, "UnvisibleName", "f_coral_35_2", 530.9232, 226.4724, 434.133, 38.82353);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 10:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground007", "BOT");
				break;
			case 13:
				Send.ZC_NORMAL.Notice(character, "You are unable to move. Where is the enemy?", 5);
				break;
			case 29:
				await track.Dialog.Msg("CORAL_35_2_SQ_4_TRACK_1");
				break;
			case 38:
				character.AddSessionObject(PropertyName.CORAL_35_2_SQ_4, 1);
				break;
			case 44:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
