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

[TrackScript("CASTLE_20_4_SQ_2_TRACK")]
public class CASTLE204SQ2TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CASTLE_20_4_SQ_2_TRACK");
		//SetMap("None");
		//CenterPos(-1122.98,-89.12,-173.56);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-972.5273f, -83.71776f, -192.0798f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 151003, "UnvisibleName", "None", -1296.052, -86.65274, -216.4635, 0, "Monster");
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.Level = 289;
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 9:
				//TRACK_SETTENDENCY();
				CreateBattleBoxInLayer(character, track);
				character.AddonMessage("NOTICE_Dm_scroll", "The Central Device is attacking!{nl}Destroy the device!", 5);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
