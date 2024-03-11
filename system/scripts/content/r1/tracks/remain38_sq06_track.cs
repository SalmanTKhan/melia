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

[TrackScript("REMAIN38_SQ06_TRACK")]
public class REMAIN38SQ06TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("REMAIN38_SQ06_TRACK");
		//SetMap("f_remains_38");
		//CenterPos(-131.20,422.89,372.19);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 47258, "", "f_remains_38", -78.56619, 422.8875, 424.5977, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 41310, "", "f_remains_38", -150.7699, 422.8875, 368.4929, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 41310, "", "f_remains_38", -93.3864, 422.8875, 344.2368, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 41447, "", "f_remains_38", -19.54728, 422.8875, 360.714, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 41447, "", "f_remains_38", 8.83816, 422.8875, 420.4291, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		character.Movement.MoveTo(new Position(-93.27329f, 422.8875f, 403.4002f));
		actors.Add(character);

		var mob5 = Shortcuts.AddMonster(0, 57064, "", "f_remains_38", -157.5493, 375.6272, 578.2559, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 3:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in001_dark", "BOT");
				break;
			case 4:
				//DRT_ACTOR_ATTACH_EFFECT("I_spread_in011", "MID");
				break;
			case 5:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in007_dark", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_bat011_smoke", "TOP");
				break;
			case 6:
				//DRT_MOVE3D(400, 1, 1, 1);
				break;
			case 8:
				//DRT_MOVE3D(450, 1, 1, 1);
				break;
			case 9:
				//DRT_MOVE3D(300, 1, 1, 1);
				break;
			case 10:
				//DRT_MOVE3D(500, 1, 1, 1);
				break;
			case 16:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground036_violet", "BOT");
				break;
			case 20:
				//DRT_ACTOR_ATTACH_EFFECT("F_pattern008_violet", "BOT");
				break;
			case 30:
				character.AddonMessage("NOTICE_Dm_!", "The uncontrollable Necroventer has been summoned!{nl}The experiment failed! Defeat Necroventer!", 3);
				break;
			case 44:
				//TRACK_MON_LOOKAT();
				//CREATE_BATTLE_BOX_INLAYER(0);
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
