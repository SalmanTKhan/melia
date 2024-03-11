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

[TrackScript("PILGRIM312_SQ_02_TRACK")]
public class PILGRIM312SQ02TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("PILGRIM312_SQ_02_TRACK");
		//SetMap("f_pilgrimroad_31_2");
		//CenterPos(-1628.01,220.88,-804.19);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 154050, "", "f_pilgrimroad_31_2", -1600.865, 220.8799, -840.1215, 0, "Peaceful");
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(-1574.422f, 220.8799f, -841.46f));
		actors.Add(character);

		var mob1 = Shortcuts.AddMonster(0, 57827, "", "f_pilgrimroad_31_2", -1576.933, 220.8799, -784.3599, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 58147, "", "f_pilgrimroad_31_2", -1247.619, 220.8799, -1022.218, 80.29411);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 58147, "", "f_pilgrimroad_31_2", -1319.769, 220.8799, -1034.622, 75.76923);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 58147, "", "f_pilgrimroad_31_2", -1206.326, 220.8799, -909.1053, 88.33334);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 58147, "", "f_pilgrimroad_31_2", -1259.66, 220.8799, -934.2886, 63.66667);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 58147, "", "f_pilgrimroad_31_2", -1222.687, 220.8799, -834.3104, 97.91666);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 58147, "", "f_pilgrimroad_31_2", -1334.701, 220.8799, -1092.656, 70.29411);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 20025, "", "f_pilgrimroad_31_2", -1626.426, 220.8799, -740.1891, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 12:
				break;
			case 16:
				break;
			case 17:
				break;
			case 18:
				//SetFixAnim("DOWN");
				break;
			case 19:
				break;
			case 20:
				break;
			case 44:
				//TRACK_SETTENDENCY();
				//CREATE_BATTLE_BOX_INLAYER(0);
				//TRACK_MON_LOOKAT();
				character.AddonMessage("NOTICE_Dm_!", "Defeat the incoming demons!", 3);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
