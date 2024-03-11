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

[TrackScript("EP12_2_D_DCAPITAL_108_MQ08_TRACK")]
public class EP122DDCAPITAL108MQ08TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP12_2_D_DCAPITAL_108_MQ08_TRACK");
		//SetMap("d_dcapital_108");
		//CenterPos(1304.30,21.77,-964.23);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 150240, "Mulia", "d_dcapital_108", 1484.576, 24.74463, -593.6582, 70.38462);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 150212, "", "d_dcapital_108", 1514.129, 24.74463, -581.7488, 68.125);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		character.Movement.MoveTo(new Position(1466.307f, 24.74463f, -548.0859f));
		actors.Add(character);

		var mob2 = Shortcuts.AddMonster(0, 150025, "", "d_dcapital_108", 1473.13, 24.74463, -654.8619, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 5:
				//DRT_SETPOS();
				break;
			case 15:
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation022_light", "TOP");
				break;
			case 16:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ08_TRACK_DLG_03");
				break;
			case 17:
				await track.Dialog.Msg("EP12_2_D_DCAPITAL_108_MQ08_TRACK_DLG_01");
				break;
			case 18:
				Send.ZC_NORMAL.Notice(character, "EP12_2_D_DCAPITAL_108_MQ08_TRACK_DLG_02", 3);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
