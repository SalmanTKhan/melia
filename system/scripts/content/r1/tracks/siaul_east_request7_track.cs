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

[TrackScript("SIAUL_EAST_REQUEST7_TRACK")]
public class SIAULEASTREQUEST7TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("SIAUL_EAST_REQUEST7_TRACK");
		//SetMap("f_siauliai_2");
		//CenterPos(125.53,151.76,680.06);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 11284, "", "f_siauliai_2", 166.363, 151.7621, 695.2922, 30.58823, "Our_Forces");
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.Level = 9;
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 10020, "", "f_siauliai_2", 137.4328, 151.7621, 671.7213, 61.42857);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 10020, "", "f_siauliai_2", 198.5907, 151.7621, 669.9379, 55);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 20114, "Refugee", "f_siauliai_2", 645.2518, 130.0227, 320.4413, 76.03448);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 20117, "Refugee", "f_siauliai_2", 617.2451, 130.0227, 354.9748, 85.74074);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 20115, "Refugee", "f_siauliai_2", 585.3276, 130.0227, 334.7321, 77.96296);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 152000, "Refugee", "f_siauliai_2", 646.3181, 130.0227, 304.9361, 84.16666);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 57193, "", "f_siauliai_2", 549.1187, 162.4583, 709.6306, 44.09091);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 57192, "", "f_siauliai_2", 841.6129, 130.0327, 207.5484, 87.22222);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 57192, "", "f_siauliai_2", 787.4442, 130.0227, 260.2992, 72.91666);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 57193, "", "f_siauliai_2", 814.3585, 130.0327, 202.936, 61.04166);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 57192, "", "f_siauliai_2", 771.2297, 130.0327, 212.3454, 75);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 40120, "", "f_siauliai_2", 233, 157, 724, 0);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 57192, "", "f_siauliai_2", 579.2833, 162.4583, 679.7344, 59.375);
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		var mob14 = Shortcuts.AddMonster(0, 57192, "", "f_siauliai_2", 690.3392, 130.0227, 306.6019, 56.48148);
		mob14.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob14.AddEffect(new ScriptInvisibleEffect());
		mob14.Layer = character.Layer;
		actors.Add(mob14);

		character.Movement.MoveTo(new Position(164.4886f, 151.7621f, 678.0543f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 18:
				//InsertHate(999);
				//InsertHate(999);
				//InsertHate(999);
				//InsertHate(999);
				//InsertHate(999);
				//DRT_SETHOOKMSGOWNER(0, 0);
				//InsertHate(999);
				//InsertHate(999);
				break;
			case 19:
				break;
			case 20:
				break;
			case 21:
				//InsertHate(999);
				//InsertHate(999);
				//InsertHate(999);
				//InsertHate(999);
				//InsertHate(999);
				//InsertHate(999);
				//InsertHate(999);
				//DRT_SETHOOKMSGOWNER(0, 0);
				break;
			case 22:
				//InsertHate(999);
				//InsertHate(999);
				//InsertHate(999);
				//InsertHate(999);
				//DRT_SETHOOKMSGOWNER(0, 0);
				//InsertHate(999);
				//InsertHate(999);
				//InsertHate(999);
				break;
			case 23:
				break;
			case 25:
				break;
			case 43:
				//TRACK_SETTENDENCY();
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			case 49:
				//InsertHate(999);
				break;
			case 51:
				//InsertHate(999);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
