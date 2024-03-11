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

[TrackScript("CORAL_35_2_SQ_9_TRACK")]
public class CORAL352SQ9TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CORAL_35_2_SQ_9_TRACK");
		//SetMap("f_coral_35_2");
		//CenterPos(-575.65,96.05,72.50);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 156030, "", "f_coral_35_2", -609.4499, 96.05452, 49.47049, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 46217, "UnvisibleName", "f_coral_35_2", -661.808, 96.05453, 95.87244, 0, "Neutral");
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		character.Movement.MoveTo(new Position(-590.8458f, 96.05452f, 65.06113f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 7:
				await track.Dialog.Msg("CORAL_35_2_SQ_9_TRACK_1");
				break;
			case 9:
				character.AddonMessage("NOTICE_Dm_scroll", "Protect Lutas until the magic circle is completed!", 6);
				break;
			case 13:
				//DRT_ACTOR_PLAY_EFT("F_pattern015_white", "BOT", 0);
				break;
			case 16:
				//DRT_ACTOR_ATTACH_EFFECT("F_pattern015_white_loop", "BOT");
				break;
			case 18:
				CreateBattleBoxInLayer(character, track);
				break;
			case 19:
				//DRT_PLAY_MGAME("CORAL_35_2_SQ_9_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
