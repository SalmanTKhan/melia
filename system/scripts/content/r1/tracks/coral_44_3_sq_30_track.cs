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

[TrackScript("CORAL_44_3_SQ_30_TRACK")]
public class CORAL443SQ30TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CORAL_44_3_SQ_30_TRACK");
		//SetMap("f_coral_44_3");
		//CenterPos(1428.10,92.36,244.77);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(1439.852f, 92.36217f, 232.5466f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 153118, "UnvisibleName", "f_coral_44_3", 1473.59, 92.36, 291.22, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 20026, "", "f_coral_44_3", 1273.413, 92.3622, 257.1252, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 20026, "", "f_coral_44_3", 1337.439, 92.36217, 161.1161, 98.88889);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 58290, "", "f_coral_44_3", 1452.593, 92.3622, 259.6265, 1.052632);
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
			case 7:
				//DRT_ACTOR_ATTACH_EFFECT("E_HUEVILLAGE_58_4_MQ11_potal_red", "BOT");
				break;
			case 9:
				//DRT_ACTOR_ATTACH_EFFECT("E_HUEVILLAGE_58_4_MQ11_potal_red", "BOT");
				break;
			case 19:
				CreateBattleBoxInLayer(character, track);
				character.AddonMessage("NOTICE_Dm_!", "The demons are coming through the portal", 5);
				//DRT_PLAY_MGAME("CORAL_44_3_SQ_30_MINI");
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
