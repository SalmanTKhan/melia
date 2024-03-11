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

[TrackScript("BRACKEN43_1_SQ7_AFTER_TRACK")]
public class BRACKEN431SQ7AFTERTRACK : TrackScript
{
	protected override void Load()
	{
		SetId("BRACKEN43_1_SQ7_AFTER_TRACK");
		//SetMap("f_bracken_43_1");
		//CenterPos(-221.90,188.33,-591.38);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 147417, "", "f_bracken_43_1", -242.27, 188.33, -632.35, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 155097, "", "f_bracken_43_1", -195.37, 188.33, -565.39, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 155097, "", "f_bracken_43_1", -186.88, 188.33, -708.77, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 155097, "", "f_bracken_43_1", -294.67, 188.33, -628.22, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 155097, "", "f_bracken_43_1", -140.58, 188.33, -629.08, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 20024, "", "f_bracken_43_1", -358.8542, 188.3345, -465.4838, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 20024, "", "f_bracken_43_1", -386.0023, 188.3345, -550.9438, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 20024, "", "f_bracken_43_1", -373.6499, 188.3345, -555.0209, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 20024, "", "f_bracken_43_1", -379.4422, 188.3345, -490.2902, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 20024, "", "f_bracken_43_1", -358.5569, 188.3345, -545.3378, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 20024, "", "f_bracken_43_1", -364.0323, 188.3345, -520.4014, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 20024, "", "f_bracken_43_1", -382.544, 188.3345, -553.9772, 0);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 20025, "", "f_bracken_43_1", -383.5118, 188.3345, -506.8768, 0);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 155045, "", "f_bracken_43_1", -118.9174, 188.3345, -753.7863, 57.91666);
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 1:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force014_ice", "arrow_cast", "None", "arrow_blow", "SLOW", 50, 1, 0, 5, 10, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force014_ice", "arrow_cast", "None", "arrow_blow", "SLOW", 50, 1, 0, 5, 10, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force014_ice", "arrow_cast", "None", "arrow_blow", "SLOW", 50, 1, 0, 5, 10, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force014_ice", "arrow_cast", "None", "arrow_blow", "SLOW", 50, 1, 0, 5, 10, 0);
				break;
			case 2:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force014_ice", "arrow_cast", "None", "arrow_blow", "SLOW", 50, 1, 0, 5, 10, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force014_ice", "arrow_cast", "None", "arrow_blow", "SLOW", 50, 1, 0, 5, 10, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force014_ice", "arrow_cast", "None", "arrow_blow", "SLOW", 50, 1, 0, 5, 10, 0);
				//DRT_PLAY_FORCE(0, 1, 2, "I_force014_ice", "arrow_cast", "None", "arrow_blow", "SLOW", 50, 1, 0, 5, 10, 0);
				break;
			case 15:
				//DRT_ACTOR_PLAY_EFT("F_explosion069_blue", "BOT", 0);
				break;
			case 18:
				//DRT_ACTOR_PLAY_EFT("F_explosion069_blue", "BOT", 0);
				break;
			case 19:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
