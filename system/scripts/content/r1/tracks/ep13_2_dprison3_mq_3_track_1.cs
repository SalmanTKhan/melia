using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.Scripting;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.Effects;
using Melia.Zone.World.Tracks;
using Yggdrasil.Logging;

[TrackScript("EP13_2_DPRISON3_MQ_3_TRACK_1")]
public class EP132DPRISON3MQ3TRACK1 : TrackScript
{
	protected override void Load()
	{
		SetId("EP13_2_DPRISON3_MQ_3_TRACK_1");
		//SetMap("ep13_2_d_prison_3");
		//CenterPos(681.17,10.10,590.80);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(681.1716f, 10.10006f, 590.8002f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 59658, "", "ep13_2_d_prison_3", 439.9876, 10.10006, 859.1388, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 59664, "", "ep13_2_d_prison_3", 460.4434, 10.10006, 734.205, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 59664, "", "ep13_2_d_prison_3", 460.595, 10.10006, 978.0547, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 59664, "", "ep13_2_d_prison_3", 583.7553, 10.10006, 977.3845, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 59664, "", "ep13_2_d_prison_3", 579.0904, 10.10006, 723.7791, 0);
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
			case 15:
				//DRT_ACTOR_PLAY_EFT("F_only_quest_smoke015_green", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_only_quest_explosion052_green", "BOT", 0);
				break;
			case 19:
				await track.Dialog.Msg("EP13_2_DPRISON3_MQ_3_TRACK_DLG1");
				break;
			case 26:
				break;
			case 27:
				break;
			case 28:
				break;
			case 34:
				//TRACK_SETTENDENCY();
				CreateBattleBoxInLayer(character, track);
				//DRT_PLAY_MGAME("EP13_2_DPRISON3_MQ_3_MGAME_1");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
