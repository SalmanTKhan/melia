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

[TrackScript("FLASH63_SQ_08_TRACK")]
public class FLASH63SQ08TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("FLASH63_SQ_08_TRACK");
		//SetMap("f_flash_63");
		//CenterPos(-533.93,265.69,1071.34);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-545.2758f, 265.6861f, 1085.979f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 57589, "", "f_flash_63", -584.1966, 265.6861, 1118.79, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 10033, "", "f_flash_63", -601.4103, 253.9864, 565.918, 81.42857);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 10033, "", "f_flash_63", -579.1683, 261.3609, 592.8843, 86.66667);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 10:
				character.AddonMessage("NOTICE_Dm_!", "3", 1);
				break;
			case 11:
				//DRT_ACTOR_ATTACH_EFFECT("F_archer_turret_hit_explosion", "BOT");
				break;
			case 14:
				character.AddonMessage("NOTICE_Dm_!", "2", 1);
				break;
			case 18:
				character.AddonMessage("NOTICE_Dm_!", "1", 1);
				break;
			case 28:
				//DRT_SETHOOKMSGOWNER(0, 0);
				//DRT_SETHOOKMSGOWNER(0, 0);
				break;
			case 46:
				character.AddonMessage("NOTICE_Dm_!", "Defeat Stone Froster and acquire the Frosty Core!", 3);
				break;
			case 49:
				//InsertHate(999);
				//InsertHate(999);
				break;
			case 54:
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
