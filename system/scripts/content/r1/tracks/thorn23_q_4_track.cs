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

[TrackScript("THORN23_Q_4_TRACK")]
public class THORN23Q4TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("THORN23_Q_4_TRACK");
		//SetMap("d_thorn_23");
		//CenterPos(-1898.05,1137.75,-2635.47);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-1871.011f, 1137.75f, -2614.113f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 41243, "", "d_thorn_23", -1872.627, 1137.75, -2370.985, 85);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 41298, "", "d_thorn_23", -1771.411, 1137.75, -2485.527, 15.3125);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 41298, "", "d_thorn_23", -2005.809, 1137.76, -2199.78, 49.23077);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 41298, "", "d_thorn_23", -1878.72, 1137.75, -2250.246, 46.25);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 41298, "", "d_thorn_23", -1823.146, 1137.75, -2255.613, 48.125);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 41298, "", "d_thorn_23", -1842.205, 1137.75, -2288.183, 45.83333);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 20024, "", "d_thorn_23", -1873.37, 1137.75, -2288.087, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 20024, "", "d_thorn_23", -1823.207, 1137.75, -2225.586, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 20024, "", "d_thorn_23", -1743.458, 1137.75, -2241.177, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 1:
				break;
			case 2:
				break;
			case 16:
				//DRT_ACTOR_ATTACH_EFFECT("E_poata_skl", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_archer_pavise_shot_smoke", "BOT");
				break;
			case 17:
				//DRT_ACTOR_ATTACH_EFFECT("E_poata_skl", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_archer_pavise_shot_smoke", "BOT");
				break;
			case 18:
				//DRT_ACTOR_ATTACH_EFFECT("E_poata_skl", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_archer_pavise_shot_smoke", "BOT");
				break;
			case 21:
				//DRT_ACTOR_ATTACH_EFFECT("F_archer_entangle_shot_smoke", "BOT");
				break;
			case 26:
				//TRACK_SETTENDENCY();
				CreateBattleBoxInLayer(character, track);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
