using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.Scripting;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.Effects;
using Melia.Zone.World.Tracks;
using Yggdrasil.Logging;

[TrackScript("EP15_1_F_ABBEY_3_6_TRACK")]
public class EP151FABBEY36TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP15_1_F_ABBEY_3_6_TRACK");
		//SetMap("ep15_1_f_abbey_3");
		//CenterPos(-0.48,44.60,1159.21);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 59776, "", "ep15_1_f_abbey_3", 15.07657, 44.60283, 1458.266, 19.25);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 153119, "", "ep15_1_f_abbey_3", 13.7632, 44.60283, 1471.244, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 59657, "", "ep15_1_f_abbey_3", 115.0347, 44.60282, 1477.246, 1.5);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 160144, "", "ep15_1_f_abbey_3", -19.9875, 44.60283, 1196.172, 85.83333);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 150237, "", "ep15_1_f_abbey_3", 86.16037, 44.60283, 1392.714, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 160151, "", "ep15_1_f_abbey_3", 31.13612, 44.60283, 1512.315, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		character.Movement.MoveTo(new Position(0.5608749f, 44.60283f, 1163.374f));
		actors.Add(character);

		var mob6 = Shortcuts.AddMonster(0, 12082, "", "ep15_1_f_abbey_3", 13.31049, 44.60283, 1467.046, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 12082, "", "ep15_1_f_abbey_3", 119.775, 44.60282, 1474.224, 18);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 12082, "", "ep15_1_f_abbey_3", 90.44661, 44.60283, 1388.231, 0);
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
				break;
			case 2:
				break;
			case 12:
				break;
			case 13:
				await track.Dialog.Msg("EP15_1_F_ABBEY3_6_DLG1");
				break;
			case 16:
				await track.Dialog.Msg("EP15_1_F_ABBEY3_6_DLG2");
				break;
			case 22:
				break;
			case 37:
				await track.Dialog.Msg("EP15_1_F_ABBEY3_6_DLG3");
				break;
			case 43:
				await track.Dialog.Msg("EP15_1_F_ABBEY3_6_DLG4");
				break;
			case 48:
				await track.Dialog.Msg("EP15_1_F_ABBEY3_6_DLG5");
				break;
			case 52:
				await track.Dialog.Msg("EP15_1_F_ABBEY3_6_DLG6");
				break;
			case 55:
				await track.Dialog.Msg("EP15_1_F_ABBEY3_6_DLG7");
				break;
			case 59:
				await track.Dialog.Msg("EP15_1_F_ABBEY3_6_DLG8");
				break;
			case 66:
				break;
			case 73:
				//DRT_CLEAR_EFFECT();
				break;
			case 77:
				//DRT_ACTOR_ATTACH_EFFECT("F_light078_holy_yellow_loop2", "BOT");
				break;
			case 79:
				await track.Dialog.Msg("EP15_1_F_ABBEY3_6_DLG9");
				break;
			case 81:
				break;
			case 94:
				await track.Dialog.Msg("EP15_1_F_ABBEY3_6_DLG10");
				break;
			case 112:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
