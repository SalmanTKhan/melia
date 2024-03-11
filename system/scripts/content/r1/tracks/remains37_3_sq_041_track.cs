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

[TrackScript("REMAINS37_3_SQ_041_TRACK")]
public class REMAINS373SQ041TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("REMAINS37_3_SQ_041_TRACK");
		//SetMap("f_remains_37_3");
		//CenterPos(-1647.14,60.14,-1191.67);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var npc0 = Shortcuts.AddNpc(0, 152044, "UnvisibleName", "f_remains_37_3", -1747.981, 60.1406, -1022.559, 0);
		npc0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc0.AddEffect(new ScriptInvisibleEffect());
		npc0.Layer = character.Layer;
		actors.Add(npc0);

		var mob0 = Shortcuts.AddMonster(0, 155009, "UnvisibleName", "f_remains_37_3", -1750.32, 60.14, -1014.65, 1);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(-1793.131f, 60.1406f, -1226.625f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 3:
				break;
			case 9:
				//DRT_PLAY_MGAME("REMAINS37_3_SQ_041_MINI");
				break;
			case 10:
				Send.ZC_NORMAL.SetupCutscene(character, false, false, true);
				break;
			case 13:
				character.AddonMessage("NOTICE_Dm_!", "The monsters are attacking!{nl}Defeat the monsters!", 5);
				break;
			case 14:
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
