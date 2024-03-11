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

[TrackScript("KATYN_45_3_SQ_3_TRACK")]
public class KATYN453SQ3TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("KATYN_45_3_SQ_3_TRACK");
		//SetMap("f_katyn_45_3");
		//CenterPos(7.85,26.91,235.51);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 107002, "", "f_katyn_45_3", 125.0031, 26.9143, 641.9097, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		character.Movement.MoveTo(new Position(-20.58401f, 26.9143f, 242.511f));
		actors.Add(character);

		var mob1 = Shortcuts.AddMonster(0, 48024, "", "f_katyn_45_3", 200.69, 26.91, 273.58, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 48023, "", "f_katyn_45_3", 163.44, 26.91, 342.01, 0.8974359);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 48021, "", "f_katyn_45_3", 125.15, 26.91, 428.57, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 20026, "", "f_katyn_45_3", -30.4674, 26.9143, 417.9697, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 20026, "", "f_katyn_45_3", -2.300621, 26.9143, 344.8998, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 20026, "", "f_katyn_45_3", -0.05523682, 26.9143, 256.6816, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 20026, "", "f_katyn_45_3", 13.2384, 26.9143, 498.257, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 20026, "", "f_katyn_45_3", 61.87866, 26.9143, 409.8159, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 20026, "", "f_katyn_45_3", 51.89551, 26.9143, 559.5919, 19.64286);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 20026, "", "f_katyn_45_3", -142.7998, 26.9143, 421.7282, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 20026, "", "f_katyn_45_3", 186.3098, 26.9143, 579.0988, 0);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 20026, "", "f_katyn_45_3", 113.662, 26.9143, 176.3596, 100);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 20026, "", "f_katyn_45_3", 51.41701, 26.9143, 621.4987, 186.4286);
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		var mob14 = Shortcuts.AddMonster(0, 20026, "", "f_katyn_45_3", 92.82762, 26.9143, 249.2053, 14.64286);
		mob14.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob14.AddEffect(new ScriptInvisibleEffect());
		mob14.Layer = character.Layer;
		actors.Add(mob14);

		var mob15 = Shortcuts.AddMonster(0, 20026, "", "f_katyn_45_3", 168.6953, 26.9143, 462.2449, 0);
		mob15.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob15.AddEffect(new ScriptInvisibleEffect());
		mob15.Layer = character.Layer;
		actors.Add(mob15);

		var mob16 = Shortcuts.AddMonster(0, 20026, "", "f_katyn_45_3", -54.72359, 26.9143, 479.129, 0);
		mob16.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob16.AddEffect(new ScriptInvisibleEffect());
		mob16.Layer = character.Layer;
		actors.Add(mob16);

		var mob17 = Shortcuts.AddMonster(0, 20026, "", "f_katyn_45_3", 78.89909, 26.9143, 508.7573, 30);
		mob17.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob17.AddEffect(new ScriptInvisibleEffect());
		mob17.Layer = character.Layer;
		actors.Add(mob17);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 1:
				//CREATE_BATTLE_BOX_INLAYER(0);
				break;
			case 7:
				break;
			case 29:
				character.AddonMessage("NOTICE_Dm_scroll", "Iltisworts are swarming all over Laukimo Vacant Lot. Deal with the Iltisworts!", 5);
				break;
			case 30:
				//TRACK_SETTENDENCY();
				Send.ZC_NORMAL.SetupCutscene(character, false, false, true);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
