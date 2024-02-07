using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.Scripting;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.Effects;
using Melia.Zone.World.Tracks;
using Yggdrasil.Logging;

[TrackScript("EP15_2_D_NICOPOLIS_2_MQ_6_TRACK")]
public class EP152DNICOPOLIS2MQ6TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP15_2_D_NICOPOLIS_2_MQ_6_TRACK");
		//SetMap("None");
		//CenterPos(52.47,0.50,856.17);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-6.996902f, 0.5f, 689.084f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 59810, "", "None", 13.80293, 0.5, 919.4171, 9);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 150237, "", "None", -59.58158, 0.5, 853.813, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 160151, "", "None", 27.44133, 0.5, 1127.537, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 160046, "", "None", 39.70169, 0.5, 1098.656, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 12082, "", "None", 13.17095, 0.5, 911.8975, 14.51613);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 12082, "", "None", -46.55367, 0.5, 843.9119, 70);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 12082, "", "None", 19.12365, 0.5, 912.299, 0);
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
				break;
			case 5:
				break;
			case 9:
				await track.Dialog.Msg("EP15_2_D_NICOPOLIS_2_MQ_6_DLG1");
				break;
			case 13:
				await track.Dialog.Msg("EP15_2_D_NICOPOLIS_2_MQ_6_DLG2");
				break;
			case 17:
				await track.Dialog.Msg("EP15_2_D_NICOPOLIS_2_MQ_6_DLG3");
				break;
			case 35:
				break;
			case 38:
				await track.Dialog.Msg("EP15_2_D_NICOPOLIS_2_MQ_6_DLG4");
				break;
			case 41:
				Send.ZC_NORMAL.Notice(character, "EP15_2_D_NICOPOLIS_2_MQ_6_DLG5", 3);
				break;
			case 62:
				break;
			case 80:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
