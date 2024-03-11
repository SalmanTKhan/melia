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

[TrackScript("ABBEY_35_3_SQ_4_TRACK")]
public class ABBEY353SQ4TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ABBEY_35_3_SQ_4_TRACK");
		//SetMap("d_abbey_35_3");
		//CenterPos(22.64,0.53,-286.43);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(6.801056f, -5.783938E-06f, -28.85306f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 20154, "마을", "d_abbey_35_3", -12.33185, -7.629395E-06, -212.3644, 0, "Our_Forces");
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 57974, "", "d_abbey_35_3", 6.620741, -7.629395E-06, 32.00001, 68.21429);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 57970, "", "d_abbey_35_3", 344.6721, 0.7295315, -252.9292, 106.7857);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 57972, "", "d_abbey_35_3", -367.9808, -7.629395E-06, -244.1949, 109.6429);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 20024, "", "d_abbey_35_3", 8.515015, -7.629395E-06, -215.2076, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 147311, "", "d_abbey_35_3", 8.374695, -7.629395E-06, -212.2074, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 147466, "", "d_abbey_35_3", 14.54971, -7.629395E-06, -222.5113, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 147311, "", "d_abbey_35_3", 11.01575, -7.629395E-06, -232.9734, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 147466, "", "d_abbey_35_3", -0.1458435, -7.629395E-06, -211.0663, 0);
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
				//DRT_ACTOR_ATTACH_EFFECT("F_fire038_loop", "BOT");
				break;
			case 13:
				//DRT_ACTOR_ATTACH_EFFECT("F_rize007", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_rize007", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_rize007", "BOT");
				break;
			case 14:
				character.AddonMessage("NOTICE_Dm_scroll", "Demons have appeared!", 3);
				break;
			case 20:
				await track.Dialog.Msg("ABBEY_35_3_SQ_4_TRACK_1");
				break;
			case 23:
				character.AddonMessage("NOTICE_Dm_scroll", "Protect the villagers from the demons!", 3);
				break;
			case 24:
				//TRACK_SETTENDENCY();
				//DRT_PLAY_MGAME("ABBEY_35_3_SQ_4_MINI");
				CreateBattleBoxInLayer(character, track);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
