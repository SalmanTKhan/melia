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

[TrackScript("CATACOMB_38_1_SQ_07_TRACK")]
public class CATACOMB381SQ07TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CATACOMB_38_1_SQ_07_TRACK");
		//SetMap("id_catacomb_38_1");
		//CenterPos(936.81,253.37,1034.63);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 57630, "", "id_catacomb_38_1", 1317.176, 241.7631, 1157.923, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(950.5286f, 253.3692f, 1025.676f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 3:
				break;
			case 29:
				CreateBattleBoxInLayer(character, track);
				character.AddonMessage("NOTICE_Dm_!", "Defeat Master Genie and release the Contract of Spirit!", 5);
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
