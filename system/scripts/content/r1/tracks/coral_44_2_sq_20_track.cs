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

[TrackScript("CORAL_44_2_SQ_20_TRACK")]
public class CORAL442SQ20TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CORAL_44_2_SQ_20_TRACK");
		//SetMap("f_coral_44_2");
		//CenterPos(980.31,-13.20,890.21);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(971.9698f, -16.29461f, 869.6224f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 47121, "", "f_coral_44_2", 879.62, -105.29, 1484, 0);
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
			case 4:
				character.AddonMessage("NOTICE_Dm_scroll", "Defeat all the Nimrah that are protecting the magic circle", 5);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
