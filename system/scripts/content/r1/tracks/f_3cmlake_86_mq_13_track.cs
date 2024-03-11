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

[TrackScript("F_3CMLAKE_86_MQ_13_TRACK")]
public class F3CMLAKE86MQ13TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_3CMLAKE_86_MQ_13_TRACK");
		//SetMap("f_3cmlake_86");
		//CenterPos(2139.64,46.74,-423.36);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 156102, "", "f_3cmlake_86", 2112.75, 46.73244, -423.864, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 156116, "Resistance Soldier", "f_3cmlake_86", 2093.279, 46.22442, -447.5096, 0.4166667);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		character.Movement.MoveTo(new Position(2139.582f, 46.65881f, -426.9791f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 1:
				//DRT_PLAY_MGAME("F_3CMLAKE_86_MQ_13_MINI");
				break;
			case 29:
				await track.Dialog.Msg("F_3CMLAKE_86_MQ_13_DLG1");
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
