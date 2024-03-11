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

[TrackScript("F_DCAPITAL_20_6_SQ_40_TRACK")]
public class FDCAPITAL206SQ40TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_DCAPITAL_20_6_SQ_40_TRACK");
		//SetMap("f_dcapital_20_6");
		//CenterPos(-1020.81,192.07,1587.95);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-1020.813f, 192.0675f, 1587.951f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 155136, "UnvisibleName", "f_dcapital_20_6", -1089.713, 192.0675, 1427.595, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 155136, "UnvisibleName", "f_dcapital_20_6", -943.2738, 192.0675, 1467.58, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 155137, "UnvisibleName", "f_dcapital_20_6", -968.4252, 192.0675, 1623.455, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 155137, "UnvisibleName", "f_dcapital_20_6", -917.7979, 243.6282, 1266.622, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 155137, "UnvisibleName", "f_dcapital_20_6", -710.7533, 197.2947, 1248.532, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 107012, "", "f_dcapital_20_6", -1018.044, 192.0675, 1606.729, 6.25, "Neutral");
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 20026, "", "f_dcapital_20_6", -1012.082, 300.7067, 1715.546, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 20026, "", "f_dcapital_20_6", -1025.1, 192.0675, 1611.913, 35);
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
				break;
			case 3:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke109", "MID");
				break;
			case 5:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke109", "MID");
				break;
			case 9:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground042_light", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke117", "BOT");
				break;
			case 25:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in023_blue", "BOT");
				break;
			case 37:
				//DRT_PLAY_MGAME("F_DCAPITAL_20_6_SQ_40_MINI");
				break;
			case 38:
				Send.ZC_NORMAL.SetupCutscene(character, false, false, true);
				character.AddonMessage("NOTICE_Dm_!", "You have lost Ausrine's mark because of the Dullahan's sudden attack", 7);
				break;
			case 39:
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
