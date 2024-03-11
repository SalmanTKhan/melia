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

[TrackScript("REMAINS37_3_SQ_010_TRACK")]
public class REMAINS373SQ010TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("REMAINS37_3_SQ_010_TRACK");
		//SetMap("f_remains_37_3");
		//CenterPos(-779.31,6.92,-584.31);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 147375, "UnvisibleName", "f_remains_37_3", -907.47, 7.11, -593.94, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var npc0 = Shortcuts.AddNpc(0, 152040, "", "f_remains_37_3", -837.08, 7.036047, -603.8461, 0);
		npc0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc0.AddEffect(new ScriptInvisibleEffect());
		npc0.Layer = character.Layer;
		actors.Add(npc0);

		var mob1 = Shortcuts.AddMonster(0, 155034, "", "f_remains_37_3", -859.74, 7.11, -589.92, 30);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		character.Movement.MoveTo(new Position(-768.4474f, 7.078092f, -538.5599f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 9:
				//DRT_PLAY_MGAME("REMAINS37_3_SQ_010");
				//TRACK_SETTENDENCY();
				//CREATE_BATTLE_BOX_INLAYER(-10);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
