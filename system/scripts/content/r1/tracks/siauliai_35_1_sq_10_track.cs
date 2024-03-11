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

[TrackScript("SIAULIAI_35_1_SQ_10_TRACK")]
public class SIAULIAI351SQ10TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("SIAULIAI_35_1_SQ_10_TRACK");
		//SetMap("f_siauliai_35_1");
		//CenterPos(24.81,-141.01,194.00);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 58427, "", "f_siauliai_35_1", -116.2686, -135.178, 4.971889, 585);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 156024, "", "f_siauliai_35_1", -70.84276, -135.178, -13.81282, 68.75);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		character.Movement.MoveTo(new Position(21.21373f, -139.8925f, 185.3917f));
		actors.Add(character);

		var npc0 = Shortcuts.AddNpc(0, 10045, "UnvisibleName", "f_siauliai_35_1", -210.3173, -135.178, -85.46375, 0);
		npc0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc0.AddEffect(new ScriptInvisibleEffect());
		npc0.Layer = character.Layer;
		actors.Add(npc0);

		var mob2 = Shortcuts.AddMonster(0, 20025, "UnvisibleName", "f_siauliai_35_1", -100.9148, -135.178, 6.655804, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 20025, "UnvisibleName", "f_siauliai_35_1", -109.8473, -135.178, 2.343723, 0);
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
			case 6:
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation032_red", "BOT");
				break;
			case 17:
				//DRT_ACTOR_ATTACH_EFFECT("F_cleric_resurrection_ground", "BOT");
				break;
			case 18:
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion004_yellow", "BOT");
				break;
			case 19:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke008", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_cleric_MassHeal_spread_out", "BOT");
				break;
			case 21:
				character.AddonMessage("NOTICE_Dm_scroll", "Carnivore seems to be suffering from the Vaidotas' Neutralizer you've sprayed.{nl}Defeat Carnivore and save Lucienne!", 8);
				break;
			case 35:
				CreateBattleBoxInLayer(character, track);
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
