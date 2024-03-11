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

[TrackScript("VPRISON511_MQ_01_TRACK")]
public class VPRISON511MQ01TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("VPRISON511_MQ_01_TRACK");
		//SetMap("d_velniasprison_51_1");
		//CenterPos(8.17,169.83,-54.18);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 57840, "", "d_velniasprison_51_1", -13.20072, 169.8298, -3.107582, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 154011, "", "d_velniasprison_51_1", -162.5219, 169.8299, -70.06667, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		character.Movement.MoveTo(new Position(-54.7276f, 169.8258f, -106.1295f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 2:
				//DRT_ACTOR_PLAY_EFT("F_ground051", "BOT", 0);
				break;
			case 18:
				await track.Dialog.Msg("VPRISON511_MQ_01_TRACK_DLG_2");
				break;
			case 49:
				character.AddSessionObject(PropertyName.VPRISON511_MQ_01, 1);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
