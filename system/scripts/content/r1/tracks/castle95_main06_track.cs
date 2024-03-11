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

[TrackScript("CASTLE95_MAIN06_TRACK")]
public class CASTLE95MAIN06TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CASTLE95_MAIN06_TRACK");
		//SetMap("f_castle_95");
		//CenterPos(1662.06,281.34,436.04);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(1603.116f, 281.3419f, 395.9002f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 156117, "", "f_castle_95", 1679, 281, 447, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 150180, "", "f_castle_95", 1568, 281, 444, 15);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 155163, "", "f_castle_95", 1576, 281, 338, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 155165, "", "f_castle_95", 1680, 281, 331, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 154067, "", "f_castle_95", 1626, 377, 1076, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 59268, "", "f_castle_95", 1627.585, 377.0311, 991.4717, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 40095, "", "f_castle_95", 1610.67, 279.02, 721.86, 20.52632);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 40095, "", "f_castle_95", 1573.71, 280.92, 664.3, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 40095, "", "f_castle_95", 1658.42, 280.23, 669.49, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 40095, "", "f_castle_95", 1616.74, 280.36, 623.51, 0);
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
			case 1:
				//DRT_ACTOR_ATTACH_EFFECT("F_circle25_red", "BOT");
				break;
			case 71:
				await track.Dialog.Msg("CASTLE95_MAIN06_02");
				break;
			case 78:
				break;
			case 93:
				await track.Dialog.Msg("CASTLE95_MAIN06_04");
				break;
			case 136:
				//DRT_ACTOR_PLAY_EFT("F_fire003_violet2", "BOT", 0);
				break;
			case 137:
				break;
			case 140:
				//DRT_ACTOR_PLAY_EFT("F_spin007_3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spin007_3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spin007_3", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_spin007_3", "BOT", 0);
				break;
			case 234:
				CreateBattleBoxInLayer(character, track);
				//TRACK_MON_LOOKAT();
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
