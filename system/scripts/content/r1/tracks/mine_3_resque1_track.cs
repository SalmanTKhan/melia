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

[TrackScript("MINE_3_RESQUE1_TRACK")]
public class MINE3RESQUE1TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("MINE_3_RESQUE1_TRACK");
		//SetMap("d_cmine_6");
		//CenterPos(-1183.29,303.49,85.39);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 41409, "", "d_cmine_6", -998.6, 181.61, -257.69, 55.5);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 41409, "", "d_cmine_6", -671.48, 181.61, -3.649994, 39.09091);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 41409, "", "d_cmine_6", -801.95, 181.76, -20.19, 32.28571);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 41409, "", "d_cmine_6", -1098.07, 253.09, -7.089996, 52.5);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 41409, "", "d_cmine_6", -1165.41, 253.09, -151.9, 52);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 41409, "", "d_cmine_6", -1070.67, 181.61, -95.78, 61.81818);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 41409, "", "d_cmine_6", -832.88, 185.55, 70.21, 51);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 20150, "Miner", "d_cmine_6", -1172.804, 303.4853, 94.02144, 26.875);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 47236, "", "d_cmine_6", -1206.568, 303.4853, 87.32335, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 20114, "", "d_cmine_6", -1170, 303, 120, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 147473, "", "d_cmine_6", -1200.253, 303.4853, 98.06091, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 151009, "Miner", "d_cmine_6", -1173.919, 303.4853, 95.35041, 0);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 151010, "", "d_cmine_6", -1170, 303, 120, 1.666667);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 151011, "", "d_cmine_6", -1200.25, 303.49, 98.06, 1);
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		var mob14 = Shortcuts.AddMonster(0, 151012, "Girl", "d_cmine_6", -1206.57, 303.49, 87.32, 2.857143);
		mob14.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob14.AddEffect(new ScriptInvisibleEffect());
		mob14.Layer = character.Layer;
		actors.Add(mob14);

		character.Movement.MoveTo(new Position(-1233.298f, 303.4853f, 0.03495789f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 3:
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion093", "BOT");
				break;
			case 5:
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion093", "BOT");
				break;
			case 11:
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion093", "BOT");
				break;
			case 12:
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion093", "BOT");
				break;
			case 13:
				break;
			case 14:
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion093", "BOT");
				break;
			case 15:
				break;
			case 16:
				break;
			case 17:
				break;
			case 19:
				break;
			case 29:
				//TRACK_SETTENDENCY();
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
