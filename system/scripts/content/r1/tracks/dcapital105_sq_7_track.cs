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

[TrackScript("DCAPITAL105_SQ_7_TRACK")]
public class DCAPITAL105SQ7TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("DCAPITAL105_SQ_7_TRACK");
		//SetMap("None");
		//CenterPos(19.58,288.27,895.88);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 154012, "", "None", 55.1296, 281.1893, 1025.625, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 154011, "", "None", 6.303755, 284.7023, 859.2131, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 6:
				//DRT_ACTOR_PLAY_EFT("F_explosion004_yellow2", "BOT", 0);
				break;
			case 18:
				await track.Dialog.Msg("DCAPITAL105_SQ_7_DLG_2");
				break;
			case 26:
				await track.Dialog.Msg("DCAPITAL105_SQ_7_DLG_3");
				break;
			case 33:
				await track.Dialog.Msg("DCAPITAL105_SQ_7_DLG_4");
				break;
			case 34:
				await track.Dialog.Msg("DCAPITAL105_SQ_7_DLG_5");
				break;
			case 39:
				character.AddSessionObject(PropertyName.DCAPITAL105_SQ_7, 1);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
