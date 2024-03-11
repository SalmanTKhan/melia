//--- Melia Script -----------------------------------------------------------
// Open Sesame (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to unknown being.
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

[QuestScript(19112)]
public class Quest19112Script : QuestScript
{
	protected override void Load()
	{
		SetId(19112);
		SetName("Open Sesame (2)");
		SetDescription("Talk to unknown being");

		AddPrerequisite(new LevelPrerequisite(111));
		AddPrerequisite(new CompletedPrerequisite("KLAIPE_HQ_01"));

		AddObjective("kill0", "Kill 5 Mine Predator(s) or Mine Fire Mage(s)", new KillObjective(5, 57463, 57464));
		AddObjective("kill1", "Kill 10 Minos Mage(s) or Mine Vubbe Archer(s)", new KillObjective(10, 57730, 57703));

		AddDialogHook("KLAIPE_HQ_02_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("KLAIPE_HQ_02_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KLAIPE_HQ_02_ST", "KLAIPE_HQ_02", "I'll solve the riddle", "Ignore"))
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

		await dialog.Msg("KLAIPE_HQ_02_COMP");
		// Func/KLAIPE_HQ_01_DESTROY;
		await dialog.Msg("FadeOutIN/1500");
		dialog.HideNPC("KLAIPE_HQ_02_NPC");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

