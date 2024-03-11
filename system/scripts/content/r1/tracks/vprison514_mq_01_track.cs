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

[TrackScript("VPRISON514_MQ_01_TRACK")]
public class VPRISON514MQ01TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("VPRISON514_MQ_01_TRACK");
		//SetMap("d_velniasprison_51_4");
		//CenterPos(-1071.89,591.23,1373.18);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 154010, "", "d_velniasprison_51_4", -1019.043, 579.5776, 1133.491, 17.09678);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 154008, "", "d_velniasprison_51_4", -1030.155, 579.4398, 1013.535, 2.794117);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 154015, "", "d_velniasprison_51_4", -971.5966, 579.5776, 1234.439, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 154014, "", "d_velniasprison_51_4", -1076.654, 579.5776, 1193.555, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		character.Movement.MoveTo(new Position(-1068.67f, 589.9178f, 1367.97f));
		actors.Add(character);

		var mob4 = Shortcuts.AddMonster(0, 20025, "", "d_velniasprison_51_4", -1016.501, 579.4611, 996.8252, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 154014, "", "d_velniasprison_51_4", -1142.426, 579.4091, 989.7051, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 154015, "", "d_velniasprison_51_4", -916.3648, 579.5225, 1007.723, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 20025, "", "d_velniasprison_51_4", -1016.501, 579.4611, 996.8252, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 20025, "", "d_velniasprison_51_4", -972.566, 579.582, 1235.694, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 20025, "", "d_velniasprison_51_4", -1073.198, 579.5776, 1192.377, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 20025, "", "d_velniasprison_51_4", -913.7238, 579.5242, 1005.717, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 20025, "", "d_velniasprison_51_4", -1143.314, 579.408, 990.1407, 0);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 20025, "", "d_velniasprison_51_4", -1025.62, 579.4446, 1009.648, 0);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 6:
				break;
			case 18:
				//DRT_ACTOR_ATTACH_EFFECT("F_light056_blue", "TOP");
				break;
			case 19:
				//DRT_ACTOR_ATTACH_EFFECT("F_light056_blue", "TOP");
				break;
			case 24:
				break;
			case 25:
				break;
			case 27:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke043_green", "TOP");
				break;
			case 68:
				//DRT_ACTOR_ATTACH_EFFECT("I_shadowgaoler_dead_event_mash", "BOT");
				break;
			case 79:
				await track.Dialog.Msg("d_velniasprison_51_4_dlg_3");
				break;
			case 84:
				//DRT_ACTOR_ATTACH_EFFECT("F_light056_blue", "TOP");
				//DRT_ACTOR_ATTACH_EFFECT("F_light056_blue", "TOP");
				break;
			case 88:
				await track.Dialog.Msg("d_velniasprison_51_4_dlg_4");
				break;
			case 89:
				character.AddSessionObject(PropertyName.VPRISON514_MQ_01, 1);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
