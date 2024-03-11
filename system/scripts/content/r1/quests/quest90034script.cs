//--- Melia Script -----------------------------------------------------------
// Checking the Statues (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Dievdirbys Asel.
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

[QuestScript(90034)]
public class Quest90034Script : QuestScript
{
	protected override void Load()
	{
		SetId(90034);
		SetName("Checking the Statues (1)");
		SetDescription("Talk to Dievdirbys Asel");

		AddPrerequisite(new LevelPrerequisite(245));
		AddPrerequisite(new CompletedPrerequisite("KATYN_45_1_SQ_3"));

		AddDialogHook("KATYN_45_1_AJEL2", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN_45_1_AJEL2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN_45_1_SQ_4_ST", "KATYN_45_1_SQ_4", "I'll wait then", "I will leave now"))
		{
			case 1:
				await dialog.Msg("KATYN_45_1_SQ_4_AG");
				ZoneServer.Instance.World.FindNPC("KATYN_45_1_OWL1")?.PlayEffectLocal(character.Connection, "I_smoke013_dark1", 2f, "MID");
				// Func/SCR_KATYN_45_1_SQ4;
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

		await dialog.Msg("KATYN_45_1_SQ_4_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

