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

[TrackScript("ABBEY22_5_SQ12_TRACK")]
public class ABBEY225SQ12TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ABBEY22_5_SQ12_TRACK");
		//SetMap("d_abbey_22_5");
		//CenterPos(1931.93,-33.07,843.11);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(1932.483f, -33.07492f, 844.4651f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 103051, "", "d_abbey_22_5", 1904.62, -33.07, 758.18, 6.666667);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 155045, "", "d_abbey_22_5", 1931.37, -33.07, 864.05, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 153188, "", "d_abbey_22_5", 1950.13, -33.07, 863.86, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 103051, "", "d_abbey_22_5", 1475.265, -54.76229, 825.9743, 102.2727);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 103051, "", "d_abbey_22_5", 1398.132, -67.66531, 775.9775, 110.4167);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 152078, "UnvisibleName", "d_abbey_22_5", 1985.593, -33.07492, 821.6328, 1.307692);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 1:
				character.AddonMessage("NOTICE_Dm_scroll", "Monk Aistis has begun to change the equipment", 3);
				break;
			case 29:
				await track.Dialog.Msg("ABBEY22_5_SUBQ12_DLG1");
				break;
			case 30:
				break;
			case 31:
				//DRT_ADDBUFF("HPLock", 100, 0, 0, 1);
				break;
			case 42:
				break;
			case 43:
				await track.Dialog.Msg("ABBEY22_5_SUBQ12_DLG2");
				//DRT_ADDBUFF("HPLock", 100, 0, 0, 1);
				break;
			case 45:
				await track.Dialog.Msg("ABBEY22_5_SUBQ12_DLG3");
				break;
			case 55:
				await track.Dialog.Msg("ABBEY22_5_SUBQ12_DLG4");
				break;
			case 57:
				await track.Dialog.Msg("ABBEY22_5_SUBQ12_DLG5");
				break;
			case 60:
				await track.Dialog.Msg("ABBEY22_5_SUBQ12_DLG6");
				break;
			case 61:
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation005_dark_red3##0.2", "BOT");
				break;
			case 66:
				await track.Dialog.Msg("ABBEY22_5_SUBQ12_DLG7");
				break;
			case 67:
				//TRACK_SETTENDENCY();
				break;
			case 68:
				CreateBattleBoxInLayer(character, track);
				character.AddonMessage("NOTICE_Dm_scroll", "Yse Agailla Flurry's equipment{nl}to attack the Hauberk", 3);
				break;
			case 69:
				CreateBattleBoxInLayer(character, track);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
