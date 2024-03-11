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

[TrackScript("F_3CMLAKE262_SQ06_TRACK")]
public class F3CMLAKE262SQ06TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_3CMLAKE262_SQ06_TRACK");
		//SetMap("f_3cmlake_26_2");
		//CenterPos(1486.83,-215.56,1165.35);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 155024, "", "f_3cmlake_26_2", 1477, -215, 1276, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(1470.917f, -215.5557f, 1251.982f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 16:
				//DRT_ACTOR_ATTACH_EFFECT("I_cylinder001_blue", "BOT");
				break;
			case 21:
				character.AddonMessage("NOTICE_Dm_scroll", "The Beholder's demons sense something is wrong and are headed towards you!{nl}Protect the Self-destruction Device until it can be activated!", 3);
				break;
			case 24:
				//CREATE_BATTLE_BOX_INLAYER(120);
				//DRT_PLAY_MGAME("F_3CMLAKE262_SQ06_MINI02");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
