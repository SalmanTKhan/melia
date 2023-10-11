//--- Melia Script -----------------------------------------------------------
// Genuine Goddess Statue (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Sculptor Tesla.
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

[QuestScript(19761)]
public class Quest19761Script : QuestScript
{
	protected override void Load()
	{
		SetId(19761);
		SetName("Genuine Goddess Statue (2)");
		SetDescription("Talk to Sculptor Tesla");

		AddPrerequisite(new LevelPrerequisite(129));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM51_SQ_4"));

		AddDialogHook("JOB_DIEVDIRBYS2_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM51_FGOD02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM51_SQ_4_0_ST", "PILGRIM51_SQ_4_0", "Go repair the Goddess Statue", "Stop it since it looks dangerous"))
		{
			case 1:
				await dialog.Msg("PILGRIM51_SQ_4_0_AC");
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

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("PILGRIM51_SQ_4_1");
	}
}

