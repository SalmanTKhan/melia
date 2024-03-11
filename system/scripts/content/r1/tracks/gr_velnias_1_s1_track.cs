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

[TrackScript("GR_VELNIAS_1_S1_TRACK")]
public class GRVELNIAS1S1TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("GR_VELNIAS_1_S1_TRACK");
		//SetMap("f_farm_47_2");
		//CenterPos(-772.77,0.34,-1175.29);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-841.2347f, 0.3364f, -1174.633f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 740016, "", "f_farm_47_2", -1140.552, 0.3364, -1194.468, 95);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 5:
				break;
			case 12:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke065_2", "BOT");
				break;
			case 13:
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation010_smoke_darkgreen", "BOT");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
