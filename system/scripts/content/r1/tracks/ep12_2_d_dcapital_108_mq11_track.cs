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

[TrackScript("EP12_2_D_DCAPITAL_108_MQ11_TRACK")]
public class EP122DDCAPITAL108MQ11TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP12_2_D_DCAPITAL_108_MQ11_TRACK");
		//SetMap("None");
		//CenterPos(2237.43,24.74,396.48);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 153188, "", "None", 2251.06, 24.74463, 334.8973, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 150240, "Mulia", "None", 2265.033, 24.74463, 352.7145, 35);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 150212, "", "None", 2291.758, 24.74463, 356.4642, 220);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		character.Movement.MoveTo(new Position(2251.316f, 24.74463f, 387.3116f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 3:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ11_TRACK_DLG_01");
				break;
			case 9:
				//DRT_ACTOR_ATTACH_EFFECT("I_spread_in009_violet", "TOP");
				break;
			case 17:
				//DRT_ACTOR_ATTACH_EFFECT("I_cylinder009_light_ice", "BOT");
				break;
			case 20:
				//DRT_ACTOR_ATTACH_EFFECT("E_pc_shield_square", "BOT");
				break;
			case 24:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ11_TRACK_DLG_02");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
