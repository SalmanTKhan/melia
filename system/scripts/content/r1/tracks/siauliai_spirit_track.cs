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

[TrackScript("SIAULIAI_SPIRIT_TRACK")]
public class SIAULIAISPIRITTRACK : TrackScript
{
	protected override void Load()
	{
		SetId("SIAULIAI_SPIRIT_TRACK");
		//SetMap("f_siauliai_11_re");
		//CenterPos(-1439.29,150.22,1544.13);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 400741, "", "f_siauliai_11_re", -1519.149, 150.2275, 1485.67, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.Level = 119;
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 11162, "", "f_siauliai_11_re", -1449.065, 150.2275, 1473.333, 43.33333);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 11162, "", "f_siauliai_11_re", -1482.972, 150.2275, 1547.119, 8.333333);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 11123, "", "f_siauliai_11_re", -1456.093, 150.2275, 1429.959, 60);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 11123, "", "f_siauliai_11_re", -1429.226, 150.2275, 1521.219, 11.66667);
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
			case 8:
				break;
			case 11:
				break;
			case 12:
				break;
			case 15:
				break;
			case 57:
				//TRACK_SETTENDENCY();
				break;
			case 58:
				CreateBattleBoxInLayer(character, track);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
