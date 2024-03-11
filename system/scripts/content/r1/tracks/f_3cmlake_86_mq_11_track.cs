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

[TrackScript("F_3CMLAKE_86_MQ_11_TRACK")]
public class F3CMLAKE86MQ11TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_3CMLAKE_86_MQ_11_TRACK");
		//SetMap("f_3cmlake_86");
		//CenterPos(0.00,0.00,0.00);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(330.6942f, 41.15479f, 432.4472f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "f_3cmlake_86", 458.011, 70.72942, 432.6609, 1.666667);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "f_3cmlake_86", 564.2254, 70.70905, 518.3308, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "f_3cmlake_86", 644.4759, 70.72531, 428.7585, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "f_3cmlake_86", 555.4633, 72.6735, 347.1171, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 156104, "", "f_3cmlake_86", 539.1511, 85.32338, 445.8336, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 156104, "", "f_3cmlake_86", 578.9614, 85.46369, 449.3483, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 156104, "", "f_3cmlake_86", 578.7117, 86.68382, 408.0607, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 156104, "", "f_3cmlake_86", 535.62, 85.78419, 408.3163, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 21:
				await track.Dialog.Msg("F_3CMLAKE_86_MQ_11_DLG1");
				break;
			case 24:
				//DRT_FUNC_ACT("F_3CMLAKE_86_MQ_11_NPC_KILL");
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
