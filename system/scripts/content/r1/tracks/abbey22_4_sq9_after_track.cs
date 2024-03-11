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

[TrackScript("ABBEY22_4_SQ9_AFTER_TRACK")]
public class ABBEY224SQ9AFTERTRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ABBEY22_4_SQ9_AFTER_TRACK");
		//SetMap("d_abbey_22_4");
		//CenterPos(-673.96,89.24,153.42);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-673.9555f, 89.2355f, 153.4152f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 155045, "", "d_abbey_22_4", -651.72, 89.23, 180.22, 10);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 47261, "UnvisibleName", "d_abbey_22_4", -652.25, 89.23, 212.37, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 47124, "UnvisibleName", "d_abbey_22_4", -659.01, 89.23, 217.51, 0, "Neutral");
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 20025, "", "d_abbey_22_4", -653.4956, 89.2355, 195.9079, 15.83333);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 57840, "", "d_abbey_22_4", -650.7748, 89.2355, 106.8977, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 19:
				//DRT_ACTOR_ATTACH_EFFECT("I_force014_ice2", "MID");
				break;
			case 25:
				//DRT_ACTOR_PLAY_EFT("F_explosion078_dark", "BOT", 0);
				break;
			case 40:
				await track.Dialog.Msg("ABBEY22_5_SUBQ10_TRACK_DLG1");
				break;
			case 52:
				await track.Dialog.Msg("ABBEY22_5_SUBQ10_TRACK_DLG2");
				break;
			case 56:
				await track.Dialog.Msg("ABBEY22_5_SUBQ10_TRACK_DLG3");
				break;
			case 59:
				await track.Dialog.Msg("ABBEY22_5_SUBQ10_TRACK_DLG4");
				break;
			case 61:
				await track.Dialog.Msg("ABBEY22_5_SUBQ10_TRACK_DLG5");
				break;
			case 63:
				//DRT_ACTOR_PLAY_EFT("F_explosion098_dark_orange", "BOT", 0);
				break;
			case 67:
				character.AddonMessage("NOTICE_Dm_scroll", "Ask Agailla Flurry's illusion{nl}about future plans", 7);
				break;
			case 69:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
