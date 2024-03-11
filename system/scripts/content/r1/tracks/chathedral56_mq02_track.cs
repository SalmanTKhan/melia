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

[TrackScript("CHATHEDRAL56_MQ02_TRACK")]
public class CHATHEDRAL56MQ02TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CHATHEDRAL56_MQ02_TRACK");
		//SetMap("d_cathedral_56");
		//CenterPos(1458.91,0.50,-472.21);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 151024, "", "d_cathedral_56", 1414, 0.5, -471, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(1458.909f, 0.4988f, -472.2103f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 2:
				character.AddonMessage("NOTICE_Dm_!", "Defend against attacks from Naktis' servants until the transformation scroll is complete!", 3);
				//DRT_ACTOR_ATTACH_EFFECT("F_cleric_bakarine_loop", "BOT");
				break;
			case 7:
				//DRT_PLAY_MGAME("CHATHEDRAL56_MQ02_MINI");
				break;
			case 9:
				CreateBattleBoxInLayer(character, track);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
