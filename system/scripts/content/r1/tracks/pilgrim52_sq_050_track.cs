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

[TrackScript("PILGRIM52_SQ_050_TRACK")]
public class PILGRIM52SQ050TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("PILGRIM52_SQ_050_TRACK");
		//SetMap("None");
		//CenterPos(-442.60,215.18,393.84);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 155038, "", "None", -481.63, 215.18, 392.36, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 57418, "", "None", -481.63, 215.18, 392.36, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		character.Movement.MoveTo(new Position(-442.6f, 215.28f, 393.84f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 3:
				//DRT_ACTOR_ATTACH_EFFECT("I_cleric_hexing_cast_dark", "MID");
				break;
			case 7:
				//DRT_ACTOR_PLAY_EFT("F_burstup001_dark", "BOT", 0);
				break;
			case 10:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup004_dark", "BOT");
				break;
			case 15:
				//CREATE_BATTLE_BOX_INLAYER(-50);
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
