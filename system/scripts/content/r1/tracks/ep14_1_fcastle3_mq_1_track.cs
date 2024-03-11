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

[TrackScript("EP14_1_FCASTLE3_MQ_1_TRACK")]
public class EP141FCASTLE3MQ1TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP14_1_FCASTLE3_MQ_1_TRACK");
		//SetMap("ep14_1_f_castle_3");
		//CenterPos(338.99,0.75,-1667.33);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(338.9853f, 0.7452714f, -1667.329f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 157115, "", "ep14_1_f_castle_3", 463.7816, 0.7454448, -1375.027, 30.54545);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 59698, "", "ep14_1_f_castle_3", 441.1627, 0.745478, -1328.286, 42.85714);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 59698, "", "ep14_1_f_castle_3", 359.8931, 0.7453779, -1446.439, 37);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 59698, "", "ep14_1_f_castle_3", 503.4968, 0.7453516, -1505.143, 27.85714);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 151021, "", "ep14_1_f_castle_3", 463.7182, 0.7454445, -1375.509, 0);
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
			case 8:
				//TRACK_MON_LOOKAT();
				break;
			case 10:
				//DRT_ACTOR_PLAY_EFT("I_emo_exclamation", "TOP", 0);
				//DRT_ACTOR_PLAY_EFT("I_emo_exclamation", "TOP", 0);
				//DRT_ACTOR_PLAY_EFT("I_emo_exclamation", "TOP", 0);
				break;
			case 16:
				break;
			case 17:
				//DRT_PLAY_FORCE(0, 1, 2, "I_arrow008", "arrow_cast", "F_spark013", "arrow_blow", "FAST", 300, 1, 0, 0, 0, 0);
				break;
			case 18:
				//DRT_PLAY_FORCE(0, 1, 2, "I_arrow008", "arrow_cast", "F_spark013", "arrow_blow", "FAST", 300, 1, 0, 0, 0, 0);
				break;
			case 19:
				//DRT_PLAY_FORCE(0, 1, 2, "I_arrow008", "arrow_cast", "F_spark013", "arrow_blow", "FAST", 300, 1, 0, 0, 0, 0);
				break;
			case 25:
				break;
			case 50:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
