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

[TrackScript("ABBEY22_5_SQ7_TRACK")]
public class ABBEY225SQ7TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ABBEY22_5_SQ7_TRACK");
		//SetMap("d_abbey_22_5");
		//CenterPos(-1513.31,64.38,898.73);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-1513.309f, 64.38169f, 898.7294f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 57840, "", "d_abbey_22_5", -1867.64, 64.73596, 889.9222, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 58857, "", "d_abbey_22_5", -1857.344, 64.73294, 804.5638, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 58862, "", "d_abbey_22_5", -1794.073, 64.68253, 992.0178, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 58862, "", "d_abbey_22_5", -1881.636, 64.74077, 989.3185, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 58857, "", "d_abbey_22_5", -1789.507, 64.7198, 794.9754, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 20026, "UnvisibleName", "d_abbey_22_5", -1370.53, 63.91059, 895.1767, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 8:
				await track.Dialog.Msg("ABBEY22_5_SUBQ7_DLG1");
				break;
			case 9:
				character.AddSessionObject(PropertyName.ABBEY22_5_SQ7, 1);
				break;
			case 10:
				character.AddonMessage("NOTICE_Dm_Clear", "It seems as if Suspicion Hauberk considers you to be King Hammer{nl}Talk to Suspicion Hauberk", 4);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
