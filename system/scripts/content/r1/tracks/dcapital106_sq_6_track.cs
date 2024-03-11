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

[TrackScript("DCAPITAL106_SQ_6_TRACK")]
public class DCAPITAL106SQ6TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("DCAPITAL106_SQ_6_TRACK");
		//SetMap("f_dcapital_106");
		//CenterPos(-1113.48,187.71,1141.34);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-1113.478f, 187.7078f, 1141.336f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 57581, "", "f_dcapital_106", -1297.453, 193.768, 1104.666, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 154012, "", "f_dcapital_106", -1301.058, 193.768, 1032.454, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 59100, "", "f_dcapital_106", -1629.904, 193.768, 1050.999, 62.08333);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 59096, "", "f_dcapital_106", -1571.95, 193.768, 951.1688, 59.16666);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 59096, "", "f_dcapital_106", -1611.144, 193.768, 985.4003, 52.08333);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 59096, "", "f_dcapital_106", -1633.214, 193.7679, 1212.023, 70);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 59100, "", "f_dcapital_106", -1601.337, 193.768, 1142.463, 52.91666);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 59096, "", "f_dcapital_106", -1586.056, 193.768, 1203.412, 60.41666);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 20025, "", "f_dcapital_106", -1301.06, 193.77, 1032.45, 0);
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
			case 14:
				break;
			case 15:
				//DRT_PLAY_FORCE(0, 1, 2, "I_force003_green", "arrow_cast", "F_hit011_puple_light", "arrow_blow", "SLOW", 150, 0.5, 0, 5, 10, 0);
				break;
			case 23:
				break;
			case 24:
				//DRT_ACTOR_ATTACH_EFFECT("F_pattern014_ground_red_loop", "BOT");
				break;
			case 39:
				//TRACK_SETTENDENCY();
				CreateBattleBoxInLayer(character, track);
				//DRT_ACTOR_PLAY_EFT("F_buff_basic025_white_line_2", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_ground016_light", "BOT", 0);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
