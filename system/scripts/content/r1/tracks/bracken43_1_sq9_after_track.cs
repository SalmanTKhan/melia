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

[TrackScript("BRACKEN43_1_SQ9_AFTER_TRACK")]
public class BRACKEN431SQ9AFTERTRACK : TrackScript
{
	protected override void Load()
	{
		SetId("BRACKEN43_1_SQ9_AFTER_TRACK");
		//SetMap("f_bracken_43_1");
		//CenterPos(-196.84,188.33,-658.62);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 155045, "", "f_bracken_43_1", -182.04, 188.33, -629.05, 880);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(-5.686497f, 188.3345f, -611.8261f));
		actors.Add(character);

		var mob1 = Shortcuts.AddMonster(0, 147417, "", "f_bracken_43_1", -242.27, 188.33, -632.35, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 155097, "신성력이", "f_bracken_43_1", -195.37, 188.33, -565.39, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 155097, "신성력이", "f_bracken_43_1", -186.88, 188.33, -708.77, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 155097, "신성력이", "f_bracken_43_1", -294.67, 188.33, -628.22, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 155097, "신성력이", "f_bracken_43_1", -140.58, 188.33, -629.08, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 20025, "", "f_bracken_43_1", -213.08, 188.33, -631.72, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 156036, "", "f_bracken_43_1", -213.08, 188.33, -631.72, 0);
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
			case 4:
				//DRT_ACTOR_PLAY_EFT("F_light009", "MID", 0);
				break;
			case 5:
				//DRT_ACTOR_ATTACH_EFFECT("F_light078_holy_yellow_loop", "BOT");
				break;
			case 10:
				await track.Dialog.Msg("BRACKEN431_SUBQ9_TRACK_DLG");
				break;
			case 18:
				//DRT_ACTOR_PLAY_EFT("F_smoke142_yellow", "BOT", 0);
				break;
			case 21:
				character.AddonMessage("NOTICE_Dm_Clear", "Vaivora Koru has disappeared", 0);
				break;
			case 24:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
