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

[TrackScript("BRACKEN43_4_SQ5_TRACK")]
public class BRACKEN434SQ5TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("BRACKEN43_4_SQ5_TRACK");
		//SetMap("f_bracken_43_4");
		//CenterPos(-268.90,102.24,-151.93);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-260.1114f, 102.2396f, -156.154f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 155046, "", "f_bracken_43_4", -245.3, 102.23, -156.9, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 47220, "UnvisibleName", "f_bracken_43_4", -222.08, 102.23, -139.76, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 155140, "", "f_bracken_43_4", -238.3984, 102.2396, -162.5264, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 155140, "UnvisibleName", "f_bracken_43_4", -210.4237, 102.2396, -155.1127, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 155140, "UnvisibleName", "f_bracken_43_4", -248.3052, 102.2396, -133.3514, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 1:
				//DRT_ACTOR_PLAY_EFT("F_smoke036_green", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_smoke036_green", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("F_smoke036_green", "BOT", 0);
				break;
			case 13:
				await track.Dialog.Msg("BRACKEN434_SUBQ3_DLG1");
				break;
			case 16:
				await track.Dialog.Msg("BRACKEN434_SUBQ3_DLG2");
				break;
			case 18:
				character.AddonMessage("NOTICE_Dm_scroll", "It looks like Priest Lintas is confusing humans as monsters because of the bracken spore.{nl}Stimulate him enough to make him regain consciousness.", 3);
				break;
			case 19:
				CreateBattleBoxInLayer(character, track);
				//TRACK_SETTENDENCY();
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
