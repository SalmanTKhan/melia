//--- Melia Script -----------------------------------------------------------
// For Death (2)
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

[QuestScript(40900)]
public class Quest40900Script : QuestScript
{
	protected override void Load()
	{
		SetId(40900);
		SetName("For Death (2)");
		SetDescription("Talk with Demon Svitrigaila");

		AddPrerequisite(new LevelPrerequisite(207));
		AddPrerequisite(new CompletedPrerequisite("FLASH_58_SQ_040"));

		AddReward(new ExpReward(475886, 475886));
		AddReward(new ItemReward("expCard10", 4));
		AddReward(new ItemReward("FLASH_58_SQ_050_ITEM_3", 1));
		AddReward(new ItemReward("Vis", 7245));

		AddDialogHook("FLASH_58_SVTRIGAILA", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH_SOUL_COLLECTOR_S2_D", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FLASH_58_SQ_050_ST", "FLASH_58_SQ_050", "I will go collect some explosives", "I can only help so much"))
		{
			case 1:
				await dialog.Msg("FLASH_58_SQ_050_AC");
				// Func/FLASH_58_SQ_050_SVTRIGAILA_SHIELD;
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

		await dialog.Msg("CameraShockWaveLocal/2/99999/3/3/200/2");
		// Func/FLASH_58_SQ_050_PC_KNOCKBACK;
		ZoneServer.Instance.World.FindNPC("FLASH_SOUL_COLLECTOR_S2_D")?.PlayEffectLocal(character.Connection, "F_burstup002_dark", 2f, "BOT");
		ZoneServer.Instance.World.FindNPC("FLASH_SOUL_COLLECTOR_S2_D")?.PlayEffectLocal(character.Connection, "F_buff_explosion_burst", 2f, "BOT");
		dialog.HideNPC("FLASH_SOUL_COLLECTOR_S2_D");
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "The barrier stone has been destroyed due to a great explosion!");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

