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

[TrackScript("CASTLE_20_4_SQ_7_TRACK")]
public class CASTLE204SQ7TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CASTLE_20_4_SQ_7_TRACK");
		//SetMap("f_castle_20_4");
		//CenterPos(-577.79,-65.52,825.36);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-56.76364f, -62.83429f, 713.1367f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 151125, "UnvisibleName", "f_castle_20_4", -128.8401, -65.52153, 714.1442, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 152022, "UnvisibleName", "f_castle_20_4", -547.6451, -65.52152, 700.4586, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 152022, "UnvisibleName", "f_castle_20_4", -363.3398, -65.52153, 887.6455, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 152022, "UnvisibleName", "f_castle_20_4", -344.2376, -65.52153, 532.9808, 0);
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
			case 4:
				//DRT_ADDBUFF("CASTLE_20_4_SQ_7_BUFF_1", 1, 0, 0, 1);
				break;
			case 8:
				//DRT_ACTOR_PLAY_EFT("F_ground077_smoke", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_burstup007_smoke", "BOT", 0);
				break;
			case 9:
				//DRT_ADDBUFF("CASTLE_20_4_SQ_7_BUFF_1", 1, 0, 0, 1);
				break;
			case 14:
				//DRT_ADDBUFF("CASTLE_20_4_SQ_7_BUFF_1", 1, 0, 0, 1);
				break;
			case 29:
				CreateBattleBoxInLayer(character, track);
				character.AddonMessage("NOTICE_Dm_scroll", "The jars have started to emit a poisonous gas{nl}Use the Military Grade Antidote and destroy the jars", 5);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
