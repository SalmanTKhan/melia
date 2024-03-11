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

[TrackScript("VPRISON514_MQ_03_TRACK")]
public class VPRISON514MQ03TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("VPRISON514_MQ_03_TRACK");
		//SetMap("d_velniasprison_51_4");
		//CenterPos(-745.60,335.57,-446.66);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 154015, "", "d_velniasprison_51_4", -942.1565, 335.5664, -451.5071, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 20026, "", "d_velniasprison_51_4", -982.1315, 335.5664, -434.0688, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		character.Movement.MoveTo(new Position(-539.4268f, 334.5994f, 373.7017f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 1:
				//DRT_ACTOR_ATTACH_EFFECT("I_cleric_zemina_mash_loop_green", "BOT");
				break;
			case 14:
				//DRT_PLAY_MGAME("VPRISON514_MQ_03_MINI");
				character.AddonMessage("NOTICE_Dm_!", "Protect Zydrone until she completes the Evening Star Key!", 3);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
