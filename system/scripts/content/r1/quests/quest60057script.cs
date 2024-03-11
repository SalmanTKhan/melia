//--- Melia Script -----------------------------------------------------------
// The Journey to Find Myself (7)
//--- Description -----------------------------------------------------------
// Quest to Talk to Demon Lord Hauberk.
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

[QuestScript(60057)]
public class Quest60057Script : QuestScript
{
	protected override void Load()
	{
		SetId(60057);
		SetName("The Journey to Find Myself (7)");
		SetDescription("Talk to Demon Lord Hauberk");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM312_SQ_06"));

		AddReward(new ExpReward(294852, 294852));
		AddReward(new ItemReward("expCard6", 6));
		AddReward(new ItemReward("Vis", 1760));

		AddDialogHook("PILGRIM312_HAUBERK_04", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM312_AGATAS_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM312_SQ_07_01", "PILGRIM312_SQ_07", "Alright", "Better do that yourself"))
		{
			case 1:
				dialog.HideNPC("PILGRIM312_PAPER_01");
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

