//--- Melia Script -----------------------------------------------------------
// Large-Scale Search Operation (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Agent Larena.
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

[QuestScript(60101)]
public class Quest60101Script : QuestScript
{
	protected override void Load()
	{
		SetId(60101);
		SetName("Large-Scale Search Operation (3)");
		SetDescription("Talk to Agent Larena");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("SIAU11RE_MQ_02"));

		AddReward(new ExpReward(13430, 13430));
		AddReward(new ItemReward("expCard2", 1));
		AddReward(new ItemReward("Vis", 169));
		AddReward(new ItemReward("Drug_SP1_Q", 15));

		AddDialogHook("SIAULIAI11RE_RARENA", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI11RE_RARENA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAU11RE_MQ_03_01", "SIAU11RE_MQ_03", "I'll try to find them", "I don't think I can, because of the rain"))
		{
			case 1:
				character.AddonMessage(AddonMessage.NOTICE_Dm_Scroll, "Find the priests' traces with Jolly!{nl}If Jolly wanders too far from you, use the whistle to call it back.", 8);
				// Func/SIAU11RE_MQ_03_DOG_RUN;
				await Task.Delay(500);
				dialog.HideNPC("SIAU11RE_MQ_03_DOG");
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

