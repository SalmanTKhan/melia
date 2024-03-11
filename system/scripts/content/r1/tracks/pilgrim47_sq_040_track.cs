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

[TrackScript("PILGRIM47_SQ_040_TRACK")]
public class PILGRIM47SQ040TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("PILGRIM47_SQ_040_TRACK");
		//SetMap("None");
		//CenterPos(231.00,44.52,1487.54);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 57297, "", "None", 224.8, 44.52, 1481.55, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 155031, "", "None", 224.8, 44.51, 1481.55, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 20026, "UnvisibleName", "None", 248.7583, 44.5154, 1348.362, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 20026, "UnvisibleName", "None", 315.4416, 44.5154, 1334.972, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		character.Movement.MoveTo(new Position(240.4424f, 44.51549f, 1448.424f));
		actors.Add(character);

		var mob4 = Shortcuts.AddMonster(0, 20026, "UnvisibleName", "None", 162.247, 44.51543, 1447.844, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 20026, "UnvisibleName", "None", 308.8565, 44.51545, 1444.937, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 20026, "UnvisibleName", "None", 315.8317, 44.5154, 1254.078, 0);
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
			case 3:
				break;
			case 4:
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion074_violet", "BOT");
				break;
			case 8:
				//DRT_PLAY_MGAME("PILGRIM47_SQ_040_MINI");
				break;
			case 9:
				character.AddonMessage("NOTICE_Dm_!", "The transformed Tree Root Crystal has turned into a Cactusvel!", 5);
				break;
			case 24:
				//CREATE_BATTLE_BOX_INLAYER(-50);
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
