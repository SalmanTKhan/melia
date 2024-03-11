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

[TrackScript("F_3CMLAKE261_SQ07_TRACK")]
public class F3CMLAKE261SQ07TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_3CMLAKE261_SQ07_TRACK");
		//SetMap("f_3cmlake_26_1");
		//CenterPos(520.64,-89.70,-1194.81);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(529.8269f, -89.52122f, -1194.833f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 20026, "", "f_3cmlake_26_1", 428.4918, -101.6569, -1193.217, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 58832, "", "f_3cmlake_26_1", 56.57144, -122.0254, -1410.519, 23.26087);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 58835, "", "f_3cmlake_26_1", 175.885, -122.0254, -1437.651, 27.25);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 58834, "", "f_3cmlake_26_1", 251.075, -122.0254, -1396.625, 34.46429);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 58835, "", "f_3cmlake_26_1", -222.5219, -91.36871, -1228.571, 42.69231);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 58834, "", "f_3cmlake_26_1", -158.2205, -122.0254, -1327.799, 32.17391);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 58832, "", "f_3cmlake_26_1", -146.2591, -122.0254, -1145.211, 36.6);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 147382, "", "f_3cmlake_26_1", 79, -122, -1054, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 20041, "", "f_3cmlake_26_1", 79, -122, -1054, 0);
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
			case 10:
				//DRT_ACTOR_ATTACH_EFFECT("I_force036_green1", "MID");
				break;
			case 12:
				character.AddonMessage("NOTICE_Dm_Clear", "The blue light from the wings is heading towards something!", 3);
				break;
			case 27:
				character.AddonMessage("NOTICE_Dm_scroll", "The monsters that reacted to the wing's light prepare to fight you!", 3);
				break;
			case 41:
				//DRT_ACTOR_ATTACH_EFFECT("I_cylinder010_light_dark", "BOT");
				break;
			case 42:
				break;
			case 69:
				//TRACK_MON_LOOKAT();
				CreateBattleBoxInLayer(character, track);
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
