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

[TrackScript("DCAPITAL106_SQ_4_TRACK")]
public class DCAPITAL106SQ4TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("DCAPITAL106_SQ_4_TRACK");
		//SetMap("f_dcapital_106");
		//CenterPos(-700.24,0.22,-125.81);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-700.2375f, 0.2153931f, -125.8141f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 154015, "", "f_dcapital_106", -1187.495, 0.2153931, -164.0819, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 154012, "", "f_dcapital_106", -1141.636, 0.2153931, -153.8368, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 59096, "", "f_dcapital_106", -1456.041, 0.2153931, -128.3335, 73.33334);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 59096, "", "f_dcapital_106", -1442.269, 0.2153931, -206.3195, 80.55556);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 59100, "", "f_dcapital_106", -1384.668, 0.2153931, -317.8694, 40.45454);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 59096, "", "f_dcapital_106", -1335.726, 0.2153931, -377.751, 91.66667);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 59100, "", "f_dcapital_106", -1509.028, 0.2153931, -127.688, 72);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 59100, "", "f_dcapital_106", -1484.036, 0.2153931, -219.205, 76.11111);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 59096, "", "f_dcapital_106", -1348.086, 0.2153931, -314.0997, 64.44444);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 32:
				break;
			case 44:
				//TRACK_SETTENDENCY();
				character.AddonMessage("NOTICE_Dm_scroll", "Zsaia left the other Kupoles behind and ran away.{nl}Defeat the oncoming demons.", 7);
				CreateBattleBoxInLayer(character, track);
				break;
			case 45:
				//DRT_ACTOR_PLAY_EFT("F_lineup014_yellow", "BOT", 0);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
