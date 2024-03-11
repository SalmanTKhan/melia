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

[TrackScript("UNDERFORTRESS_66_MQ010_TRACK")]
public class UNDERFORTRESS66MQ010TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("UNDERFORTRESS_66_MQ010_TRACK");
		//SetMap("d_underfortress_66");
		//CenterPos(1272.97,136.59,-215.88);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 153040, "", "d_underfortress_66", 1250.972, 136.5897, -205.1971, 70);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 10033, "Royal Army", "d_underfortress_66", 1037.039, 136.5897, -60.02801, 51.25, "Our_Forces");
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 10033, "", "d_underfortress_66", 1036.249, 136.5897, -86.97742, 63.5);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 10033, "", "d_underfortress_66", 1056.488, 136.5897, -35.00661, 53.75);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 57956, "", "d_underfortress_66", 926.1071, 136.5897, -44.75771, 66.92308);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 57956, "", "d_underfortress_66", 792.1262, 136.5897, -63.28071, 87.75);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 57956, "", "d_underfortress_66", 911.4568, 136.5897, -78.32979, 93.75);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		character.Movement.MoveTo(new Position(1291.368f, 136.5897f, -200.8638f));
		actors.Add(character);

		var mob7 = Shortcuts.AddMonster(0, 57956, "", "d_underfortress_66", 864.2336, 136.5897, -96.21368, 65);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 57956, "", "d_underfortress_66", 890.9357, 136.5897, -39.66054, 60.52632);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 12:
				await track.Dialog.Msg("UNDER66_MQ010_TRACK_DIALOG01");
				break;
			case 13:
				//DRT_SETHOOKMSGOWNER(0, 1);
				//DRT_SETHOOKMSGOWNER(0, 1);
				//DRT_SETHOOKMSGOWNER(0, 1);
				break;
			case 14:
				break;
			case 16:
				break;
			case 18:
				break;
			case 37:
				character.AddonMessage("NOTICE_Dm_!", "The Royal Army guards are being chased by the monsters! It's better to save them for now.", 4);
				break;
			case 39:
				CreateBattleBoxInLayer(character, track);
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
