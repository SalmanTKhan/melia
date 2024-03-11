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

[TrackScript("CHAPLE575_MQ_09_TRACK")]
public class CHAPLE575MQ09TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CHAPLE575_MQ_09_TRACK");
		//SetMap("d_chapel_57_5");
		//CenterPos(421.47,0.55,-812.10);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(305.7755f, 0.5532f, -789.0436f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 57087, "", "d_chapel_57_5", 487.8518, 0.5532, -851.0488, 280);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 11283, "", "d_chapel_57_5", 499.5216, 0.5532, -795.496, 69.28572);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 12082, "", "d_chapel_57_5", 364.8761, 0.5532, -790.8254, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 40:
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion078_dark", "BOT");
				break;
			case 44:
				//TRACK_SETTENDENCY();
				character.AddonMessage("NOTICE_Dm_!", "Defeat Cyclops and find its minions!", 3);
				CreateBattleBoxInLayer(character, track);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
