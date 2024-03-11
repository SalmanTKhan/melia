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

[TrackScript("ORCHARD_323_MQ_02_TRACK")]
public class ORCHARD323MQ02TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ORCHARD_323_MQ_02_TRACK");
		//SetMap("f_orchard_32_3");
		//CenterPos(-1005.44,0.87,-295.16);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 47236, "", "f_orchard_32_3", -775.5559, 0.8661499, -463.6187, 74.28571);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 58087, "Demon", "f_orchard_32_3", -865.2983, -47.51526, -631.691, 36.5, "Neutral");
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 58158, "", "f_orchard_32_3", -926.2305, -47.51526, -647.6411, 0, "Neutral");
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 58158, "", "f_orchard_32_3", -884.9162, -41.96634, -679.1328, 0, "Neutral");
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 58158, "", "f_orchard_32_3", -836.6243, -47.51526, -681.5814, 0, "Neutral");
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		character.Movement.MoveTo(new Position(-992.8618f, 0.8661499f, -302.8998f));
		actors.Add(character);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 10:
				break;
			case 19:
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_basic025_white_line", "BOT");
				break;
			case 20:
				break;
			case 21:
				break;
			case 22:
				break;
			case 35:
				await track.Dialog.Msg("ORCHARD_323_MQ_02_track_01");
				break;
			case 66:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
