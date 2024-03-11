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

[TrackScript("UNDERFORTRESS_67_SQ020_TRACK")]
public class UNDERFORTRESS67SQ020TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("UNDERFORTRESS_67_SQ020_TRACK");
		//SetMap("None");
		//CenterPos(1772.92,370.92,803.64);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 47170, "", "None", 1769.67, 370.92, 778.65, 153.75);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 57408, "", "None", 1779.95, 370.9224, 797.7264, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 11283, "원한", "None", 1776.07, 370.9224, 802.0408, 1.315789);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		character.Movement.MoveTo(new Position(1754.195f, 370.9224f, 767.4531f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 19:
				//DRT_ACTOR_PLAY_EFT("F_explosion027_green2", "BOT", 0);
				break;
			case 27:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup001_dark", "BOT");
				break;
			case 28:
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion078_dark", "BOT");
				break;
			case 38:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground046_smoke", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_drop_stone001", "MID");
				break;
			case 45:
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
