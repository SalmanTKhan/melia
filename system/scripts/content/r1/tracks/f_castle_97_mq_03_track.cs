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

[TrackScript("F_CASTLE_97_MQ_03_TRACK")]
public class FCASTLE97MQ03TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_CASTLE_97_MQ_03_TRACK");
		//SetMap("f_castle_97");
		//CenterPos(1021.58,133.96,-843.07);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(1015.351f, 135.4341f, -837.9459f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 150210, "", "f_castle_97", 1434.896, 130.533, -703.3896, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 47257, "", "f_castle_97", 1278.572, 130.533, -892.9176, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 47258, "", "f_castle_97", 1342.536, 130.533, -828.6025, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 156168, "UnvisibleName", "f_castle_97", 1311.115, 130.533, -860.58, 210);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "f_castle_97", 1373.497, 130.533, -781.1184, 0);
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
			case 25:
				await track.Dialog.Msg("F_CASTLE_97_MQ_03_TRACK_DLG1");
				break;
			case 27:
				//DRT_ACTOR_PLAY_EFT("F_light139_2", "MID", 0);
				break;
			case 29:
				//DRT_ACTOR_PLAY_EFT("F_light139_2", "MID", 0);
				break;
			case 31:
				//DRT_ACTOR_PLAY_EFT("F_light139_2", "MID", 0);
				break;
			case 33:
				//DRT_ACTOR_PLAY_EFT("F_light139_2", "MID", 0);
				break;
			case 35:
				//DRT_ACTOR_PLAY_EFT("F_light139_2", "MID", 0);
				break;
			case 37:
				//DRT_ACTOR_PLAY_EFT("F_light139_3", "TOP", 0);
				break;
			case 39:
				//CREATE_BATTLE_BOX_INLAYER(0);
				//DRT_FUNC_ACT("SCR_F_CASTLE_97_MQ_03_START_RUN");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
