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

[TrackScript("ZACHA4F_MQ_04_TRACK")]
public class ZACHA4FMQ04TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ZACHA4F_MQ_04_TRACK");
		//SetMap("d_zachariel_35");
		//CenterPos(11.10,-32.31,8.81);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(116.7951f, -27.0933f, 33.50465f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 47260, "", "d_zachariel_35", -26.7312, -27.0833, -33.67281, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 47260, "", "d_zachariel_35", 240.9034, -27.0833, -31.55409, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 47252, "", "d_zachariel_35", 108.1736, -27.0933, -28.39736, 0);
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
			case 1:
				character.AddonMessage("NOTICE_Dm_!", "Stop the Royal Mausoleum Guardian from destroying the Royal Mausoleum!", 5);
				break;
			case 2:
				//DRT_PLAY_MGAME("ZACHA4F_MQ_04_MINI");
				break;
			case 4:
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
