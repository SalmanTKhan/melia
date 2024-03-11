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

[TrackScript("TABLELAND_70_SQ4_AFTER_TRACK")]
public class TABLELAND70SQ4AFTERTRACK : TrackScript
{
	protected override void Load()
	{
		SetId("TABLELAND_70_SQ4_AFTER_TRACK");
		//SetMap("f_tableland_70");
		//CenterPos(3268.15,561.63,-2197.60);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 103037, "", "f_tableland_70", 3311.912, 561.6254, -2134.484, 33.33333, "Neutral");
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 10032, "", "f_tableland_70", 3374.57, 561.62, -2192.14, 111.0714);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 10032, "", "f_tableland_70", 3345.66, 561.62, -2283.89, 30.45454);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 10032, "", "f_tableland_70", 3364.43, 561.62, -2241.86, 33.86364);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 10032, "", "f_tableland_70", 3245.98, 561.62, -2310.08, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 10032, "", "f_tableland_70", 3283.02, 561.62, -2308.61, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 10032, "", "f_tableland_70", 3319.35, 561.62, -2317.15, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		character.Movement.MoveTo(new Position(3280.469f, 561.6254f, -2200.149f));
		actors.Add(character);

		var mob7 = Shortcuts.AddMonster(0, 10032, "", "f_tableland_70", 3265.99, 561.62, -2346.22, 0);
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
			case 1:
				await track.Dialog.Msg("TABLELAND70_SUBQ04_TRAKC_DLG4");
				//DRT_ACTOR_PLAY_EFT("I_emo_exclamation", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("I_emo_exclamation", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("I_emo_exclamation", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("I_emo_exclamation", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("I_emo_exclamation", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("I_emo_exclamation", "MID", 0);
				//DRT_ACTOR_PLAY_EFT("I_emo_exclamation", "MID", 0);
				break;
			case 12:
				await track.Dialog.Msg("TABLELAND70_SUBQ04_TRAKC_DLG1");
				break;
			case 25:
				await track.Dialog.Msg("TABLELAND70_SUBQ04_TRAKC_DLG2");
				break;
			case 28:
				await track.Dialog.Msg("TABLELAND70_SUBQ04_TRAKC_DLG3");
				break;
			case 49:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
