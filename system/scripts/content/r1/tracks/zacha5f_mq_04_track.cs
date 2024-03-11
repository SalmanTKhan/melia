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

[TrackScript("ZACHA5F_MQ_04_TRACK")]
public class ZACHA5FMQ04TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ZACHA5F_MQ_04_TRACK");
		//SetMap("d_zachariel_36");
		//CenterPos(-2495.68,363.57,-1136.87);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-2495.679f, 363.5677f, -1136.874f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 147467, "", "d_zachariel_36", -2491.932, 363.5677, -1094.533, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 41229, "", "d_zachariel_36", -2491.151, 368.3015, -358.5819, 49.0625);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 1:
				//DRT_ACTOR_ATTACH_EFFECT("F_cleric_energy_blast_shot", "BOT");
				break;
			case 10:
				//DRT_ACTOR_PLAY_EFT("F_cleric_ironskin_shot_ground", "BOT", 0);
				break;
			case 23:
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation036_smoke_dark_green", "BOT");
				break;
			case 24:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_out004_dark", "BOT");
				break;
			case 33:
				await track.Dialog.Msg("ZACHA5F_REXIPHER01");
				break;
			case 34:
				await track.Dialog.Msg("ZACHA5F_REXIPHER02");
				break;
			case 39:
				//TRACK_SETTENDENCY();
				CreateBattleBoxInLayer(character, track);
				//DRT_MOVETOTGT(50);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
