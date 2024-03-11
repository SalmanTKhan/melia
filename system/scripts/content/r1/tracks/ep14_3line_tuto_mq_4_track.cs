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

[TrackScript("EP14_3LINE_TUTO_MQ_4_TRACK")]
public class EP143LINETUTOMQ4TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP14_3LINE_TUTO_MQ_4_TRACK");
		//SetMap("c_klaipe_castle");
		//CenterPos(1501.86,26.83,559.53);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(1497.522f, 26.97156f, 584.1078f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 150285, "", "c_klaipe_castle", 1498.61, 27.15005, 827.2811, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 150212, "", "c_klaipe_castle", 1490.131, 27.15005, 795.4388, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 150230, "", "c_klaipe_castle", 1514.301, 27.15005, 794.5102, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 150290, "", "c_klaipe_castle", 1473.819, 0.919632, 521.412, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 150290, "", "c_klaipe_castle", 1526.439, 0.919632, 524.7275, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 150286, "", "c_klaipe_castle", 1499.595, 27.15005, 663.3121, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 3:
				await track.Dialog.Msg("EP14_3LINE_TUTO_MQ_4_TRACK_DLG_2");
				break;
			case 35:
				await track.Dialog.Msg("EP14_3LINE_TUTO_MQ_4_TRACK_DLG_3");
				break;
			case 39:
				character.AddSessionObject(PropertyName.EP14_3LINE_TUTO_MQ_4, 1);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
