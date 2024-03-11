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

[TrackScript("F_3CMLAKE_86_MQ_10_TRACK")]
public class F3CMLAKE86MQ10TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_3CMLAKE_86_MQ_10_TRACK");
		//SetMap("f_3cmlake_86");
		//CenterPos(381.88,217.70,-781.02);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(377.1992f, 217.7039f, -776.6328f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 156103, "", "f_3cmlake_86", 380.1359, 217.7039, -980.2907, 70);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 156116, "Resistance Soldier", "f_3cmlake_86", 363.5837, 217.7039, -705.1686, 57.91666);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "f_3cmlake_86", 376.0029, 217.7039, -975.3647, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 147469, "UnvisibleName", "f_3cmlake_86", 370.4841, 217.7039, -906.9845, 0);
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
			case 28:
				await track.Dialog.Msg("F_3CMLAKE_86_MQ_10_DLG1");
				break;
			case 32:
				//SetFixAnim("on_loop");
				//DRT_ACTOR_ATTACH_EFFECT("F_levitation005_yellow", "BOT");
				break;
			case 39:
				//DRT_ACTOR_PLAY_EFT("F_spread_out033_ground_light", "BOT", 0);
				break;
			case 44:
				break;
			case 45:
				//DRT_ACTOR_PLAY_EFT("F_lineup003", "BOT", 0);
				break;
			case 46:
				//DRT_ACTOR_ATTACH_EFFECT("F_light054", "MID");
				break;
			case 51:
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
