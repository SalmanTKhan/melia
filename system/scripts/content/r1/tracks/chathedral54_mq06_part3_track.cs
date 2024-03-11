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

[TrackScript("CHATHEDRAL54_MQ06_PART3_TRACK")]
public class CHATHEDRAL54MQ06PART3TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CHATHEDRAL54_MQ06_PART3_TRACK");
		//SetMap("d_cathedral_54");
		//CenterPos(1547.90,0.04,-1515.45);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(1547.903f, 0.0420168f, -1515.454f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 20025, "", "d_cathedral_54", 1502.639, -0.3458319, -1223.747, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 47234, "", "d_cathedral_54", 1547.04, 11.06, -1353.86, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 154043, "", "d_cathedral_54", 1547.04, 11.06, -1353.86, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 154042, "", "d_cathedral_54", 1519.97, 0.1890907, -1135.038, 3.666667);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 154044, "", "d_cathedral_54", 1554.027, 0.1890907, -1151.268, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 13:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground065_smoke", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation010_smoke", "BOT");
				break;
			case 14:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground065_smoke", "BOT");
				break;
			case 49:
				//DRT_ACTOR_ATTACH_EFFECT("F_light078_holy_yellow_loop", "BOT");
				break;
			case 62:
				await track.Dialog.Msg("CHATHEDRAL55_MQ06_DLG02");
				break;
			case 70:
				await track.Dialog.Msg("CHATHEDRAL55_MQ06_DLG04");
				break;
			case 80:
				//DRT_PLAY_FORCE(0, 1, 2, "I_spread_out001_light", "holyark_loop", "F_ground012_light", "skl_holylight", "SLOW", 100, 1, 80, 1, 0, 0);
				break;
			case 89:
				//DRT_FUNC_ACT("CHATHEDRAL54_MQ06_QUEST_COMPLETE");
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
