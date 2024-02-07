using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.Scripting;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.Effects;
using Melia.Zone.World.Tracks;
using Yggdrasil.Logging;

[TrackScript("EP15_1_F_ABBEY1_1_TRACK")]
public class EP151FABBEY11TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP15_1_F_ABBEY1_1_TRACK");
		//SetMap("c_orsha");
		//CenterPos(146.59,176.08,293.55);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(146.5932f, 176.0767f, 293.554f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 154102, "", "c_orsha", 238.9941, 175.9909, 313.8801, 181.5385);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 12082, "", "c_orsha", 241.9537, 175.9806, 309.9567, 0);
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
			case 9:
				break;
			case 11:
				//DRT_ACTOR_ATTACH_EFFECT("F_light078_holy_yellow_katadikazo", "BOT");
				break;
			case 19:
				await track.Dialog.Msg("EP15_1_F_ABBEY1_1_DLG3");
				break;
			case 30:
				//TRACK_BASICLAYER_MOVE();
				//DRT_FUNC_ACT("EP15_1_ABBEY1_WARP");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
