//--- Melia Script -----------------------------------------------------------
// Reliable Assistant
//--- Description -----------------------------------------------------------
// Quest to Talk to the Guide Owl Sculpture.
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

[QuestScript(30063)]
public class Quest30063Script : QuestScript
{
	protected override void Load()
	{
		SetId(30063);
		SetName("Reliable Assistant");
		SetDescription("Talk to the Guide Owl Sculpture");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("KATYN_12_MQ_03"));

		AddReward(new ExpReward(84420, 84420));
		AddReward(new ItemReward("expCard3", 2));
		AddReward(new ItemReward("Vis", 1159));

		AddDialogHook("KATYN_12_NPC_01", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN_12_NPC_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN_12_MQ_04_select", "KATYN_12_MQ_04", "Talk about Mardas", "It worries me too"))
		{
			case 1:
				await dialog.Msg("KATYN_12_MQ_04_agree");
				dialog.UnHideNPC("KATYN_12_NPC_02");
				dialog.HideNPC("KATYN_10_NPC_01_AFTER");
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


		return HookResult.Break;
	}
}

