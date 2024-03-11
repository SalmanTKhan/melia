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

[TrackScript("UNDERFORTRESS_69_MQ050_TRACK")]
public class UNDERFORTRESS69MQ050TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("UNDERFORTRESS_69_MQ050_TRACK");
		//SetMap("d_underfortress_69");
		//CenterPos(-130.59,740.42,-70.52);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 153059, "", "d_underfortress_69", -107.3453, 740.3456, -42.17761, 15.55556);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 153139, "", "d_underfortress_69", -141.96, 739.92, -44.74, 79.16666);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 57707, "", "d_underfortress_69", -173.5275, 741.3011, 18.77505, 5);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		character.Movement.MoveTo(new Position(-129.6069f, 740.4292f, -69.40555f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 13:
				await track.Dialog.Msg("UNDER_69_MQ050_TRACK01");
				break;
			case 20:
				//DRT_ACTOR_PLAY_EFT("F_ground038", "BOT", 0);
				break;
			case 36:
				//DRT_ACTOR_ATTACH_EFFECT("F_bg_fire003_green", "BOT");
				break;
			case 40:
				await track.Dialog.Msg("UNDER_69_MQ050_TRACK02");
				break;
			case 41:
				//DRT_ACTOR_PLAY_EFT("F_burstup027_fire1_green", "BOT", 0);
				break;
			case 42:
				//DisableBornAni();
				break;
			case 54:
				CreateBattleBoxInLayer(character, track);
				//TRACK_SETTENDENCY();
				break;
			case 68:
				await track.Dialog.Msg("UNDER_69_MQ050_TRACK01");
				break;
			case 78:
				await track.Dialog.Msg("UNDER_69_MQ050_TRACK02");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
