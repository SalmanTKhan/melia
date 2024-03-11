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

[TrackScript("EP14_2_DCASTLE2_MQ_2_TRACK")]
public class EP142DCASTLE2MQ2TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP14_2_DCASTLE2_MQ_2_TRACK");
		//SetMap("ep14_2_d_castle_2");
		//CenterPos(252.25,95.68,-345.02);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 150287, "", "ep14_2_d_castle_2", 190.0155, 95.67754, -338.806, 0, "Our_Forces");
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.Level = 470;
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 157115, "", "ep14_2_d_castle_2", 210.6382, 95.67754, -389.4012, 9.166666, "Our_Forces");
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.Level = 470;
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		character.Movement.MoveTo(new Position(251.106f, 95.67754f, -359.5486f));
		actors.Add(character);

		var mob2 = Shortcuts.AddMonster(0, 59744, "", "ep14_2_d_castle_2", 425.913, 95.67754, -268.5352, 51.42857);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 59749, "", "ep14_2_d_castle_2", 281.6035, 95.67754, -195.9888, 70);
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
			case 7:
				break;
			case 34:
				//DRT_PLAY_MGAME("EP14_2_DCASTLE2_MQ_2_MINI");
				CreateBattleBoxInLayer(character, track);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
