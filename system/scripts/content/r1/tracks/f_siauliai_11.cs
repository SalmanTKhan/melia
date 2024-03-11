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

[TrackScript("f_siauliai_11")]
public class fsiauliai11 : TrackScript
{
	protected override void Load()
	{
		SetId("f_siauliai_11");
		//CenterPos(2261.51,209.72,716.01);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 20160, "", "", 2238.02, 209.7252, 762.5151, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 20160, "", "", 2247.238, 209.7252, 715.4051, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 20160, "", "", 2138.971, 209.7252, 745.3569, 3.75);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 20160, "", "", 2266.125, 209.7252, 723.6611, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 20160, "", "", 2215.711, 209.7252, 666.2797, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 20160, "", "", 2179.914, 209.7252, 764.8723, 0);
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
			case 4:
				//DRT_RUN_FUNCTION("TALK_WOODMAN_07");
				break;
			case 5:
				//DRT_RUN_FUNCTION("TALK_WOODMAN_02");
				break;
			case 8:
				//DRT_RUN_FUNCTION("TALK_WOODMAN_06");
				break;
			case 12:
				//DRT_RUN_FUNCTION("TALK_WOODMAN_04");
				break;
			case 23:
				//DRT_RUN_FUNCTION("TALK_WOODMAN_02");
				break;
			case 29:
				//DRT_RUN_FUNCTION("None");
				break;
			case 36:
				//DRT_RUN_FUNCTION("TALK_WOODMAN_06");
				break;
			case 38:
				//DRT_RUN_FUNCTION("TALK_WOODMAN_02");
				break;
			case 47:
				//DRT_RUN_FUNCTION("TALK_WOODMAN_04");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
