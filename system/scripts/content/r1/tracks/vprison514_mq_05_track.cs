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

[TrackScript("VPRISON514_MQ_05_TRACK")]
public class VPRISON514MQ05TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("VPRISON514_MQ_05_TRACK");
		//SetMap("d_velniasprison_51_4");
		//CenterPos(-2061.88,444.30,777.02);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(-2114.261f, 444.2133f, 802.9097f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 154001, "UnvisibleName", "d_velniasprison_51_4", -2180.714, 441.1934, 790.7649, 9.411764);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 103013, "", "d_velniasprison_51_4", -2597.502, 415.4192, 762.0284, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 57581, "", "d_velniasprison_51_4", -2139.4, 443.6373, 792.7873, 10);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 154001, "UnvisibleName", "d_velniasprison_51_4", -2180.71, 441.19, 790.76, 72.5);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 154001, "UnvisibleName", "d_velniasprison_51_4", -2180.71, 441.19, 790.76, 17.64706);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 57827, "", "d_velniasprison_51_4", -2491.056, 408.6438, 948.615, 35.71429);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 20024, "", "d_velniasprison_51_4", -2497.337, 408.6438, 962.6229, 0);
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
			case 7:
				//DRT_ACTOR_ATTACH_EFFECT("F_buff_basic025_white_line", "BOT");
				break;
			case 8:
				//DRT_ACTOR_ATTACH_EFFECT("F_cleric_dodola_line", "BOT");
				break;
			case 11:
				//DRT_ACTOR_ATTACH_EFFECT("F_cleric_dodola_line", "BOT");
				break;
			case 15:
				//DRT_ACTOR_ATTACH_EFFECT("F_cleric_dodola_line", "BOT");
				break;
			case 37:
				//DRT_ACTOR_ATTACH_EFFECT("F_light055_black", "TOP");
				break;
			case 44:
				break;
			case 48:
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion098_dark_blue", "MID");
				break;
			case 51:
				//SetFixAnim("astd");
				break;
			case 63:
				//DRT_ACTOR_ATTACH_EFFECT("F_burstup001_dark", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_pattern008_explosion_mash_square", "BOT");
				break;
			case 64:
				//InsertHate(999);
				//DRT_SETHOOKMSGOWNER(0, 0);
				//InsertHate(999);
				//DRT_SETHOOKMSGOWNER(0, 1);
				break;
			case 66:
				character.AddonMessage("NOTICE_Dm_!", "Get Dionys!", 3);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
