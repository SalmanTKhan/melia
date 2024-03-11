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

[TrackScript("CATACOMB_02_SQ_07_TRACK")]
public class CATACOMB02SQ07TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CATACOMB_02_SQ_07_TRACK");
		//SetMap("id_catacomb_02");
		//CenterPos(-812.60,278.97,1278.90);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 57631, "", "id_catacomb_02", -834, 279, 1159, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 151056, "", "id_catacomb_02", -876, 279, 1321, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 147449, "제인", "id_catacomb_02", -697, 279, 1275, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		character.Movement.MoveTo(new Position(-727.3354f, 278.9725f, 1188.531f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 11:
				//DRT_ACTOR_ATTACH_EFFECT("I_chain_dead_mash", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_ground038", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion004_yellow2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup001_yellow", "BOT");
				break;
			case 12:
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion004_yellow2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup001_yellow", "BOT");
				break;
			case 18:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup001_smoke1", "BOT");
				break;
			case 28:
				//DRT_ACTOR_ATTACH_EFFECT("I_magic_prison_mash", "BOT");
				break;
			case 30:
				character.AddonMessage("NOTICE_Dm_!", "Archon has been released and abducted Jane!{nl}Defeat Archon and save Jane!", 5);
				break;
			case 31:
				//DRT_ACTOR_ATTACH_EFFECT("F_spin023", "MID");
				//SetFixAnim("event_uploop");
				break;
			case 39:
				//TRACK_SETTENDENCY();
				Send.ZC_NORMAL.SetupCutscene(character, false, false, true);
				CreateBattleBoxInLayer(character, track);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
