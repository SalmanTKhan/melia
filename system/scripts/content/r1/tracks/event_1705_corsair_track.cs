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

[TrackScript("EVENT_1705_CORSAIR_TRACK")]
public class EVENT1705CORSAIRTRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EVENT_1705_CORSAIR_TRACK");
		//SetMap("c_Klaipe");
		//CenterPos(-416.58,148.82,-109.99);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 147508, "", "c_Klaipe", -355, 148, -125, 1);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 147438, "", "c_Klaipe", -210.7043, 148.8251, -47.32141, 51.5);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		character.Movement.MoveTo(new Position(-325.3224f, 148.8223f, -103.2212f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 11:
				await track.Dialog.Msg("EVENT_1705_CORSAIR_DLG3");
				break;
			case 12:
				await track.Dialog.Msg("EVENT_1705_CORSAIR_DLG4");
				break;
			case 13:
				await track.Dialog.Msg("EVENT_1705_CORSAIR_DLG5");
				break;
			case 14:
				await track.Dialog.Msg("EVENT_1705_CORSAIR_DLG6");
				break;
			case 15:
				await track.Dialog.Msg("EVENT_1705_CORSAIR_DLG7");
				break;
			case 27:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
