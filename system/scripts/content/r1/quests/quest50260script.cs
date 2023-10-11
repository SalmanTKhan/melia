//--- Melia Script -----------------------------------------------------------
// Precious Object
//--- Description -----------------------------------------------------------
// Quest to Talk to Arghidas from the Dico Tomb Thieves.
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

[QuestScript(50260)]
public class Quest50260Script : QuestScript
{
	protected override void Load()
	{
		SetId(50260);
		SetName("Precious Object");
		SetDescription("Talk to Arghidas from the Dico Tomb Thieves");

		AddPrerequisite(new LevelPrerequisite(193));
		AddPrerequisite(new CompletedPrerequisite("FLASH59_SQ_13"));

		AddReward(new ItemReward("misc_scrollskulp", 1));

		AddDialogHook("FLASH63_HQ1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH64_KARRIAT", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FLASH63_HQ1_start1", "FLASH63_HQ1", "I'll deliver the things for you.", "I can't help you with that."))
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

		await dialog.Msg("FLASH63_HQ1_succ1");
		// Func/FLASH63_HQ1_AGREE_FUNC;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

