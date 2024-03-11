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

[TrackScript("ABBAY_64_3_MQ040_AFTER_TRACK")]
public class ABBAY643MQ040AFTERTRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ABBAY_64_3_MQ040_AFTER_TRACK");
		//SetMap("d_abbey_64_3");
		//CenterPos(-1462.73,622.42,110.76);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 153119, "", "d_abbey_64_3", -1459, 622.42, 175, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 153110, "Edmundas", "d_abbey_64_3", -1548.75, 616.52, -192.7, 61.60714);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 47123, "UnvisibleName", "d_abbey_64_3", -1459, 622.42, 175, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 153120, "", "d_abbey_64_3", -1454.4, 622.42, 244.96, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 47254, "UnvisibleName", "d_abbey_64_3", -1555, 621, 268, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 2:
				//DRT_ACTOR_PLAY_EFT("F_smoke027_dark", "BOT", 0);
				break;
			case 4:
				//DRT_ACTOR_PLAY_EFT("F_smoke072_sviolet", "BOT", 0);
				break;
			case 7:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke008_red_noloop", "BOT");
				break;
			case 45:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
