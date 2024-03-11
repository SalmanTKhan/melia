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

[TrackScript("PILGRIM41_4_SQ12_TRACK")]
public class PILGRIM414SQ12TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("PILGRIM41_4_SQ12_TRACK");
		//SetMap("f_pilgrimroad_41_4");
		//CenterPos(37.95,-105.37,-1201.44);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(41.42609f, -105.3662f, -1198.678f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 155045, "", "f_pilgrimroad_41_4", -24.22889, -79.90107, -1196.377, 89.16666);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 57986, "", "f_pilgrimroad_41_4", -42.31998, -75.44202, -1193.852, 83.33334);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 57986, "", "f_pilgrimroad_41_4", 209.4772, -105.3662, -1437.587, 57.5);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 57986, "", "f_pilgrimroad_41_4", 320.9173, -105.3662, -1123.816, 64.44444);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 155045, "", "f_pilgrimroad_41_4", 184.97, -105.37, -1247.47, 0);
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
			case 37:
				break;
			case 41:
				//DRT_ACTOR_PLAY_EFT("I_emo_exclamation", "TOP", 1);
				//DRT_ACTOR_PLAY_EFT("I_emo_exclamation", "TOP", 1);
				break;
			case 44:
				break;
			case 51:
				break;
			case 55:
				//SetFixAnim("event_sit_2");
				break;
			case 69:
				Send.ZC_NORMAL.SetupCutscene(character, false, false, true);
				//CREATE_BATTLE_BOX_INLAYER(-100);
				//DRT_SETHOOKMSGOWNER(1, 0);
				break;
			case 70:
				//DRT_RUN_FUNCTION("SCR_PILGRIM414_SQ_12_OWNER");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
