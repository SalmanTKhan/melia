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

[TrackScript("CORAL_35_2_SQ_10_TRACK")]
public class CORAL352SQ10TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CORAL_35_2_SQ_10_TRACK");
		//SetMap("f_coral_35_2");
		//CenterPos(923.14,218.63,417.59);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(964.6285f, 218.6319f, 402.9591f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 156030, "", "f_coral_35_2", 856.8643, 218.6318, 412.7183, 73.33334);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 57344, "", "f_coral_35_2", 1118.887, 218.6318, 547.7529, 10.55556);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 17:
				break;
			case 24:
				character.AddonMessage("NOTICE_Dm_scroll", "An Orange Crabil suddenly appeared!", 4);
				break;
			case 25:
				await track.Dialog.Msg("CORAL_35_2_SQ_10_TRACK_1");
				break;
			case 47:
				//SetFixAnim("sit_loop");
				break;
			case 48:
				character.AddonMessage("NOTICE_Dm_scroll", "Defeat Orange Crabil and save Lutas!", 6);
				break;
			case 51:
				CreateBattleBoxInLayer(character, track);
				break;
			case 52:
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
