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

[TrackScript("LOWLV_EYEOFBAIGA_SQ_50_TRACK")]
public class LOWLVEYEOFBAIGASQ50TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("LOWLV_EYEOFBAIGA_SQ_50_TRACK");
		//SetMap("d_velniasprison_51_1");
		//CenterPos(74.86,259.30,1033.22);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(63.62629f, 259.2954f, 904.6378f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 154065, "UnvisibleName", "d_velniasprison_51_1", 650.6097, 346.1506, 1453.084, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var npc0 = Shortcuts.AddNpc(0, 57313, "", "d_velniasprison_51_1", 158.8273, 259.2954, 1056.913, 0);
		npc0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc0.AddEffect(new ScriptInvisibleEffect());
		npc0.Layer = character.Layer;
		actors.Add(npc0);

		var npc1 = Shortcuts.AddNpc(0, 57313, "", "d_velniasprison_51_1", 57.43552, 259.2954, 1129.161, 0);
		npc1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc1.AddEffect(new ScriptInvisibleEffect());
		npc1.Layer = character.Layer;
		actors.Add(npc1);

		var npc2 = Shortcuts.AddNpc(0, 57313, "", "d_velniasprison_51_1", 285.5829, 346.1506, 1272.345, 10);
		npc2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc2.AddEffect(new ScriptInvisibleEffect());
		npc2.Layer = character.Layer;
		actors.Add(npc2);

		var npc3 = Shortcuts.AddNpc(0, 57313, "", "d_velniasprison_51_1", 360.5559, 346.1506, 1622.618, 10);
		npc3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc3.AddEffect(new ScriptInvisibleEffect());
		npc3.Layer = character.Layer;
		actors.Add(npc3);

		var npc4 = Shortcuts.AddNpc(0, 57313, "", "d_velniasprison_51_1", 487.5158, 352.9353, 1522.151, 645);
		npc4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc4.AddEffect(new ScriptInvisibleEffect());
		npc4.Layer = character.Layer;
		actors.Add(npc4);

		var npc5 = Shortcuts.AddNpc(0, 57313, "", "d_velniasprison_51_1", 588.7963, 346.1506, 1358.056, 10);
		npc5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc5.AddEffect(new ScriptInvisibleEffect());
		npc5.Layer = character.Layer;
		actors.Add(npc5);

		var npc6 = Shortcuts.AddNpc(0, 57313, "", "d_velniasprison_51_1", 718.6459, 346.1506, 1335.129, 0);
		npc6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc6.AddEffect(new ScriptInvisibleEffect());
		npc6.Layer = character.Layer;
		actors.Add(npc6);

		var npc7 = Shortcuts.AddNpc(0, 57313, "", "d_velniasprison_51_1", 647.9368, 346.1506, 1545.112, 0);
		npc7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc7.AddEffect(new ScriptInvisibleEffect());
		npc7.Layer = character.Layer;
		actors.Add(npc7);

		var npc8 = Shortcuts.AddNpc(0, 57313, "", "d_velniasprison_51_1", 187.3133, 346.1506, 1431.473, 0);
		npc8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc8.AddEffect(new ScriptInvisibleEffect());
		npc8.Layer = character.Layer;
		actors.Add(npc8);

		var npc9 = Shortcuts.AddNpc(0, 57313, "", "d_velniasprison_51_1", 688.4921, 346.1506, 1454.294, 0);
		npc9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc9.AddEffect(new ScriptInvisibleEffect());
		npc9.Layer = character.Layer;
		actors.Add(npc9);

		var mob1 = Shortcuts.AddMonster(0, 154000, "UnvisibleName", "d_velniasprison_51_1", 72, 260, 901, 0);
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
			case 4:
				//DRT_ADDBUFF("LOWLV_EYEOFBAIGA_SQ_50_BUFF", 1, 0, 0, 1);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
