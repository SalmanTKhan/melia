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

[TrackScript("SIAUL_WEST_MEET_NAGLIS_TRACK")]
public class SIAULWESTMEETNAGLISTRACK : TrackScript
{
	protected override void Load()
	{
		SetId("SIAUL_WEST_MEET_NAGLIS_TRACK");
		//SetMap("None");
		//CenterPos(-1416.45,260.83,-237.94);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 10046, "Search Scout", "f_siauliai_west", -1493.458, 260.8254, -145.3675, 2.916667, "Our_Forces");
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 400002, "", "f_siauliai_west", -1436.278, 260.8254, -237.2791, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 400001, "", "f_siauliai_west", -1518.687, 260.8254, -221.9198, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 400001, "", "f_siauliai_west", -1471.611, 260.8254, -262.1268, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 400001, "", "f_siauliai_west", -1382.271, 260.8254, -231.7135, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 400001, "", "f_siauliai_west", -1376.506, 260.8254, -183.5491, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 2:
				break;
			case 4:
				//InsertHate(999);
				break;
			case 6:
				//InsertHate(999);
				break;
			case 7:
				break;
			case 8:
				//InsertHate(999);
				break;
			case 10:
				//InsertHate(999);
				break;
			case 13:
				//InsertHate(999);
				break;
			case 15:
				//DRT_SETHOOKMSGOWNER(0, 0);
				break;
			case 17:
				character.AddonMessage("NOTICE_Dm_!", "Defeat the Large Kepa!", 3);
				break;
			case 19:
				CreateBattleBoxInLayer(character, track);
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
