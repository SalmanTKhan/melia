//--- Melia Script -----------------------------------------------------------
// Parias Forest Post (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Pajauta.
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

[QuestScript(60407)]
public class Quest60407Script : QuestScript
{
	protected override void Load()
	{
		SetId(60407);
		SetName("Parias Forest Post (1)");
		SetDescription("Talk to Pajauta");

		AddPrerequisite(new LevelPrerequisite(380));
		AddPrerequisite(new CompletedPrerequisite("PAYAUTA_EP11_7"));

		AddReward(new ItemReward("expCard16", 1));
		AddReward(new ItemReward("Vis", 20140));

		AddDialogHook("PAYAUTA_EP11_NPC_232", "BeforeStart", BeforeStart);
		AddDialogHook("PAYAUTA_EP11_NPC_232_FLLW", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PAYAUTA_EP11_8_1", "PAYAUTA_EP11_8", "Let's go.", "Please wait"))
		{
			case 1:
				await dialog.Msg("FadeOutIN/3000");
				dialog.HideNPC("PAYAUTA_EP11_NPC_232");
				// Func/PAJAUTA_FOLLOWNPC_LIB/PAYAUTA_EP11_8;
				dialog.UnHideNPC("PAYAUTA_EP11_8_OBJ_1");
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

		await dialog.Msg("PAYAUTA_EP11_8_3");
		dialog.HideNPC("PAYAUTA_EP11_8_OBJ_1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

