//--- Melia Script -----------------------------------------------------------
// In to the Lion's Mouth (10)
//--- Description -----------------------------------------------------------
// Quest to Talk to Monk Aistis.
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

[QuestScript(50353)]
public class Quest50353Script : QuestScript
{
	protected override void Load()
	{
		SetId(50353);
		SetName("In to the Lion's Mouth (10)");
		SetDescription("Talk to Monk Aistis");

		AddPrerequisite(new LevelPrerequisite(354));
		AddPrerequisite(new CompletedPrerequisite("ABBEY22_4_SQ9"));

		AddObjective("kill0", "Kill 20 Black Hohen Mage(s)", new KillObjective(20, MonsterId.Hohen_Mage_Black));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("Vis", 18054));
		AddReward(new ItemReward("expCard15", 1));

		AddDialogHook("ABBEY22_4_SUBQ10_NPC1", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY22_4_SUBQ10_NPC1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBEY22_4_SUBQ10_START1", "ABBEY22_4_SQ10", "I'll defeat the demons around here", "Let's leave it be."))
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

		await dialog.Msg("ABBEY22_4_SUBQ10_SUCC1");
		// Func/ABBEY22_4_SUBQ10_COMP;
		dialog.HideNPC("ABBEY22_4_SUBQ10_NPC1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

