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

[TrackScript("LIMESTONE_52_1_MQ_7_TRACK")]
public class LIMESTONE521MQ7TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("LIMESTONE_52_1_MQ_7_TRACK");
		//SetMap("d_limestonecave_52_1");
		//CenterPos(-474.00,-229.30,-234.21);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 147500, "UnvisibleName", "d_limestonecave_52_1", -571.246, -229.3001, -257.3481, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 57578, "", "d_limestonecave_52_1", -513.0403, -229.3001, -218.75, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 156033, "UnvisibleName", "d_limestonecave_52_1", -571.5099, -229.3001, -257.2259, 0, "Neutral");
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 154014, "", "d_limestonecave_52_1", -504.7701, -229.3001, -263.728, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		character.Movement.MoveTo(new Position(-482.2631f, -229.3001f, -236.5971f));
		actors.Add(character);

		var mob4 = Shortcuts.AddMonster(0, 20025, "", "d_limestonecave_52_1", -576.4855, -229.3001, -256.9357, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 58475, "", "d_limestonecave_52_1", -294.0665, -229.3001, -63.03576, 775);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 58475, "", "d_limestonecave_52_1", -261.2233, -229.3001, -253.1108, 0);
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
			case 4:
				await track.Dialog.Msg("LIMESTONE_52_1_MQ_7_TRACK_1");
				break;
			case 5:
				//SetFixAnim("event_atk");
				break;
			case 8:
				//DRT_ACTOR_ATTACH_EFFECT("F_wizard_teleportation_cast", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_wizard_teleportation_cast", "BOT");
				break;
			case 9:
				//DRT_ACTOR_ATTACH_EFFECT("F_light078_holy_yellow_loop", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_light078_holy_yellow_loop", "BOT");
				break;
			case 10:
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_basic025_white_line", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_light059_event", "BOT");
				break;
			case 14:
				character.AddonMessage("NOTICE_Dm_scroll", "Demons that have felt the divine energy have begun to attack!", 6);
				//SetFixAnim("event_loop2");
				break;
			case 18:
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			case 19:
				//TRACK_SETTENDENCY();
				//DRT_PLAY_MGAME("LIMESTONE_52_1_MQ_7_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
