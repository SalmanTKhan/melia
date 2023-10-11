//--- Melia Script -----------------------------------------------------------
// Farmers in Danger
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

[QuestScript(70023)]
public class Quest70023Script : QuestScript
{
	protected override void Load()
	{
		SetId(70023);
		SetName("Farmers in Danger");
		SetDescription("Talk to Druid Martinek");

		AddPrerequisite(new LevelPrerequisite(152));
		AddPrerequisite(new CompletedPrerequisite("FARM49_2_MQ03"));

		AddReward(new ExpReward(426450, 426450));
		AddReward(new ItemReward("expCard8", 3));
		AddReward(new ItemReward("Vis", 4408));

		AddDialogHook("FARM492_MQ_04", "BeforeStart", BeforeStart);
		AddDialogHook("FARM492_MQ_04", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FARM49_2_MQ_04_1", "FARM49_2_MQ04", "I will rescue the people first", "About the Corruption in the Farm", "Ignore"))
		{
			case 1:
				await dialog.Msg("FARM49_2_MQ_04_2");
				dialog.UnHideNPC("FARM492_MQ_04_FARMER");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("FARM49_2_MQ_04_3");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("FARM49_2_MQ_04_5");
		dialog.HideNPC("FARM492_MQ_04_FARMER");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

