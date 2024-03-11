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

[TrackScript("TABLELAND_74_SQ5_TRACK")]
public class TABLELAND74SQ5TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("TABLELAND_74_SQ5_TRACK");
		//SetMap("f_tableland_74");
		//CenterPos(932.19,720.48,1223.81);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 151000, "UnvisibleName", "f_tableland_74", 1236.56, 712.5, 1284.1, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 10032, "", "f_tableland_74", 804.0566, 782.7722, 1241.717, 59.16666);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		character.Movement.MoveTo(new Position(984.1698f, 712.5023f, 1217.075f));
		actors.Add(character);

		var mob2 = Shortcuts.AddMonster(0, 57979, "", "f_tableland_74", 1326.642, 712.5023, 1291.358, 39.28571);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 57904, "", "f_tableland_74", 1244.73, 712.5023, 1377.172, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 57904, "", "f_tableland_74", 1180.669, 712.5023, 1201.42, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 57904, "", "f_tableland_74", 1246.29, 712.5023, 1174.419, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 57904, "", "f_tableland_74", 1152.314, 712.5023, 1318.115, 15);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 57904, "", "f_tableland_74", 1313.695, 712.5023, 1206.685, 24);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 57904, "", "f_tableland_74", 1312.524, 712.5023, 1367.179, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 40095, "", "f_tableland_74", 1250.414, 712.5023, 1264.201, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 1:
				//DRT_ACTOR_PLAY_EFT("F_levitation032_red", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("F_ground068_smoke", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_ground068_smoke", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_ground068_smoke", "BOT");
				break;
			case 2:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground068_smoke", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_ground068_smoke", "BOT");
				break;
			case 3:
				//InsertHate(999);
				//DRT_ACTOR_ATTACH_EFFECT("F_ground068_smoke", "BOT");
				break;
			case 4:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground079_smoke", "BOT");
				break;
			case 8:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground083_smoke", "BOT");
				break;
			case 16:
				CreateBattleBoxInLayer(character, track);
				//TRACK_SETTENDENCY();
				break;
			case 17:
				Send.ZC_NORMAL.SetupCutscene(character, false, false, true);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
