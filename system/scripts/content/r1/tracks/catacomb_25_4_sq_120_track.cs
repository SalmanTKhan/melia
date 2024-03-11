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

[TrackScript("CATACOMB_25_4_SQ_120_TRACK")]
public class CATACOMB254SQ120TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CATACOMB_25_4_SQ_120_TRACK");
		//SetMap("id_catacomb_25_4");
		//CenterPos(-876.21,-46.29,-1181.54);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 20000, "", "id_catacomb_25_4", -991.3958, -46.28895, -1066.648, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 147500, "UnvisibleName", "id_catacomb_25_4", -870.62, -46.28, -1182.41, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 107010, "", "id_catacomb_25_4", -996.908, -46.28895, -1061.453, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		character.Movement.MoveTo(new Position(-872.0597f, -46.289f, -1182.081f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 3:
				//DRT_ACTOR_ATTACH_EFFECT("I_levitation001_dark", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_spread_in011", "BOT");
				break;
			case 5:
				//DRT_ACTOR_ATTACH_EFFECT("F_summon_ghede", "BOT");
				break;
			case 7:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in005_dark", "BOT");
				break;
			case 12:
				//DRT_ACTOR_ATTACH_EFFECT("F_pattern008_violet", "TOP");
				break;
			case 14:
				//DRT_ACTOR_ATTACH_EFFECT("F_stone003", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion065_violet", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_stone005", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_ground036_violet", "BOT");
				break;
			case 17:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup001_violet", "BOT");
				break;
			case 18:
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion074_violet", "BOT");
				break;
			case 19:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup001_dark", "BOT");
				break;
			case 20:
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion016_red", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_lineup017_violet", "BOT");
				break;
			case 23:
				character.AddonMessage("NOTICE_Dm_scroll", "The Specter Lord that had been sealed in the hidden room has awoken", 7);
				break;
			case 26:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup029_smoke_dark", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup002_dark", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_light098_red", "BOT");
				break;
			case 27:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_out029_red", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke005_dark", "BOT");
				break;
			case 35:
				//TRACK_SETTENDENCY();
				break;
			case 39:
				Send.ZC_NORMAL.SetupCutscene(character, false, false, true);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
