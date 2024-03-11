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

[TrackScript("THORN21_MQ07_TRACK")]
public class THORN21MQ07TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("THORN21_MQ07_TRACK");
		//SetMap("d_thorn_21");
		//CenterPos(5403.65,333.20,-187.27);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 400901, "", "d_thorn_21", 5924.467, 333.2023, -196.0142, 45);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 47234, "계시", "d_thorn_21", 5984.543, 333.2123, -202.0941, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		character.Movement.MoveTo(new Position(5471.698f, 333.2023f, -191.2108f));
		actors.Add(character);

		var mob2 = Shortcuts.AddMonster(0, 12080, "", "d_thorn_21", 5447.176, 333.2123, -197.3077, 60);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 25:
				character.AddonMessage("NOTICE_Dm_!", "Cross here after drinking the Enhanced Thorn Flower Powder!", 3);
				break;
			case 26:
				//DRT_PLAY_MGAME("THORN21_MQ07_BOSS_BATTLE");
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
