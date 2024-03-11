//--- Melia Script -----------------------------------------------------------
// A Solution to the Curse
//--- Description -----------------------------------------------------------
// Quest to Talk to the Royal Soldier Spirit.
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

[QuestScript(72224)]
public class Quest72224Script : QuestScript
{
	protected override void Load()
	{
		SetId(72224);
		SetName("A Solution to the Curse");
		SetDescription("Talk to the Royal Soldier Spirit");

		AddPrerequisite(new LevelPrerequisite(395));
		AddPrerequisite(new CompletedPrerequisite("CASTLE94_MAIN01"));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("CASTLE94_MAIN04_ITEM", 1));
		AddReward(new ItemReward("CASTLE94_MAIN07_ITEM", 1));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));

		AddDialogHook("CASTLE94_NPC_MAIN02", "BeforeStart", BeforeStart);
		AddDialogHook("EXORCIST_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CASTLE94_MAIN02_01", "CASTLE94_MAIN02", "Alright", "Yeah, yeah. See ya!"))
		{
			case 1:
				await dialog.Msg("CASTLE94_MAIN02_02");
				await dialog.Msg("BalloonText/CASTLE94_MAIN02_MONOLOG1/5");
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

		await dialog.Msg("CASTLE94_MAIN02_06");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

