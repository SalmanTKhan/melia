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

[TrackScript("ZACHA4F_MQ_02_TRACK")]
public class ZACHA4FMQ02TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ZACHA4F_MQ_02_TRACK");
		//SetMap("d_zachariel_35");
		//CenterPos(1116.63,-52.88,-312.33);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(1160.14f, -52.8668f, -397.0988f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 41276, "", "d_zachariel_35", 1126.101, -36.17266, -146.3085, 36);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 41276, "", "d_zachariel_35", 1195.547, -52.8768, -191.6837, 39.28571);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 41276, "", "d_zachariel_35", 1241.485, -22.7888, -88.06921, 53.75);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 41276, "", "d_zachariel_35", 1182.164, -22.7888, -103.1112, 30);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 47260, "", "d_zachariel_35", 1142.707, -22.7788, -39.49763, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 400841, "", "d_zachariel_35", 1267.219, -22.7888, -45.62124, 73.33333);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 400841, "", "d_zachariel_35", 1102.644, -22.7888, -74.18346, 26.66667);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 400841, "", "d_zachariel_35", 1171.751, -22.7888, -4.967113, 30);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 47252, "왕릉비석", "d_zachariel_35", 1161, -52, -292, 0);
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
			case 8:
				//DRT_ACTOR_ATTACH_EFFECT("F_hit_bad", "MID");
				break;
			case 12:
				//DRT_ACTOR_ATTACH_EFFECT("F_hit_bad", "BOT");
				break;
			case 13:
				break;
			case 14:
				//DRT_ACTOR_ATTACH_EFFECT("F_hit_bad", "BOT");
				break;
			case 15:
				break;
			case 16:
				break;
			case 19:
				CreateBattleBoxInLayer(character, track);
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
