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

[TrackScript("DCAPITAL53_1_MQ_03_TRACK")]
public class DCAPITAL531MQ03TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("DCAPITAL53_1_MQ_03_TRACK");
		//SetMap("f_desolated_capital_53_1");
		//CenterPos(2019.13,-65.53,743.36);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(2098.983f, -65.52768f, 810.2552f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 47150, "", "f_desolated_capital_53_1", 1950, -65, 725, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 20042, "UnvisibleName", "f_desolated_capital_53_1", 2061.479, -65.52768, 724.594, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 20042, "UnvisibleName", "f_desolated_capital_53_1", 1827.262, -65.52768, 724.5411, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 20042, "UnvisibleName", "f_desolated_capital_53_1", 1932.153, -65.52768, 847.8765, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 20042, "UnvisibleName", "f_desolated_capital_53_1", 1951.969, -65.52768, 596.6481, 0);
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
			case 2:
				//DRT_RUN_FUNCTION("SCR_DCAPITAL53_1_MQ_03_SYMBOL_SET");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
