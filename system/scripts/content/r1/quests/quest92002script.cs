//--- Melia Script -----------------------------------------------------------
// Power Generator of Descend Arcade
//--- Description -----------------------------------------------------------
// Quest to Talk to Mulia.
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

[QuestScript(92002)]
public class Quest92002Script : QuestScript
{
	protected override void Load()
	{
		SetId(92002);
		SetName("Power Generator of Descend Arcade");
		SetDescription("Talk to Mulia");

		AddPrerequisite(new LevelPrerequisite(450));
		AddPrerequisite(new CompletedPrerequisite("EP12_2_D_DCAPITAL_108_MQ02"));

		AddReward(new ExpReward(2249869568, 2249869568));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 32));
		AddReward(new ItemReward("Vis", 27900));

		AddDialogHook("EP12_2_D_DCAPITAL_108_MQ02_GIRL", "BeforeStart", BeforeStart);
		AddDialogHook("RANGDAGIRL_FOLLOWNPC_CHAT_108", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP12_2_D_DCAPITAL_108_MQ03_DLG1", "EP12_2_D_DCAPITAL_108_MQ03", "I'll lead the way.", "It would be better to take some rest here."))
		{
			case 1:
				await dialog.Msg("FadeOutIN/2000");
				dialog.HideNPC("EP12_2_D_DCAPITAL_108_MQ01_MASTER");
				dialog.HideNPC("EP12_2_D_DCAPITAL_108_MQ02_GIRL");
				// Func/SCR_RANGDAGIRL108_SUMMON;
				// Func/SCR_RANGDAMASTER108_SUMMON;
				await dialog.Msg("EP12_2_D_DCAPITAL_108_MQ03_DLG2");
				// Func/SCR_DCAPITAL108_GUIDE;
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

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP12_2_D_DCAPITAL_108_MQ04");
	}
}

