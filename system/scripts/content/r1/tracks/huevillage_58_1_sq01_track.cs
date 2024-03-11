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

[TrackScript("HUEVILLAGE_58_1_SQ01_TRACK")]
public class HUEVILLAGE581SQ01TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("HUEVILLAGE_58_1_SQ01_TRACK");
		//SetMap("f_huevillage_58_1");
		//CenterPos(-1218.98,230.98,497.16);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 47325, "", "f_huevillage_58_1", -946.8989, 230.9787, 377.6842, 70);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(476.8085f, 371.3248f, -747.0408f));
		actors.Add(character);

		var mob1 = Shortcuts.AddMonster(0, 47124, "", "f_huevillage_58_1", -1250, 230, 490, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 20025, "", "f_huevillage_58_1", -397.5957, 230.9787, -162.9517, 120.7143);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 20025, "", "f_huevillage_58_1", -363.2737, 230.9787, -162.9143, 189.1667);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 147487, "", "f_huevillage_58_1", -805.6993, 229.3649, 227.8291, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 20025, "", "f_huevillage_58_1", -810.88, 278.1323, 234.4063, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 20025, "", "f_huevillage_58_1", -628.1457, 229.3649, -53.80838, 2.857143);
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
			case 7:
				//DRT_ACTOR_ATTACH_EFFECT("F_archer_entangle_active_smoke", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke022", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion041_smoke", "BOT");
				break;
			case 10:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke039", "BOT");
				break;
			case 15:
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion041_smoke", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_Moyabruka_born_mash", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_statue_parts_mash", "BOT");
				break;
			case 16:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke043_green", "BOT");
				break;
			case 18:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke079", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_drop_leaf004", "BOT");
				break;
			case 22:
				character.AddonMessage("NOTICE_Dm_!", "Defeat Moyabruka!", 3);
				break;
			case 27:
				//DRT_MOVETOTGT(50);
				break;
			case 29:
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
