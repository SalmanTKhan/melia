//--- Melia Script -----------------------------------------------------------
// Nightmare Seed
//--- Description -----------------------------------------------------------
// Quest to Talk to Ineta.
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

[QuestScript(60429)]
public class Quest60429Script : QuestScript
{
	protected override void Load()
	{
		SetId(60429);
		SetName("Nightmare Seed");
		SetDescription("Talk to Ineta");

		AddPrerequisite(new LevelPrerequisite(401));
		AddPrerequisite(new CompletedPrerequisite("PAYAUTA_EP11_11"), new CompletedPrerequisite("CASTLE98_MQ_8"));
		AddPrerequisite(new ItemPrerequisite("CASTLE98_MQ_7_ITEM", -100));

		AddReward(new ItemReward("Vis", 23028));

		AddDialogHook("CASTLE98_MQ_INETA_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("PAYAUTA_EP11_NPC_CITY_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CASTLE98_MQ_END_1", "CASTLE98_MQ_END", "I can think of someone, yes.", "I don't know"))
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

		await dialog.Msg("CASTLE98_MQ_END_3");
		// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
		dialog.HideNPC("CASTLE98_MQ_INETA_NPC");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

