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

[TrackScript("SIAU11RE_MQ_05_TRACK")]
public class SIAU11REMQ05TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("SIAU11RE_MQ_05_TRACK");
		//SetMap("f_siauliai_11_re");
		//CenterPos(-347.24,85.14,1144.71);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-321.5363f, 125.9841f, 1229.54f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 155044, "", "f_siauliai_11_re", -521.9797, 146.4835, 1409.435, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 57997, "", "f_siauliai_11_re", -527.6658, 146.4835, 1467.915, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 41294, "", "f_siauliai_11_re", -500.7676, 146.4835, 1423.054, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 41294, "", "f_siauliai_11_re", -487.5873, 146.4835, 1502.24, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 41294, "", "f_siauliai_11_re", -576.0133, 146.4835, 1447.424, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 153041, "UnVisibleName", "f_siauliai_11_re", -649.8314, 146.4835, 1493.233, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var npc0 = Shortcuts.AddNpc(0, 46011, "UnVisibleName", "f_siauliai_11_re", -599.8804, 146.4835, 1493.826, 0);
		npc0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc0.AddEffect(new ScriptInvisibleEffect());
		npc0.Layer = character.Layer;
		actors.Add(npc0);

		var mob6 = Shortcuts.AddMonster(0, 147375, "UnVisibleName", "f_siauliai_11_re", -641.4741, 146.4835, 1569.292, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 147375, "UnVisibleName", "f_siauliai_11_re", -544.7236, 146.4835, 1575.421, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var npc1 = Shortcuts.AddNpc(0, 46212, "UnVisibleName", "f_siauliai_11_re", -574.8713, 146.4835, 1512.985, 0);
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
			case 31:
				break;
			case 32:
				break;
			case 35:
				//TRACK_SETTENDENCY();
				//CREATE_BATTLE_BOX_INLAYER(0);
				//TRACK_MON_LOOKAT();
				character.AddonMessage("NOTICE_Dm_!", "Defeat Specter Monarch and rescue Priest Pranas!", 3);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
