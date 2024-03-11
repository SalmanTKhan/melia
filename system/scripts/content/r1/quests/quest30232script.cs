//--- Melia Script -----------------------------------------------------------
// Inspect Inner Wall District 9 (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Liepa.
//---------------------------------------------------------------------------

using System.Threading.Tasks;
using Melia.Shared.Game.Const;
using Melia.Zone;
using Melia.Zone.Scripting;
using Melia.Zone.Scripting.Dialogues;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Quests;
using Melia.Zone.World.Quests.Objectives;
using Melia.Zone.World.Quests.Prerequisites;
using Melia.Zone.World.Quests.Rewards;

[QuestScript(30232)]
public class Quest30232Script : QuestScript
{
	protected override void Load()
	{
		SetId(30232);
		SetName("Inspect Inner Wall District 9 (2)");
		SetDescription("Talk to Kupole Liepa");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "CASTLE_20_2_SQ_2_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(282));
		AddPrerequisite(new CompletedPrerequisite("CASTLE_20_2_SQ_1"));

		AddObjective("kill0", "Kill 8 Akhlass Sensor(s)", new KillObjective(8, MonsterId.Aklascenser));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 11844));

		AddDialogHook("CASTLE_20_2_NPC_1", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CASTLE_20_2_SQ_2_select", "CASTLE_20_2_SQ_2", "I will go myself.", "I too hate monsters."))
		{
			case 1:
				await dialog.Msg("CASTLE_20_2_SQ_2_agree");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}
}

