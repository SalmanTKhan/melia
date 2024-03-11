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

[TrackScript("F_3CMLAKE_86_SQ_03_TRACK")]
public class F3CMLAKE86SQ03TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_3CMLAKE_86_SQ_03_TRACK");
		//SetMap("f_3cmlake_86");
		//CenterPos(-1183.14,40.18,-751.19);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 156100, "", "f_3cmlake_86", -1206.307, 40.17743, -730.2626, 41.66666);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 156102, "", "f_3cmlake_86", -1121.946, 40.17743, -729.0566, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 156102, "", "f_3cmlake_86", -1120.935, 40.17744, -817.3894, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 156102, "", "f_3cmlake_86", -1205.561, 40.17743, -817.4218, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		character.Movement.MoveTo(new Position(-1178.194f, 40.17744f, -746.1507f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 1:
				//SetFixAnim("on_loop");
				//DRT_RUN_FUNCTION("SCR_F_3CMLAKE_86_SQ_03_BASIN_EFFECT");
				//SetFixAnim("on_loop");
				//SetFixAnim("on_loop");
				//SetFixAnim("on_loop");
				break;
			case 8:
				//DRT_PLAY_MGAME("F_3CMLAKE_86_SQ_03_MINI");
				break;
			case 19:
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
