//--- Melia Script -----------------------------------------------------------
// Outer Wall Post (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Pajauta.
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

[QuestScript(60405)]
public class Quest60405Script : QuestScript
{
	protected override void Load()
	{
		SetId(60405);
		SetName("Outer Wall Post (2)");
		SetDescription("Talk to Pajauta");

		AddPrerequisite(new LevelPrerequisite(380));
		AddPrerequisite(new CompletedPrerequisite("PAYAUTA_EP11_5"));

		AddReward(new ItemReward("expCard16", 1));

		AddDialogHook("PAYAUTA_EP11_NPC_201", "BeforeStart", BeforeStart);
		AddDialogHook("PAYAUTA_EP11_NPC_201", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PAYAUTA_EP11_6_1", "PAYAUTA_EP11_6", "Console them", "Wait and see"))
		{
			case 1:
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

		await dialog.Msg("PAYAUTA_EP11_6_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

