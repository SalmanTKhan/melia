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

[TrackScript("THORN39_1_SQ06_TRACK")]
public class THORN391SQ06TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("THORN39_1_SQ06_TRACK");
		//SetMap("d_thorn_39_1");
		//CenterPos(1276.32,1216.38,-1469.78);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(1276.32f, 1216.375f, -1469.778f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 20024, "", "d_thorn_39_1", 1298.548, 1216.375, -1288.16, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 20024, "", "d_thorn_39_1", 1443.448, 1216.375, -1431.824, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 20024, "", "d_thorn_39_1", 1120.601, 1216.375, -1464.691, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 20024, "", "d_thorn_39_1", 1274.55, 1216.375, -1604.298, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 57653, "", "d_thorn_39_1", 822.5368, 1216.375, -1706.745, 9.0625);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 57653, "", "d_thorn_39_1", 820.6131, 1216.375, -1634.44, 7.5);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 41197, "", "d_thorn_39_1", 868.5065, 1216.375, -1638.085, 7.941176);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 41197, "", "d_thorn_39_1", 894.9039, 1216.375, -1651.91, 3.636364);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 41197, "", "d_thorn_39_1", 885.4752, 1216.375, -1700.957, 7.352941);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 31:
				CreateBattleBoxInLayer(character, track);
				break;
			case 34:
				//TRACK_SETTENDENCY();
				character.AddonMessage("NOTICE_Dm_!", "Monsters sensed something!{nl}Protect the Anti-Mobility Device!", 3);
				//DRT_PLAY_MGAME("THORN39_1_SQ06_TRACK_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
