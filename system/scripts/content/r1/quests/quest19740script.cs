//--- Melia Script -----------------------------------------------------------
// Worship for the Blessing (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Priest Master.
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

[QuestScript(19740)]
public class Quest19740Script : QuestScript
{
	protected override void Load()
	{
		SetId(19740);
		SetName("Worship for the Blessing (3)");
		SetDescription("Talk to the Priest Master");

		AddPrerequisite(new LevelPrerequisite(129));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM51_SQ_2_1"));

		AddDialogHook("MASTER_PRIEST", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM51_SR02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM51_SQ_2_2_ST", "PILGRIM51_SQ_2_2", "I will purify the sanctum", "Give up on the purification since it looks dangerous"))
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

		ZoneServer.Instance.World.FindNPC("PILGRIM51_SR02")?.PlayEffectLocal(character.Connection, "I_cleric_devinestigma_force_dark", 1f, "BOT");
		await Task.Delay(1000);
		ZoneServer.Instance.World.FindNPC("PILGRIM51_SR02")?.PlayEffectLocal(character.Connection, "F_burstup001_blue", 0.7f, "BOT");
		await Task.Delay(500);
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "Purified the Sanctum!");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

