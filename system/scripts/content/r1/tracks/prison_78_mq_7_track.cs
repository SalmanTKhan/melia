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

[TrackScript("PRISON_78_MQ_7_TRACK")]
public class PRISON78MQ7TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("PRISON_78_MQ_7_TRACK");
		//SetMap("d_prison_78");
		//CenterPos(624.12,640.24,1598.41);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var npc0 = Shortcuts.AddNpc(0, 152031, "UnvisibleName", "d_prison_78", 634, 640.2397, 1687, 0);
		npc0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc0.AddEffect(new ScriptInvisibleEffect());
		npc0.Layer = character.Layer;
		actors.Add(npc0);

		var mob0 = Shortcuts.AddMonster(0, 58431, "", "d_prison_78", 634.7097, 640.2397, 1793.179, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(597.5536f, 620.4806f, 1411.153f));
		actors.Add(character);

		var mob1 = Shortcuts.AddMonster(0, 57707, "", "d_prison_78", 423.1287, 619.5419, 2351.904, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 8:
				break;
			case 11:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke129_spreadout", "BOT");
				break;
			case 13:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke129_spreadout", "BOT");
				break;
			case 15:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke129_spreadout", "BOT");
				break;
			case 17:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke129_spreadout", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup003_1", "BOT");
				break;
			case 26:
				break;
			case 33:
				//DRT_ACTOR_PLAY_EFT("F_ground058_smoke", "BOT", 0);
				break;
			case 39:
				//DRT_ACTOR_PLAY_EFT("F_ground058_smoke", "BOT", 0);
				break;
			case 44:
				//DRT_ACTOR_PLAY_EFT("F_burstup001_smoke1", "BOT", 0);
				break;
			case 51:
				//DRT_ADDBUFF("PRISON_78_MQ_7_BUFF", 1, 0, 0, 1);
				break;
			case 52:
				//TRACK_SETTENDENCY();
				character.AddonMessage("NOTICE_Dm_scroll", "Use the Magic Control Scroll to weaken Mandara and defeat it!", 10);
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
