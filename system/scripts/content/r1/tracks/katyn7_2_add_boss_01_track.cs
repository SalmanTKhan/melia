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

[TrackScript("KATYN7_2_ADD_BOSS_01_TRACK")]
public class KATYN72ADDBOSS01TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("KATYN7_2_ADD_BOSS_01_TRACK");
		//SetMap("f_katyn_7_2");
		//CenterPos(3695.05,229.69,-581.88);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 41221, "", "f_katyn_7_2", 3942.017, 229.722, -269.2538, 5.869565);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 48022, "", "f_katyn_7_2", 3570.944, 229.6948, -479.2342, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 20025, "", "f_katyn_7_2", 3966.551, 289.5887, -193.7553, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		character.Movement.MoveTo(new Position(3582.541f, 229.6948f, -518.4874f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 1:
				//DRT_ACTOR_ATTACH_EFFECT("I_drop_stone001_mash", "BOT");
				break;
			case 3:
				//DRT_ACTOR_ATTACH_EFFECT("I_drop_stone001_mash", "BOT");
				break;
			case 5:
				//DRT_ACTOR_ATTACH_EFFECT("I_drop_stone001_mash", "BOT");
				break;
			case 10:
				character.AddonMessage("NOTICE_Dm_!", "Throneweaver has appeared!", 3);
				break;
			case 19:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke016_green", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke030", "BOT");
				break;
			case 34:
				//TRACK_SETTENDENCY();
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
