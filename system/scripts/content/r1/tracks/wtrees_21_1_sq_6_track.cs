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

[TrackScript("WTREES_21_1_SQ_6_TRACK")]
public class WTREES211SQ6TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("WTREES_21_1_SQ_6_TRACK");
		//SetMap("f_whitetrees_21_1");
		//CenterPos(-78.03,132.99,1103.02);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 151050, "", "f_whitetrees_21_1", -105, 132.99, 1131, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 107021, "", "f_whitetrees_21_1", -492.0139, 132.9931, 1070.111, 29);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		character.Movement.MoveTo(new Position(-81.39754f, 132.9931f, 1104.4f));
		actors.Add(character);

		var mob2 = Shortcuts.AddMonster(0, 20026, "", "f_whitetrees_21_1", -478.1731, 132.9931, 1088.675, 0);
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
			case 2:
				break;
			case 8:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke050", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke052_green", "BOT");
				break;
			case 13:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup001_red", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_fire_spread", "BOT");
				break;
			case 18:
				character.AddonMessage("NOTICE_Dm_scroll", "Cerberus, the demon coveting the treaty that Kupole Lenja talked about, has appeared.{nl}Defeat Cerberus.", 5);
				break;
			case 19:
				CreateBattleBoxInLayer(character, track);
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
