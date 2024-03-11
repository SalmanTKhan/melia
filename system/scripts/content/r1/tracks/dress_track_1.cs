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

[TrackScript("DRESS_TRACK_1")]
public class DRESSTRACK1 : TrackScript
{
	protected override void Load()
	{
		SetId("DRESS_TRACK_1");
		//SetMap("c_barber_dress");
		//CenterPos(40.71,6.88,1101.14);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(39.24422f, 6.875391f, 1091.025f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 150020, "", "c_barber_dress", -3.163143, 6.875391, 1105.253, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 161003, "", "c_barber_dress", 23, 6, 1063, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 10:
				//DRT_SERVER_ANIM("close_std", 1);
				break;
			case 25:
				//DRT_SERVER_PLAYPOSE(14);
				break;
			case 30:
				//DRT_SERVER_ANIM("open", 1);
				break;
			case 47:
				//DRT_S_FIXCAM(34.79, 6.98, 1098.98, 230);
				break;
			case 48:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
