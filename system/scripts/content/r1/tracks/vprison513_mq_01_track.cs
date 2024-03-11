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

[TrackScript("VPRISON513_MQ_01_TRACK")]
public class VPRISON513MQ01TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("VPRISON513_MQ_01_TRACK");
		//SetMap("d_velniasprison_51_3");
		//CenterPos(-2540.03,93.49,-603.47);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 57827, "", "d_velniasprison_51_3", -2516.737, 93.4918, -406.8278, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(-2531.806f, 93.4918f, -473.4721f));
		actors.Add(character);

		var mob1 = Shortcuts.AddMonster(0, 57716, "", "d_velniasprison_51_3", -2707.886, 116.4952, -704.9551, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 57716, "", "d_velniasprison_51_3", -2389.676, 93.4918, -719.619, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 57716, "", "d_velniasprison_51_3", -2725.695, 116.4951, -663.0903, 14.2);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 57716, "", "d_velniasprison_51_3", -2327.351, 93.4918, -722.7074, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 57716, "", "d_velniasprison_51_3", -2320.354, 93.4918, -663.7606, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 57716, "", "d_velniasprison_51_3", -2533.691, 93.4918, -822.2676, 87.22222);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 57716, "", "d_velniasprison_51_3", -2573.426, 93.4918, -831.3337, 94.44445);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 57719, "", "d_velniasprison_51_3", -2544.525, 93.4918, -759.1776, 93.33334);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 12:
				await track.Dialog.Msg("VPRISON513_MQ_01_01");
				break;
			case 20:
				break;
			case 28:
				//DRT_ACTOR_PLAY_EFT("I_smoke001_dark_2", "MID", 0);
				break;
			case 29:
				//TRACK_SETTENDENCY();
				CreateBattleBoxInLayer(character, track);
				//TRACK_MON_LOOKAT();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
