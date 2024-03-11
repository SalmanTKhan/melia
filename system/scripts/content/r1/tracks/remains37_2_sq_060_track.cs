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

[TrackScript("REMAINS37_2_SQ_060_TRACK")]
public class REMAINS372SQ060TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("REMAINS37_2_SQ_060_TRACK");
		//SetMap("f_remains_37_2");
		//CenterPos(-1651.33,154.67,1001.89);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 57627, "", "f_remains_37_2", -1656.786, 154.6744, 1007.319, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 57627, "", "f_remains_37_2", -1619.116, 154.6744, 1104.809, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var npc0 = Shortcuts.AddNpc(0, 152041, "UnvisibleName", "f_remains_37_2", -1740, 153, 1073, 0);
		npc0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc0.AddEffect(new ScriptInvisibleEffect());
		npc0.Layer = character.Layer;
		actors.Add(npc0);

		character.Movement.MoveTo(new Position(-1691.97f, 154.6744f, 1060.063f));
		actors.Add(character);

		var npc1 = Shortcuts.AddNpc(0, 152032, "UnvisibleName", "f_remains_37_2", -1739.88, 154.6744, 1073.796, 35);
		npc1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc1.AddEffect(new ScriptInvisibleEffect());
		npc1.Layer = character.Layer;
		actors.Add(npc1);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case -1:
				break;
			case 5:
				break;
			case 7:
				break;
			case 12:
				//DRT_PLAY_MGAME("REMAINS37_2_SQ_060_MINI");
				break;
			case 13:
				character.AddonMessage("NOTICE_Dm_!", "The monsters are rushing in after smelling the oil burning!{nl}Defeat all the monsters!", 5);
				break;
			case 14:
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
