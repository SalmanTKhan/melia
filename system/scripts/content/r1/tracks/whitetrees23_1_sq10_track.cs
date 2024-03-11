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

[TrackScript("WHITETREES23_1_SQ10_TRACK")]
public class WHITETREES231SQ10TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("WHITETREES23_1_SQ10_TRACK");
		//SetMap("f_whitetrees_23_1");
		//CenterPos(-868.07,-53.22,-145.07);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-859.9175f, -53.21634f, -136.9643f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 47202, "UnVisibleName", "f_whitetrees_23_1", -940.31, -53.22, -23.04, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 47202, "UnVisibleName", "f_whitetrees_23_1", -925.11, -53.22, -109.29, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 47202, "UnVisibleName", "f_whitetrees_23_1", -841.45, -53.22, -134.15, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 58527, "에메트", "f_whitetrees_23_1", -1397.176, -53.21634, -158.1, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 155142, "Vilhelmas", "f_whitetrees_23_1", -998.798, 77.77127, 239.7716, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 20026, "", "f_whitetrees_23_1", -1074.104, -53.21634, 12.56924, 8);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 155142, "Vilhelmas", "f_whitetrees_23_1", -754.8536, -105.9465, 65.0201, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 32:
				//DRT_ACTOR_ATTACH_EFFECT("I_emo_exclamation", "TOP");
				break;
			case 61:
				//DRT_ACTOR_PLAY_EFT("I_archer_JumpShot_hit1", "BOT", 1);
				break;
			case 62:
				//DRT_ACTOR_PLAY_EFT("I_emo_exclamation", "TOP", 1);
				break;
			case 83:
				await track.Dialog.Msg("WHITETREES231_SQ_10_track1");
				break;
			case 90:
				//TRACK_BASICLAYER_MOVE();
				Send.ZC_NORMAL.SetupCutscene(character, false, false, true);
				character.AddonMessage("NOTICE_Dm_scroll", "The beast has run!{nl}Follow Vilhelmas who is going after the beast!", 5);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
