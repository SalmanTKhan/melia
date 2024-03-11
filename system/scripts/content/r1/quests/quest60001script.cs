//--- Melia Script -----------------------------------------------------------
// A Place Unreachable (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Demon Lord Hauberk.
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

[QuestScript(60001)]
public class Quest60001Script : QuestScript
{
	protected override void Load()
	{
		SetId(60001);
		SetName("A Place Unreachable (2)");
		SetDescription("Talk to Demon Lord Hauberk");

		AddPrerequisite(new LevelPrerequisite(151));
		AddPrerequisite(new CompletedPrerequisite("VPRISON511_MQ_PRE_01"));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 8));

		AddDialogHook("VELNIASP511_PORTAL_HAUBERK", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("VPRISON511_MQ_PRE_02_01", "VPRISON511_MQ_PRE_02", "I will do that", "Decline"))
		{
			case 1:
				// Func/TO_VELNIASP511_PORTAL_MAGE_AI_PRE_SCR;
				await Task.Delay(100);
				// Func/TO_VELNIASP511_PORTAL_PC;
				dialog.HideNPC("VELNIASP511_PORTAL_HAUBERK");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("VPRISON511_MQ_01");
	}
}

