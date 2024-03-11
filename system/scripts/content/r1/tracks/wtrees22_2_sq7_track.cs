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

[TrackScript("WTREES22_2_SQ7_TRACK")]
public class WTREES222SQ7TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("WTREES22_2_SQ7_TRACK");
		//SetMap("f_whitetrees_22_2");
		//CenterPos(-65.51,222.22,741.72);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-76.66025f, 220.5829f, 741.4708f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 103048, "", "f_whitetrees_22_2", 121.0735, 195.7253, 93.33621, 46.875);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 58847, "", "f_whitetrees_22_2", 88.03004, 209.2859, 155.5703, 85.55556);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 58847, "", "f_whitetrees_22_2", 162.9475, 199.7605, 127.9943, 89.31034);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 58847, "", "f_whitetrees_22_2", 42.03218, 213.3766, 190.5948, 87.03703);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 58847, "", "f_whitetrees_22_2", 62.87457, 213.3048, 178.4477, 83.88889);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 58844, "", "f_whitetrees_22_2", 125.1826, 199.1606, 111.0082, 145.625);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 58844, "", "f_whitetrees_22_2", 102.2025, 203.5797, 120.2344, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 58844, "", "f_whitetrees_22_2", 143.0762, 197.8592, 111.4434, 180.625);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 2:
				character.AddonMessage("NOTICE_Dm_scroll", "The effect of Sporgimo seems to be stronger than expected.", 3);
				break;
			case 10:
				break;
			case 58:
				character.AddonMessage("NOTICE_Dm_scroll", "Hauberk's chief hunter found you.{nl}Defeat him.", 5);
				break;
			case 59:
				//TRACK_SETTENDENCY();
				CreateBattleBoxInLayer(character, track);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
