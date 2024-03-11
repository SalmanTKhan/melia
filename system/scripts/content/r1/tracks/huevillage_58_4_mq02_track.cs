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

[TrackScript("HUEVILLAGE_58_4_MQ02_TRACK")]
public class HUEVILLAGE584MQ02TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("HUEVILLAGE_58_4_MQ02_TRACK");
		//SetMap("f_huevillage_58_4");
		//CenterPos(22.35986,5.71,-453.49);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 147385, "", "f_huevillage_58_4", 21.41992, 34.2, -186.01, 10);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 47321, "", "f_huevillage_58_4", -164.7324, 25.67221, -747.052, 994);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 147388, "", "f_huevillage_58_4", 107.0298, 34.2, -203.09, 55);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.Level = 42;
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 147387, "", "f_huevillage_58_4", -53.25977, 34.2, -201.09, 45);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.Level = 42;
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 47321, "", "f_huevillage_58_4", 44.73486, -5.666137, -519.1309, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		character.Movement.MoveTo(new Position(29.13477f, 34.2037f, -370.022f));
		actors.Add(character);

		var mob5 = Shortcuts.AddMonster(0, 155052, "UnVisibleName", "f_huevillage_58_4", 28.47998, 34.2, -188.4, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 47122, "", "f_huevillage_58_4", 21.2793, 34.20367, -183.1071, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 9:
				break;
			case 15:
				//DRT_ACTOR_ATTACH_EFFECT("I_sphere011_mash", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_sphere011_mash", "BOT");
				break;
			case 31:
				//DRT_ACTOR_ATTACH_EFFECT("I_sphere011_mash", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_sphere011_mash", "BOT");
				break;
			case 33:
				break;
			case 44:
				//TRACK_SETTENDENCY();
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
