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

[TrackScript("FANTASYLIB485_MQ_5_TRACK")]
public class FANTASYLIB485MQ5TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("FANTASYLIB485_MQ_5_TRACK");
		//SetMap("d_fantasylibrary_48_5");
		//CenterPos(895.62,-107.87,-366.79);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(897.2747f, -107.8744f, -339.8472f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 154102, "", "d_fantasylibrary_48_5", 875.4045, -107.8744, -383.7922, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 154080, "Giltine", "d_fantasylibrary_48_5", 878.11, -107.87, -66.69, 0);
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
			case 4:
				await track.Dialog.Msg("FANTASYLIB485_MQ_5_T_1");
				break;
			case 5:
				//DRT_PLAY_MGAME("FANTASYLIB485_MQ_5_MINI");
				break;
			case 14:
				character.AddonMessage("NOTICE_Dm_scroll", "Go with Neringa and track Demon Goddess Giltine!", 8);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
