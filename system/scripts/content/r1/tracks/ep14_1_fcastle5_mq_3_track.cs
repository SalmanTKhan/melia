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

[TrackScript("EP14_1_FCASTLE5_MQ_3_TRACK")]
public class EP141FCASTLE5MQ3TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP14_1_FCASTLE5_MQ_3_TRACK");
		//SetMap("ep14_1_f_castle_5");
		//CenterPos(1298.99,191.87,-1419.17);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(1298.995f, 191.8694f, -1419.175f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", 1282, 192.8653, -1403.002, 67.94118, "Our_Forces");
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.Level = 470;
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", 1249.539, 193.564, -1429.336, 63.23529, "Our_Forces");
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.Level = 470;
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", 1263.289, 193.564, -1345.884, 50.29412, "Our_Forces");
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.Level = 470;
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", 1227.893, 193.564, -1379.909, 68.23529, "Our_Forces");
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.Level = 470;
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", 1222.104, 193.564, -1298.838, 71.17647, "Our_Forces");
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.Level = 470;
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", 1189.489, 193.564, -1416.939, 62.64706, "Our_Forces");
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.Level = 470;
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", 1198.622, 193.564, -1321.488, 80.58823, "Our_Forces");
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.Level = 470;
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", 1313.255, 190.5508, -1363.949, 48.82353, "Our_Forces");
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.Level = 470;
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", 1315.533, 190.8699, -1452.215, 50.88235, "Our_Forces");
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.Level = 470;
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 150290, "", "ep14_1_f_castle_5", 1344.899, 187.5794, -1432.942, 62.05882, "Our_Forces");
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.Level = 470;
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 2:
				//DRT_SETPOS();
				break;
			case 18:
				//DRT_PLAY_MGAME("EP14_1_FCASTLE5_MQ_3_MGAME");
				CreateBattleBoxInLayer(character, track);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
