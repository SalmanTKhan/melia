//--- Melia Script -----------------------------------------------------------
// To the Stele Road
//--- Description -----------------------------------------------------------
// Quest to Head in the direction your compass is pointing on Stele Road.
//---------------------------------------------------------------------------

using System.Threading.Tasks;
using Melia.Shared.Tos.Const;
using Melia.Zone;
using Melia.Zone.Scripting;
using Melia.Zone.Scripting.Dialogues;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Quests;
using Melia.Zone.World.Quests.Objectives;
using Melia.Zone.World.Quests.Prerequisites;
using Melia.Zone.World.Quests.Rewards;

[QuestScript(91225)]
public class Quest91225Script : QuestScript
{
	protected override void Load()
	{
		SetId(91225);
		SetName("To the Stele Road");
		SetDescription("Head in the direction your compass is pointing on Stele Road");

		AddPrerequisite(new LevelPrerequisite(500));
		AddPrerequisite(new CompletedPrerequisite("EP16_1_PILGRIM_36_2_MQ14"));

		AddReward(new ExpReward(5699999744, 5699999744));
		AddReward(new ItemReward("Vis", 47586));

		AddDialogHook("MASTER_CHRONO", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_CHRONO", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP16_1_REMAINS_37_MQ15_NPC_DLG1", "EP16_1_REMAINS_37_MQ15"))
		{
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		dialog.UnHideNPC("GODDESS_DESPAIR_ISLAND");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

