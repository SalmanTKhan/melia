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

[TrackScript("CHATHEDRAL53_SQ07_TRACK")]
public class CHATHEDRAL53SQ07TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CHATHEDRAL53_SQ07_TRACK");
		//SetMap("d_cathedral_53");
		//CenterPos(-1629.08,0.00,27.99);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-1629.92f, 0.0002708435f, 21.51679f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 147469, "", "d_cathedral_53", -1632.678, 0.0002708435, 49.48859, 50);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 57678, "", "d_cathedral_53", -1903.798, 0.0002708435, 22.46329, 36.17647);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 57678, "", "d_cathedral_53", -1517.398, 0.0002708435, 263.7518, 54.0625);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 57678, "", "d_cathedral_53", -1469.885, 0.0002744558, -114.495, 30);
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
				//DRT_ACTOR_PLAY_EFT("F_bg_light010_white_ornage_long2", "BOT", 0);
				break;
			case 12:
				character.AddonMessage("NOTICE_Dm_!", "Monsters have sensed the energy. Prepare for the wave!{nl}", 3);
				break;
			case 14:
				break;
			case 26:
				CreateBattleBoxInLayer(character, track);
				break;
			case 27:
				//DRT_PLAY_MGAME("CHATHEDRAL53_SQ07_TRACK_MINI");
				break;
			case 29:
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
