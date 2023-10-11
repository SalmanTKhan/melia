//--- Melia Script -----------------------------------------------------------
// It Only Gets Worse
//--- Description -----------------------------------------------------------
// Quest to Talk to Kind Owl Sculpture.
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

[QuestScript(90066)]
public class Quest90066Script : QuestScript
{
	protected override void Load()
	{
		SetId(90066);
		SetName("It Only Gets Worse");
		SetDescription("Talk to Kind Owl Sculpture");

		AddPrerequisite(new LevelPrerequisite(253));
		AddPrerequisite(new CompletedPrerequisite("KATYN_45_3_SQ_8"));

		AddObjective("kill0", "Kill 12 Yellow Griba(s) or Green Meduja(s) or Blue Sakmoli(s) or Blue Fisherman(s)", new KillObjective(12, 400444, 400243, 400564, 400342));

		AddReward(new ExpReward(985061, 985061));
		AddReward(new ItemReward("expCard12", 3));
		AddReward(new ItemReward("Vis", 10120));

		AddDialogHook("KATYN_45_3_OWL3", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN_45_3_OWL3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN_45_3_SQ_12_ST", "KATYN_45_3_SQ_12", "Of course I'll help defeat them.", "That's tough"))
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

		await dialog.Msg("KATYN_45_3_SQ_12_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

