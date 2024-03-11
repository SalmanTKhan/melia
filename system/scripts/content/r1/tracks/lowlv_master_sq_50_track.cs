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

[TrackScript("LOWLV_MASTER_SQ_50_TRACK")]
public class LOWLVMASTERSQ50TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("LOWLV_MASTER_SQ_50_TRACK");
		//SetMap("id_catacomb_33_2");
		//CenterPos(99.40,146.58,-1361.79);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(86.75591f, 146.5769f, -1349.245f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 151108, "", "id_catacomb_33_2", 67.17, 146.58, -1327.01, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var npc0 = Shortcuts.AddNpc(0, 147424, "UnvisibleName", "id_catacomb_33_2", -87, 147, -1272, 0);
		npc0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc0.AddEffect(new ScriptInvisibleEffect());
		npc0.Layer = character.Layer;
		actors.Add(npc0);

		var npc1 = Shortcuts.AddNpc(0, 147424, "UnvisibleName", "id_catacomb_33_2", 19, 147, -1169, 0);
		npc1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc1.AddEffect(new ScriptInvisibleEffect());
		npc1.Layer = character.Layer;
		actors.Add(npc1);

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
