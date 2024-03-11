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

[TrackScript("F_MAPLE_24_3_MQ_08_TRACK")]
public class FMAPLE243MQ08TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_MAPLE_24_3_MQ_08_TRACK");
		//SetMap("f_maple_24_3");
		//CenterPos(-846.55,0.70,-1089.18);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-846.5546f, 0.6999969f, -1089.179f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 156105, "마력이", "f_maple_24_3", -874.8173, 0.6999969, -1023.299, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 154013, "", "f_maple_24_3", -879.1161, 0.6999969, -1082.232, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 59228, "", "f_maple_24_3", -293.9919, 0.6999969, -1221.739, 0);
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
				await track.Dialog.Msg("F_MAPLE_24_3_MQ_08_DLG1");
				break;
			case 23:
				await track.Dialog.Msg("F_MAPLE_24_3_MQ_08_DLG2");
				break;
			case 34:
				//DRT_PLAY_MGAME("F_MAPLE_24_3_MQ_08_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
