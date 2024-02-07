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

[TrackScript("EP15_1_F_ABBEY_3_3_TRACK")]
public class EP151FABBEY33TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP15_1_F_ABBEY_3_3_TRACK");
		//SetMap("ep15_1_f_abbey_3");
		//CenterPos(-759.33,5.92,-711.92);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-805.4083f, 5.918015f, -674.7061f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 160154, "", "ep15_1_f_abbey_3", -845.0215, 5.918015, -732.723, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 160144, "", "ep15_1_f_abbey_3", -772.6815, 5.918015, -662.5452, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 59772, "", "ep15_1_f_abbey_3", -850.7036, 95.30366, -115.2995, 66.78571);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 59772, "", "ep15_1_f_abbey_3", -801.6584, 113.5198, -20.48921, 63.07693);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 59778, "", "ep15_1_f_abbey_3", -834.9621, 113.5198, 149.8837, 70.71429);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 59778, "", "ep15_1_f_abbey_3", -780.9678, 108.9084, -85.151, 91.92308);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 12082, "", "ep15_1_f_abbey_3", -822.677, 5.918012, -748.9602, 10.71429);
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
			case 3:
				break;
			case 10:
				//DRT_ACTOR_ATTACH_EFFECT("velcoffer_gimmick_prop_dead", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke065_2", "TOP");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke014_firesteam_dead2", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion007_pink", "TOP");
				break;
			case 13:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke065_2", "TOP");
				break;
			case 15:
				break;
			case 16:
				break;
			case 41:
				CreateBattleBoxInLayer(character, track);
				//DRT_PLAY_MGAME("EP15_1_F_ABBEY_3_3_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
