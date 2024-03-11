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

[TrackScript("FIRETOWER691_MQ_5_TRACK")]
public class FIRETOWER691MQ5TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("FIRETOWER691_MQ_5_TRACK");
		//SetMap("d_firetower_69_1");
		//CenterPos(2377.48,-725.82,369.27);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 151043, "", "d_firetower_69_1", 2425.786, -725.8188, 365.5205, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 154087, "", "d_firetower_69_1", 2413.63, -725.8188, 414.8395, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 58525, "", "d_firetower_69_1", 2318.883, -725.8188, 475.7037, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 20024, "", "d_firetower_69_1", 2318.88, -725.82, 475.7, 0);
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
			case 29:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground009", "BOT");
				break;
			case 31:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke122_blue", "BOT");
				break;
			case 32:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke142_yellow", "BOT");
				break;
			case 33:
				//DRT_ACTOR_ATTACH_EFFECT("F_circle011_dark", "BOT");
				break;
			case 41:
				//DRT_ACTOR_PLAY_EFT("F_explosion078_dark", "BOT", 0);
				break;
			case 44:
				character.AddonMessage("NOTICE_Dm_!", "A magic crazed boss has appeared!{nl}You were not able to see the end of Agailla Flurry's plan!{nl}Defeat the boss!", 8);
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
