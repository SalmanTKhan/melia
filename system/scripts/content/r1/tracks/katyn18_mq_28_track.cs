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

[TrackScript("KATYN18_MQ_28_TRACK")]
public class KATYN18MQ28TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("KATYN18_MQ_28_TRACK");
		//CenterPos(-1241.19,595.03,-1610.24);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-1250f, 595f, -1590f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 57092, "", "", -1242.942, 595.041, -1590.341, 160);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(-1241.189f, 595.041f, -1610.244f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 7:
				await track.Dialog.Msg("f_katyn_18_dlg_5");
				break;
			case 8:
				//DRT_ACTOR_ATTACH_EFFECT("F_ghostnpc_born", "BOT");
				break;
			case 11:
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
