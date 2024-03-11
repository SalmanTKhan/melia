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

[TrackScript("CASTLE65_2_MQ01_TRACK")]
public class CASTLE652MQ01TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CASTLE65_2_MQ01_TRACK");
		//SetMap("None");
		//CenterPos(1193.23,0.51,-262.25);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(1857.424f, 1.219482f, -154.0541f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 155095, "", "None", 1241.982, -10.51855, -269.3587, 87.22222);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 155096, "", "None", 1251.388, -10.51855, -210.0595, 2.205882);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 155113, "", "None", 1149.07, -10.52, -281.3, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 155094, "", "None", 1188.85, -10.52, -350.1, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 11282, "", "None", 1188.486, -10.51855, -156.0741, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 11282, "", "None", 1276.153, -10.51855, -173.7655, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 11283, "", "None", 1144.917, -10.51855, -161.9452, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 11283, "", "None", 1324.32, -10.51855, -245.4446, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 22:
				await track.Dialog.Msg("CASTLE652_MQ_01_track1");
				break;
			case 24:
				await track.Dialog.Msg("CASTLE652_MQ_01_track2");
				break;
			case 26:
				await track.Dialog.Msg("CASTLE652_MQ_01_track3");
				break;
			case 28:
				await track.Dialog.Msg("CASTLE652_MQ_01_track4");
				break;
			case 30:
				await track.Dialog.Msg("CASTLE652_MQ_01_track5");
				break;
			case 32:
				await track.Dialog.Msg("CASTLE652_MQ_01_track6");
				break;
			case 39:
				await track.Dialog.Msg("CASTLE652_MQ_01_track7");
				break;
			case 40:
				await track.Dialog.Msg("CASTLE652_MQ_01_track8");
				break;
			case 42:
				await track.Dialog.Msg("CASTLE652_MQ_01_track9");
				break;
			case 45:
				Send.ZC_NORMAL.SetupCutscene(character, false, false, true);
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
