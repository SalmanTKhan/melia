//--- Melia Script -----------------------------------------------------------
// Stubborn
//--- Description -----------------------------------------------------------
// Quest to Talk to Historian Kepeck.
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

[QuestScript(60157)]
public class Quest60157Script : QuestScript
{
	protected override void Load()
	{
		SetId(60157);
		SetName("Stubborn");
		SetDescription("Talk to Historian Kepeck");

		AddPrerequisite(new LevelPrerequisite(58));
		AddPrerequisite(new CompletedPrerequisite("ROKAS24_QB_15"));

		AddObjective("kill0", "Kill 10 Dandel(s) or Geppetto(s) or Pino(s) or Tontus(s)", new KillObjective(10, 401401, 401101, 401181, 401061));

		AddReward(new ExpReward(8442, 8442));
		AddReward(new ItemReward("expCard3", 1));
		AddReward(new ItemReward("Vis", 1044));

		AddDialogHook("ROKAS_24_KEFEK", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS_24_KEFEK", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS24_RP_1_1", "ROKAS24_RP_1", "I'll try and help.", "Let's go somewhere safe."))
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

		await dialog.Msg("ROKAS24_RP_1_3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

