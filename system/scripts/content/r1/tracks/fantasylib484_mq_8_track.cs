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

[TrackScript("FANTASYLIB484_MQ_8_TRACK")]
public class FANTASYLIB484MQ8TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("FANTASYLIB484_MQ_8_TRACK");
		//SetMap("None");
		//CenterPos(-458.40,338.29,-1236.16);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-537.5836f, 338.2912f, -1318.66f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 154104, "", "None", -412.149, 338.2912, -1311.627, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 107028, "", "None", -217.6049, 338.2912, -1309.934, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 9:
				character.AddonMessage("NOTICE_Dm_scroll", "Defeat Demon Lord Lucy{nl}near the Ballanos Collapsing Device!", 8);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
