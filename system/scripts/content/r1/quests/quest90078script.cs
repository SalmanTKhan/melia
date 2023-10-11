//--- Melia Script -----------------------------------------------------------
// Winning Favors (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Loremaster Daroul.
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

[QuestScript(90078)]
public class Quest90078Script : QuestScript
{
	protected override void Load()
	{
		SetId(90078);
		SetName("Winning Favors (1)");
		SetDescription("Talk to Loremaster Daroul");

		AddPrerequisite(new LevelPrerequisite(235));
		AddPrerequisite(new CompletedPrerequisite("CORAL_32_2_SQ_9"));

		AddObjective("kill0", "Kill 8 Blue Colimen(s) or Red Lepusbunny(s) or Red Lepusbunny Assassin(s)", new KillObjective(8, 57947, 57888, 57892));

		AddReward(new ExpReward(985061, 985061));
		AddReward(new ItemReward("Vis", 8460));
		AddReward(new ItemReward("expCard12", 3));

		AddDialogHook("CORAL_32_2_DARUL2", "BeforeStart", BeforeStart);
		AddDialogHook("CORAL_32_2_DARUL2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CORAL_32_2_SQ_10_ST", "CORAL_32_2_SQ_10", "I'll drive the monsters away from Kranta Skerries.", "I'll do it, but I'm gonna rest for a while first."))
		{
			case 1:
				await dialog.Msg("CORAL_32_2_SQ_10_STD");
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

		await dialog.Msg("CORAL_32_2_SQ_10_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

