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

[TrackScript("FARM47_CROPS01_DIE_TRACK")]
public class FARM47CROPS01DIETRACK : TrackScript
{
	protected override void Load()
	{
		SetId("FARM47_CROPS01_DIE_TRACK");
		//SetMap("None");
		//CenterPos(-169.10,156.54,17.28);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 47201, "", "None", -178.6687, 156.5406, -59.05937, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 47201, "", "None", -143.3046, 156.5406, -61.15696, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 47201, "", "None", -163.8471, 156.5406, -32.99286, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 47201, "", "None", -133.0434, 156.5406, -32.62661, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 47201, "", "None", -179.0268, 156.5406, -3.639767, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 47201, "", "None", -144.8223, 156.5406, -6.549465, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 47201, "", "None", -162.2165, 156.5406, 23.63589, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 47201, "", "None", -129.7853, 156.5406, 24.54705, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 47201, "", "None", -80.10576, 156.5406, -59.77641, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 47201, "", "None", -45.46738, 156.5406, -60.99061, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 47201, "", "None", -66.89835, 156.5406, -32.97582, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 47201, "", "None", -33.84982, 156.5406, -31.54564, 0);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 47201, "", "None", -83.22498, 156.5406, -6.282738, 0);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 47201, "", "None", -50.13311, 156.5406, -3.105927, 0);
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		var mob14 = Shortcuts.AddMonster(0, 47201, "", "None", -69.82184, 156.5406, 23.01534, 0);
		mob14.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob14.AddEffect(new ScriptInvisibleEffect());
		mob14.Layer = character.Layer;
		actors.Add(mob14);

		var mob15 = Shortcuts.AddMonster(0, 47201, "", "None", -34.83418, 156.5406, 22.53554, 0);
		mob15.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob15.AddEffect(new ScriptInvisibleEffect());
		mob15.Layer = character.Layer;
		actors.Add(mob15);

		character.Movement.MoveTo(new Position(-192.1474f, 156.5406f, 163.6291f));
		actors.Add(character);

		var mob16 = Shortcuts.AddMonster(0, 47223, "UnvisibleName", "None", -197.29, 156.54, 191.36, 0);
		mob16.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob16.AddEffect(new ScriptInvisibleEffect());
		mob16.Layer = character.Layer;
		actors.Add(mob16);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 2:
				//DRT_ACTOR_ATTACH_EFFECT("F_blood002_dark", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_blood002_dark", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_blood002_dark", "BOT");
				break;
			case 3:
				//DRT_ACTOR_ATTACH_EFFECT("F_blood002_dark", "BOT");
				break;
			case 5:
				//DRT_ACTOR_ATTACH_EFFECT("None", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_blood002_dark", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_blood002_dark", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_blood002_dark", "BOT");
				break;
			case 7:
				//DRT_ACTOR_ATTACH_EFFECT("F_blood002_dark", "BOT");
				break;
			case 8:
				//DRT_ACTOR_ATTACH_EFFECT("F_blood002_dark", "BOT");
				break;
			case 9:
				//DRT_ACTOR_ATTACH_EFFECT("F_blood002_dark", "BOT");
				break;
			case 12:
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			case 23:
				character.AddonMessage("NOTICE_Dm_!", "The crops suddenly dies and turns dark!", 5);
				break;
			case 24:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
