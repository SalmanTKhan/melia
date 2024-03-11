//--- Melia Script -----------------------------------------------------------
// His Only Desire (1)
//--- Description -----------------------------------------------------------
// Quest to Talk with Demon Svitrigaila.
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

[QuestScript(40870)]
public class Quest40870Script : QuestScript
{
	protected override void Load()
	{
		SetId(40870);
		SetName("His Only Desire (1)");
		SetDescription("Talk with Demon Svitrigaila");

		AddPrerequisite(new LevelPrerequisite(207));
		AddPrerequisite(new CompletedPrerequisite("FLASH_58_SQ_010"));

		AddReward(new ExpReward(475886, 475886));
		AddReward(new ItemReward("expCard10", 4));
		AddReward(new ItemReward("Vis", 7245));

		AddDialogHook("FLASH_58_SVTRIGAILA", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH_58_SVTRIGAILA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FLASH_58_SQ_020_ST", "FLASH_58_SQ_020", "I'll cooperate", "About The Reason Behind His Deathwish", "I can't help the demons"))
		{
			case 1:
				await dialog.Msg("FLASH_58_SQ_020_AC");
				// Func/SCR_FLASH_58_SQ_010_COLLECTOR_DEBUFF_REMOVE;
				// Func/SCR_FLASH_58_SQ_010_STAMINA_BACK;
				// Func/SCR_FLASH_58_SQ_010_PC_EFFECT;
				character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "The curse has been released");
				dialog.UnHideNPC("FLASH_58_GRASS");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("FLASH_58_SQ_020_ADD");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("FLASH_58_SQ_020_COMP");
		await Task.Delay(100);
		await dialog.Msg("NPCAin/FLASH_58_SVTRIGAILA/SKL3/0");
		await Task.Delay(1000);
		await dialog.Msg("FLASH_58_SQ_020_COMP_2");
		dialog.HideNPC("FLASH_58_GRASS");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("FLASH_58_SQ_030");
	}
}

