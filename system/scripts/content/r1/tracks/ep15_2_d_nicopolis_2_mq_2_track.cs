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

[TrackScript("EP15_2_D_NICOPOLIS_2_MQ_2_TRACK")]
public class EP152DNICOPOLIS2MQ2TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP15_2_D_NICOPOLIS_2_MQ_2_TRACK");
		//SetMap("ep15_1_f_abbey_2");
		//CenterPos(898.14,156.78,-304.99);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(892.9709f, 156.7779f, -326.094f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 153207, "", "ep15_1_f_abbey_2", 874.2567, 156.7779, -67.38519, 0);
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
			case 6:
				await track.Dialog.Msg("EP15_2_D_NICOPOLIS_2_MQ_2_DLG2");
				break;
			case 17:
				await track.Dialog.Msg("EP15_2_D_NICOPOLIS_2_MQ_2_DLG3");
				break;
			case 23:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
