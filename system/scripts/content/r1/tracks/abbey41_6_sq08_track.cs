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

[TrackScript("ABBEY41_6_SQ08_TRACK")]
public class ABBEY416SQ08TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ABBEY41_6_SQ08_TRACK");
		//SetMap("d_abbey_41_6");
		//CenterPos(913.08,52.41,170.82);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(922.3671f, 52.80945f, 160.9694f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 155126, "", "d_abbey_41_6", 949.29, 53.31, 172.79, 25);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 155043, "데이만타스", "d_abbey_41_6", 1419.971, -9.433147, 550.8053, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 58429, "", "d_abbey_41_6", 1419.97, -9.43, 550.81, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.Level = 280;
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 20045, "", "d_abbey_41_6", 1001.567, 45.87729, 798.9521, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 20049, "", "d_abbey_41_6", 975.94, 53.47, 182.4, 2.877095);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 155097, "", "d_abbey_41_6", 962.9027, 53.56498, 181.5995, 5);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 20026, "", "d_abbey_41_6", 1439.57, -9.433143, 447.1805, 2.686567);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 20026, "", "d_abbey_41_6", 1429.743, -9.433131, 539.2029, 0);
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
			case 5:
				//DRT_ACTOR_PLAY_EFT("F_light073_yellow", "BOT", 1);
				break;
			case 6:
				break;
			case 10:
				//DRT_ACTOR_PLAY_EFT("F_light073_yellow", "BOT", 1);
				break;
			case 15:
				//DRT_ACTOR_PLAY_EFT("F_light073_yellow", "BOT", 1);
				break;
			case 57:
				await track.Dialog.Msg("ABBEY416_SQ_08_track1");
				break;
			case 59:
				await track.Dialog.Msg("ABBEY416_SQ_08_track2");
				break;
			case 61:
				await track.Dialog.Msg("ABBEY416_SQ_08_track3");
				break;
			case 62:
				//DRT_ACTOR_ATTACH_EFFECT("F_light059_2", "BOT");
				break;
			case 63:
				//DRT_ACTOR_ATTACH_EFFECT("F_light059_2", "BOT");
				break;
			case 69:
				break;
			case 70:
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation005_dark_blue", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation005_dark_blue", "BOT");
				break;
			case 76:
				character.AddonMessage("NOTICE_Dm_!", "Deymantas turned into a Blue Riteris.{nl}Defeat it.", 3);
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion004_blue", "BOT");
				break;
			case 85:
				CreateBattleBoxInLayer(character, track);
				//TRACK_SETTENDENCY();
				Send.ZC_NORMAL.SetupCutscene(character, false, false, true);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
