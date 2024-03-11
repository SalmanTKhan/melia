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

[TrackScript("DIR_GT2_ZEMINA_1")]
public class DIRGT2ZEMINA1 : TrackScript
{
	protected override void Load()
	{
		SetId("DIR_GT2_ZEMINA_1");
		//SetMap("mission_groundtower_2");
		//CenterPos(-5750.03,241.78,6499.66);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 154072, "", "mission_groundtower_2", -5747.568, 239.9338, 6803.778, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 57580, "", "mission_groundtower_2", -5736.296, 239.9338, 6690.106, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		character.Movement.MoveTo(new Position(-5758.157f, 240.0172f, 6525.693f));
		actors.Add(character);

		var mob2 = Shortcuts.AddMonster(0, 20024, "", "mission_groundtower_2", -5747.57, 239.93, 6803.78, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 152055, "UnvisibleName", "mission_groundtower_2", -5737.913, 239.9338, 6730.773, 0, "Neutral");
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 152055, "UnvisibleName", "mission_groundtower_2", -5749.106, 239.9338, 6722.107, 0, "Neutral");
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 152055, "UnvisibleName", "mission_groundtower_2", -5722.403, 239.9338, 6721.49, 0, "Neutral");
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 152055, "UnvisibleName", "mission_groundtower_2", -5764.398, 239.9338, 6717.586, 0, "Neutral");
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 152055, "UnvisibleName", "mission_groundtower_2", -5712.289, 239.9338, 6708.796, 0, "Neutral");
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 152055, "UnvisibleName", "mission_groundtower_2", -5776.972, 239.9338, 6706.053, 0, "Neutral");
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 152055, "UnvisibleName", "mission_groundtower_2", -5787.737, 239.9338, 6696.333, 0, "Neutral");
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 152055, "UnvisibleName", "mission_groundtower_2", -5794.37, 239.9338, 6685.539, 0, "Neutral");
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 152055, "UnvisibleName", "mission_groundtower_2", -5696.708, 239.9338, 6689.455, 0, "Neutral");
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 152055, "UnvisibleName", "mission_groundtower_2", -5801.265, 239.9338, 6674.527, 0, "Neutral");
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 152055, "UnvisibleName", "mission_groundtower_2", -5809.714, 239.9338, 6656.473, 0, "Neutral");
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		var mob14 = Shortcuts.AddMonster(0, 152055, "UnvisibleName", "mission_groundtower_2", -5684.652, 239.9338, 6666.142, 0, "Neutral");
		mob14.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob14.AddEffect(new ScriptInvisibleEffect());
		mob14.Layer = character.Layer;
		actors.Add(mob14);

		var mob15 = Shortcuts.AddMonster(0, 152055, "UnvisibleName", "mission_groundtower_2", -5676.58, 239.9338, 6648.94, 0, "Neutral");
		mob15.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob15.AddEffect(new ScriptInvisibleEffect());
		mob15.Layer = character.Layer;
		actors.Add(mob15);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 3:
				break;
			case 4:
				break;
			case 5:
				break;
			case 6:
				//DRT_ACTOR_ATTACH_EFFECT("F_archer_circling_ground##40", "TOP");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke110", "BOT");
				break;
			case 7:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke110", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke110", "BOT");
				break;
			case 8:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke110", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke110", "BOT");
				break;
			case 9:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke110", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke110", "BOT");
				break;
			case 10:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke110", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke110", "BOT");
				break;
			case 11:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke110", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke110", "BOT");
				break;
			case 12:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke110", "BOT");
				break;
			case 13:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke110", "BOT");
				break;
			case 19:
				await track.Dialog.Msg("GT2_ZEMINA_1");
				break;
			case 22:
				break;
			case 33:
				await track.Dialog.Msg("GT2_ZEMINA_2");
				break;
			case 36:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke033_1", "BOT");
				break;
			case 37:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke033_1", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke033_1", "BOT");
				break;
			case 38:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke033_1", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke033_1", "BOT");
				break;
			case 39:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke033_1", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke033_1", "BOT");
				break;
			case 40:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke033_1", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke033_1", "BOT");
				break;
			case 41:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke033_1", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke033_1", "BOT");
				break;
			case 42:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke033_1", "BOT");
				break;
			case 43:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke033_1", "BOT");
				break;
			case 44:
				Send.ZC_NORMAL.Notice(character, "GT2_ZEMINA_BOX_1", 2.5f);
				break;
			case 70:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
