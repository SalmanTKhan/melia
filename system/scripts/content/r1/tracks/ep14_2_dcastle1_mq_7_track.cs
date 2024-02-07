using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.Scripting;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.Effects;
using Melia.Zone.World.Tracks;
using Yggdrasil.Logging;

[TrackScript("EP14_2_DCASTLE1_MQ_7_TRACK")]
public class EP142DCASTLE1MQ7TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP14_2_DCASTLE1_MQ_7_TRACK");
		//SetMap("ep14_2_d_castle_1");
		//CenterPos(60.49,129.90,2179.30);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-353.7313f, 233.2691f, 3082.428f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 59742, "", "ep14_2_d_castle_1", -359.2883, 233.2691, 2996.725, 85);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 59743, "", "ep14_2_d_castle_1", -420.8564, 233.2691, 3108.696, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 59742, "", "ep14_2_d_castle_1", -364.4536, 233.2691, 3180.433, 0);
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
			case 7:
				break;
			case 8:
				break;
			case 9:
				//TRACK_SETTENDENCY();
				break;
			case 34:
				CreateBattleBoxInLayer(character, track);
				//DRT_PLAY_MGAME("EP14_2_DCASTLE1_MQ_7_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
