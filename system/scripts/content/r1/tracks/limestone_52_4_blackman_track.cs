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

[TrackScript("LIMESTONE_52_4_BLACKMAN_TRACK")]
public class LIMESTONE524BLACKMANTRACK : TrackScript
{
	protected override void Load()
	{
		SetId("LIMESTONE_52_4_BLACKMAN_TRACK");
		//SetMap("d_limestonecave_52_4");
		//CenterPos(-1119.14,247.10,231.51);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-1119.135f, 247.1012f, 231.5136f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 147382, "", "d_limestonecave_52_4", -1458.533, 201.7502, 513.7784, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 154014, "", "d_limestonecave_52_4", -1084.713, 249.3617, 225.8304, 65.2381);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "d_limestonecave_52_4", -1452.68, 201.7501, 513.7223, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 14:
				//DRT_ACTOR_PLAY_EFT("F_smoke019_dark", "BOT", 0);
				break;
			case 19:
				break;
			case 25:
				await track.Dialog.Msg("LIMESTONE_52_4_BLACKMAN_DLG2");
				break;
			case 27:
				await track.Dialog.Msg("LIMESTONE_52_4_BLACKMAN_DLG3");
				break;
			case 29:
				//DRT_ACTOR_PLAY_EFT("F_smoke019_dark", "BOT", 0);
				break;
			case 32:
				//DRT_ACTOR_PLAY_EFT("F_levitation044_dark_TOP", "BOT", 0);
				break;
			case 40:
				await track.Dialog.Msg("LIMESTONE_52_4_BLACKMAN_DLG4");
				break;
			case 49:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
