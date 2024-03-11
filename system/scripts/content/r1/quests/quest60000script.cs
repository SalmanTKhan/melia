//--- Melia Script -----------------------------------------------------------
// A Place Unreachable (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Hasta.
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

[QuestScript(60000)]
public class Quest60000Script : QuestScript
{
	protected override void Load()
	{
		SetId(60000);
		SetName("A Place Unreachable (1)");
		SetDescription("Talk to Hasta");

		AddPrerequisite(new LevelPrerequisite(151));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 8));

		AddDialogHook("VELNIASP511_PORTAL_MAGE", "BeforeStart", BeforeStart);
		AddDialogHook("VELNIASP511_PORTAL_HAUBERK", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("VPRISON511_MQ_PRE_01_01", "VPRISON511_MQ_PRE_01", "I'll help you", "I won't deal with the demons"))
		{
			case 1:
				dialog.HideNPC("PORTAL_MAGE_HOVER");
				// Func/VELNIASP511_PORTAL_HAUBERK_SCR_01;
				await Task.Delay(3000);
				// Func/VELNIASP511_PORTAL_HAUBERK_SCR_02;
				await Task.Delay(1000);
				dialog.UnHideNPC("VELNIASP511_PORTAL_HAUBERK");
				await Task.Delay(500);
				// Func/VELNIASP511_PORTAL_HAUBERK_SCR_03;
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

		await dialog.Msg("VPRISON511_MQ_PRE_01_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

