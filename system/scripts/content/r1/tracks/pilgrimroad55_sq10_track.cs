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

[TrackScript("PILGRIMROAD55_SQ10_TRACK")]
public class PILGRIMROAD55SQ10TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("PILGRIMROAD55_SQ10_TRACK");
		//SetMap("f_pilgrimroad_55");
		//CenterPos(-223.89,242.42,-425.16);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 155037, "", "f_pilgrimroad_55", -279.5936, 242.4188, -618.5714, 405);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 47252, "", "f_pilgrimroad_55", -317.52, 242.42, -614.92, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 57368, "", "f_pilgrimroad_55", -153.5941, 242.4188, -219.1591, 68.54166);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 57369, "", "f_pilgrimroad_55", -118.3015, 242.4188, -238.5364, 63.80953);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 57369, "", "f_pilgrimroad_55", -96.30762, 242.4188, -233.732, 73.91305);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 57369, "", "f_pilgrimroad_55", -120.1774, 242.4188, -769.6731, 40.90909);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 57369, "", "f_pilgrimroad_55", 6.352341, 242.4188, -551.7219, 87.72727);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 57368, "", "f_pilgrimroad_55", -138.841, 242.4188, -780.2805, 52.69231);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 57369, "", "f_pilgrimroad_55", -139.2001, 242.4188, -260.5564, 66.875);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 57368, "", "f_pilgrimroad_55", -138.8781, 242.4188, -767.9092, 38.88889);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		character.Movement.MoveTo(new Position(-228.0086f, 242.4188f, -458.4513f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 14:
				await track.Dialog.Msg("PILGRIMROAD55_SQ11_DLG01");
				break;
			case 15:
				break;
			case 16:
				break;
			case 18:
				break;
			case 20:
				await track.Dialog.Msg("PILGRIMROAD55_SQ11_DLG02");
				break;
			case 26:
				break;
			case 28:
				break;
			case 30:
				break;
			case 32:
				Send.ZC_NORMAL.SetupCutscene(character, false, false, true);
				//TRACK_MON_LOOKAT();
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
