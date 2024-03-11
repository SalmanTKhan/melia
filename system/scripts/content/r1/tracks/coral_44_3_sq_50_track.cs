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

[TrackScript("CORAL_44_3_SQ_50_TRACK")]
public class CORAL443SQ50TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CORAL_44_3_SQ_50_TRACK");
		//SetMap("f_coral_44_3");
		//CenterPos(-256.38,-75.10,-120.85);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-298.6626f, -69.41351f, -142.4383f));
		actors.Add(character);

		var npc0 = Shortcuts.AddNpc(0, 58831, "", "f_coral_44_3", 201.5062, -107.7407, -58.42498, 118.75);
		npc0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc0.AddEffect(new ScriptInvisibleEffect());
		npc0.Layer = character.Layer;
		actors.Add(npc0);

		var mob0 = Shortcuts.AddMonster(0, 20024, "", "f_coral_44_3", 19.71688, -107.7407, -301.8212, 495);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 20024, "", "f_coral_44_3", 185.8372, -107.7407, -200.339, 387.5);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 20024, "", "f_coral_44_3", 29.68544, -107.7407, -81.4592, 32.5);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 155051, "", "f_coral_44_3", 821.6268, -107.7407, -650.254, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var npc1 = Shortcuts.AddNpc(0, 58831, "", "f_coral_44_3", 108.7527, -107.7407, -391.5728, 0.862069);
		npc1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc1.AddEffect(new ScriptInvisibleEffect());
		npc1.Layer = character.Layer;
		actors.Add(npc1);

		var mob4 = Shortcuts.AddMonster(0, 20024, "", "f_coral_44_3", 165.5317, -107.7407, -422.9375, 200);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var npc2 = Shortcuts.AddNpc(0, 58831, "", "f_coral_44_3", 573.4286, -107.7407, -491.1462, 10.83333);
		npc2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc2.AddEffect(new ScriptInvisibleEffect());
		npc2.Layer = character.Layer;
		actors.Add(npc2);

		var npc3 = Shortcuts.AddNpc(0, 58831, "", "f_coral_44_3", 679.8875, -107.7407, -688.1691, 227.5);
		npc3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc3.AddEffect(new ScriptInvisibleEffect());
		npc3.Layer = character.Layer;
		actors.Add(npc3);

		var mob5 = Shortcuts.AddMonster(0, 20024, "", "f_coral_44_3", 762.1983, -107.7407, -709.0013, 200);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 20024, "", "f_coral_44_3", 635.7227, -107.7407, -606.4333, 200);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 20024, "", "f_coral_44_3", 856.3929, -107.7407, -586.0419, 3115);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 20053, "", "f_coral_44_3", -439.0071, -47.73416, -158.2088, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 20053, "", "f_coral_44_3", 878.6386, -107.7407, -901.5182, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 20053, "", "f_coral_44_3", 1009.514, -107.7407, -498.9182, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 14:
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
