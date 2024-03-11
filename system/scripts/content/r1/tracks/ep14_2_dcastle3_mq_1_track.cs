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

[TrackScript("EP14_2_DCASTLE3_MQ_1_TRACK")]
public class EP142DCASTLE3MQ1TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP14_2_DCASTLE3_MQ_1_TRACK");
		//SetMap("ep14_2_d_castle_3");
		//CenterPos(-3.55,198.58,343.06);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(12.6748f, 198.576f, 343.1648f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 154079, "", "ep14_2_d_castle_3", -1.560474, 198.576, 379.76, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 18:
				character.AddonMessage("NOTICE_Dm_!", "It seems to be dangerous to touch the barrier beyond this.", 3);
				break;
			case 24:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
