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

[TrackScript("EP14_2_DCASTLE3_MQ_2_TRACK")]
public class EP142DCASTLE3MQ2TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP14_2_DCASTLE3_MQ_2_TRACK");
		//SetMap("ep14_2_d_castle_3");
		//CenterPos(295.57,257.19,-723.32);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 160129, "", "ep14_2_d_castle_3", 314.9625, 257.1866, -746.7657, 3.25);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(236.9144f, 257.1866f, -646.8525f));
		actors.Add(character);

		var mob1 = Shortcuts.AddMonster(0, 59750, "", "ep14_2_d_castle_3", 252.8754, 257.1866, -767.3263, 75);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 59750, "", "ep14_2_d_castle_3", 365.7167, 257.1866, -693.35, 710);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 59751, "", "ep14_2_d_castle_3", 238.9861, 257.1866, -630.7136, 0);
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
			case 21:
				break;
			case 22:
				break;
			case 23:
				break;
			case 34:
				//TRACK_SETTENDENCY();
				CreateBattleBoxInLayer(character, track);
				//DRT_PLAY_MGAME("EP14_2_DCASTLE3_MQ_2_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
