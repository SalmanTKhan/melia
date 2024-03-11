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

[TrackScript("CASTLE94_MAIN01_TRACK")]
public class CASTLE94MAIN01TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CASTLE94_MAIN01_TRACK");
		//SetMap("f_castle_94");
		//CenterPos(1112.00,289.92,811.84);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 150200, "왕국", "f_castle_94", 1074.057, 295.1365, 766.6777, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 155131, "", "f_castle_94", 1074.311, 289.9216, 1168.286, 21.94444);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 155132, "", "f_castle_94", 1289.839, 289.9216, 1081.804, 22.55319);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 154017, "", "f_castle_94", 1331.95, 289.9216, 837.6294, 17.90698);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		character.Movement.MoveTo(new Position(1088.838f, 292.2007f, 787.2609f));
		actors.Add(character);

		var mob4 = Shortcuts.AddMonster(0, 20042, "", "f_castle_94", 1182.46, 289.92, 798.99, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 20042, "", "f_castle_94", 1169.68, 289.92, 906.19, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 20042, "", "f_castle_94", 1075.23, 289.92, 931.7, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 59246, "", "f_castle_94", 1182.46, 289.92, 798.99, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 59246, "", "f_castle_94", 1075.23, 289.92, 931.7, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 59245, "", "f_castle_94", 1169.68, 289.92, 906.19, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 40120, "", "f_castle_94", 1133.87, 295.1365, 726.7617, 0);
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
			case 58:
				//DRT_ACTOR_ATTACH_EFFECT("F_circle032_dark_loop", "BOT");
				break;
			case 59:
				//DRT_ACTOR_ATTACH_EFFECT("F_circle032_dark_loop", "BOT");
				break;
			case 60:
				//DRT_ACTOR_ATTACH_EFFECT("F_circle032_dark_loop", "BOT");
				break;
			case 73:
				//DRT_ACTOR_PLAY_EFT("F_explosion078_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion078_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion078_dark", "BOT", 0);
				//DisableBornAni();
				//DisableBornAni();
				//DisableBornAni();
				break;
			case 88:
				//TRACK_MON_LOOKAT();
				CreateBattleBoxInLayer(character, track);
				//TRACK_SETTENDENCY();
				break;
			case 89:
				//DRT_PLAY_MGAME("CASTLE94_MAIN01_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
