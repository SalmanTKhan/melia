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

[TrackScript("REMAINS37_1_SQ_060_TRACK")]
public class REMAINS371SQ060TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("REMAINS37_1_SQ_060_TRACK");
		//SetMap("f_remains_37_1");
		//CenterPos(-579.47,445.06,1563.10);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var npc0 = Shortcuts.AddNpc(0, 152030, "UnvisibleName", "f_remains_37_1", -664, 445.06, 1658, 1);
		npc0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc0.AddEffect(new ScriptInvisibleEffect());
		npc0.Layer = character.Layer;
		actors.Add(npc0);

		character.Movement.MoveTo(new Position(-657.7369f, 445.057f, 1632.324f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 5:
				//DRT_PLAY_MGAME("REMAINS37_1_SQ_060_MINI");
				break;
			case 8:
				character.AddonMessage("NOTICE_Dm_!", "After smelling the Craute Grass, monsters rushed in!", 5);
				break;
			case 9:
				//TRACK_SETTENDENCY();
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
