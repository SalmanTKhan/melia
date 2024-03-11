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

[TrackScript("STARTOWER_90_MQ_50_TRACK")]
public class STARTOWER90MQ50TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("STARTOWER_90_MQ_50_TRACK");
		//SetMap("d_startower_90");
		//CenterPos(-324.37,67.27,151.79);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-511.9627f, 67.26649f, 161.1533f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 105018, "12층의", "d_startower_90", -1145.309, 67.44365, 136.7677, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 40100, "", "d_startower_90", -1261, 67, 158, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 147374, "", "d_startower_90", -694.8367, 67.31528, 162.9209, 0);
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
			case 48:
				character.AddonMessage("NOTICE_Dm_scroll", "Defeat the Devilglove blocking your way and investigate your surroundings!", 3);
				break;
			case 49:
				//TRACK_MON_LOOKAT();
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
