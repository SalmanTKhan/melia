//--- Melia Script -----------------------------------------------------------
// Disciple Laius' Circumstances
//--- Description -----------------------------------------------------------
// Quest to Talk to Disciple Laius.
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

[QuestScript(30001)]
public class Quest30001Script : QuestScript
{
	protected override void Load()
	{
		SetId(30001);
		SetName("Disciple Laius' Circumstances");
		SetDescription("Talk to Disciple Laius");

		AddPrerequisite(new LevelPrerequisite(188));

		AddReward(new ExpReward(475886, 475886));
		AddReward(new ItemReward("CATACOMB_38_2_SQ_02_ITEM", 1));
		AddReward(new ItemReward("expCard10", 4));
		AddReward(new ItemReward("Vis", 5828));

		AddDialogHook("CATACOMB_38_2_NPC_01", "BeforeStart", BeforeStart);
		AddDialogHook("CATACOMB_38_2_NPC_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CATACOMB_38_2_SQ_01_start", "CATACOMB_38_2_SQ_01", "I am going to help the research if you are okay with me", "Comfort him and leave"))
		{
			case 1:
				await dialog.Msg("CATACOMB_38_2_SQ_01_agree");
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

		if (character.Inventory.HasItem("CATACOMB_38_2_SQ_01_ITEM", 1))
		{
			character.Inventory.RemoveItem("CATACOMB_38_2_SQ_01_ITEM", 1);
			await dialog.Msg("CATACOMB_38_2_SQ_01_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("CATACOMB_38_2_SQ_02");
	}
}

