//--- Melia Script -----------------------------------------------------------
// Secret Trade (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Grave Robber Amanda.
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

[QuestScript(8856)]
public class Quest8856Script : QuestScript
{
	protected override void Load()
	{
		SetId(8856);
		SetName("Secret Trade (2)");
		SetDescription("Talk to Grave Robber Amanda");

		AddPrerequisite(new LevelPrerequisite(200));
		AddPrerequisite(new CompletedPrerequisite("FLASH64_MQ_01"));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 24));
		AddReward(new ItemReward("Vis", 7000));

		AddDialogHook("FLASH64_AMANDA", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH64_AMANDA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FLASH64_MQ_02_01", "FLASH64_MQ_02", "Leave it to me", "Decline"))
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

		await dialog.Msg("FLASH64_MQ_02_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

