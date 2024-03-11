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

[TrackScript("F_DCAPITAL_20_6_SQ_50_TRACK")]
public class FDCAPITAL206SQ50TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_DCAPITAL_20_6_SQ_50_TRACK");
		//SetMap("None");
		//CenterPos(318.28,16.47,1292.90);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-427.4473f, 172.1997f, -346.509f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 58627, "Diena", "None", 257.3792, 16.4679, 1367.982, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 107012, "", "None", 379.938, 16.4679, 1342.044, 7.5, "Neutral");
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 20026, "", "None", 260.3806, 16.4679, 1362.893, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 400344, "", "None", 367.4351, 16.4679, 1264.795, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 3:
				break;
			case 13:
				//DRT_ACTOR_ATTACH_EFFECT("F_magic_prison_circle", "BOT");
				break;
			case 22:
				await track.Dialog.Msg("F_DCAPITAL_20_6_SQ_50_BOSS1");
				break;
			case 38:
				await track.Dialog.Msg("F_DCAPITAL_20_6_SQ_50_BOSS2");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
