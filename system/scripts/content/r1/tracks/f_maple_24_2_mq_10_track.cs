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

[TrackScript("F_MAPLE_24_2_MQ_10_TRACK")]
public class FMAPLE242MQ10TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_MAPLE_24_2_MQ_10_TRACK");
		//SetMap("f_maple_24_2");
		//CenterPos(-1361.72,11.09,-548.33);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 156158, "", "f_maple_24_2", -1371.001, 11.09299, -523.0507, 4.545455, "Our_Forces");
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(-1240.308f, 11.09299f, -528.7079f));
		actors.Add(character);

		var mob1 = Shortcuts.AddMonster(0, 59256, "", "f_maple_24_2", -1100.381, 11.09299, -461.5029, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 59256, "", "f_maple_24_2", -1054.626, 11.09299, -483.9995, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 59256, "", "f_maple_24_2", -1080.093, 11.09299, -525.4775, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 59256, "", "f_maple_24_2", -1036.244, 11.09299, -547.7348, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 59256, "", "f_maple_24_2", -1092.743, 11.09299, -395.3258, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 59256, "", "f_maple_24_2", -978.1279, 20.64224, -415.778, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 59256, "", "f_maple_24_2", -984.2882, 11.09299, -454.7412, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 3:
				await track.Dialog.Msg("F_MAPLE_242_10_TRACK_DLG_01");
				break;
			case 20:
				await track.Dialog.Msg("F_MAPLE_242_10_TRACK_DLG_02");
				break;
			case 29:
				//CREATE_BATTLE_BOX_INLAYER(0);
				//DRT_PLAY_MGAME("F_MAPLE_24_2_MQ_10_MINI");
				character.AddonMessage("NOTICE_Dm_scroll", "Protect Goddess Medeina from the oncoming demons!", 7);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
