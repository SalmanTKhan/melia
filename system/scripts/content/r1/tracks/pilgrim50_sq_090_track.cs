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

[TrackScript("PILGRIM50_SQ_090_TRACK")]
public class PILGRIM50SQ090TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("PILGRIM50_SQ_090_TRACK");
		//SetMap("f_pilgrimroad_50");
		//CenterPos(-1818.44,507.36,193.41);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 57298, "", "f_pilgrimroad_50", -1818.713, 507.3573, 113.0076, 100);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 152006, "", "f_pilgrimroad_50", -1935.65, 507.36, 350.64, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 155038, "머지에게", "f_pilgrimroad_50", -1935.65, 530.36, 350.64, 8.75);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		character.Movement.MoveTo(new Position(-1910.183f, 507.3573f, 308.8249f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 5:
				break;
			case 23:
				//DRT_ACTOR_ATTACH_EFFECT("F_pattern007_dark_loop", "BOT");
				break;
			case 25:
				//DRT_ACTOR_ATTACH_EFFECT("I_cleric_zemina_mash_loop_green", "BOT");
				break;
			case 29:
				//TRACK_SETTENDENCY();
				character.AddonMessage("NOTICE_Dm_!", "Defeat the soul binding Merge!", 3);
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
