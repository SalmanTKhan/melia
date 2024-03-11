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

[TrackScript("FARM49_1_SQ08_TRACK")]
public class FARM491SQ08TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("FARM49_1_SQ08_TRACK");
		//SetMap("f_farm_49_1");
		//CenterPos(-823.39,188.16,717.35);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-823.3887f, 188.1609f, 717.3469f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 153067, "", "f_farm_49_1", -848.6013, 188.1609, 723.8847, 21.875);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 57352, "", "f_farm_49_1", -568.6085, 188.1609, 853.0338, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 57352, "", "f_farm_49_1", -525.1046, 188.1609, 840.7756, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 57352, "", "f_farm_49_1", -508.2104, 188.1609, 733.2098, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 57352, "", "f_farm_49_1", -466.694, 188.1477, 702.1827, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 6:
				break;
			case 8:
				break;
			case 10:
				break;
			case 12:
				break;
			case 17:
				character.AddonMessage("NOTICE_Dm_!", "As you approach the flower to pick up, monsters rush towards you!", 3);
				break;
			case 27:
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			case 28:
				//DRT_PLAY_MGAME("FARM49_1_SQ08_TRACK_MINI");
				break;
			case 29:
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
