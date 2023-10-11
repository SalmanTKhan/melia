//--- Melia Script -----------------------------------------------------------
// The Journey to Find Myself (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Demon Lord Hauberk.
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

[QuestScript(60053)]
public class Quest60053Script : QuestScript
{
	protected override void Load()
	{
		SetId(60053);
		SetName("The Journey to Find Myself (2)");
		SetDescription("Talk to Demon Lord Hauberk");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM312_SQ_02"));

		AddObjective("collect0", "Collect 11 Shadow Essence(s)", new CollectItemObjective("PILGRIM312_SQ_03_ITEM", 11));
		AddDrop("PILGRIM312_SQ_03_ITEM", 10f, 58146, 58138, 58147);

		AddReward(new ExpReward(147426, 147426));
		AddReward(new ItemReward("expCard6", 4));
		AddReward(new ItemReward("Vis", 1760));

		AddDialogHook("PILGRIM312_HAUBERK_01", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM312_HAUBERK_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM312_SQ_03_01", "PILGRIM312_SQ_03", "Tell him that you will take care of it", "Tell him that the demons can't be trusted"))
		{
			case 1:
				await dialog.Msg("PILGRIM312_SQ_03_AG");
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

