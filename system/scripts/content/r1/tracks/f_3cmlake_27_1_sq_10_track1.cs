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

[TrackScript("F_3CMLAKE_27_1_SQ_10_TRACK1")]
public class F3CMLAKE271SQ10TRACK1 : TrackScript
{
	protected override void Load()
	{
		SetId("F_3CMLAKE_27_1_SQ_10_TRACK1");
		//SetMap("f_3cmlake_27_1");
		//CenterPos(-1360.43,46.66,602.99);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-1360.427f, 46.66467f, 602.9881f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 156133, "", "f_3cmlake_27_1", -1390.354, 46.66467, 546.5677, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 155163, "", "f_3cmlake_27_1", -1339.279, 46.66467, 602.3563, 2.5);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 59216, "", "f_3cmlake_27_1", -1530.247, 46.66467, 813.6913, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 59216, "", "f_3cmlake_27_1", -1466.655, 46.66467, 828.1531, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 59216, "", "f_3cmlake_27_1", -1742.051, 46.66467, 664.8421, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 59216, "", "f_3cmlake_27_1", -1732.559, 46.66467, 606.0461, 2.1875);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 59263, "", "f_3cmlake_27_1", -1660.797, 47.54378, 197.8522, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 59216, "", "f_3cmlake_27_1", -1706.502, 46.66467, 714.5226, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 59216, "", "f_3cmlake_27_1", -1396.865, 46.66467, 783.6005, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 155164, "", "f_3cmlake_27_1", -1695.824, 46.66467, 653.7502, 170);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 155165, "", "f_3cmlake_27_1", -1472.661, 46.66467, 771.4386, 24.23077);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 10:
				break;
			case 12:
				//DRT_ACTOR_PLAY_EFT("F_hit_good", "BOT", 0);
				break;
			case 25:
				//DRT_ACTOR_PLAY_EFT("F_hit_good", "BOT", 0);
				break;
			case 33:
				//DRT_ACTOR_PLAY_EFT("F_hit_good", "BOT", 0);
				break;
			case 38:
				//DRT_ACTOR_PLAY_EFT("F_hit_good", "BOT", 0);
				break;
			case 43:
				//DRT_ACTOR_PLAY_EFT("F_hit_good", "BOT", 0);
				break;
			case 48:
				//DRT_ACTOR_PLAY_EFT("F_hit_good", "MID", 0);
				break;
			case 65:
				//DRT_ACTOR_PLAY_EFT("F_hit_good", "BOT", 0);
				break;
			case 71:
				//DRT_ACTOR_PLAY_EFT("F_hit_good", "BOT", 0);
				break;
			case 83:
				break;
			case 129:
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
