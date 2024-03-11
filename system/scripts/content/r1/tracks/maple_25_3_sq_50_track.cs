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

[TrackScript("MAPLE_25_3_SQ_50_TRACK")]
public class MAPLE253SQ50TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("MAPLE_25_3_SQ_50_TRACK");
		//SetMap("f_maple_25_3");
		//CenterPos(-1630.36,0.43,-1252.07);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 57581, "", "f_maple_25_3", -1747.399, -15.59065, -1380.877, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(-1269.841f, 0.3881807f, -1032.21f));
		actors.Add(character);

		var mob1 = Shortcuts.AddMonster(0, 157013, "UnvisibleName", "f_maple_25_3", -1679.547, 0.4295101, -1205.088, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 157013, "UnvisibleName", "f_maple_25_3", -1427.647, 0.4295101, -1018.849, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 157013, "UnvisibleName", "f_maple_25_3", -1578.77, 0.4295101, -1132.503, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 157013, "UnvisibleName", "f_maple_25_3", -1645.712, 0.4295101, -1364.451, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 157013, "UnvisibleName", "f_maple_25_3", -1505.948, 0.4295101, -1358.668, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 157013, "UnvisibleName", "f_maple_25_3", -1388.732, 0.4295101, -1348.852, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 12:
				//DRT_ACTOR_PLAY_EFT("I_smoke004_2", "MID", 0);
				break;
			case 16:
				character.AddonMessage("NOTICE_Dm_scroll", "You hear something breaking behind you", 3);
				//DRT_ACTOR_ATTACH_EFFECT("maple_25_supplemants_event_dead", "BOT");
				break;
			case 26:
				//DRT_ACTOR_PLAY_EFT("I_smoke004_2", "MID", 0);
				break;
			case 28:
				//DRT_ACTOR_PLAY_EFT("I_smoke004_2", "MID", 0);
				break;
			case 30:
				//DRT_ACTOR_ATTACH_EFFECT("maple_25_supplemants_event_dead", "BOT");
				break;
			case 35:
				character.AddonMessage("NOTICE_Dm_scroll", "A Kupole appeared and broke all of the supplement bottles!{nl}Ask what is going on", 7);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
