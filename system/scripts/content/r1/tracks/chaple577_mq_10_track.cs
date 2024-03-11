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

[TrackScript("CHAPLE577_MQ_10_TRACK")]
public class CHAPLE577MQ10TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CHAPLE577_MQ_10_TRACK");
		//SetMap("d_chapel_57_7");
		//CenterPos(852.38,35.92,-1217.80);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 47234, "", "d_chapel_57_7", 949.818, 35.9174, -1243.263, 15);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(831.4788f, 35.9174f, -1258.435f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 18:
				//SetFixAnim("STD");
				break;
			case 34:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force068_green", "holyark_loop", "F_ground012_light", "skl_holylight", "SLOW", 50, 1, 0, 1, 10, 0);
				break;
			case 43:
				await track.Dialog.Msg("d_chapel_57_7_dlg_2");
				break;
			case 44:
				character.AddonMessage("NOTICE_Dm_GetItem", "You've received 'Revelation of the Goddess'!", 3);
				//DRT_FUNC_ACT("SSN_CHAPLE577_MQ_10_AFTER");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
