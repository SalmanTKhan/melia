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

[TrackScript("SIAULIAI16_BOSSKILL1_TRACK")]
public class SIAULIAI16BOSSKILL1TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("SIAULIAI16_BOSSKILL1_TRACK");
		//SetMap("f_siauliai_16");
		//CenterPos(-1744.40,65.41,-1190.98);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-1773.222f, 65.4232f, -1259.019f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 41224, "", "f_siauliai_16", -1520.398, 65.4232, -1516.392, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.Level = 59;
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 41317, "", "f_siauliai_16", -1566.332, 65.4232, -1471.971, 30);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.Level = 59;
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 11124, "", "f_siauliai_16", -1539.948, 65.4232, -1570.637, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 11124, "", "f_siauliai_16", -1459.654, 65.4232, -1516.346, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 41317, "", "f_siauliai_16", -1485.949, 65.4232, -1566.603, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.Level = 59;
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 41317, "", "f_siauliai_16", -1485.248, 65.4232, -1455.56, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.Level = 59;
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 41317, "", "f_siauliai_16", -1592.026, 65.4232, -1543.199, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.Level = 59;
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 11127, "", "f_siauliai_16", -1609.643, 65.4232, -1437.968, 8.823529);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 11127, "", "f_siauliai_16", -1626.084, 65.4232, -1506.867, 8.529411);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 11127, "", "f_siauliai_16", -1523.392, 65.4232, -1427.204, 10.58823);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 400207, "", "f_siauliai_16", -1657.455, 65.4232, -1451.642, 13.52941);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 400207, "", "f_siauliai_16", -1602.745, 65.4232, -1395.288, 14.11765);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 1:
				break;
			case 2:
				break;
			case 26:
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
