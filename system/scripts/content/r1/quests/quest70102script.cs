//--- Melia Script -----------------------------------------------------------
// Relief Assistance
//--- Description -----------------------------------------------------------
// Quest to Talk to Senior Monk Potos.
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

[QuestScript(70102)]
public class Quest70102Script : QuestScript
{
	protected override void Load()
	{
		SetId(70102);
		SetName("Relief Assistance");
		SetDescription("Talk to Senior Monk Potos");

		AddPrerequisite(new LevelPrerequisite(173));
		AddPrerequisite(new CompletedPrerequisite("THORN39_2_MQ02"));

		AddReward(new ExpReward(628002, 628002));
		AddReward(new ItemReward("expCard9", 3));
		AddReward(new ItemReward("Vis", 5190));

		AddDialogHook("THORN392_MQ_03", "BeforeStart", BeforeStart);
		AddDialogHook("THORN392_MQ_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN39_2_MQ_03_1", "THORN39_2_MQ03", "Tell him that you will ask the Hunters", "About the circumstances at the monastery", "Tell him that you don't know how to do it"))
		{
			case 1:
				await dialog.Msg("THORN39_2_MQ_03_2");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("THORN39_2_MQ_03_1_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("THORN39_2_MQ_03_5");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

