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

[TrackScript("CORAL_32_1_SQ_6_TRACK")]
public class CORAL321SQ6TRACK : TrackScript
{
	protected override void Load()
	{
		SetId("CORAL_32_1_SQ_6_TRACK");
		//SetMap("f_coral_32_1");
		//CenterPos(785.75,142.95,-553.58);
	}

	public override IActor[] OnStart(Character character, Track track)
	{
		base.OnStart(character, track);

		var actors = new List<IActor>();
		character.Movement.MoveTo(new Position(799.2601f, 142.9497f, -561.2481f));
		actors.Add(character);

		var mob0 = Shortcuts.AddMonster(0, 153141, "UnvisibleName", "f_coral_32_1", 816.6097, 142.9497, -539.7165, 0, "Neurtal");
		mob0.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob0.AddEffect(new ScriptInvisibleEffect());
		mob0.Layer = character.Layer;
		actors.Add(mob0);

		var mob1 = Shortcuts.AddMonster(0, 153141, "UnvisibleName", "f_coral_32_1", 771.5529, 142.9497, -529.8959, 0, "Neutral");
		mob1.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob1.AddEffect(new ScriptInvisibleEffect());
		mob1.Layer = character.Layer;
		actors.Add(mob1);

		var mob2 = Shortcuts.AddMonster(0, 10022, "Security Guard", "f_coral_32_1", 805.3177, 142.9497, -532.223, 11.42857, "Neutral");
		mob2.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob2.AddEffect(new ScriptInvisibleEffect());
		mob2.Layer = character.Layer;
		actors.Add(mob2);

		var mob3 = Shortcuts.AddMonster(0, 20118, "", "f_coral_32_1", 769.5388, 142.9497, -536.7662, 11.71875);
		mob3.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob3.AddEffect(new ScriptInvisibleEffect());
		mob3.Layer = character.Layer;
		actors.Add(mob3);

		var mob4 = Shortcuts.AddMonster(0, 10022, "Security Guard", "f_coral_32_1", 774.5209, 142.9497, -294.5049, 52.85714, "Neutral");
		mob4.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob4.AddEffect(new ScriptInvisibleEffect());
		mob4.Layer = character.Layer;
		actors.Add(mob4);

		var mob5 = Shortcuts.AddMonster(0, 10022, "Security Guard", "f_coral_32_1", 753.2069, 142.9497, -323.9405, 37.5, "Neutral");
		mob5.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob5.AddEffect(new ScriptInvisibleEffect());
		mob5.Layer = character.Layer;
		actors.Add(mob5);

		var mob6 = Shortcuts.AddMonster(0, 155118, "", "f_coral_32_1", 718.3566, 142.9497, -374.7722, 58.33333);
		mob6.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob6.AddEffect(new ScriptInvisibleEffect());
		mob6.Layer = character.Layer;
		actors.Add(mob6);

		var mob7 = Shortcuts.AddMonster(0, 107000, "", "f_coral_32_1", 963.8258, 142.9497, -373.8636, 25.83333);
		mob7.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob7.AddEffect(new ScriptInvisibleEffect());
		mob7.Layer = character.Layer;
		actors.Add(mob7);

		var mob8 = Shortcuts.AddMonster(0, 12082, "", "f_coral_32_1", 895.3594, 142.9497, -178.9422, 0);
		mob8.SetVisibilty(ActorVisibility.Track, character.ObjectId);
		mob8.AddEffect(new ScriptInvisibleEffect());
		mob8.Layer = character.Layer;
		actors.Add(mob8);

		return actors.ToArray();
	}

	public override async Task OnProgress(Character character, Track track, int frame)
	{
		switch (frame)
		{
			case 2:
				break;
			case 44:
				character.AddonMessage("NOTICE_Dm_!", "A strange scent has spread instantly!", 3);
				break;
			case 49:
				break;
			case 59:
				character.AddonMessage("NOTICE_Dm_!", "Defeat the Carapace who is attracted by the scent!", 3);
				break;
			case 63:
				CreateBattleBoxInLayer(character, track);
				break;
			case 64:
				//TRACK_SETTENDENCY();
				Send.ZC_NORMAL.SetupCutscene(character, false, false, true);
				break;
			default:
				Log.Warning("OnProgress: Unsupported frame {0} called from {1}.", frame, this.TrackId);
				break;
		}
		await base.OnProgress(character, track, frame);
	}

}
