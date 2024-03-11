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

[TrackScript("CASTLE93_MAIN06_TRACK")]
public class CASTLE93MAIN06TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CASTLE93_MAIN06_TRACK");
		//SetMap("f_castle_93");
		//CenterPos(447.57,291.67,-482.73);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(442.966f, 291.6668f, -482.3147f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 156116, "Schaffenstar", "f_castle_93", 181.4832, 291.6668, -526.8291, 28.75);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 155163, "", "f_castle_93", 267, 291, -188, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 156128, "", "f_castle_93", 395, 291, -193, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 156122, "", "f_castle_93", 441, 291, -499, 50);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 156124, "", "f_castle_93", 143, 291, -487, 0);
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

		var mob7 = Shortcuts.AddMonster(0, 147468, "", "f_castle_93", 315.4277, 291.6668, -347.439, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 155165, "", "f_castle_93", -124, 291, 1027, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 150180, "", "f_castle_93", -50, 291, 1015, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 150179, "", "f_castle_93", -28, 291, 1067, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 147468, "", "f_castle_93", 21, 291, 1074, 0);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 156127, "", "f_castle_93", 387, 291, -1036, 0);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 156124, "", "f_castle_93", 402, 291, -1191, 0);
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		var mob14 = Shortcuts.AddMonster(0, 156122, "", "f_castle_93", 500, 291, -982, 0);
		mob14.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob14.AddEffect(new ScriptInvisibleEffect());
		mob14.Layer = character.Layer;
		actors.Add(mob14);

		var mob15 = Shortcuts.AddMonster(0, 156123, "", "f_castle_93", 611, 291, -1036, 158);
		mob15.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob15.AddEffect(new ScriptInvisibleEffect());
		mob15.Layer = character.Layer;
		actors.Add(mob15);

		var mob16 = Shortcuts.AddMonster(0, 147468, "", "f_castle_93", 584, 291, -1075, 0);
		mob16.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob16.AddEffect(new ScriptInvisibleEffect());
		mob16.Layer = character.Layer;
		actors.Add(mob16);

		var mob17 = Shortcuts.AddMonster(0, 156106, "", "f_castle_93", -232, 291, 1077, 0);
		mob17.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob17.AddEffect(new ScriptInvisibleEffect());
		mob17.Layer = character.Layer;
		actors.Add(mob17);

		var mob18 = Shortcuts.AddMonster(0, 156106, "", "f_castle_93", -202, 291, 1045, 0);
		mob18.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob18.AddEffect(new ScriptInvisibleEffect());
		mob18.Layer = character.Layer;
		actors.Add(mob18);

		var mob19 = Shortcuts.AddMonster(0, 156106, "", "f_castle_93", -175, 291, 1010, 0);
		mob19.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob19.AddEffect(new ScriptInvisibleEffect());
		mob19.Layer = character.Layer;
		actors.Add(mob19);

		var mob20 = Shortcuts.AddMonster(0, 156106, "", "f_castle_93", -135, 291, 1000, 0);
		mob20.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob20.AddEffect(new ScriptInvisibleEffect());
		mob20.Layer = character.Layer;
		actors.Add(mob20);

		var mob21 = Shortcuts.AddMonster(0, 156106, "", "f_castle_93", 3, 291, 997, 0);
		mob21.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob21.AddEffect(new ScriptInvisibleEffect());
		mob21.Layer = character.Layer;
		actors.Add(mob21);

		var mob22 = Shortcuts.AddMonster(0, 156106, "", "f_castle_93", 38, 291, 1020, 0);
		mob22.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob22.AddEffect(new ScriptInvisibleEffect());
		mob22.Layer = character.Layer;
		actors.Add(mob22);

		var mob23 = Shortcuts.AddMonster(0, 156106, "", "f_castle_93", 75, 291, 1049, 0);
		mob23.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob23.AddEffect(new ScriptInvisibleEffect());
		mob23.Layer = character.Layer;
		actors.Add(mob23);

		var mob24 = Shortcuts.AddMonster(0, 156106, "", "f_castle_93", 88, 291, 1090, 0);
		mob24.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob24.AddEffect(new ScriptInvisibleEffect());
		mob24.Layer = character.Layer;
		actors.Add(mob24);

		var mob25 = Shortcuts.AddMonster(0, 156106, "", "f_castle_93", -31.99998, 291, 981, 0);
		mob25.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob25.AddEffect(new ScriptInvisibleEffect());
		mob25.Layer = character.Layer;
		actors.Add(mob25);

		var mob26 = Shortcuts.AddMonster(0, 156106, "", "f_castle_93", 355, 291, -1181, 0);
		mob26.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob26.AddEffect(new ScriptInvisibleEffect());
		mob26.Layer = character.Layer;
		actors.Add(mob26);

		var mob27 = Shortcuts.AddMonster(0, 156106, "", "f_castle_93", 330, 291, -1223, 0);
		mob27.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob27.AddEffect(new ScriptInvisibleEffect());
		mob27.Layer = character.Layer;
		actors.Add(mob27);

		var mob28 = Shortcuts.AddMonster(0, 156106, "", "f_castle_93", 330, 291, -1311, 0);
		mob28.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob28.AddEffect(new ScriptInvisibleEffect());
		mob28.Layer = character.Layer;
		actors.Add(mob28);

		var mob29 = Shortcuts.AddMonster(0, 156106, "", "f_castle_93", 324, 291, -1268, 0);
		mob29.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob29.AddEffect(new ScriptInvisibleEffect());
		mob29.Layer = character.Layer;
		actors.Add(mob29);

		var mob30 = Shortcuts.AddMonster(0, 156106, "", "f_castle_93", 328, 291, -1040, 0);
		mob30.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob30.AddEffect(new ScriptInvisibleEffect());
		mob30.Layer = character.Layer;
		actors.Add(mob30);

		var mob31 = Shortcuts.AddMonster(0, 156106, "", "f_castle_93", 340, 291, -995, 0);
		mob31.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob31.AddEffect(new ScriptInvisibleEffect());
		mob31.Layer = character.Layer;
		actors.Add(mob31);

		var mob32 = Shortcuts.AddMonster(0, 156106, "", "f_castle_93", 351, 291, -1075, 0);
		mob32.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob32.AddEffect(new ScriptInvisibleEffect());
		mob32.Layer = character.Layer;
		actors.Add(mob32);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 79:
				//TRACK_BASICLAYER_MOVE();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
