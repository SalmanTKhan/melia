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

[TrackScript("REMAIN37_MQ07_TRACK")]
public class REMAIN37MQ07TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("REMAIN37_MQ07_TRACK");
		//SetMap("f_remains_37");
		//CenterPos(315.17,1426.84,2873.81);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 41350, "", "f_remains_37", 411.1193, 1426.839, 2867.587, 119.2857);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 47192, "", "f_remains_37", 433, 1427, 2880, 3.26087);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 20158, "", "f_remains_37", 317, 1427, 2902, 75.83333);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		character.Movement.MoveTo(new Position(315.1717f, 1426.839f, 2873.813f));
		actors.Add(character);

		var mob3 = Shortcuts.AddMonster(0, 20157, "", "f_remains_37", 303.8579, 1426.839, 2709.793, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 14:
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			case 24:
				break;
			case 25:
				//DRT_ACTOR_ATTACH_EFFECT("I_General_bear_dead_mash", "BOT");
				break;
			case 26:
				//TRACK_SETTENDENCY();
				break;
			case 29:
				character.AddonMessage("NOTICE_Dm_!", "Magburk killed epigraphist Schmid!{nl}Defeat Magburk!", 3);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
