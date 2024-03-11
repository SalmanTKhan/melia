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

[TrackScript("WHITETREES23_1_SQ11_TRACK")]
public class WHITETREES231SQ11TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("WHITETREES23_1_SQ11_TRACK");
		//SetMap("f_whitetrees_23_1");
		//CenterPos(-304.01,52.91,-990.44);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 58527, "에메트", "f_whitetrees_23_1", -495.96, 52.90842, -1107.831, 147.5);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 20026, "", "f_whitetrees_23_1", -819.7367, 52.90842, -1214.983, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		character.Movement.MoveTo(new Position(-304.0059f, 52.90842f, -990.4428f));
		actors.Add(character);

		var mob2 = Shortcuts.AddMonster(0, 58530, "Vilhelmas", "f_whitetrees_23_1", -230.9854, 52.90842, -1210.22, 0, "Our_Forces");
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.Level = 316;
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 4:
				//DRT_ACTOR_ATTACH_EFFECT("I_emo_exclamation", "TOP");
				//DRT_ACTOR_PLAY_EFT("I_stonedrop_mash_1", "BOT", 1);
				break;
			case 5:
				//DRT_ACTOR_PLAY_EFT("F_smoke132_dash", "BOT", 0);
				break;
			case 39:
				//DRT_RUN_FUNCTION("SCR_WHITETREES231_SQ_11_OWNER");
				break;
			case 40:
				Send.ZC_NORMAL.SetupCutscene(character, false, false, true);
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
