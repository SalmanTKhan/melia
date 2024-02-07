using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.Scripting;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.Effects;
using Melia.Zone.World.Tracks;
using Yggdrasil.Logging;

[TrackScript("EP14_3LINE_TUTO_MQ_2_TRACK")]
public class EP143LINETUTOMQ2TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("EP14_3LINE_TUTO_MQ_2_TRACK");
		//SetMap("c_klaipe_castle");
		//CenterPos(1857.06,-157.39,-498.23);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 150238, "", "c_klaipe_castle", 1890.769, -157.3853, -461.3331, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(1892.711f, -157.3853f, -485.5441f));
		actors.Add(character);

		var mob1 = Shortcuts.AddMonster(0, 20061, "", "c_klaipe_castle", 1822.857, -157.3853, -465.4695, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 20063, "", "c_klaipe_castle", 1826.973, -157.3853, -486.2512, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 151092, "", "c_klaipe_castle", 1953.184, -157.3853, -461.8537, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 151093, "", "c_klaipe_castle", 1937.81, -157.3853, -470.5002, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 153109, "", "c_klaipe_castle", 1822.32, -157.3853, -584.3142, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 147407, "", "c_klaipe_castle", 1825.385, -157.3853, -566.1783, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 155022, "", "c_klaipe_castle", 1942.667, -157.3853, -515.0305, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 155021, "", "c_klaipe_castle", 1944.179, -157.3853, -537.8539, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 150290, "", "c_klaipe_castle", 1858.898, -125.8337, -422.8087, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 150290, "", "c_klaipe_castle", 1930.713, -125.8574, -421.2195, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 400101, "", "c_klaipe_castle", 1886.698, -157.3853, -570.3412, 0);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.Journal = false;
		mob11.Level = 440;
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 400101, "", "c_klaipe_castle", 1836.457, -157.3853, -505.6104, 0);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.Journal = false;
		mob12.Level = 440;
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 400101, "", "c_klaipe_castle", 1942.183, -157.3853, -502.8928, 0);
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.Journal = false;
		mob13.Level = 440;
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		var mob14 = Shortcuts.AddMonster(0, 400101, "", "c_klaipe_castle", 1920.938, -157.3853, -542.6207, 0);
		mob14.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob14.Journal = false;
		mob14.Level = 440;
		mob14.AddEffect(new ScriptInvisibleEffect());
		mob14.Layer = character.Layer;
		actors.Add(mob14);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 5:
				break;
			case 24:
				break;
			case 27:
				break;
			case 30:
				break;
			case 32:
				await track.Dialog.Msg("EP14_3LINE_TUTO_MQ_2_TRACK_DLG_2");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
