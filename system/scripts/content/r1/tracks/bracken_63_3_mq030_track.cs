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

[TrackScript("BRACKEN_63_3_MQ030_TRACK")]
public class BRACKEN633MQ030TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("BRACKEN_63_3_MQ030_TRACK");
		//SetMap("f_bracken_63_3");
		//CenterPos(370.85,189.32,101.42);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 153119, "", "f_bracken_63_3", 49.8458, 189.5829, 489.813, 13.7069);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 153120, "", "f_bracken_63_3", -32.52414, 189.5829, 445.9684, 85);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 103024, "", "f_bracken_63_3", 119.8212, 187.872, 479.7784, 6.875);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 103024, "", "f_bracken_63_3", 97.38564, 188.4732, 419.1493, 5.357143);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 103024, "", "f_bracken_63_3", 45.29771, 189.5829, 373.9808, 14.13043);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 103024, "", "f_bracken_63_3", -16.44249, 189.5829, 398.5644, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 40095, "UnvisibleName", "f_bracken_63_3", -77.5948, 189.5829, 393.3543, 8.947369);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		character.Movement.MoveTo(new Position(336.0921f, 189.3179f, 119.9228f));
		actors.Add(character);

		var mob7 = Shortcuts.AddMonster(0, 153115, "", "f_bracken_63_3", -70, 189.58, 591, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 20046, "", "f_bracken_63_3", -57.94, 189.58, 477.32, 0);
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
			case 2:
				//DRT_ACTOR_PLAY_EFT("F_light081_ground_orange2", "BOT", 0);
				break;
			case 4:
				//DRT_ACTOR_PLAY_EFT("F_smoke019_dark", "BOT", 0);
				break;
			case 5:
				//DRT_ACTOR_PLAY_EFT("F_pattern008_violet", "BOT", 0);
				break;
			case 7:
				//DRT_ACTOR_PLAY_EFT("F_light081_ground_orange2", "BOT", 0);
				break;
			case 12:
				//DRT_ACTOR_PLAY_EFT("F_light081_ground_orange2", "BOT", 0);
				break;
			case 47:
				//DRT_PLAY_MGAME("BRACKEN_63_3_MQ030");
				break;
			case 49:
				CreateBattleBoxInLayer(character, track);
				//TRACK_SETTENDENCY();
				character.AddonMessage("NOTICE_Dm_!", "The demons are trying to kidnap Rose!{nl}Rescue Rose from the demons!", 5);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
