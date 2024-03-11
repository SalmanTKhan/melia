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

[TrackScript("THORN20_MQ07_TRACK")]
public class THORN20MQ07TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("THORN20_MQ07_TRACK");
		//SetMap("d_thorn_20");
		//CenterPos(2564.15,488.84,597.75);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 153019, "UnvisibleName", "d_thorn_20", 2528.409, 488.938, 738.8268, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 153029, "", "d_thorn_20", 2535.123, 488.9306, 738.0419, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 41439, "", "d_thorn_20", 2467.793, 489.0255, 801.0137, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 41439, "", "d_thorn_20", 2589.957, 488.8922, 810.7077, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 41439, "", "d_thorn_20", 2457.629, 488.975, 663.6102, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 400381, "", "d_thorn_20", 2623.073, 488.8136, 681.3912, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 400381, "", "d_thorn_20", 2551.638, 488.9096, 631.3278, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 41245, "", "d_thorn_20", 2537.262, 488.9233, 724.4655, 395);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 5:
				//DRT_ACTOR_PLAY_EFT("F_spread_out002", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_out002", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spread_out002", "BOT", 0);
				break;
			case 8:
				character.AddonMessage("NOTICE_Dm_!", "Destroy the Demon Summoning Crystal", 3);
				break;
			case 18:
				break;
			case 23:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke037_1", "BOT");
				break;
			case 27:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup001_dark", "BOT");
				break;
			case 29:
				CreateBattleBoxInLayer(character, track);
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
