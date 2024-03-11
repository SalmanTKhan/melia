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

[TrackScript("THORN20_MQ02_TRACK")]
public class THORN20MQ02TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("THORN20_MQ02_TRACK");
		//SetMap("d_thorn_20");
		//CenterPos(20.12,558.86,89.78);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		var mob0 = Shortcuts.AddMonster(0, 400661, "", "d_thorn_20", -108.2958, 559.2428, 421.532, 65);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 41439, "", "d_thorn_20", -69.34314, 558.8649, 255.0953, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 41439, "", "d_thorn_20", 32.66872, 559.1187, 388.2769, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 41439, "", "d_thorn_20", -71.12878, 559.0524, 370.803, 3.636364);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 153019, "UnvisibleName", "d_thorn_20", -16.84008, 558.991, 314.3348, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 153029, "", "d_thorn_20", -12.97147, 558.9988, 310.3829, 0);
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
				//DRT_ACTOR_PLAY_EFT("F_ground122_dark", "BOT", 1);
				break;
			case 10:
				//DRT_ACTOR_ATTACH_EFFECT("I_cleric_skl_Ironskin1_mash", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_cleric_skl_Ironskin1_mash", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_cleric_skl_Ironskin1_mash", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("F_ground122_dark", "BOT");
				break;
			case 16:
				//DRT_ACTOR_ATTACH_EFFECT("I_cleric_skl_Ironskin1_mash", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_cleric_skl_Ironskin1_mash", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_cleric_skl_Ironskin1_mash", "BOT");
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
