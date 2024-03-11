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

[TrackScript("PILGRIM50_SQ_010_TRACK")]
public class PILGRIM50SQ010TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("PILGRIM50_SQ_010_TRACK");
		//SetMap("f_pilgrimroad_50");
		//CenterPos(-8.34,507.36,-477.05);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 155036, "", "f_pilgrimroad_50", -87.66, 507.36, -457.26, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "f_pilgrimroad_50", -110.9037, 507.3573, -488.5634, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 41450, "", "f_pilgrimroad_50", -148.8712, 507.3573, -451.3081, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 41450, "", "f_pilgrimroad_50", -113.3613, 507.3573, -545.0881, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 41450, "", "f_pilgrimroad_50", -46.19875, 507.3573, -509.1114, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 18:
				//DRT_ACTOR_ATTACH_EFFECT("F_cleric_OOBE_shot_explosion", "TOP");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke043_loop", "MID");
				break;
			case 26:
				//DRT_PLAY_MGAME("PILGRIM50_SQ_010_MINI");
				break;
			case 29:
				//CREATE_BATTLE_BOX_INLAYER(0);
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
