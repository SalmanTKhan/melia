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

[TrackScript("F_NICOPOLIS_81_3_SQ_02_TRACK")]
public class FNICOPOLIS813SQ02TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_NICOPOLIS_81_3_SQ_02_TRACK");
		//SetMap("None");
		//CenterPos(1439.43,-29.90,149.92);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(1401.78f, -28.53f, 238.18f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 151000, "", "None", 1445.66, -28.66, 192.64, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 153214, "", "None", 1434.56, -28.64, 226.34, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 147382, "", "None", 1457.472, -31.7473, 127.147, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 58786, "", "None", 1517.822, -28.65325, 199.2813, 0, "Neutral");
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
			case 1:
				await track.Dialog.Msg("NICO813_SUBQ02_DLG1");
				break;
			case 32:
				await track.Dialog.Msg("NICO813_SUBQ02_DLG2");
				break;
			case 34:
				//TRACK_BASICLAYER_MOVE();
				//DRT_FUNC_ACT("NICO813_SUBQ02_TRACK_FUNC");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
