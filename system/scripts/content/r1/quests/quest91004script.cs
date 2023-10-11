//--- Melia Script -----------------------------------------------------------
// Alongside Assisters(3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Geraldasia..
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

[QuestScript(91004)]
public class Quest91004Script : QuestScript
{
	protected override void Load()
	{
		SetId(91004);
		SetName("Alongside Assisters(3)");
		SetDescription("Talk to Geraldasia.");

		AddPrerequisite(new LevelPrerequisite(100));
		AddPrerequisite(new CompletedPrerequisite("ASSISTOR_TUTO_02"));

		AddReward(new ItemReward("Ancient_CardBook_ALL", 1));

		AddDialogHook("NPC_JUNK_SHOP_KLAPEDA", "BeforeStart", BeforeStart);
		AddDialogHook("NPC_JUNK_SHOP_KLAPEDA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ASSISTOR_TUTO_DLG_07", "ASSISTOR_TUTO_03", "It's too difficult.", "Piece of cake."))
		{
			case 1:
				await dialog.Msg("ASSISTOR_TUTO_DLG_08");
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

		await dialog.Msg("ASSISTOR_TUTO_DLG_11");
		dialog.ShowHelp("TUTO_ASSISTOR_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

