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

[TrackScript("FTOWER44_MQ_04_TRACK")]
public class FTOWER44MQ04TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("FTOWER44_MQ_04_TRACK");
		//SetMap("d_firetower_44");
		//CenterPos(-1652.98,531.46,678.08);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-1585.028f, 536.9449f, 574.6259f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 147449, "", "d_firetower_44", -1597.261, 536.9874, 579.0332, 47.22223, "Neutal");
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 20026, "Magic Circle", "d_firetower_44", -1603.538, 536.9973, 614.043, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 57050, "", "d_firetower_44", -1604.693, 536.9874, 813.693, 17.5);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 57050, "", "d_firetower_44", -1699.466, 536.9874, 709.7641, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 57050, "", "d_firetower_44", -1497.396, 536.9873, 682.5378, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 57050, "", "d_firetower_44", -1712.982, 536.9874, 566.9691, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 57050, "", "d_firetower_44", -1530.36, 536.9874, 587.9568, 0);
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
			case 1:
				await track.Dialog.Msg("FTOWER44_MQ_04_TRACK_01");
				break;
			case 2:
				//DRT_ACTOR_ATTACH_EFFECT("F_wizard_prominence_ground", "BOT");
				break;
			case 15:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground064_fire", "BOT");
				break;
			case 22:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground120_fire", "BOT");
				break;
			case 26:
				break;
			case 30:
				break;
			case 31:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground119_fire", "BOT");
				break;
			case 32:
				break;
			case 43:
				character.AddonMessage("NOTICE_Dm_!", "Protect Grita while she is controlling the magic of the tower!", 3);
				break;
			case 44:
				//CREATE_BATTLE_BOX_INLAYER(0);
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
