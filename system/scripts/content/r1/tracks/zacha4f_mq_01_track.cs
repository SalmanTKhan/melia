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

[TrackScript("ZACHA4F_MQ_01_TRACK")]
public class ZACHA4FMQ01TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ZACHA4F_MQ_01_TRACK");
		//SetMap("d_zachariel_35");
		//CenterPos(920.13,-18.75,-1396.54);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(923.1392f, -18.7458f, -1401.23f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 41276, "", "d_zachariel_35", 775.6956, -53.6786, -1132.516, 33.88889);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 41276, "", "d_zachariel_35", 856.8217, -53.6786, -1017.234, 16.81818);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 41276, "", "d_zachariel_35", 890.0222, -53.6786, -1191.88, 35.71429);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 47256, "", "d_zachariel_35", 789.5924, -53.6686, -1190.206, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 47258, "", "d_zachariel_35", 891.4128, -53.6786, -1036.565, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 47257, "", "d_zachariel_35", 955.6788, -53.6786, -1188.251, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 401241, "", "d_zachariel_35", 841.0522, -53.6786, -1192.726, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 401241, "", "d_zachariel_35", 954.3442, -53.6786, -1121.72, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 401241, "", "d_zachariel_35", 826.9774, -53.6786, -1100.416, 0);
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
			case 2:
				break;
			case 11:
				break;
			case 13:
				break;
			case 15:
				//DRT_ACTOR_ATTACH_EFFECT("F_archer_pavise_shot_smoke", "BOT");
				break;
			case 17:
				//DRT_ACTOR_ATTACH_EFFECT("F_archer_pavise_shot_smoke", "BOT");
				//DRT_ACTOR_PLAY_EFT("F_wizard_BRIQUETTING_BORN_water2", "BOT", 0);
				break;
			case 20:
				//DRT_ACTOR_ATTACH_EFFECT("F_archer_pavise_shot_smoke", "BOT");
				break;
			case 24:
				//TRACK_SETTENDENCY();
				CreateBattleBoxInLayer(character, track);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
