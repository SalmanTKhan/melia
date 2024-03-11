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

[TrackScript("F_3CMLAKE_87_MQ_13_TRACK")]
public class F3CMLAKE87MQ13TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_3CMLAKE_87_MQ_13_TRACK");
		//SetMap("f_3cmlake_87");
		//CenterPos(10.75,164.18,2157.91);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(10.75114f, 164.184f, 2157.909f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 156120, "", "f_3cmlake_87", -10.9937, 153.8066, 1856.278, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 156119, "", "f_3cmlake_87", -42.24073, 153.8066, 1880.604, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 147405, "", "f_3cmlake_87", -33.89347, 164.184, 1826.551, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 156127, "", "f_3cmlake_87", 14.44198, 164.184, 1810.446, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 156128, "", "f_3cmlake_87", -83.31664, 160.2934, 1847.957, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 21:
				await track.Dialog.Msg("F_3CMLAKE_87_MQ_13_DLG1");
				break;
			case 22:
				await track.Dialog.Msg("F_3CMLAKE_87_MQ_13_DLG2");
				break;
			case 49:
				Send.ZC_NORMAL.SetupCutscene(character, false, false, true);
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
