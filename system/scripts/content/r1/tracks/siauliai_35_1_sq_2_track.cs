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

[TrackScript("SIAULIAI_35_1_SQ_2_TRACK")]
public class SIAULIAI351SQ2TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("SIAULIAI_35_1_SQ_2_TRACK");
		//SetMap("f_siauliai_35_1");
		//CenterPos(-873.96,-79.45,147.90);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-950.0954f, -79.45325f, 195.9577f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 156024, "", "f_siauliai_35_1", -639.8842, -79.45325, 150.8929, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 57910, "", "f_siauliai_35_1", -736.5332, -79.45325, 122.7879, 12.85714);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 57910, "", "f_siauliai_35_1", -621.3864, -79.45325, 50.88815, 15);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 57912, "", "f_siauliai_35_1", -759.9324, -79.45325, 81.75961, 26.42857);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 57912, "", "f_siauliai_35_1", -651.5529, -79.45325, 34.34513, 20);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 57913, "", "f_siauliai_35_1", -773.0856, -79.45325, 167.1303, 17);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 57913, "", "f_siauliai_35_1", -582.3659, -79.45325, 43.61427, 9);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 5:
				//SetFixAnim("rest_ready");
				break;
			case 14:
				character.AddonMessage("NOTICE_Dm_scroll", "Drive the monster away{nl}and save the person in danger!", 10);
				break;
			case 18:
				CreateBattleBoxInLayer(character, track);
				break;
			case 19:
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
