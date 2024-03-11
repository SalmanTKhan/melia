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

[TrackScript("TABLELAND_73_SQ6_TRACK")]
public class TABLELAND73SQ6TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("TABLELAND_73_SQ6_TRACK");
		//SetMap("f_tableland_73");
		//CenterPos(1217.22,677.64,1433.95);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 47105, "", "f_tableland_73", 1207.06, 677.64, 1461.72, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 103040, "", "f_tableland_73", 1261.434, 677.6448, 1218.63, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 20024, "", "f_tableland_73", 1350.445, 677.6448, 1367.769, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 20024, "UnvisibleName", "f_tableland_73", 1127.034, 677.6448, 1342.599, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 20024, "UnvisibleName", "f_tableland_73", 1209.638, 677.6448, 1188.908, 0);
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
			case 3:
				character.AddonMessage("NOTICE_Dm_!", "A Lavenzard appeared{nl}as you try to destroy the scultpure", 3);
				break;
			case 25:
				//DRT_ACTOR_PLAY_EFT("F_smoke137_white2", "BOT", 0);
				break;
			case 31:
				//DRT_ACTOR_PLAY_EFT("F_smoke137_white2", "BOT", 0);
				break;
			case 33:
				//DRT_ACTOR_PLAY_EFT("F_smoke137_white2", "BOT", 0);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
