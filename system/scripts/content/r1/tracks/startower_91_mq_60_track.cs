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

[TrackScript("STARTOWER_91_MQ_60_TRACK")]
public class STARTOWER91MQ60TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("STARTOWER_91_MQ_60_TRACK");
		//SetMap("d_startower_91");
		//CenterPos(813.67,907.21,-584.60);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(813.4758f, 907.2094f, -584.5543f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 156120, "", "d_startower_91", 810.7819, 801.4536, -778.745, 91.15385);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 155163, "", "d_startower_91", 791.7927, 784.3021, -809.5179, 75);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 156128, "", "d_startower_91", 830.6893, 785.9096, -806.6337, 74.375);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 150182, "", "d_startower_91", 794.3763, 1059.677, 210.715, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 59088, "", "d_startower_91", 754.4295, 1059.677, 236.4426, 26.13636);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 59089, "", "d_startower_91", 824.6979, 1059.677, 264.7332, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 59088, "", "d_startower_91", 776.9686, 1059.677, 270.7183, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 154065, "", "d_startower_91", 796.8678, 907.2094, -356.4059, 1.777778);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 150179, "", "d_startower_91", 813.9008, 817.2939, -750.3246, 41.94445);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 147469, "", "d_startower_91", 816.2806, 1053.142, 160.8851, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 74:
				await track.Dialog.Msg("STARTOWER_91_MQ_60_TRACK_DLG1");
				break;
			case 80:
				await track.Dialog.Msg("STARTOWER_91_MQ_60_TRACK_DLG2");
				break;
			case 97:
				//DRT_ACTOR_PLAY_EFT("F_wizard_dirtywall_shot_new", "BOT", 0);
				break;
			case 102:
				await track.Dialog.Msg("STARTOWER_91_MQ_60_TRACK_DLG3");
				break;
			case 105:
				//DRT_ACTOR_PLAY_EFT("F_burstup001_dark", "BOT", 0);
				break;
			case 131:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
