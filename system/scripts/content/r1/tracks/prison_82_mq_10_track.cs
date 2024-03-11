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

[TrackScript("PRISON_82_MQ_10_TRACK")]
public class PRISON82MQ10TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("PRISON_82_MQ_10_TRACK");
		//SetMap("d_prison_82");
		//CenterPos(-555.16,618.94,-1415.12);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 151003, "UnvisibleName", "d_prison_82", -550, 618.94, -1577, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(-555.1586f, 618.9418f, -1415.119f));
		actors.Add(character);

		var mob1 = Shortcuts.AddMonster(0, 151107, "", "d_prison_82", -529.8386, 618.9418, -1555.701, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 58412, "", "d_prison_82", -539.9122, 553.882, -1048.723, 89.58333);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 20026, "", "d_prison_82", -550, 618.94, -1577, 4.285714);
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
			case 6:
				//SetFixAnim("soul_pray");
				break;
			case 7:
				await track.Dialog.Msg("PRISON_82_MQ_10_TRACK_dlg1");
				//DRT_ACTOR_ATTACH_EFFECT("F_ground023", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_summon_ground_red2", "BOT");
				break;
			case 10:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke007_green", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_ground051_loop2", "BOT");
				break;
			case 14:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_out003_darkblue", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("F_light078_holy_yellow_loop", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_in027_green_loop", "BOT");
				break;
			case 31:
				await track.Dialog.Msg("PRISON_82_MQ_10_TRACK_dlg2");
				break;
			case 36:
				//DRT_ACTOR_ATTACH_EFFECT("F_spread_out039_green", "BOT");
				break;
			case 47:
				character.AddonMessage("NOTICE_Dm_scroll", "Nebulas' power became weaker after disabling the demon barrier.{nl}Defeat Nebulas!", 5);
				break;
			case 48:
				//TRACK_SETTENDENCY();
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
