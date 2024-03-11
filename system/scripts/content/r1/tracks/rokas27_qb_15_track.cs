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

[TrackScript("ROKAS27_QB_15_TRACK")]
public class ROKAS27QB15TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ROKAS27_QB_15_TRACK");
		//SetMap("f_rokas_27");
		//CenterPos(1038.43,1342.26,324.34);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(1027.755f, 1341.859f, 337.9692f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 152001, "", "f_rokas_27", 910, 1342, 380, 0);
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
			case 3:
				//CREATE_BATTLE_BOX_INLAYER(0);
				//TRACK_SETTENDENCY();
				//DRT_PLAY_MGAME("ROKAS27_QB_5_MINI");
				//TRACK_MON_LOOKAT();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
