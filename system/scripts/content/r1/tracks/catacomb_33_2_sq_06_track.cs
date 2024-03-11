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

[TrackScript("CATACOMB_33_2_SQ_06_TRACK")]
public class CATACOMB332SQ06TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CATACOMB_33_2_SQ_06_TRACK");
		//SetMap("id_catacomb_33_2");
		//CenterPos(740.70,221.36,1420.00);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(740.696f, 221.3557f, 1420f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 152008, "", "id_catacomb_33_2", 741.7705, 221.3716, 1452.398, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 155022, "칼라일의", "id_catacomb_33_2", 741.9152, 232.323, 1326.301, 12);
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
			case 4:
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation005_dark_blue", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke120_dark", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke122_blue", "BOT");
				break;
			case 6:
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation005_dark_blue", "BOT");
				break;
			case 8:
				character.AddonMessage("NOTICE_Dm_!", "As the ominous energy starts to spread to the Holy Relic of the Order{nl}Carlyle's Spirit starts to suffer!", 5);
				break;
			case 18:
				CreateBattleBoxInLayer(character, track);
				break;
			case 19:
				character.AddonMessage("NOTICE_Dm_scroll", "The stone that is filled with evil thoughts is shining{nl}It seems that you would be able to destroy the sacred objects if you use the stone.", 5);
				//DRT_RUN_FUNCTION("CATACOMB_33_2_UNHOLY_RUN");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
