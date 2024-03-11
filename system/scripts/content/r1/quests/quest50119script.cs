//--- Melia Script -----------------------------------------------------------
// The Rescue (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Monk Goss.
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

[QuestScript(50119)]
public class Quest50119Script : QuestScript
{
	protected override void Load()
	{
		SetId(50119);
		SetName("The Rescue (3)");
		SetDescription("Talk to Monk Goss");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("ABBAY_64_1_MQ020"));

		AddObjective("collect0", "Collect 10 Green Apparition Essence(s)", new CollectItemObjective("ABBAY641_MQ3_ITEM01", 10));
		AddDrop("ABBAY641_MQ3_ITEM01", 10f, "Sec_Spector_Gh");

		AddReward(new ExpReward(126630, 126630));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("Vis", 675));

		AddDialogHook("ABBEY641_MONK02", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY641_MONK02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBAY_64_1_MQ030_startnpc01", "ABBAY_64_1_MQ030", "Is there a way to open the door?", "Can you tell me about the attack at the Novaha Monastery?", "We need to find another way"))
		{
			case 1:
				await dialog.Msg("ABBAY_64_1_MQ030_startnpc02");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("ABBAY_64_1_MQ030_ADD");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

