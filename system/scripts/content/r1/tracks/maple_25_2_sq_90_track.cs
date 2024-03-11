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

[TrackScript("MAPLE_25_2_SQ_90_TRACK")]
public class MAPLE252SQ90TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("MAPLE_25_2_SQ_90_TRACK");
		//SetMap("f_maple_25_2");
		//CenterPos(-1360.43,-77.99,-673.92);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-1359.771f, -78.04153f, -675.7476f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 20166, "", "f_maple_25_2", -1788.396, -77.88174, -589.8846, 0.8333333);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 58543, "", "f_maple_25_2", -1782.017, -77.88174, -710.174, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 58543, "", "f_maple_25_2", -1685.536, -77.75797, -710.5444, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 58543, "", "f_maple_25_2", -1642.851, -78.6013, -643.3649, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 58543, "", "f_maple_25_2", -1660.63, -77.88232, -578.9348, 43);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 10045, "UnvisibleName", "f_maple_25_2", -1777.838, -77.88174, -601.4844, 3.5, "Neutral");
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
			case 22:
				//TRACK_MON_LOOKAT();
				break;
			case 23:
				//TRACK_SETTENDENCY();
				character.AddonMessage("NOTICE_Dm_scroll", "A girl is asking for help", 7);
				//DRT_PLAY_MGAME("MAPLE_25_2_SQ_90_MINI");
				break;
			case 24:
				Send.ZC_NORMAL.SetupCutscene(character, false, false, true);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
