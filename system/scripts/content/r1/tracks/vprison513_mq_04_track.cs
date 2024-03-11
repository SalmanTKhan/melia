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

[TrackScript("VPRISON513_MQ_04_TRACK")]
public class VPRISON513MQ04TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("VPRISON513_MQ_04_TRACK");
		//SetMap("d_velniasprison_51_3");
		//CenterPos(-1386.90,91.04,908.82);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 154013, "", "d_velniasprison_51_3", -1382.73, 91.0399, 940.1274, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 154001, "", "d_velniasprison_51_3", -1455.837, 91.0399, 936.0593, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 154001, "", "d_velniasprison_51_3", 1513.614, 91.0399, 924.5654, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 154012, "", "d_velniasprison_51_3", 1307.466, 91.0399, 916.0295, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 57827, "", "d_velniasprison_51_3", -731.8076, 50.63948, 406.6648, 13.21429);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.Level = 181;
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 147382, "", "d_velniasprison_51_3", -693.0938, 50.63947, 511.5096, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		character.Movement.MoveTo(new Position(-659.9124f, 91.03986f, 858.3978f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 33:
				await track.Dialog.Msg("VPRISON513_MQ_04_BLACKMAN_01");
				break;
			case 45:
				await track.Dialog.Msg("VPRISON513_MQ_04_BLACKMAN_02");
				break;
			case 49:
				//DRT_ACTOR_PLAY_EFT("I_smoke001_dark_2", "MID", 0);
				break;
			case 63:
				await track.Dialog.Msg("VPRISON513_MQ_04_BLACKMAN_03");
				break;
			case 64:
				//DRT_ACTOR_PLAY_EFT("F_smoke019_dark", "BOT", 0);
				break;
			case 68:
				//DRT_ACTOR_PLAY_EFT("F_levitation044_dark_TOP", "BOT", 0);
				break;
			case 74:
				//DRT_PLAY_MGAME("VPRISON513_MQ_04_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
