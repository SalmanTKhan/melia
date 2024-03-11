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

[TrackScript("MINE_1_CRYSTAL_10_TRACK")]
public class MINE1CRYSTAL10TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("MINE_1_CRYSTAL_10_TRACK");
		//SetMap("d_cmine_01");
		//CenterPos(791.78,16.03,74.34);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(797.8787f, 14.92619f, 72.46992f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 11125, "", "d_cmine_01", 1047.965, 3.5999, 79.24179, 58);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 11125, "", "d_cmine_01", 1122.538, 3.599945, 94.29276, 63.75);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 11125, "", "d_cmine_01", 1116.108, 3.599905, 77.73704, 63.5);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 41244, "", "d_cmine_01", 1236.338, 3.5899, 190.5945, 66.81818);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 147453, "", "d_cmine_01", 748.1676, 17.45878, 103.7228, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 151004, "UnvisibleName", "d_cmine_01", 1072.24, 3.5899, 79.31609, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 20024, "UnvisibleName", "d_cmine_01", 1115.482, 3.5899, 68.21442, 0);
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
			case 1:
				//DRT_ACTOR_PLAY_EFT("F_explosion006_orange1", "BOT", 0);
				break;
			case 22:
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion042_smoke", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_crystal2_mash", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_archer_entangle_shot_smoke", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke129_spreadout", "BOT");
				break;
			case 39:
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
