//--- Melia Script -----------------------------------------------------------
// There is a Way (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Jane's Spirit.
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

[QuestScript(30026)]
public class Quest30026Script : QuestScript
{
	protected override void Load()
	{
		SetId(30026);
		SetName("There is a Way (2)");
		SetDescription("Talk to Jane's Spirit");

		AddPrerequisite(new LevelPrerequisite(197));
		AddPrerequisite(new CompletedPrerequisite("CATACOMB_02_SQ_02"));

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

		switch (await dialog.Select("CATACOMB_02_SQ_03_select", "CATACOMB_02_SQ_03", "Is there a way to obtain Valius' magical power?", "We need to find another way"))
		{
			case 1:
				await dialog.Msg("CATACOMB_02_SQ_03_agree");
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

		if (character.Inventory.HasItem("CATACOMB_02_SQ_03_ITEM", 1))
		{
			character.Inventory.RemoveItem("CATACOMB_02_SQ_03_ITEM", 1);
			await dialog.Msg("CATACOMB_02_SQ_03_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("CATACOMB_02_SQ_04");
	}
}

