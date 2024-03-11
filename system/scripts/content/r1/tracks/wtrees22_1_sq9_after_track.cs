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

[TrackScript("WTREES22_1_SQ9_AFTER_TRACK")]
public class WTREES221SQ9AFTERTRACK : TrackScript
{
	protected override void Load()
	{
		SetId("WTREES22_1_SQ9_AFTER_TRACK");
		//SetMap("f_whitetrees_22_1");
		//CenterPos(1055.66,145.85,1130.73);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 153185, "", "f_whitetrees_22_1", 1052.63, 145.85, 1182.93, 92.5);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 155126, "", "f_whitetrees_22_1", 1000.34, 145.85, 1146.94, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		character.Movement.MoveTo(new Position(1055.66f, 145.8521f, 1130.733f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 1:
				//DRT_FUNC_ACT("WTREES22_1_SUBQ9_AFTER_TRACK_BGM1");
				break;
			case 38:
				await track.Dialog.Msg("WTREES22_1_SUBQ9_SUCC1");
				break;
			case 44:
				//TRACK_BASICLAYER_MOVE();
				character.AddonMessage("NOTICE_Dm_scroll", "Follow Indrea to Tacasz Pond.", 3);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
