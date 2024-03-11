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

[TrackScript("ABBEY_35_3_SQ_8_TRACK")]
public class ABBEY353SQ8TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ABBEY_35_3_SQ_8_TRACK");
		//SetMap("d_abbey_35_3");
		//CenterPos(12.24,-95.33,-1121.75);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(18.3695f, -88.0842f, -1022.892f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 156000, "", "d_abbey_35_3", -80.99303, -95.33443, -1209.028, 5.909091);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 20138, "마을", "d_abbey_35_3", -2.498276, -95.33443, -1177.652, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 20154, "마을", "d_abbey_35_3", -16.61148, -95.33443, -1267.957, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 20149, "마을", "d_abbey_35_3", -5.46155, -95.33443, -1220.936, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 153041, "", "d_abbey_35_3", -51.59954, -95.33443, -1165.62, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 40071, "", "d_abbey_35_3", 16.53296, -95.33443, -1438.184, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 20024, "", "d_abbey_35_3", -51.6, -95.33, -1165.62, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 20024, "", "d_abbey_35_3", -141.0078, -95.33443, -1073.417, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 20024, "", "d_abbey_35_3", -170.7211, -95.33443, -1123.824, 0);
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
			case 13:
				await track.Dialog.Msg("ABBEY_35_3_SQ_8_TRACK_1");
				break;
			case 17:
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke019_dark_loop", "BOT");
				break;
			case 29:
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion016_red", "MID");
				break;
			case 30:
				//DRT_ACTOR_ATTACH_EFFECT("I_smoke035_dark", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion043", "MID");
				//DRT_ACTOR_ATTACH_EFFECT("I_EventVab_mash", "TOP");
				//DRT_ACTOR_ATTACH_EFFECT("I_EventVab_mash", "TOP");
				//DRT_ACTOR_ATTACH_EFFECT("F_ground034_violet", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_smoke072_sviolet2", "MID");
				break;
			case 31:
				//DRT_ACTOR_ATTACH_EFFECT("I_EventVab02_mash", "BOT");
				break;
			case 33:
				//DRT_ACTOR_ATTACH_EFFECT("I_EventVab02_mash", "BOT");
				break;
			case 46:
				await track.Dialog.Msg("ABBEY_35_3_SQ_8_TRACK_2");
				break;
			case 56:
				await track.Dialog.Msg("ABBEY_35_3_SQ_8_TRACK_3");
				break;
			case 78:
				character.AddSessionObject(PropertyName.ABBEY_35_3_SQ_8, 1);
				break;
			case 79:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
