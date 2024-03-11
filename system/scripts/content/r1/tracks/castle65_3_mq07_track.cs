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

[TrackScript("CASTLE65_3_MQ07_TRACK")]
public class CASTLE653MQ07TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CASTLE65_3_MQ07_TRACK");
		//SetMap("f_castle_65_3");
		//CenterPos(878.26,0.75,-1366.35);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(878.2566f, 0.7454834f, -1366.346f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 155094, "", "f_castle_65_3", 901.4535, 0.7454834, -1327.671, 90, "Our_Forces");
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.Level = 100;
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 47255, "UnVisibleName", "f_castle_65_3", 590.1978, 0.7454834, -697.6559, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 147379, "UnVisibleName", "f_castle_65_3", 1197.16, 2.61, -1555.22, 2.459016);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 47241, "UnVisibleName", "f_castle_65_3", 550.59, 0.74, -1049.98, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 47241, "UnVisibleName", "f_castle_65_3", 587.1, 0.75, -1283.4, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 47241, "UnVisibleName", "f_castle_65_3", 583.46, 0.75, -1219.16, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 47241, "UnVisibleName", "f_castle_65_3", 615.2752, 0.7454834, -1138.313, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 147374, "", "f_castle_65_3", 575.41, 0.75, -1161.79, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 47255, "", "f_castle_65_3", 142.3607, 0.7454834, -1084.263, 0);
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
			case 5:
				//DRT_ACTOR_PLAY_EFT("I_emo_exclamation", "TOP", 1);
				break;
			case 6:
				//DRT_ACTOR_PLAY_EFT("I_emo_exclamation", "TOP", 1);
				break;
			case 12:
				break;
			case 13:
				//DRT_ACTOR_PLAY_EFT("F_explosion042_smoke", "BOT", 1);
				break;
			case 17:
				break;
			case 18:
				//DRT_ACTOR_PLAY_EFT("F_burstup007_smoke2", "BOT", 1);
				break;
			case 26:
				await track.Dialog.Msg("CASTLE653_MQ_07_track1");
				break;
			case 48:
				await track.Dialog.Msg("CASTLE653_MQ_07_track2");
				break;
			case 67:
				//DRT_PLAY_MGAME("CASTLE65_3_MQ07_MINI");
				CreateBattleBoxInLayer(character, track);
				Send.ZC_NORMAL.SetupCutscene(character, false, false, true);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
