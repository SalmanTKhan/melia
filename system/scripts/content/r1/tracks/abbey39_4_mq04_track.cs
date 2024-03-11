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

[TrackScript("ABBEY39_4_MQ04_TRACK")]
public class ABBEY394MQ04TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ABBEY39_4_MQ04_TRACK");
		//SetMap("None");
		//CenterPos(-1435.88,144.85,340.34);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-1335.696f, 144.8543f, 324.9301f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 155042, "선임", "None", -1336.432, 144.8543, 301.1734, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 57421, "", "None", -1701.064, 144.8543, 316.9816, 3.333333);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 20026, "", "None", -2001.053, 144.8543, 87.76009, 2.980769);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 153018, "", "None", -2001.598, 144.8543, 188.1793, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 19:
				break;
			case 20:
				//DRT_ACTOR_ATTACH_EFFECT("I_emo_exclamation", "TOP");
				//DRT_ACTOR_ATTACH_EFFECT("I_emo_exclamation", "TOP");
				//DRT_ACTOR_PLAY_EFT("F_smoke008", "BOT", 1);
				break;
			case 44:
				CreateBattleBoxInLayer(character, track);
				character.AddonMessage("NOTICE_Dm_!", "Defeat Tetraox!", 3);
				//TRACK_SETTENDENCY();
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
