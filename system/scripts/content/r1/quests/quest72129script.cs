//--- Melia Script -----------------------------------------------------------
// Guilty Conscience (2)
//--- Description -----------------------------------------------------------
// Quest to Find the Stolen Goods.
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

[QuestScript(72129)]
public class Quest72129Script : QuestScript
{
	protected override void Load()
	{
		SetId(72129);
		SetName("Guilty Conscience (2)");
		SetDescription("Find the Stolen Goods");

		AddPrerequisite(new LevelPrerequisite(45));
		AddPrerequisite(new CompletedPrerequisite("MASTER_SAPPER1_1"));

		AddDialogHook("JOB_SAPPER2_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("AKALABETH", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("JOB_SAPPER2_2_succ1");
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "Deliver the pouch from the Sapper Master to the Cleric Master!");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnStart(Character character, Quest quest)
	{
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "Give the Sappers Master's item to people of Klaipeda!");
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("MASTER_SAPPER1_3");
	}
}

