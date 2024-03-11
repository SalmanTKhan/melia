//--- Melia Script -----------------------------------------------------------
// Swift Movement(2)
//--- Description -----------------------------------------------------------
// Quest to Check the Central Laboratory's Magic Source.
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

[QuestScript(60208)]
public class Quest60208Script : QuestScript
{
	protected override void Load()
	{
		SetId(60208);
		SetName("Swift Movement(2)");
		SetDescription("Check the Central Laboratory's Magic Source");

		AddPrerequisite(new LevelPrerequisite(308));
		AddPrerequisite(new CompletedPrerequisite("FIRETOWER691_SQ_1"));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 14168));

		AddDialogHook("FIRETOWER691_SQ_2_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("FIRETOWER691_SQ_2_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FIRETOWER691_SQ_2_1", "FIRETOWER691_SQ_2", "Collect", "Stop"))
		{
			case 1:
				dialog.UnHideNPC("FIRETOWER691_SQ_2_OBJ");
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

		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "The Central Laboratory's Magic Source has been activated");
		dialog.HideNPC("FIRETOWER691_SQ_2_OBJ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

