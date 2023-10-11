//--- Melia Script -----------------------------------------------------------
// Legacy of the Royal Family (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Ahylas Jonas.
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

[QuestScript(20166)]
public class Quest20166Script : QuestScript
{
	protected override void Load()
	{
		SetId(20166);
		SetName("Legacy of the Royal Family (1)");
		SetDescription("Talk to Ahylas Jonas");

		AddPrerequisite(new LevelPrerequisite(58));
		AddPrerequisite(new CompletedPrerequisite("ROKAS24_KILL1"));

		AddReward(new ExpReward(42210, 42210));
		AddReward(new ItemReward("expCard3", 1));
		AddReward(new ItemReward("Vis", 1044));

		AddDialogHook("ROKAS24_ALCHEMIST", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS24_ALCHEMIST", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS24_MQ_1_select01", "ROKAS24_MQ_1", "I'll get the sap", "About obtaining the secret of the Great King", "I don't feel like it"))
		{
			case 1:
				await dialog.Msg("ROKAS24_MQ_1_startnpc01");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("ROKAS24_MQ_1_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("ROKAS24_MQ_1_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ROKAS24_MQ_2");
	}
}

