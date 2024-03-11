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

[TrackScript("PARTY_Q_040_TRACK")]
public class PARTYQ040TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("PARTY_Q_040_TRACK");
		//SetMap("f_huevillage_58_1");
		//CenterPos(356.17,371.33,-574.07);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 10032, "UnvisibleName", "f_huevillage_58_1", 171.5699, 338.4878, -518.6178, 0, "Our_Forces");
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 10032, "UnvisibleName", "f_huevillage_58_1", 403.7723, 371.3148, -686.3214, 0, "Our_Forces");
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 10032, "UnvisibleName", "f_huevillage_58_1", 326.1083, 371.2776, -472.2592, 0, "Our_Forces");
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 10032, "UnvisibleName", "f_huevillage_58_1", 455.5787, 371.3148, -488.7049, 0, "Our_Forces");
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 155022, "Klaipeda", "f_huevillage_58_1", 259.6478, 371.8764, -656.0121, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 10032, "UnvisibleName", "f_huevillage_58_1", 593.9943, 371.3148, -655.3801, 0, "Our_Forces");
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 10032, "UnvisibleName", "f_huevillage_58_1", 587.7311, 371.3148, -540.9464, 0, "Our_Forces");
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 20016, "UnvisibleName", "f_huevillage_58_1", 235.4543, 364.5525, -613.5458, 0, "Neutral");
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 20019, "UnvisibleName", "f_huevillage_58_1", 290.735, 371.3661, -647.6323, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 40120, "", "f_huevillage_58_1", 217.9, 371.31, -916.16, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 1:
				//DRT_PLAY_MGAME("PARTY_Q_040_MINI");
				break;
			case 8:
				//TRACK_SETTENDENCY();
				break;
			case 9:
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
