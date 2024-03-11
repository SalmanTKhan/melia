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

[TrackScript("TABLELAND28_2_SQ07_TRACK")]
public class TABLELAND282SQ07TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("TABLELAND28_2_SQ07_TRACK");
		//SetMap("None");
		//CenterPos(38.29,213.56,1311.99);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-21.10859f, 213.4912f, 1580.496f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 57841, "", "None", 192.9129, 194.4026, 1259.785, 3540);
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
			case 2:
				//DRT_ACTOR_ATTACH_EFFECT("F_bg_statu_mint", "MID");
				break;
			case 26:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke076", "BOT");
				break;
			case 45:
				//DRT_FUNC_ACT("SCR_TABLELAND282_SQ_07_NOTICE");
				break;
			case 50:
				Send.ZC_NORMAL.SetupCutscene(character, false, false, true);
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
