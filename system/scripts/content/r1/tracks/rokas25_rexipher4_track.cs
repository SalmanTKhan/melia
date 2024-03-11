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

[TrackScript("ROKAS25_REXIPHER4_TRACK")]
public class ROKAS25REXIPHER4TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ROKAS25_REXIPHER4_TRACK");
		//SetMap("f_rokas_25");
		//CenterPos(1032.41,164.31,-201.88);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 47102, "", "f_rokas_25", 1080, 164, -200, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 47107, "Support", "f_rokas_25", 1030.453, 164.3084, -100.7098, 0, "Monster");
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.Level = 69;
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 47107, "Support", "f_rokas_25", 1032.625, 164.3084, -301.4351, 5, "Monster");
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.Level = 69;
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 47107, "Support", "f_rokas_25", 1199.29, 164.31, -195.64, 0, "Monster");
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.Level = 69;
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 1:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground012_light", "BOT");
				//DRT_RUN_FUNCTION("SCR_ROKAS25_REXIPHER4_SEAL1_TEXT_PLAY");
				break;
			case 2:
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion041_smoke", "BOT");
				//DRT_ACTOR_PLAY_EFT("F_explosion041_smoke", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion041_smoke", "BOT");
				break;
			case 4:
				//DRT_PLAY_MGAME("ROKAS25_REXIPHER4_MINI");
				break;
			case 5:
				//DRT_LINK_OBJECT("OOBE", "Node", "Node");
				//DRT_LINK_OBJECT("OOBE", "Node", "Node");
				//DRT_LINK_OBJECT("OOBE", "Node", "Node");
				break;
			case 6:
				//DRT_ACTOR_ATTACH_EFFECT("F_wizard_firepillar_shot_burstup", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_wizard_firepillar_shot_burstup", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_wizard_firepillar_shot_burstup", "BOT");
				break;
			case 9:
				character.AddonMessage("NOTICE_Dm_!", "A second seal device was summoned when you touched the seal!{nl}Destroy the secondary seal device!", 3);
				break;
			case 10:
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			case 11:
				Send.ZC_NORMAL.SetupCutscene(character, false, false, true);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
