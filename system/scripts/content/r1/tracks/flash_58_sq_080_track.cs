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

[TrackScript("FLASH_58_SQ_080_TRACK")]
public class FLASH58SQ080TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("FLASH_58_SQ_080_TRACK");
		//SetMap("None");
		//CenterPos(840.02,382.43,420.29);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 152055, "UnvisibleName", "None", 841.31, 382.43, 444.9, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(874.4128f, 382.4338f, 436.632f));
		actors.Add(character);

		var mob1 = Shortcuts.AddMonster(0, 20025, "UnvisibleName", "None", 841.31, 382.43, 444.9, 0);
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
			case 13:
				//DRT_PLAY_MGAME("FLASH_58_SQ_080_MINI");
				break;
			case 19:
				//TRACK_MON_LOOKAT();
				character.AddonMessage("NOTICE_Dm_!", "A large amount of monsters are coming due to the sound of the destroyed intensive spirit's device!", 5);
				//TRACK_SETTENDENCY();
				//CREATE_BATTLE_BOX_INLAYER(0);
				//TRACK_SETTENDENCY();
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation010_smoke", "BOT");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
