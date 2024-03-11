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

[TrackScript("CASTLE_20_4_SQ_10_TRACK")]
public class CASTLE204SQ10TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CASTLE_20_4_SQ_10_TRACK");
		//SetMap("f_castle_20_4");
		//CenterPos(833.32,132.99,270.13);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(833.3215f, 132.9903f, 270.1254f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 58463, "", "f_castle_20_4", 555.0813, 132.9903, 279.8809, 0);
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
			case 12:
				//SCR_SAME_LAYER_SETPOS_FADEOUT_RUN(-30, 30);
				break;
			case 34:
				CreateBattleBoxInLayer(character, track);
				character.AddonMessage("NOTICE_Dm_scroll", "You have caught up with Assassin Ebonypawn{nl}Defeat Ebonypawn", 5);
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
