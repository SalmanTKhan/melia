//--- Melia Script -----------------------------------------------------------
// Sacred Tree of the Forest (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Guide Owl Sculpture.
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

[QuestScript(30062)]
public class Quest30062Script : QuestScript
{
	protected override void Load()
	{
		SetId(30062);
		SetName("Sacred Tree of the Forest (2)");
		SetDescription("Talk to the Guide Owl Sculpture");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("KATYN_12_MQ_02"));

		AddReward(new ExpReward(84420, 84420));
		AddReward(new ItemReward("KATYN_12_MQ_03_ITEM", 1));
		AddReward(new ItemReward("expCard3", 2));
		AddReward(new ItemReward("Vis", 1159));

		AddDialogHook("KATYN_12_NPC_01", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN_12_NPC_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN_12_MQ_03_select", "KATYN_12_MQ_03", "Take the branch and go", "Are you absolutely sure?"))
		{
			case 1:
				await dialog.Msg("KATYN_12_MQ_03_agree");
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

