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

[TrackScript("EP13_F_SIAULIAI_2_MQ_01_TRACK")]
public class EP13FSIAULIAI2MQ01TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP13_F_SIAULIAI_2_MQ_01_TRACK");
		//SetMap("ep13_f_siauliai_2");
		//CenterPos(2549.92,139.07,-913.78);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(2548.364f, 139.0712f, -911.1902f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 150242, "", "ep13_f_siauliai_2", 2521.595, 139.0712, -910.572, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 150243, "", "ep13_f_siauliai_2", 1137.989, 139.0711, -839.8904, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 150243, "", "ep13_f_siauliai_2", 1396.782, 139.0712, -895.5403, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 150243, "", "ep13_f_siauliai_2", 1268.405, 139.071, -1029.074, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 150244, "", "ep13_f_siauliai_2", 1188.873, 139.0711, -832.3201, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 150244, "", "ep13_f_siauliai_2", 1422.781, 139.0711, -936.9665, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 150244, "", "ep13_f_siauliai_2", 1230.879, 139.071, -1059.564, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 59580, "", "ep13_f_siauliai_2", 1185.215, 139.0711, -914.6032, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 59580, "", "ep13_f_siauliai_2", 1283.235, 139.071, -794.6613, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 59581, "", "ep13_f_siauliai_2", 1276.345, 139.0711, -964.4799, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 59581, "", "ep13_f_siauliai_2", 1163.29, 139.071, -985.4249, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 59582, "", "ep13_f_siauliai_2", 1326.016, 139.0711, -842.4063, 0);
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
			case 62:
				await track.Dialog.Msg("EP13_F_SIAULIAI_2_MQ_01_DLG_T1");
				break;
			case 74:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
