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

[TrackScript("HUEVILLAGE_58_4_MQ11_TRACK")]
public class HUEVILLAGE584MQ11TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("HUEVILLAGE_58_4_MQ11_TRACK");
		//SetMap("f_huevillage_58_4");
		//CenterPos(9.82,34.20,-170.45);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 147385, "", "f_huevillage_58_4", 28, 34, -146, 50);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 47234, "", "f_huevillage_58_4", 25.8501, 34.2037, -162.7629, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 147469, "", "f_huevillage_58_4", 100.6466, 34.2037, -159.9165, 600);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		character.Movement.MoveTo(new Position(32.63232f, 34.2037f, -176.0237f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 1:
				break;
			case 2:
				break;
			case 15:
				await track.Dialog.Msg("HUEVILLAGE_58_4_MQ11_TRACK1");
				break;
			case 17:
				await track.Dialog.Msg("HUEVILLAGE_58_4_MQ11_TRACK2");
				break;
			case 32:
				//DRT_ACTOR_ATTACH_EFFECT("E_HUEVILLAGE_58_4_MQ11_potal", "BOT");
				break;
			case 41:
				character.AddonMessage("NOTICE_Dm_Clear", "Use the portal to move to Rukas Plateau", 10);
				break;
			case 51:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
