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

[TrackScript("EP14_2_DCASTLE3_MQ_4_TRACK")]
public class EP142DCASTLE3MQ4TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP14_2_DCASTLE3_MQ_4_TRACK");
		//SetMap("ep14_2_d_castle_3");
		//CenterPos(303.93,256.74,121.15);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 160129, "", "ep14_2_d_castle_3", 318.0515, 256.738, 136.0223, 6.785715);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(226.3793f, 256.738f, 35.22198f));
		actors.Add(character);

		var mob1 = Shortcuts.AddMonster(0, 59751, "", "ep14_2_d_castle_3", 394.8398, 256.738, 56.99527, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 59750, "", "ep14_2_d_castle_3", 389.0435, 256.738, 147.1109, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 59750, "", "ep14_2_d_castle_3", 225.4235, 256.738, 197.0092, 0);
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
			case 23:
				break;
			case 24:
				break;
			case 25:
				break;
			case 34:
				CreateBattleBoxInLayer(character, track);
				//DRT_PLAY_MGAME("EP14_2_DCASTLE3_MQ_4_MINI");
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
