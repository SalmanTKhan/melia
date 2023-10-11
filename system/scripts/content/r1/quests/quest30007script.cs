//--- Melia Script -----------------------------------------------------------
// Mind of Disciple Laius
//--- Description -----------------------------------------------------------
// Quest to Talk to Disciple Laius.
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

[QuestScript(30007)]
public class Quest30007Script : QuestScript
{
	protected override void Load()
	{
		SetId(30007);
		SetName("Mind of Disciple Laius");
		SetDescription("Talk to Disciple Laius");

		AddPrerequisite(new LevelPrerequisite(188));
		AddPrerequisite(new CompletedPrerequisite("CATACOMB_38_2_SQ_04"));

		AddReward(new ExpReward(237943, 237943));
		AddReward(new ItemReward("expCard10", 3));
		AddReward(new ItemReward("Vis", 5828));

		AddDialogHook("CATACOMB_38_2_NPC_01", "BeforeStart", BeforeStart);
		AddDialogHook("CATACOMB_38_2_NPC_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CATACOMB_38_2_SQ_11_start", "CATACOMB_38_2_SQ_11", "Tell him what has happened so far", "Don't answer"))
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

		await dialog.Msg("CATACOMB_38_2_SQ_11_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

