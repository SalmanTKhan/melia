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

[TrackScript("THORN21_MQ06_TRACK")]
public class THORN21MQ06TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("THORN21_MQ06_TRACK");
		//SetMap("d_thorn_21");
		//CenterPos(1935.68,331.97,-11.11);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 46213, "", "d_thorn_21", 2003.165, 331.9713, -3.252419, 3.773585);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 20026, "", "d_thorn_21", 1972.521, 331.9714, -125.0075, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 20026, "", "d_thorn_21", 1853.924, 331.9714, 14.16351, 60.27778);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 20026, "", "d_thorn_21", 2081.859, 331.9714, 90.05106, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 20026, "", "d_thorn_21", 2010.817, 331.9713, 145.164, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 41242, "", "d_thorn_21", 2160.288, 331.9714, 148.2992, 0);
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
				//DRT_ACTOR_PLAY_EFT("F_smoke017_red", "BOT", 0);
				break;
			case 2:
				//DRT_ACTOR_PLAY_EFT("F_smoke017_red", "BOT", 0);
				break;
			case 3:
				//DRT_ACTOR_PLAY_EFT("F_smoke017_red", "BOT", 0);
				break;
			case 4:
				//DRT_ACTOR_PLAY_EFT("F_smoke017_red", "BOT", 0);
				break;
			case 17:
				//DRT_ACTOR_PLAY_EFT("F_ground011_yellow", "BOT", 0);
				break;
			case 18:
				//DRT_ACTOR_PLAY_EFT("F_explosion004_yellow", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion004_yellow", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion004_yellow", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_explosion004_yellow", "BOT", 0);
				break;
			case 28:
				break;
			case 31:
				character.AddonMessage("NOTICE_Dm_!", "Honeypin has suddenly appeared!", 3);
				break;
			case 34:
				//TRACK_SETTENDENCY();
				CreateBattleBoxInLayer(character, track);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
