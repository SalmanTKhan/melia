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

[TrackScript("CASTLE93_MAIN07_AFTER_TRACK")]
public class CASTLE93MAIN07AFTERTRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CASTLE93_MAIN07_AFTER_TRACK");
		//SetMap("f_castle_93");
		//CenterPos(215.64,291.67,-304.48);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(212.6525f, 291.6668f, -305.4107f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 156116, "Schaffenstar", "f_castle_93", 178.68, 291.67, -335.12, 0.6);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 155163, "", "f_castle_93", 152.99, 291.67, -143, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 156128, "", "f_castle_93", 196.09, 291.67, -271.16, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 156122, "", "f_castle_93", 149.47, 291.67, -442.7, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 156124, "", "f_castle_93", 121.63, 291.67, -509.53, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 156126, "", "f_castle_93", 154, 291, -389, 0.4761905);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 156129, "", "f_castle_93", 167, 291, -229, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 147468, "", "f_castle_93", 316, 291, -348, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 59219, "", "f_castle_93", -773.7806, 237.4194, -281.894, 55.55556);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 59219, "", "f_castle_93", -773.5831, 237.3717, -310.8127, 55.11111);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 59219, "", "f_castle_93", -809.6503, 241.8552, -279.1714, 56.11111);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 59219, "", "f_castle_93", -815.9127, 243.7877, -308.9359, 56.55556);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 59249, "", "f_castle_93", -857.8942, 258.6145, -282.521, 56.66667);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 59249, "", "f_castle_93", -852.7037, 256.4626, -313.1098, 56.66667);
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		var mob14 = Shortcuts.AddMonster(0, 59249, "", "f_castle_93", -897.1656, 272.2915, -281.0646, 58);
		mob14.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob14.AddEffect(new ScriptInvisibleEffect());
		mob14.Layer = character.Layer;
		actors.Add(mob14);

		var mob15 = Shortcuts.AddMonster(0, 59249, "", "f_castle_93", -898.6614, 272.4141, -309.605, 58.11111);
		mob15.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob15.AddEffect(new ScriptInvisibleEffect());
		mob15.Layer = character.Layer;
		actors.Add(mob15);

		var mob16 = Shortcuts.AddMonster(0, 59247, "", "f_castle_93", -932.2351, 284.5052, -279.7639, 58.77778);
		mob16.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob16.AddEffect(new ScriptInvisibleEffect());
		mob16.Layer = character.Layer;
		actors.Add(mob16);

		var mob17 = Shortcuts.AddMonster(0, 59247, "", "f_castle_93", -935.7434, 285.1916, -312.4382, 59);
		mob17.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob17.AddEffect(new ScriptInvisibleEffect());
		mob17.Layer = character.Layer;
		actors.Add(mob17);

		var mob18 = Shortcuts.AddMonster(0, 59247, "", "f_castle_93", -997.1577, 291.4138, -264.5431, 60.88889);
		mob18.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob18.AddEffect(new ScriptInvisibleEffect());
		mob18.Layer = character.Layer;
		actors.Add(mob18);

		var mob19 = Shortcuts.AddMonster(0, 59247, "", "f_castle_93", -999.3132, 291.4138, -297.0057, 60.77778);
		mob19.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob19.AddEffect(new ScriptInvisibleEffect());
		mob19.Layer = character.Layer;
		actors.Add(mob19);

		var mob20 = Shortcuts.AddMonster(0, 156134, "", "f_castle_93", 696.3284, 318.5967, -192.0775, 20.3125);
		mob20.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob20.AddEffect(new ScriptInvisibleEffect());
		mob20.Layer = character.Layer;
		actors.Add(mob20);

		var mob21 = Shortcuts.AddMonster(0, 156129, "", "f_castle_93", 714.8075, 315.0904, -165.7725, 27.26563);
		mob21.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob21.AddEffect(new ScriptInvisibleEffect());
		mob21.Layer = character.Layer;
		actors.Add(mob21);

		var mob22 = Shortcuts.AddMonster(0, 156125, "", "f_castle_93", 732.6624, 314.1304, -182.3322, 25.39063);
		mob22.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob22.AddEffect(new ScriptInvisibleEffect());
		mob22.Layer = character.Layer;
		actors.Add(mob22);

		var mob23 = Shortcuts.AddMonster(0, 156128, "", "f_castle_93", 762.4495, 305.6467, -163.1758, 28.90625);
		mob23.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob23.AddEffect(new ScriptInvisibleEffect());
		mob23.Layer = character.Layer;
		actors.Add(mob23);

		var mob24 = Shortcuts.AddMonster(0, 156127, "", "f_castle_93", 746.0699, 306.3957, -138.101, 25.78125);
		mob24.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob24.AddEffect(new ScriptInvisibleEffect());
		mob24.Layer = character.Layer;
		actors.Add(mob24);

		var mob25 = Shortcuts.AddMonster(0, 150180, "", "f_castle_93", 776.9279, 298.8392, -145.5117, 27.1875);
		mob25.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob25.AddEffect(new ScriptInvisibleEffect());
		mob25.Layer = character.Layer;
		actors.Add(mob25);

		var mob26 = Shortcuts.AddMonster(0, 59219, "", "f_castle_93", -215.9719, 291.6668, -327.6585, 0);
		mob26.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob26.AddEffect(new ScriptInvisibleEffect());
		mob26.Layer = character.Layer;
		actors.Add(mob26);

		var mob27 = Shortcuts.AddMonster(0, 59219, "", "f_castle_93", -232.6427, 291.6668, -253.8566, 0);
		mob27.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob27.AddEffect(new ScriptInvisibleEffect());
		mob27.Layer = character.Layer;
		actors.Add(mob27);

		var mob28 = Shortcuts.AddMonster(0, 59219, "", "f_castle_93", -219.5041, 291.6668, -231.7232, 0);
		mob28.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob28.AddEffect(new ScriptInvisibleEffect());
		mob28.Layer = character.Layer;
		actors.Add(mob28);

		var mob29 = Shortcuts.AddMonster(0, 59249, "", "f_castle_93", -217.0986, 291.6668, -357.51, 85);
		mob29.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob29.AddEffect(new ScriptInvisibleEffect());
		mob29.Layer = character.Layer;
		actors.Add(mob29);

		var mob30 = Shortcuts.AddMonster(0, 59249, "", "f_castle_93", -265.2404, 291.6668, -235.0438, 117);
		mob30.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob30.AddEffect(new ScriptInvisibleEffect());
		mob30.Layer = character.Layer;
		actors.Add(mob30);

		var mob31 = Shortcuts.AddMonster(0, 59249, "", "f_castle_93", -256.3175, 291.6668, -342.3222, 116);
		mob31.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob31.AddEffect(new ScriptInvisibleEffect());
		mob31.Layer = character.Layer;
		actors.Add(mob31);

		var mob32 = Shortcuts.AddMonster(0, 59247, "", "f_castle_93", -168.9395, 291.6668, -313.8152, 92.5);
		mob32.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob32.AddEffect(new ScriptInvisibleEffect());
		mob32.Layer = character.Layer;
		actors.Add(mob32);

		var mob33 = Shortcuts.AddMonster(0, 59247, "", "f_castle_93", -172.231, 291.6668, -259.5747, 108.75);
		mob33.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob33.AddEffect(new ScriptInvisibleEffect());
		mob33.Layer = character.Layer;
		actors.Add(mob33);

		var mob34 = Shortcuts.AddMonster(0, 59247, "", "f_castle_93", -174.6542, 291.6668, -290.3178, 115);
		mob34.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob34.AddEffect(new ScriptInvisibleEffect());
		mob34.Layer = character.Layer;
		actors.Add(mob34);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 43:
				break;
			case 94:
				await track.Dialog.Msg("CASTLE93_MAIN07_02");
				break;
			case 121:
				break;
			case 124:
				break;
			case 129:
				break;
			case 134:
				break;
			case 216:
				//DRT_FUNC_ACT("SCR_CASTLE93_MAIN07_TRACK_END");
				break;
			case 219:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
