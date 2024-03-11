//--- Melia Script -----------------------------------------------------------
// First Step
//--- Description -----------------------------------------------------------
// Quest to Talk to Pajauta.
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

[QuestScript(60410)]
public class Quest60410Script : QuestScript
{
	protected override void Load()
	{
		SetId(60410);
		SetName("First Step");
		SetDescription("Talk to Pajauta");

		AddPrerequisite(new LevelPrerequisite(380));
		AddPrerequisite(new CompletedPrerequisite("PAYAUTA_EP11_10"));

		AddReward(new ItemReward("card_payawoota", 1));

		AddDialogHook("PAYAUTA_EP11_NPC_232_2", "BeforeStart", BeforeStart);
		AddDialogHook("PAYAUTA_EP11_NPC_CITY_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PAYAUTA_EP11_11_1", "PAYAUTA_EP11_11", "I will follow soon", "Please wait"))
		{
			case 1:
				await dialog.Msg("FadeOutIN/3000");
				dialog.HideNPC("PAYAUTA_EP11_NPC_232_2");
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

		await dialog.Msg("PAYAUTA_EP11_11_3");
		// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

