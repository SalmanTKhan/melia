//--- Melia Script -----------------------------------------------------------
// Special Necklace
//--- Description -----------------------------------------------------------
// Quest to Talk to Pilgrim Theophilis.
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

[QuestScript(19951)]
public class Quest19951Script : QuestScript
{
	protected override void Load()
	{
		SetId(19951);
		SetName("Special Necklace");
		SetDescription("Talk to Pilgrim Theophilis");

		AddPrerequisite(new LevelPrerequisite(133));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM52_SQ_090"));

		AddReward(new ItemReward("NECK01_136", 1));
		AddReward(new ItemReward("COLLECT_115", 1));

		AddDialogHook("PILGRIM52_NPC01", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM52_NPC01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM52_SQ_091_ST", "PILGRIM52_SQ_091", "Show the Succubus Eyes", "About the reason of concern", "I can't lose this precious thing so I refuse."))
		{
			case 1:
				await dialog.Msg("PILGRIM52_SQ_091_AC");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("PILGRIM52_SQ_091_ADD");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("PILGRIM52_SQ_091_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

