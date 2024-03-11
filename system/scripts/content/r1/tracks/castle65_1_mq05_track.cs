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

[TrackScript("CASTLE65_1_MQ05_TRACK")]
public class CASTLE651MQ05TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CASTLE65_1_MQ05_TRACK");
		//SetMap("None");
		//CenterPos(63.77,63.68,432.77);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(313.8469f, 81.7554f, 231.8585f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 155094, "", "None", 328.53, 81.76, 196.95, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 155105, "", "None", 46.02, 81.76, 534.29, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 155116, "", "None", 46.02, 81.76, 534.29, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 155107, "", "None", 38.77, 81.76, 513.37, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 155107, "", "None", 61.42, 81.76, 519.42, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 155107, "", "None", 66.16, 81.76, 541.83, 0);
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
			case 14:
				//DRT_ACTOR_PLAY_EFT("F_buff_basic008_blue", "BOT", 1);
				break;
			case 15:
				//DRT_ACTOR_PLAY_EFT("F_circle006", "BOT", 1);
				break;
			case 17:
				//DRT_ACTOR_PLAY_EFT("F_circle006", "BOT", 1);
				break;
			case 19:
				//DRT_ACTOR_PLAY_EFT("F_explosion015", "BOT", 1);
				//DRT_ACTOR_PLAY_EFT("F_explosion012", "BOT", 1);
				//DRT_ACTOR_PLAY_EFT("F_circle006", "BOT", 1);
				break;
			case 20:
				//DRT_ACTOR_PLAY_EFT("F_buff_explosion_burst", "BOT", 1);
				//DRT_ACTOR_PLAY_EFT("F_explosion015", "BOT", 1);
				//DRT_ACTOR_PLAY_EFT("F_explosion012", "BOT", 1);
				break;
			case 21:
				//DRT_ACTOR_PLAY_EFT("F_explosion012", "BOT", 1);
				//DRT_ACTOR_PLAY_EFT("F_explosion015", "BOT", 1);
				//DRT_ACTOR_PLAY_EFT("F_buff_explosion_burst", "BOT", 1);
				break;
			case 22:
				//DRT_ACTOR_PLAY_EFT("F_buff_explosion_burst", "BOT", 1);
				break;
			case 23:
				//DRT_ACTOR_PLAY_EFT("F_explosion049_fire", "BOT", 1);
				break;
			case 24:
				//DRT_ACTOR_PLAY_EFT("F_buff_explosion_burst", "BOT", 1);
				break;
			case 25:
				//DRT_ACTOR_PLAY_EFT("F_explosion050_fire2", "BOT", 1);
				break;
			case 26:
				//DRT_ACTOR_PLAY_EFT("F_explosion012", "BOT", 1);
				break;
			case 27:
				//DRT_ACTOR_PLAY_EFT("F_explosion025", "BOT", 1);
				break;
			case 28:
				//DRT_ACTOR_PLAY_EFT("F_explosion050_fire", "BOT", 1);
				break;
			case 29:
				//DRT_ACTOR_PLAY_EFT("F_explosion049_fire", "BOT", 1);
				//DRT_ACTOR_PLAY_EFT("F_explosion041_smoke", "BOT", 1);
				break;
			case 30:
				//DRT_ACTOR_PLAY_EFT("F_explosion042_smoke", "BOT", 1);
				//DRT_ACTOR_PLAY_EFT("F_explosion050_fire2", "BOT", 1);
				break;
			case 31:
				//DRT_ACTOR_PLAY_EFT("F_explosion097", "BOT", 1);
				//DRT_ACTOR_PLAY_EFT("F_explosion081_smoke", "BOT", 1);
				break;
			case 32:
				break;
			case 33:
				//DRT_ACTOR_PLAY_EFT("F_smoke023_red", "BOT", 1);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
