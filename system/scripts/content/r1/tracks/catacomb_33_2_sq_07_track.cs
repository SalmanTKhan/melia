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

[TrackScript("CATACOMB_33_2_SQ_07_TRACK")]
public class CATACOMB332SQ07TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CATACOMB_33_2_SQ_07_TRACK");
		//SetMap("id_catacomb_33_2");
		//CenterPos(735.18,221.36,1393.76);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(735.1752f, 221.3609f, 1393.757f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 155022, "", "id_catacomb_33_2", 742.1356, 232.323, 1327.106, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 156001, "", "id_catacomb_33_2", 731.0786, 230.5981, 970.8759, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 156000, "", "id_catacomb_33_2", 734.3176, 230.5981, 991.5888, 48.47826);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 58155, "", "id_catacomb_33_2", 724.0739, 230.5981, 923.0697, 43.27586);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 22:
				await track.Dialog.Msg("CATACOMB_33_2_TRACK");
				break;
			case 23:
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation005_dark_red", "MID");
				break;
			case 37:
				//DRT_ACTOR_ATTACH_EFFECT("F_pattern007_dark_loop", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup002_dark", "BOT");
				break;
			case 38:
				//DRT_SETRENDER(1);
				break;
			case 44:
				//DRT_ACTOR_ATTACH_EFFECT("I_boss_skl_pillarobb_dead_mash", "BOT");
				break;
			case 49:
				//TRACK_SETTENDENCY();
				break;
			case 50:
				CreateBattleBoxInLayer(character, track);
				break;
			case 51:
				character.AddonMessage("NOTICE_Dm_!", "Defeat Margiris!", 3);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
