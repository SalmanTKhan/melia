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

[TrackScript("F_3CMLAKE_85_MQ_05_TRACK")]
public class F3CMLAKE85MQ05TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_3CMLAKE_85_MQ_05_TRACK");
		//SetMap("f_3cmlake_85");
		//CenterPos(-1228.95,162.56,421.78);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-1224.868f, 162.5566f, 437.1702f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 59070, "", "f_3cmlake_85", -1391.362, 159.7019, -59.23137, 36.33333);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 59070, "", "f_3cmlake_85", -1335.715, 159.7019, -42.46964, 27.35294);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 59070, "", "f_3cmlake_85", -1313.277, 157.8397, -70.97894, 27.1875);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 59070, "", "f_3cmlake_85", -1269.098, 157.8397, -49.3639, 22.5);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 156100, "", "f_3cmlake_85", -1375.669, 157.0991, 626.8421, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 156102, "", "f_3cmlake_85", -980.8139, 164.8682, 346.9686, 145.5556);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 156102, "", "f_3cmlake_85", -1078.042, 164.8682, 344.8452, 133.8235);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 156102, "", "f_3cmlake_85", -1174.379, 164.8682, 344.7397, 103.2353);
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
			case 23:
				character.AddonMessage("NOTICE_Dm_scroll", "The demons want to destroy the Water Facility!{nl}Defeat them!", 5);
				break;
			case 24:
				//CREATE_BATTLE_BOX_INLAYER(0);
				//DRT_PLAY_MGAME("F_3CMLAKE_85_MQ_05_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
