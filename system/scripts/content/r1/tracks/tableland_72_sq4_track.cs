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

[TrackScript("TABLELAND_72_SQ4_TRACK")]
public class TABLELAND72SQ4TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("TABLELAND_72_SQ4_TRACK");
		//SetMap("f_tableland_72");
		//CenterPos(-402.84,406.14,-72.93);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-408.1421f, 406.1369f, -74.4338f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 153157, "", "f_tableland_72", -442.1999, 406.1369, -61.51435, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 40120, "", "f_tableland_72", -272.54, 406.13, -74.31, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 155043, "마을", "f_tableland_72", -425.44, 406.13, 69.72, 67.69231);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 155046, "마을", "f_tableland_72", -394.34, 406.13, 83.38, 65.33334);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 147459, "", "f_tableland_72", -424.0255, 406.1369, -71.31687, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 3:
				break;
			case 8:
				//DRT_ACTOR_ATTACH_EFFECT("I_light013_spark_orange2", "TOP");
				break;
			case 12:
				//DRT_ACTOR_ATTACH_EFFECT("I_light013_spark_orange2", "TOP");
				break;
			case 16:
				//DRT_ACTOR_ATTACH_EFFECT("I_light013_spark_orange2", "TOP");
				break;
			case 22:
				//DRT_ACTOR_PLAY_EFT("F_explosion050_fire", "BOT", 0);
				break;
			case 23:
				//DRT_ACTOR_PLAY_EFT("F_bg_fire001", "BOT", 0);
				break;
			case 29:
				character.AddonMessage("NOTICE_Dm_Clear", "The Observation Orb has been destroyed", 3);
				break;
			case 45:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
