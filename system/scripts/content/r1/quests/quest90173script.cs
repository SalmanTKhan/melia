//--- Melia Script -----------------------------------------------------------
// Suspicious Movement (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Linker Master.
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

[QuestScript(90173)]
public class Quest90173Script : QuestScript
{
	protected override void Load()
	{
		SetId(90173);
		SetName("Suspicious Movement (4)");
		SetDescription("Talk to the Linker Master");

		AddPrerequisite(new LevelPrerequisite(290));
		AddPrerequisite(new CompletedPrerequisite("LOWLV_EYEOFBAIGA_SQ_30"));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("misc_ore17", 2));
		AddReward(new ItemReward("Vis", 12180));

		AddDialogHook("JOB_2_LINKER_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_LINKER_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LOWLV_EYEOFBAIGA_SQ_40_ST", "LOWLV_EYEOFBAIGA_SQ_40", "How can I acquire them?", "Too complicated for me, sorry."))
		{
			case 1:
				await dialog.Msg("LOWLV_EYEOFBAIGA_SQ_40_AG");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("LOWLV_EYEOFBAIGA_SQ_40_ITEM", 4))
		{
			character.Inventory.RemoveItem("LOWLV_EYEOFBAIGA_SQ_40_ITEM", 4);
			await dialog.Msg("LOWLV_EYEOFBAIGA_SQ_40_SU");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

