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

[TrackScript("BARBER_TRACK_2")]
public class BARBERTRACK2 : TrackScript
{
	protected override void Load()
	{
		SetId("BARBER_TRACK_2");
		//SetMap("c_barber_dress");
		//CenterPos(-19.69,4.72,6.07);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-18.38189f, 4.718109f, 2.647856f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 150019, "", "c_barber_dress", -13.07946, 4.718109, 4.107284, 55);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 161005, "", "c_barber_dress", -4.904564, 4.718109, 8.684072, 6);
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
			case 8:
				break;
			case 30:
				//DRT_FAKE_UNEQUIP_ITEM("HAIR");
				break;
			case 52:
				//DRT_S_FIXCAM(-7.83, 4.81, 13.42, 230);
				break;
			case 53:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
