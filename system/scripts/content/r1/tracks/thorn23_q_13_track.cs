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

[TrackScript("THORN23_Q_13_TRACK")]
public class THORN23Q13TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("THORN23_Q_13_TRACK");
		//SetMap("d_thorn_23");
		//CenterPos(-969.79,600.29,288.46);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 47223, "", "d_thorn_23", -993.4451, 600.2852, 290.9677, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 10033, "", "d_thorn_23", -1174.681, 635.1166, 444.4597, 62.5, "Neutral");
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 10033, "", "d_thorn_23", -1199.204, 653.3872, 468.3163, 47.1875, "Neutral");
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 10033, "", "d_thorn_23", -1282.717, 626.145, 353.8048, 49.6875, "Neutral");
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 10033, "", "d_thorn_23", -1283.428, 626.6511, 350.9019, 56.25, "Neutral");
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 10033, "", "d_thorn_23", -1184.449, 642.6094, 469.3116, 46.875, "Neutral");
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 10033, "", "d_thorn_23", -1280.677, 621.3917, 327.336, 60.3125, "Neutral");
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		character.Movement.MoveTo(new Position(-970.1514f, 600.2852f, 288.0944f));
		actors.Add(character);

		var mob7 = Shortcuts.AddMonster(0, 10032, "", "d_thorn_23", -873.0078, 589.4425, 515.6752, 60.66667, "Neutral");
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
			case 1:
				break;
			case 3:
				break;
			case 4:
				break;
			case 5:
				break;
			case 6:
				break;
			case 7:
				break;
			case 17:
				break;
			case 84:
				//TRACK_BASICLAYER_MOVE();
				break;
			case 85:
				//TRACK_ACTOR_FUNC("UnHideNPC(self, 'THORN23_BONFIRE',0,0,0)");
				character.Tracks.End(this.TrackId);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
