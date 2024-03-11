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

[TrackScript("F_NICOPOLIS_81_1_SQ_04_TRACK")]
public class FNICOPOLIS811SQ04TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_NICOPOLIS_81_1_SQ_04_TRACK");
		//SetMap("f_nicopolis_81_1");
		//CenterPos(1673.21,49.79,596.87);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(1673.208f, 49.79012f, 596.8695f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 153241, "", "f_nicopolis_81_1", 1682.403, 49.53734, 610.2006, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 59169, "", "f_nicopolis_81_1", 1667.163, 49.53734, 669.1655, 50);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 20025, "", "f_nicopolis_81_1", 1669.466, 49.53734, 657.9204, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 5:
				//DRT_ACTOR_PLAY_EFT("F_pattern020_ground_mint", "BOT", 0);
				break;
			case 10:
				//DRT_ACTOR_PLAY_EFT("F_ground047", "BOT", 0);
				break;
			case 20:
				//DRT_ACTOR_PLAY_EFT("F_explosion098_dark_red", "BOT", 0);
				break;
			case 21:
				break;
			case 29:
				//CREATE_BATTLE_BOX_INLAYER(0);
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
