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

[TrackScript("VPRISON513_MQ_05_TRACK")]
public class VPRISON513MQ05TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("VPRISON513_MQ_05_TRACK");
		//SetMap("d_velniasprison_51_3");
		//CenterPos(1169.36,91.04,908.90);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(938.9637f, -17.01222f, 123.1902f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 57827, "", "d_velniasprison_51_3", 1082.307, 30.33628, 298.3636, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 154012, "", "d_velniasprison_51_3", 1316.444, 91.0399, 897.8573, 716);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 154014, "", "d_velniasprison_51_3", 840.7829, 30.33628, 354.1979, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 154015, "", "d_velniasprison_51_3", 1258.844, 30.33622, 262.3038, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 6:
				//DRT_ACTOR_PLAY_EFT("F_ground051", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground051", "BOT", 0);
				break;
			case 18:
				await track.Dialog.Msg("VPRISON514_MQ_05_01");
				break;
			case 20:
				//DRT_SETHOOKMSGOWNER(0, 1);
				//DRT_ACTOR_PLAY_EFT("F_ground051", "BOT", 0);
				break;
			case 27:
				//DRT_SETHOOKMSGOWNER(0, 1);
				//DRT_ACTOR_PLAY_EFT("F_ground051", "BOT", 0);
				break;
			case 46:
				await track.Dialog.Msg("VPRISON514_MQ_05_02");
				break;
			case 49:
				CreateBattleBoxInLayer(character, track);
				//TRACK_SETTENDENCY();
				character.AddonMessage("NOTICE_Dm_!", "Get Hauberk!", 3);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
