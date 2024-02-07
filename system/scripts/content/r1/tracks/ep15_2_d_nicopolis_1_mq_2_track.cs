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

[TrackScript("EP15_2_D_NICOPOLIS_1_MQ_2_TRACK")]
public class EP152DNICOPOLIS1MQ2TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP15_2_D_NICOPOLIS_1_MQ_2_TRACK");
		//SetMap("ep15_2_d_nicopolis_1");
		//CenterPos(-246.98,74.54,-1194.00);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-323.9505f, 74.53714f, -1182.502f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 150237, "", "ep15_2_d_nicopolis_1", -215.2769, 74.53714, -1180.879, 1.842105);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 59805, "", "ep15_2_d_nicopolis_1", -271.6926, 74.53714, -1288.223, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 59805, "", "ep15_2_d_nicopolis_1", -164.627, 74.53714, -1304.559, 11.875);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 59805, "", "ep15_2_d_nicopolis_1", -96.35893, 74.53714, -1296.258, 54.28572);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 59805, "", "ep15_2_d_nicopolis_1", -205.7992, 74.53714, -1052.16, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 59805, "", "ep15_2_d_nicopolis_1", -135.7963, 74.53714, -1012.867, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 59805, "", "ep15_2_d_nicopolis_1", -58.03588, 74.53714, -1063.615, 52.5);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 12082, "", "ep15_2_d_nicopolis_1", -208.075, 74.53714, -1187.802, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 12082, "", "ep15_2_d_nicopolis_1", -206.9301, 74.53714, -1126.266, 665);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 12082, "", "ep15_2_d_nicopolis_1", -228.5029, 74.53714, -1224.187, 415);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 12082, "", "ep15_2_d_nicopolis_1", -178.5346, 74.53714, -1151.092, 1310);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 12082, "", "ep15_2_d_nicopolis_1", -118.4173, 74.53714, -1151.385, 325);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 12082, "", "ep15_2_d_nicopolis_1", -166.4197, 74.53714, -1259.911, 1310);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 12082, "", "ep15_2_d_nicopolis_1", -145.6726, 74.53714, -1238.747, 235);
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 7:
				break;
			case 9:
				await track.Dialog.Msg("EP15_2_D_NICOPOLIS_1_MQ_2_DLG3");
				break;
			case 14:
				break;
			case 15:
				break;
			case 17:
				await track.Dialog.Msg("EP15_2_D_NICOPOLIS_1_MQ_2_DLG4");
				break;
			case 19:
				break;
			case 21:
				break;
			case 22:
				break;
			case 27:
				break;
			case 28:
				break;
			case 36:
				await track.Dialog.Msg("EP15_2_D_NICOPOLIS_1_MQ_2_DLG5");
				break;
			case 42:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
