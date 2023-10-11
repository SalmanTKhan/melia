//--- Melia Script -----------------------------------------------------------
// Old Seeds (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Druid Martinek.
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

[QuestScript(70026)]
public class Quest70026Script : QuestScript
{
	protected override void Load()
	{
		SetId(70026);
		SetName("Old Seeds (3)");
		SetDescription("Talk to Druid Martinek");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "FARM49_2_MQ07_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(152));
		AddPrerequisite(new CompletedPrerequisite("FARM49_2_MQ06"));
		AddPrerequisite(new ItemPrerequisite("FARM49_1_MQ05_ITEM", -100));

		AddReward(new ExpReward(426450, 426450));
		AddReward(new ItemReward("expCard8", 3));
		AddReward(new ItemReward("Vis", 4408));

		AddDialogHook("FARM492_MQ_04", "BeforeStart", BeforeStart);
		AddDialogHook("FARM493_MQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FARM49_2_MQ_07_1", "FARM49_2_MQ07"))
		{
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("FARM49_2_MQ_07_4");
		dialog.HideNPC("FARM492_MQ_04");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

