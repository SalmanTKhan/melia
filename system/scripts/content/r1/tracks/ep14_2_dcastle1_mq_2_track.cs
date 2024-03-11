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

[TrackScript("EP14_2_DCASTLE1_MQ_2_TRACK")]
public class EP142DCASTLE1MQ2TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP14_2_DCASTLE1_MQ_2_TRACK");
		//SetMap("ep14_2_d_castle_1");
		//CenterPos(1668.44,1.04,-276.64);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(1668.44f, 1.038883f, -276.6444f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 59740, "", "ep14_2_d_castle_1", 1615.932, 1.048122, -233.5277, 45);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 59741, "", "ep14_2_d_castle_1", 1691.912, 1.034267, -225.766, 46.25);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 59740, "", "ep14_2_d_castle_1", 1733.62, 1.026303, -252.2597, 347.5);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 59740, "", "ep14_2_d_castle_1", 1598.463, 1.052162, -276.4745, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 157115, "", "ep14_2_d_castle_1", 1654.652, 1.041598, -307.6717, 4.722222);
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
				break;
			case 14:
				break;
			case 16:
				break;
			case 18:
				break;
			case 39:
				CreateBattleBoxInLayer(character, track);
				//DRT_PLAY_MGAME("EP14_2_DCASTLE1_MQ_2_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
