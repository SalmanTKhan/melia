//--- Melia Script -----------------------------------------------------------
// There is a Way (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Jane's Spirit.
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

[QuestScript(30025)]
public class Quest30025Script : QuestScript
{
	protected override void Load()
	{
		SetId(30025);
		SetName("There is a Way (1)");
		SetDescription("Talk to Jane's Spirit");

		AddPrerequisite(new LevelPrerequisite(197));
		AddPrerequisite(new CompletedPrerequisite("CATACOMB_02_SQ_01"));

		AddReward(new ExpReward(475886, 475886));
		AddReward(new ItemReward("expCard10", 4));
		AddReward(new ItemReward("Vis", 6107));

		AddDialogHook("CATACOMB_02_NPC_01", "BeforeStart", BeforeStart);
		AddDialogHook("CATACOMB_02_NPC_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CATACOMB_02_SQ_02_select", "CATACOMB_02_SQ_02", "We need to find a way to defeat Archon together", "I'll think a little more"))
		{
			case 1:
				await dialog.Msg("CATACOMB_02_SQ_02_agree");
				dialog.UnHideNPC("CATACOMB_02_BOOK_03");
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

		await dialog.Msg("CATACOMB_02_SQ_02_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("CATACOMB_02_SQ_03");
	}
}

