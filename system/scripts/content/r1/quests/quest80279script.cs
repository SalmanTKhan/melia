//--- Melia Script -----------------------------------------------------------
// Reactivating the Water Facility (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Elder Ramunas.
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

[QuestScript(80279)]
public class Quest80279Script : QuestScript
{
	protected override void Load()
	{
		SetId(80279);
		SetName("Reactivating the Water Facility (2)");
		SetDescription("Talk to Elder Ramunas");

		AddPrerequisite(new LevelPrerequisite(366));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_86_SQ_01"));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("expCard15", 1));
		AddReward(new ItemReward("Vis", 19032));

		AddDialogHook("F_3CMLAKE_86_MQ_01_NPC_2", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_3CMLAKE_86_SQ_02_ST", "F_3CMLAKE_86_SQ_02", "Leave it to me.", "That seems difficult."))
		{
			case 1:
				await dialog.Msg("F_3CMLAKE_86_SQ_02_AFST");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}
}

