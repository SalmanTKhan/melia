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

[TrackScript("PILGRIM_49_SQ_060_TRACK")]
public class PILGRIM49SQ060TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("PILGRIM_49_SQ_060_TRACK");
		//SetMap("f_pilgrimroad_49");
		//CenterPos(-1109.31,201.77,-2100.39);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-1175.984f, 201.7679f, -2105.771f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 155038, "Kestas", "f_pilgrimroad_49", -1192.18, 201.77, -2044.8, 1);
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
			case 13:
				//DRT_PLAY_MGAME("PILGRIM_49_SQ_060_MINI");
				break;
			case 18:
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			case 19:
				//TRACK_SETTENDENCY();
				character.AddonMessage("NOTICE_Dm_!", "The monsters who stole the sign of Nestospa are attacking again!", 5);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
