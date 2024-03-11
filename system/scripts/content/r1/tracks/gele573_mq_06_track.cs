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

[TrackScript("GELE573_MQ_06_TRACK")]
public class GELE573MQ06TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("GELE573_MQ_06_TRACK");
		//SetMap("f_gele_57_3");
		//CenterPos(301.42,283.03,580.18);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 41383, "", "f_gele_57_3", 245.536, 284.1678, 998.7772, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 11283, "", "f_gele_57_3", 265, 281, 545, 71.66667);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		character.Movement.MoveTo(new Position(319.7193f, 281.9593f, 557.2245f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 13:
				//InsertHate(999);
				break;
			case 15:
				break;
			case 49:
				character.AddonMessage("NOTICE_Dm_!", "Defeat Minotaur{nl}with the help of Follower Kayetonas!", 3);
				//TRACK_SETTENDENCY();
				//CREATE_BATTLE_BOX_INLAYER(0);
				//TRACK_MON_LOOKAT();
				//TRACK_MON_LOOKAT();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
