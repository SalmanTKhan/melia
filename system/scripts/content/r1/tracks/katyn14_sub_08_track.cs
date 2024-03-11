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

[TrackScript("KATYN14_SUB_08_TRACK")]
public class KATYN14SUB08TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("KATYN14_SUB_08_TRACK");
		//SetMap("f_katyn_14");
		//CenterPos(-2745.11,422.17,1361.11);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 41247, "", "f_katyn_14", -3398.218, 422.1801, 1339.344, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 400441, "", "f_katyn_14", -3276.914, 422.1801, 1469.178, 56.52174);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 400441, "", "f_katyn_14", -3331.647, 422.1701, 1284.71, 56.81818);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 400245, "", "f_katyn_14", -3306.872, 422.1801, 1350.676, 73.04348);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 400245, "", "f_katyn_14", -3361.942, 422.1701, 1340.428, 74.78261);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 400245, "", "f_katyn_14", -3291.733, 422.1701, 1379.731, 63.91304);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 400245, "", "f_katyn_14", -3321.403, 422.1701, 1423.913, 68.33334);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 400245, "", "f_katyn_14", -3204.121, 422.1801, 1353.8, 65);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 400245, "", "f_katyn_14", -3173.482, 422.1801, 1334.267, 56.37931);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 47170, "무명", "f_katyn_14", -2724.93, 422.17, 1381.91, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 9:
				//TargetCamera();
				//CameraShockWave(2, 999, 15, 1, 70, 0);
				//PlayAnim("born", 1, 1, 0);
				break;
			case 11:
				//PlayAnim("astd", 1, 1, 0);
				break;
			case 19:
				//Dead();
				break;
			case 20:
				//Dead();
				//Dead();
				//Dead();
				break;
			case 21:
				//Dead();
				break;
			case 22:
				//Dead();
				break;
			case 23:
				//PlayAnim("angry_event", 1, 1, 0);
				break;
			case 27:
				//CameraShockWave(2, 999, 5, 2, 60, 0);
				break;
			case 29:
				//Dead();
				break;
			case 30:
				//Dead();
				break;
			case 32:
				//TRACK_SETTENDENCY();
				break;
			case 34:
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
