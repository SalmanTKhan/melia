//--- Melia Script -----------------------------------------------------------
// Cutting the Tail (3)
//--- Description -----------------------------------------------------------
// Quest to Talk with Member Irmantas.
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

[QuestScript(60046)]
public class Quest60046Script : QuestScript
{
	protected override void Load()
	{
		SetId(60046);
		SetName("Cutting the Tail (3)");
		SetDescription("Talk with Member Irmantas");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM311_SQ_03"));

		AddReward(new ExpReward(137160, 137160));
		AddReward(new ItemReward("expCard5", 4));
		AddReward(new ItemReward("Vis", 1640));
		AddReward(new ItemReward("Drug_SP2_Q", 30));

		AddDialogHook("PILGRIM311_IRMANTAS_02", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM311_GRAZINA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM311_SQ_04_01", "PILGRIM311_SQ_04", "Sure, I'll help", "Decline"))
		{
			case 1:
				dialog.HideNPC("PILGRIM311_GRAZINA");
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

