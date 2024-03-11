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

[TrackScript("EP15_1_F_ABBEY2_8_TRACK")]
public class EP151FABBEY28TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP15_1_F_ABBEY2_8_TRACK");
		//SetMap("ep15_1_f_abbey_2");
		//CenterPos(-1341.36,74.90,1561.69);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-1344.796f, 74.9019f, 1560.979f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 59770, "", "ep15_1_f_abbey_2", -1480.829, 74.90191, 1673.776, 16.52778);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 59657, "", "ep15_1_f_abbey_2", -1483.356, 74.90192, 1602.505, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 153119, "", "ep15_1_f_abbey_2", -1286.89, 74.9019, 1546.821, 0.5172414);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 160144, "", "ep15_1_f_abbey_2", -1348.231, 74.9019, 1495.454, 11.25);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 12082, "", "ep15_1_f_abbey_2", -1481.038, 74.90191, 1603.105, 5.322581);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 12082, "", "ep15_1_f_abbey_2", -1459.18, 74.90191, 1585.055, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 12082, "", "ep15_1_f_abbey_2", -1295.949, 74.9019, 1557.865, 60);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 4:
				break;
			case 6:
				break;
			case 7:
				break;
			case 10:
				await track.Dialog.Msg("EP15_1_F_ABBEY2_8_DLG1");
				break;
			case 16:
				break;
			case 24:
				break;
			case 26:
				await track.Dialog.Msg("EP15_1_F_ABBEY2_8_DLG2");
				//DRT_SETPOS();
				break;
			case 42:
				await track.Dialog.Msg("EP15_1_F_ABBEY2_8_DLG3");
				break;
			case 60:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
