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

[TrackScript("F_3CMLAKE262_SQ03_TRACK")]
public class F3CMLAKE262SQ03TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("F_3CMLAKE262_SQ03_TRACK");
		//SetMap("f_3cmlake_26_2");
		//CenterPos(-297.95,114.93,-1629.04);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-324.1355f, 114.9337f, -1686.292f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 153059, "", "f_3cmlake_26_2", -224, 114, -1561, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 153059, "", "f_3cmlake_26_2", -167, 114, -1840, 21.89189);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 153059, "", "f_3cmlake_26_2", -497, 111, -1822, 64.58333);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 153059, "", "f_3cmlake_26_2", -502, 114, -1632, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 20042, "", "f_3cmlake_26_2", -497, 111, -1822, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 20042, "", "f_3cmlake_26_2", -224, 114, -1561, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 20042, "", "f_3cmlake_26_2", -167, 114, -1840, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 20042, "", "f_3cmlake_26_2", -502, 114, -1632, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 151056, "", "f_3cmlake_26_2", -323, 114, -1732, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 47106, "", "f_3cmlake_26_2", -389, 111, -1800, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 47106, "", "f_3cmlake_26_2", -253, 114, -1792, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 47106, "", "f_3cmlake_26_2", -258, 111, -1669, 427.5);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 47106, "", "f_3cmlake_26_2", -390, 113, -1669, 0);
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 6:
				//DRT_ACTOR_PLAY_EFT("I_cylinder005_light_blue", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("I_cylinder005_light_blue", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("I_cylinder005_light_blue", "BOT", 0);
				//DRT_ACTOR_PLAY_EFT("I_cylinder005_light_blue", "BOT", 0);
				break;
			case 12:
				character.AddonMessage("NOTICE_Dm_Clear", "The defense mechanisms have been activated!", 3);
				break;
			case 14:
				//DRT_PLAY_MGAME("F_3CMLAKE262_SQ03_MINI");
				//CREATE_BATTLE_BOX_INLAYER(-30);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
