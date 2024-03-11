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

[TrackScript("CATACOMB_38_1_SQ_06_TRACK")]
public class CATACOMB381SQ06TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CATACOMB_38_1_SQ_06_TRACK");
		//SetMap("id_catacomb_38_1");
		//CenterPos(-846.89,166.47,-79.84);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 153047, "", "id_catacomb_38_1", -836, 167, -3, 75);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 151055, "UnvisibleName", "id_catacomb_38_1", -836, 175, -3, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		character.Movement.MoveTo(new Position(-791.6556f, 166.4677f, -16.89469f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 1:
				break;
			case 2:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke014_firesteam", "BOT");
				break;
			case 4:
				character.AddonMessage("NOTICE_Dm_!", "Defend until the Contract of Flesh has finished burning!", 5);
				//TRACK_SETTENDENCY();
				CreateBattleBoxInLayer(character, track);
				//DRT_PLAY_MGAME("CATACOMB_38_1_SQ_06_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
