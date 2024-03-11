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

[TrackScript("CHAPLE576_MQ_09_TRACK")]
public class CHAPLE576MQ09TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CHAPLE576_MQ_09_TRACK");
		//SetMap("d_chapel_57_6");
		//CenterPos(-568.07,10.97,463.35);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 147358, "", "d_chapel_57_6", -523, 12, 446, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 47502, "", "d_chapel_57_6", -525.0021, 0.4931, 304.4551, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 40069, "", "d_chapel_57_6", -837.164, 2.825836, 414.5916, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 40069, "", "d_chapel_57_6", -559.0444, 1.39051, 784.2073, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 40069, "", "d_chapel_57_6", -222.3654, 3.246766, 492.0119, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 40069, "", "d_chapel_57_6", -225.659, 3.246766, 362.2036, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 40069, "", "d_chapel_57_6", -492.7114, 0.01866195, 88.71492, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		character.Movement.MoveTo(new Position(-548.945f, 10.9683f, 440.2292f));
		actors.Add(character);

		var mob7 = Shortcuts.AddMonster(0, 40069, "", "d_chapel_57_6", -498.9435, 1.016025, 782.1996, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 40069, "", "d_chapel_57_6", -841.1947, 2.825837, 475.6265, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 40069, "", "d_chapel_57_6", -551.3807, 0.01866195, 91.59029, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 40069, "", "d_chapel_57_6", -225.9052, 3.246766, 422.1176, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 4:
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation008_alpha", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation008_alpha", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation008_alpha", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation008_alpha", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation008_alpha", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation008_alpha", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation008_alpha", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation008_alpha", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation008_alpha", "BOT");
				break;
			case 12:
				//TRACK_MON_LOOKAT();
				//TRACK_SETTENDENCY();
				CreateBattleBoxInLayer(character, track);
				break;
			case 16:
				break;
			case 28:
				character.AddonMessage("NOTICE_Dm_!", "You've been caught in Mallet Wyvern's trap!{nl}Defeat Mallet Wyvern!", 3);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
