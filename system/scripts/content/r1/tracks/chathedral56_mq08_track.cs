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

[TrackScript("CHATHEDRAL56_MQ08_TRACK")]
public class CHATHEDRAL56MQ08TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CHATHEDRAL56_MQ08_TRACK");
		//SetMap("None");
		//CenterPos(-1613.88,0.00,784.54);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 147357, "", "None", -1672.6, 0, 835.22, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 147357, "", "None", -1673.53, 0.49, 622.19, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 147357, "", "None", -1436.67, 0.49, 854, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 147357, "", "None", -1378.54, 0, 693.38, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 147357, "", "None", -1496.29, 0.49, 567.74, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 20026, "", "None", -1553.61, 0, 733.95, 0);
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
				//DRT_ACTOR_PLAY_EFT("F_buff_basic029_red_line", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_buff_basic027_navy_line", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_buff_basic032_yellow_line", "BOT", 0);
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_basic031_green_line", "BOT");
				//DRT_ACTOR_PLAY_EFT("F_buff_basic028_violet_line", "BOT", 0);
				break;
			case 8:
				//DRT_ACTOR_ATTACH_EFFECT("E_HUEVILLAGE_58_4_MQ11_potal", "BOT");
				break;
			case 34:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
