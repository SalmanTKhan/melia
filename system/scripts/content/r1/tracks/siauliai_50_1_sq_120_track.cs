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

[TrackScript("SIAULIAI_50_1_SQ_120_TRACK")]
public class SIAULIAI501SQ120TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("SIAULIAI_50_1_SQ_120_TRACK");
		//SetMap("f_siauliai_50_1");
		//CenterPos(-1860.33,-209.70,28.72);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 20019, "", "f_siauliai_50_1", -1885.538, -209.7028, 27.54425, 55.51724);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 20015, "", "f_siauliai_50_1", -1703.152, -209.7028, -96.31863, 105.7407);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 20014, "", "f_siauliai_50_1", -1703.594, -209.7028, -138.1255, 105);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 20013, "", "f_siauliai_50_1", -1671.798, -209.7028, -72.24424, 98.88889);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 20011, "", "f_siauliai_50_1", -1766.968, -209.7028, -83.71095, 105.7407);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		character.Movement.MoveTo(new Position(-1856.721f, -209.7028f, 29.02179f));
		actors.Add(character);

		var mob5 = Shortcuts.AddMonster(0, 41376, "", "f_siauliai_50_1", -1701.01, -209.7028, -198.7554, 0);
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
			case 17:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup007_smoke1", "BOT");
				break;
			case 18:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground045_smoke", "BOT");
				break;
			case 22:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_out026_leaf", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup001_smoke", "BOT");
				break;
			case 24:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup001_smoke1", "BOT");
				break;
			case 29:
				CreateBattleBoxInLayer(character, track);
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
