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

[TrackScript("ABBEY_35_4_SQ_7_TRACK")]
public class ABBEY354SQ7TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ABBEY_35_4_SQ_7_TRACK");
		//SetMap("d_abbey_35_4");
		//CenterPos(531.83,67.99,-1189.12);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(531.8346f, 67.9936f, -1189.119f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 156000, "", "d_abbey_35_4", 261.9628, 67.9936, -1184.952, 0);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 20025, "UnvisibleName", "d_abbey_35_4", 341.8055, 67.9936, -1183.923, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 58428, "", "d_abbey_35_4", 360.1924, 67.9936, -1192.812, 30);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 20025, "UnvisibleName", "d_abbey_35_4", 213.6949, 67.9936, -1185.863, 0);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 156029, "UnvisibleName", "d_abbey_35_4", 369.9378, 67.9936, -1233.767, 0, "Neutral");
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 156029, "UnvisibleName", "d_abbey_35_4", 407.9806, 67.9936, -1123.12, 0, "Neutral");
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 156029, "UnvisibleName", "d_abbey_35_4", 316.046, 67.9936, -1217.07, 0, "Neutral");
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 156029, "UnvisibleName", "d_abbey_35_4", 391.5643, 67.9936, -1272.658, 0, "Neutral");
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 156029, "UnvisibleName", "d_abbey_35_4", 276.5338, 67.9936, -1294.271, 45, "Neutral");
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 156029, "UnvisibleName", "d_abbey_35_4", 281.351, 67.9936, -1117.861, 0, "Neutral");
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 156029, "UnvisibleName", "d_abbey_35_4", 325.5785, 67.9936, -1165.094, 0, "Neutral");
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 156029, "UnvisibleName", "d_abbey_35_4", 377.1158, 67.9936, -1158.994, 0, "Neutral");
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 156029, "UnvisibleName", "d_abbey_35_4", 396.9636, 67.9936, -1197.8, 0, "Neutral");
		mob12.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob12.AddEffect(new ScriptInvisibleEffect());
		mob12.Layer = character.Layer;
		actors.Add(mob12);

		var mob13 = Shortcuts.AddMonster(0, 156029, "UnvisibleName", "d_abbey_35_4", 340.7088, 67.9936, -1191.414, 0, "Neutral");
		mob13.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob13.AddEffect(new ScriptInvisibleEffect());
		mob13.Layer = character.Layer;
		actors.Add(mob13);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 4:
				break;
			case 5:
				break;
			case 7:
				break;
			case 8:
				break;
			case 10:
				//DRT_ACTOR_ATTACH_EFFECT("F_ground134_red_loop2", "BOT");
				break;
			case 12:
				await track.Dialog.Msg("ABBEY_35_4_SQ_7_TRACK_1");
				break;
			case 13:
				break;
			case 14:
				await track.Dialog.Msg("ABBEY_35_4_SQ_7_TRACK_2");
				break;
			case 15:
				break;
			case 16:
				//DRT_ACTOR_ATTACH_EFFECT("F_circle25_red", "BOT");
				break;
			case 17:
				break;
			case 30:
				//DRT_ACTOR_PLAY_EFT("F_explosion047_red", "BOT", 0);
				break;
			case 33:
				//DRT_ACTOR_ATTACH_EFFECT("F_light096_red_loop2", "MID");
				break;
			case 40:
				character.AddonMessage("NOTICE_Dm_scroll", "Glutton has appeared from the magic circle of Dominikas!{nl}Defeat Dominikas!", 5);
				break;
			case 43:
				//TRACK_SETTENDENCY();
				//DRT_ACTOR_ATTACH_EFFECT("F_explosion004_violet", "BOT");
				//DRT_ACTOR_ATTACH_EFFECT("I_vine_event_dead_mash", "BOT");
				break;
			case 44:
				CreateBattleBoxInLayer(character, track);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
