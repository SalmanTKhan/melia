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

[TrackScript("PILGRIM311_SQ_01_TRACK")]
public class PILGRIM311SQ01TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("PILGRIM311_SQ_01_TRACK");
		//SetMap("f_pilgrimroad_31_1");
		//CenterPos(-352.30,1.64,-366.28);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 154049, "", "f_pilgrimroad_31_1", -302.3263, 1.635254, -331.6739, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(-303.2296f, 1.635254f, -364.8453f));
		actors.Add(character);

		var mob1 = Shortcuts.AddMonster(0, 58144, "", "f_pilgrimroad_31_1", -697.8768, 1.635254, -344.3835, 61);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 58144, "", "f_pilgrimroad_31_1", -697.8462, 1.635254, -375.5426, 81);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 58144, "", "f_pilgrimroad_31_1", -666.6343, 1.635254, -405.3544, 53.82353);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 58144, "", "f_pilgrimroad_31_1", -697.5428, 1.635254, -435.2614, 51.94445);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 58144, "", "f_pilgrimroad_31_1", -695.0825, 1.635254, -472.6888, 55);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 58144, "", "f_pilgrimroad_31_1", -654.3561, 1.635254, -453.0574, 76.53847);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 58144, "", "f_pilgrimroad_31_1", -668.5292, 1.635254, -366.553, 64.61539);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 58144, "", "f_pilgrimroad_31_1", -671.1484, 1.635254, -323.2794, 75.76923);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 20025, "", "f_pilgrimroad_31_1", -288.7565, 1.635254, -331.669, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 8:
				//DRT_ACTOR_ATTACH_EFFECT("E_light", "BOT");
				break;
			case 18:
				break;
			case 20:
				break;
			case 21:
				break;
			case 23:
				break;
			case 34:
				//TRACK_MON_LOOKAT();
				//TRACK_SETTENDENCY();
				character.AddonMessage("NOTICE_Dm_!", "Defeat the demon pursuers!", 3);
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
