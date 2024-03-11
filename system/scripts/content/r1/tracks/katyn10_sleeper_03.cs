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

[TrackScript("KATYN10_SLEEPER_03")]
public class KATYN10SLEEPER03 : TrackScript
{
	protected override void Load()
	{
		SetId("KATYN10_SLEEPER_03");
		//CenterPos(-49.73,241.46,247.97);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var npc0 = Shortcuts.AddNpc(0, 401663, "", "", -36.6503, 243.6498, 254.2098, 0);
		npc0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc0.AddEffect(new ScriptInvisibleEffect());
		npc0.Layer = character.Layer;
		actors.Add(npc0);

		var mob0 = Shortcuts.AddMonster(0, 40069, "", "", -34.30282, 207.1231, 214.6482, 0);
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
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
