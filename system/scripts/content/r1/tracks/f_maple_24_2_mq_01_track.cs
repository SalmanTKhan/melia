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

[TrackScript("F_MAPLE_24_2_MQ_01_TRACK")]
public class FMAPLE242MQ01TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_MAPLE_24_2_MQ_01_TRACK");
		//SetMap("f_maple_24_1");
		//CenterPos(-1229.18,8.77,712.15);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 156158, "", "f_maple_24_1", -1285.848, 8.768949, 687.5028, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 156159, "Kartas", "f_maple_24_1", -1178.1, 1.2381, 692.0751, 23.23529);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 59256, "", "f_maple_24_1", -1246.241, 8.768948, 763.499, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 59256, "", "f_maple_24_1", -1266.735, 8.76895, 598.9686, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 59256, "", "f_maple_24_1", -1204.755, 8.768947, 605.2863, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 59256, "", "f_maple_24_1", -1189.461, 8.768948, 771.6163, 0.4);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 147469, "", "f_maple_24_1", -1283.437, 8.768949, 684.5901, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 47124, "", "f_maple_24_1", -1206.731, 8.768949, 764.4238, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 47124, "", "f_maple_24_1", -1238.3, 8.768948, 589.6307, 0);
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
			case 1:
				//DRT_ACTOR_ATTACH_EFFECT("F_pattern014_ground_red_loop", "BOT");
				break;
			case 15:
				await track.Dialog.Msg("F_MAPLE_242_TRACK_01");
				break;
			case 17:
				await track.Dialog.Msg("F_MAPLE_242_TRACK_02");
				break;
			case 19:
				await track.Dialog.Msg("F_MAPLE_242_TRACK_03");
				break;
			case 21:
				await track.Dialog.Msg("F_MAPLE_242_TRACK_04");
				break;
			case 23:
				await track.Dialog.Msg("F_MAPLE_242_TRACK_05");
				break;
			case 25:
				await track.Dialog.Msg("F_MAPLE_242_TRACK_06");
				break;
			case 27:
				await track.Dialog.Msg("F_MAPLE_242_TRACK_07");
				break;
			case 29:
				await track.Dialog.Msg("F_MAPLE_242_TRACK_08");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
