//--- Melia Script -----------------------------------------------------------
// Collect Antidote Sample
//--- Description -----------------------------------------------------------
// Quest to Talk to the Elder's Granddaughter.
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

[QuestScript(60166)]
public class Quest60166Script : QuestScript
{
	protected override void Load()
	{
		SetId(60166);
		SetName("Collect Antidote Sample");
		SetDescription("Talk to the Elder's Granddaughter");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("collect0", "Collect 7 Antidote Sample(s)", new CollectItemObjective("CM3LAKE83_RP_1_ITEM", 7));
		AddDrop("CM3LAKE83_RP_1_ITEM", 6f, "Sec_merog_wogu");

		AddReward(new ExpReward(8442, 8442));
		AddReward(new ItemReward("expCard3", 1));
		AddReward(new ItemReward("Vis", 1235));

		AddDialogHook("3CMLAKE_83_LADY", "BeforeStart", BeforeStart);
		AddDialogHook("3CMLAKE_83_LADY", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CM3LAKE83_RP_1_1", "CM3LAKE83_RP_1", "I'll help you", "I'm busy"))
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


		return HookResult.Break;
	}
}

