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

[TrackScript("VPRISON515_MQ_06_TRACK")]
public class VPRISON515MQ06TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("VPRISON515_MQ_06_TRACK");
		//SetMap("d_velniasprison_51_5");
		//CenterPos(-130.68,26.79,-51.29);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 154010, "", "d_velniasprison_51_5", -65.45618, 23.1219, -190.292, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 20026, "", "d_velniasprison_51_5", -2.220001, 23.06, -97.66, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 154015, "", "d_velniasprison_51_5", -212.4905, 26.7903, -146.7074, 260);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 154014, "", "d_velniasprison_51_5", 87.84412, 23.12187, -29.06441, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 154013, "", "d_velniasprison_51_5", -240.9929, 26.7903, -42.34282, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 154012, "", "d_velniasprison_51_5", 60.99593, 26.7904, 116.2334, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 154016, "", "d_velniasprison_51_5", -197.3031, 26.7903, 94.5843, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 154011, "", "d_velniasprison_51_5", -64.27762, 26.7903, 160.0671, 120);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		character.Movement.MoveTo(new Position(-101.3874f, 23.1219f, -196.721f));
		actors.Add(character);

		var mob8 = Shortcuts.AddMonster(0, 20025, "", "d_velniasprison_51_5", 62.19, 22.96, -148.69, 0);
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
			case 13:
				break;
			case 14:
				break;
			case 15:
				break;
			case 16:
				break;
			case 26:
				//SetFixAnim("event_loop3");
				//SetFixAnim("event_loop2");
				//SetFixAnim("event_loop2");
				break;
			case 27:
				//SetFixAnim("event_loop2");
				//SetFixAnim("event_loop2");
				//SetFixAnim("event_loop2");
				//SetFixAnim("event_loop2");
				break;
			case 29:
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation005_yellow_event", "BOT");
				break;
			case 49:
				//DRT_PLAY_MGAME("VPRISON515_MQ_06_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
