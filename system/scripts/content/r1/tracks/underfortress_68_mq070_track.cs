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

[TrackScript("UNDERFORTRESS_68_MQ070_TRACK")]
public class UNDERFORTRESS68MQ070TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("UNDERFORTRESS_68_MQ070_TRACK");
		//SetMap("d_underfortress_68");
		//CenterPos(2559.92,444.03,-289.02);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(2559.925f, 444.0327f, -289.0224f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 153139, "", "d_underfortress_68", 2420.931, 379.672, 110.4462, 35);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 57895, "", "d_underfortress_68", 2282.385, 350.1288, 166.8452, 39);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 57896, "", "d_underfortress_68", 2349.026, 350.1288, 284.4192, 50);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 57895, "", "d_underfortress_68", 2297.986, 350.1288, 218.6443, 29);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 1:
				break;
			case 2:
				break;
			case 20:
				Send.ZC_NORMAL.Notice(character, "UNDER_68_MQ070_TRACK01", 3);
				break;
			case 38:
				character.AddonMessage("NOTICE_Dm_!", "Inform Amanda what you just witnessed", 3);
				break;
			case 39:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
