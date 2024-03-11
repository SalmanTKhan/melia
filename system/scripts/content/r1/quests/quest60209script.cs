//--- Melia Script -----------------------------------------------------------
// Swift Movement(3)
//--- Description -----------------------------------------------------------
// Quest to Check the Researcher Auditorium's Magic Source.
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

[QuestScript(60209)]
public class Quest60209Script : QuestScript
{
	protected override void Load()
	{
		SetId(60209);
		SetName("Swift Movement(3)");
		SetDescription("Check the Researcher Auditorium's Magic Source");

		AddPrerequisite(new LevelPrerequisite(308));
		AddPrerequisite(new CompletedPrerequisite("FIRETOWER691_SQ_2"));

		AddReward(new ExpReward(36303568, 36303568));
		AddReward(new ItemReward("expCard14", 2));
		AddReward(new ItemReward("Vis", 14168));

		AddDialogHook("FIRETOWER691_SQ_3_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("FIRETOWER691_SQ_3_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FIRETOWER691_SQ_3_1", "FIRETOWER691_SQ_3", "Collect", "It is useless"))
		{
			case 1:
				dialog.UnHideNPC("FIRETOWER691_SQ_3_OBJ");
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

		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "The Researcher Auditorium's Magic Source has been activated");
		dialog.HideNPC("FIRETOWER691_SQ_3_OBJ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

