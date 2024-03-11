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

[TrackScript("EP12_2_F_CASTLE_101_MQ01_TRACK_01")]
public class EP122FCASTLE101MQ01TRACK01 : TrackScript
{
	protected override void Load()
	{
		SetId("EP12_2_F_CASTLE_101_MQ01_TRACK_01");
		//SetMap("f_castle_101");
		//CenterPos(362.86,281.08,-1592.86);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(370.5863f, 279.5571f, -1588.341f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 150230, "", "f_castle_101", -322.9788, 240.7855, -1564.817, 82.27273);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 150212, "", "f_castle_101", -303.4865, 240.7871, -1575.534, 115);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 59524, "", "f_castle_101", 169.2424, 240.7965, -1432.875, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 59524, "", "f_castle_101", 248.1278, 240.7964, -1452.488, 33.75);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 40120, "", "f_castle_101", 93.08417, 240.7966, -1390.875, 0);
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
			case 11:
				break;
			case 15:
				Send.ZC_NORMAL.Notice(character, "EP12_2_F_CASTLE_101_MQ01_DLG_4", 3);
				break;
			case 34:
				break;
			case 56:
				//DRT_ACTOR_PLAY_EFT("F_burstup002_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_burstup002_dark", "BOT", 0);
				break;
			case 65:
				//DRT_ACTOR_PLAY_EFT("F_burstup025_dark", "BOT", 0);
				break;
			case 69:
				//DRT_ACTOR_PLAY_EFT("F_burstup002_dark", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_burstup002_dark", "BOT", 0);
				break;
			case 79:
				Send.ZC_NORMAL.Notice(character, "EP12_2_F_DACPITAL_104_MQ01_DLG_05", 3);
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
