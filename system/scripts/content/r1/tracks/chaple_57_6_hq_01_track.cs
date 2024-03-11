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

[TrackScript("CHAPLE_57_6_HQ_01_TRACK")]
public class CHAPLE576HQ01TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CHAPLE_57_6_HQ_01_TRACK");
		//SetMap("d_abbey_64_3");
		//CenterPos(957.09,449.14,357.88);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(954.4376f, 449.1434f, 333.1221f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 59306, "", "d_abbey_64_3", 850.9464, 451.2133, -37.87083, 77);
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
			case 6:
				break;
			case 39:
				character.AddonMessage("NOTICE_Dm_scroll", "Chapparition has appeared!", 5);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
