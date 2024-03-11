//--- Melia Script -----------------------------------------------------------
// Portal Investigation (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Resistance Deputy Commander Kron.
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

[QuestScript(72176)]
public class Quest72176Script : QuestScript
{
	protected override void Load()
	{
		SetId(72176);
		SetName("Portal Investigation (3)");
		SetDescription("Talk to Resistance Deputy Commander Kron");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("expCard15", 3));
		AddReward(new ItemReward("Vis", 19344));

		AddDialogHook("D_STARTOWER_88_RESISTANCE_SUB_LEADER_KRON_02", "BeforeStart", BeforeStart);
		AddDialogHook("D_STARTOWER_88_RESISTANCE_SUB_LEADER_KRON_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("STARTOWER_88_MQ_40_DLG1", "STARTOWER_88_MQ_40", "Alright", "I need more time."))
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


		return HookResult.Break;
	}
}

