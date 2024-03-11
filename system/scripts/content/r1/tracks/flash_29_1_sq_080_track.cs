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

[TrackScript("FLASH_29_1_SQ_080_TRACK")]
public class FLASH291SQ080TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("FLASH_29_1_SQ_080_TRACK");
		//SetMap("f_flash_29_1");
		//CenterPos(1552.43,278.84,505.54);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 147341, "UnvisibleName", "f_flash_29_1", 1594.4, 278.84, 566.4, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(1586.757f, 278.8416f, 544.8803f));
		actors.Add(character);

		var mob1 = Shortcuts.AddMonster(0, 20026, "", "f_flash_29_1", 1593.492, 278.8424, 569.2736, 61.25);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 20026, "미약한", "f_flash_29_1", 1596.008, 278.8425, 565.9242, 31);
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
			case 16:
				break;
			case 17:
				//DRT_PLAY_MGAME("FLASH_29_1_SQ_080_MINI");
				break;
			case 18:
				character.AddonMessage("NOTICE_Dm_!", "Faint Petrifying Frost poured from the box!{nl}Defeat monsters to avoid the Petrifying Frost!", 5);
				break;
			case 19:
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
