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

[TrackScript("ABBEY22_4_SQ1_TRACK")]
public class ABBEY224SQ1TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("ABBEY22_4_SQ1_TRACK");
		//SetMap("d_abbey_22_4");
		//CenterPos(1278.61,-4.13,1492.50);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(1279.708f, -4.131926f, 1492.801f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 155045, "", "d_abbey_22_4", 1283.18, -4.13, 1490.05, 82.30769);
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 47261, "UnvisibleName", "d_abbey_22_4", 547.77, 0.6400003, 1090.87, 0);
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var npc0 = Shortcuts.AddNpc(0, 47124, "UnvisibleName", "d_abbey_22_4", 549.95, 0.64, 1089.59, 0);
		npc0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		npc0.AddEffect(new ScriptInvisibleEffect());
		npc0.Layer = character.Layer;
		actors.Add(npc0);

		var mob2 = Shortcuts.AddMonster(0, 57840, "", "d_abbey_22_4", 440.6587, -11.92071, 1198.36, 0);
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 58737, "", "d_abbey_22_4", 551.5079, -11.92071, 1193.002, 24.64789);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 58851, "", "d_abbey_22_4", 575.1378, -11.92071, 1263.839, 0);
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 58857, "", "d_abbey_22_4", 527.2644, -11.92071, 1312.669, 0);
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 58857, "", "d_abbey_22_4", 606.8739, -11.92071, 1303.637, 0);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 58857, "", "d_abbey_22_4", 630.486, -11.92071, 1256.848, 0);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 58857, "", "d_abbey_22_4", 560.4367, -11.92071, 1345.739, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		var mob9 = Shortcuts.AddMonster(0, 58851, "", "d_abbey_22_4", 635.2358, -11.92071, 1195.859, 0);
		mob9.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob9.AddEffect(new ScriptInvisibleEffect());
		mob9.Layer = character.Layer;
		actors.Add(mob9);

		var mob10 = Shortcuts.AddMonster(0, 58857, "", "d_abbey_22_4", 690.7192, -11.92071, 1181.272, 0);
		mob10.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob10.AddEffect(new ScriptInvisibleEffect());
		mob10.Layer = character.Layer;
		actors.Add(mob10);

		var mob11 = Shortcuts.AddMonster(0, 58857, "", "d_abbey_22_4", 674.8474, -11.92071, 1235.471, 0);
		mob11.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob11.AddEffect(new ScriptInvisibleEffect());
		mob11.Layer = character.Layer;
		actors.Add(mob11);

		var mob12 = Shortcuts.AddMonster(0, 58857, "", "d_abbey_22_4", 664.67, -11.92071, 1157.903, 0);
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
			case 27:
				await track.Dialog.Msg("ABBEY22_4_HAUBERK_DLG1");
				break;
			case 38:
				await track.Dialog.Msg("ABBEY22_4_HAUBERK_DLG2");
				break;
			case 49:
				await track.Dialog.Msg("ABBEY22_4_HAUBERK_DLG3");
				break;
			case 70:
				await track.Dialog.Msg("ABBEY22_4_HAUBERK_DLG4");
				break;
			case 81:
				await track.Dialog.Msg("ABBEY22_4_SUBQ1_NPC1_DLG1");
				break;
			case 83:
				character.AddonMessage("NOTICE_Dm_Clear", "Hauberk scouts wish to destroy Agailla Flurry's equipment{nl}Defeat the scouts in order to protect the equipment", 5);
				break;
			case 84:
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
