//--- Melia Script -----------------------------------------------------------
// The Guardian's Jar (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Secret Guardian.
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

[QuestScript(8388)]
public class Quest8388Script : QuestScript
{
	protected override void Load()
	{
		SetId(8388);
		SetName("The Guardian's Jar (1)");
		SetDescription("Talk to the Secret Guardian");

		AddPrerequisite(new LevelPrerequisite(93));
		AddPrerequisite(new CompletedPrerequisite("ZACHA4F_MQ_05"));

		AddObjective("collect0", "Collect 8 Royal Mausoleum's Magic Source(s)", new CollectItemObjective("ZACHA5F_MQ_01_ITEM", 8));
		AddDrop("ZACHA5F_MQ_01_ITEM", 10f, "schlesien_darkmage");

		AddReward(new ExpReward(640130, 640130));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 68));
		AddReward(new ItemReward("Vis", 1860));

		AddDialogHook("ZACHARIEL_GUARDIAN", "BeforeStart", BeforeStart);
		AddDialogHook("ZACHARIEL_GUARDIAN", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ZACHA5F_MQ_01_01", "ZACHA5F_MQ_01", "I'll save the magic source of the Royal Mausoleum", "I'm not ready yet"))
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

		if (character.Inventory.HasItem("ZACHA5F_MQ_01_ITEM", 8))
		{
			character.Inventory.RemoveItem("ZACHA5F_MQ_01_ITEM", 8);
			await dialog.Msg("ZACHA5F_MQ_01_03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ZACHA5F_MQ_02");
	}
}

