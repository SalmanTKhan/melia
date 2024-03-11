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

[TrackScript("CHAPLE576_MQ_04_TRACK")]
public class CHAPLE576MQ04TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CHAPLE576_MQ_04_TRACK");
		//SetMap("d_chapel_57_6");
		//CenterPos(-1655.02,0.42,437.11);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-1728.831f, 0.4277f, 425.8162f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 41372, "", "d_chapel_57_6", -1050.647, -1.788287, 441.778, 110);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 147379, "", "d_chapel_57_6", -1777.938, 0.4177, 425.9765, 0);
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
			case 3:
				break;
			case 34:
				CreateBattleBoxInLayer(character, track);
				character.AddonMessage("NOTICE_Dm_!", "Defeat Mummyghast!", 3);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
