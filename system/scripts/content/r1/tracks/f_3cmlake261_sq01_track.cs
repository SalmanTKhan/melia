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

[TrackScript("F_3CMLAKE261_SQ01_TRACK")]
public class F3CMLAKE261SQ01TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_3CMLAKE261_SQ01_TRACK");
		//SetMap("f_3cmlake_26_1");
		//CenterPos(1274.34,-121.90,791.00);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(1274.849f, -121.8975f, 789.9982f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 147382, "", "f_3cmlake_26_1", 1635, -116, 891, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 156115, "", "f_3cmlake_26_1", 1580.027, -121.0907, 882.0131, 1.764706);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 20040, "", "f_3cmlake_26_1", 1317.978, -121.6252, 812.5804, 105);
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
			case 13:
				await track.Dialog.Msg("3CMLAKE261_SQ01_DLG05");
				break;
			case 32:
				await track.Dialog.Msg("3CMLAKE261_SQ01_DLG06");
				break;
			case 35:
				//DRT_ACTOR_PLAY_EFT("F_pc_warp_circle", "BOT", 0);
				break;
			case 36:
				break;
			case 38:
				//DRT_ACTOR_PLAY_EFT("F_pc_warp_light", "BOT", 0);
				break;
			case 53:
				//DRT_ACTOR_PLAY_EFT("F_pc_warp_circle", "BOT", 0);
				break;
			case 55:
				//DRT_ACTOR_PLAY_EFT("F_pc_warp_light", "BOT", 0);
				break;
			case 56:
				//DRT_ACTOR_PLAY_EFT("F_pc_warp_light", "BOT", 0);
				break;
			case 67:
				await track.Dialog.Msg("3CMLAKE261_SQ01_DLG07");
				break;
			case 69:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
