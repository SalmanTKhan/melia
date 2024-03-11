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

[TrackScript("EP16_1_PILGRIM_36_2_MQ13_TRACK")]
public class EP161PILGRIM362MQ13TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP16_1_PILGRIM_36_2_MQ13_TRACK");
		//SetMap("f_pilgrimroad_36_2");
		//CenterPos(-138.50,225.38,-532.60);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 160201, "", "f_pilgrimroad_36_2", -234.205, 225.3776, -561.712, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 150210, "", "f_pilgrimroad_36_2", -226.2622, 225.3776, -448.5073, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		character.Movement.MoveTo(new Position(-159.3284f, 225.3776f, -517.4701f));
		actors.Add(character);

		var mob2 = Shortcuts.AddMonster(0, 59832, "", "f_pilgrimroad_36_2", 25, 255, -493, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 59834, "", "f_pilgrimroad_36_2", -45, 255, -664, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 5:
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_basic028_violet_line", "BOT");
				break;
			case 14:
				//DRT_RUN_FUNCTION("SCR_EP16_1_PILGRIM_36_2_MQ13_BAIGA_DLG");
				break;
			case 19:
				//DRT_RUN_FUNCTION("SCR_EP16_1_PILGRIM_36_2_MQ13_DAMIJONAS_DLG");
				break;
			case 24:
				//DRT_RUN_FUNCTION("SCR_EP16_1_PILGRIM_36_2_MQ13_BAIGA_DLG");
				break;
			case 29:
				//DRT_RUN_FUNCTION("SCR_EP16_1_PILGRIM_36_2_MQ13_DIRECTION_EFFECT_PC_TO_BAIGA");
				break;
			case 35:
				//DRT_RUN_FUNCTION("SCR_EP16_1_PILGRIM_36_2_MQ13_DIRECTION_EFFECT_BAIGA_TO_PC");
				break;
			case 43:
				//DRT_RUN_FUNCTION("SCR_EP16_1_PILGRIM_36_2_MQ13_DIRECTION_ITEM");
				break;
			case 49:
				//DRT_RUN_FUNCTION("SCR_EP16_1_PILGRIM_36_2_MQ13_BAIGA_DLG");
				break;
			case 65:
				break;
			case 73:
				break;
			case 81:
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_basic028_violet_line", "BOT");
				break;
			case 89:
				//DRT_PLAY_MGAME("EP16_1_PILGRIM_36_2_MQ13_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
