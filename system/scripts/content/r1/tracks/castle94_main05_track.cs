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

[TrackScript("CASTLE94_MAIN05_TRACK")]
public class CASTLE94MAIN05TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CASTLE94_MAIN05_TRACK");
		//SetMap("f_castle_94");
		//CenterPos(-945.15,289.92,1017.08);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-1024.938f, 289.9216f, 996.5706f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 151050, "", "f_castle_94", -1416, 289, 1000, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 153156, "UnvisibleName", "f_castle_94", -1366, 289, 950, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 153156, "UnvisibleName", "f_castle_94", -1466, 289, 950, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 153156, "UnvisibleName", "f_castle_94", -1366, 289, 1050, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 153156, "UnvisibleName", "f_castle_94", -1466, 289, 1050, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 154067, "", "f_castle_94", -1416, 289, 1000, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 154067, "", "f_castle_94", -1416, 289, 1000, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 154067, "", "f_castle_94", -1416, 289, 1000, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 22:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic009_blue", "BOT", 0);
				break;
			case 26:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic033_orange_line", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_buff_basic033_orange_line", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_buff_basic033_orange_line", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_buff_basic033_orange_line", "BOT", 0);
				break;
			case 27:
				//DRT_ACTOR_ATTACH_EFFECT("I_sphere007_mash", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_sphere007_mash", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_sphere007_mash", "BOT");
				break;
			case 34:
				CreateBattleBoxInLayer(character, track);
				//DRT_PLAY_MGAME("CASTLE94_MAIN05_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
