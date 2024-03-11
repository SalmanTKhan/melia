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

[TrackScript("VPRISON515_MQ_01_TRACK")]
public class VPRISON515MQ01TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("VPRISON515_MQ_01_TRACK");
		//SetMap("d_velniasprison_51_5");
		//CenterPos(-119.62,23.12,-188.69);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 154010, "", "d_velniasprison_51_5", -108.8576, 23.1219, -181.1343, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(-98.98813f, 29.5156f, -288.6962f));
		actors.Add(character);

		var mob1 = Shortcuts.AddMonster(0, 20026, "", "d_velniasprison_51_5", -151.4417, 26.7903, 41.14857, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 57720, "", "d_velniasprison_51_5", -251.3899, 26.7903, 74.87395, 54);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 57720, "", "d_velniasprison_51_5", -206.7674, 26.7903, 35.61421, 57.5);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 57720, "", "d_velniasprison_51_5", -190.168, 26.7903, -9.052942, 37);
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
			case 12:
				//DRT_ACTOR_PLAY_EFT("F_explosion019_rize", "MID", 0);
				break;
			case 13:
				//DRT_ACTOR_PLAY_EFT("F_explosion019_rize", "MID", 0);
				break;
			case 14:
				//DRT_ACTOR_PLAY_EFT("F_explosion019_rize", "MID", 0);
				break;
			case 19:
				character.AddSessionObject(PropertyName.VPRISON515_MQ_01, 1);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
