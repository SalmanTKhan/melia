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

[TrackScript("PILGRIM52_SQ_081_TRACK")]
public class PILGRIM52SQ081TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("PILGRIM52_SQ_081_TRACK");
		//SetMap("f_pilgrimroad_52");
		//CenterPos(1240.71,233.90,2136.57);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 152013, "", "f_pilgrimroad_52", 1041.164, 233.8956, 2276.617, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 152012, "", "f_pilgrimroad_52", 1049.558, 233.8956, 2273.475, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		character.Movement.MoveTo(new Position(1139.338f, 219.5423f, 2188.218f));
		actors.Add(character);

		var mob2 = Shortcuts.AddMonster(0, 152007, "", "f_pilgrimroad_52", 1146.55, 233.89, 2065.66, 0);
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
			case 2:
				break;
			case 18:
				character.AddonMessage("NOTICE_Dm_!", "The Tree of Faith came to life again as the Spring of Silence was purified!{nl}But an evil energy is felt from the Peddler Camp!", 5);
				break;
			case 19:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
