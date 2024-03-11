//--- Melia Script -----------------------------------------------------------
// Heretics, Here and There
//--- Description -----------------------------------------------------------
// Quest to Talk to Believer Jaonus.
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

[QuestScript(90083)]
public class Quest90083Script : QuestScript
{
	protected override void Load()
	{
		SetId(90083);
		SetName("Heretics, Here and There");
		SetDescription("Talk to Believer Jaonus");

		AddPrerequisite(new LevelPrerequisite(292));

		AddObjective("kill0", "Kill 8 Yellow Pag Clamper(s) or Green Pag Nurse(s) or Yellow Pag Shearer(s) or Blue Pag Doper(s)", new KillObjective(8, 58501, 58502, 58503, 58500));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 12264));

		AddDialogHook("CATACOMB_25_4_SQ_JAUNIUS1", "BeforeStart", BeforeStart);
		AddDialogHook("CATACOMB_25_4_SQ_JAUNIUS1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CATACOMB_25_4_SQ_10_ST", "CATACOMB_25_4_SQ_10", "Hmmm... okay....", "Not interested."))
		{
			case 1:
				await dialog.Msg("CATACOMB_25_4_SQ_10_AG");
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

		await dialog.Msg("CATACOMB_25_4_SQ_10_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

