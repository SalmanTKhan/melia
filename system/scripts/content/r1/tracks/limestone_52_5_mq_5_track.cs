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

[TrackScript("LIMESTONE_52_5_MQ_5_TRACK")]
public class LIMESTONE525MQ5TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("LIMESTONE_52_5_MQ_5_TRACK");
		//SetMap("d_limestonecave_52_5");
		//CenterPos(153.74,756.10,155.84);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 153157, "UnvisibleName", "d_limestonecave_52_5", 117.2086, 756.1429, 194.3887, 95);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(149.7127f, 756.1f, 156.8749f));
		actors.Add(character);

		var mob1 = Shortcuts.AddMonster(0, 57581, "", "d_limestonecave_52_5", 169.5076, 756.1, 176.2982, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 58037, "", "d_limestonecave_52_5", -1.916351, 756.1, 138.9011, 155);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 15:
				character.AddonMessage("NOTICE_Dm_scroll", "A Lavenzard appeared as soon as you tried to look at the Sinister Idol!", 6);
				break;
			case 16:
				//DRT_ACTOR_PLAY_EFT("F_burstup001_violet", "BOT", 0);
				break;
			case 23:
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			case 24:
				//TRACK_SETTENDENCY();
				//InsertHate(999);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
