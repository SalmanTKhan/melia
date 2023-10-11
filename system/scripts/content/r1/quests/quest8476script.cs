//--- Melia Script -----------------------------------------------------------
// Goddess Gabija (6)
//--- Description -----------------------------------------------------------
// Quest to Talk to Grita.
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

[QuestScript(8476)]
public class Quest8476Script : QuestScript
{
	protected override void Load()
	{
		SetId(8476);
		SetName("Goddess Gabija (6)");
		SetDescription("Talk to Grita");

		AddPrerequisite(new LevelPrerequisite(113));
		AddPrerequisite(new CompletedPrerequisite("FTOWER41_MQ_03"));

		AddReward(new ExpReward(301560, 301560));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 2712));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 5));

		AddDialogHook("FTOWER41_G_AI", "BeforeStart", BeforeStart);
		AddDialogHook("FTOWER41_G_AI", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FTOWER41_MQ_04_01", "FTOWER41_MQ_04", "What should I do?", "Let's just get up there quickly!"))
		{
			case 1:
				await dialog.Msg("FTOWER41_MQ_04_AG");
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

		await dialog.Msg("FTOWER41_MQ_04_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("FTOWER41_MQ_05");
	}
}

