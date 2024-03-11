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

[TrackScript("SIAU15RE_MQ_05_TRACK")]
public class SIAU15REMQ05TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("SIAU15RE_MQ_05_TRACK");
		//SetMap("f_siauliai_15_re");
		//CenterPos(-2902.94,864.42,492.87);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-2895.101f, 850.4572f, 446.81f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 57995, "", "f_siauliai_15_re", -3007.42, 864.4171, 905.0195, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 147375, "UnvisibleName", "f_siauliai_15_re", -3079.445, 864.4171, 745.4936, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 147375, "UnvisibleName", "f_siauliai_15_re", -3010.628, 864.4171, 913.3397, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var npc0 = Shortcuts.AddNpc(0, 46011, "UnvisibleName", "f_siauliai_15_re", -2916.685, 864.4171, 812.6766, 0);
		npc0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc0.AddEffect(new ScriptInvisibleEffect());
		npc0.Layer = character.Layer;
		actors.Add(npc0);

		var mob3 = Shortcuts.AddMonster(0, 58009, "", "f_siauliai_15_re", -3030.816, 864.4171, 755.6855, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 147322, "UnvisibleName", "f_siauliai_15_re", -3040.68, 864.4171, 818.5499, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 58009, "", "f_siauliai_15_re", -3020.835, 864.4171, 796.2947, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 58009, "", "f_siauliai_15_re", -2967.59, 864.4171, 825.0274, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 58009, "", "f_siauliai_15_re", -3122.525, 864.4171, 859.4014, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 58010, "", "f_siauliai_15_re", -2937.015, 864.4171, 926.0873, 51.66666);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 58010, "", "f_siauliai_15_re", -3002.033, 864.4171, 881.4645, 31.66667);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 58010, "", "f_siauliai_15_re", -2908.422, 864.4171, 848.5433, 321.6667);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 147312, "", "f_siauliai_15_re", -3007.42, 864.42, 905.02, 0);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 8:
				break;
			case 19:
				break;
			case 45:
				//TRACK_SETTENDENCY();
				//TRACK_MON_LOOKAT();
				character.AddonMessage("NOTICE_Dm_scroll", "Something has fallen from the tent that the Minotaur had destroyed.{nl}Defeat Minotaur and check what has fallen down!", 5);
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
