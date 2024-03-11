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

[TrackScript("CATACOMB_04_SQ_06_TRACK")]
public class CATACOMB04SQ06TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CATACOMB_04_SQ_06_TRACK");
		//SetMap("id_catacomb_04");
		//CenterPos(-748.47,264.90,895.63);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 57591, "", "id_catacomb_04", -774, 265, 952, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(-777.5331f, 264.8955f, 939.1784f));
		actors.Add(character);

		var mob1 = Shortcuts.AddMonster(0, 147469, "", "id_catacomb_04", -774, 265, 952, 0);
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
			case 8:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup002_dark", "BOT");
				break;
			case 16:
				//DRT_ACTOR_PLAY_EFT("F_burstup001_dark", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("F_circle011_dark", "BOT");
				break;
			case 20:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke108", "BOT");
				break;
			case 34:
				//TRACK_SETTENDENCY();
				character.AddonMessage("NOTICE_Dm_!", "Defeat Templeshooter and obtain the Spatial Magic Gem!", 5);
				CreateBattleBoxInLayer(character, track);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
