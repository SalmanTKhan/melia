//--- Melia Script -----------------------------------------------------------
// Who Did It?
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

[QuestScript(90038)]
public class Quest90038Script : QuestScript
{
	protected override void Load()
	{
		SetId(90038);
		SetName("Who Did It?");
		SetDescription("Talk to Dievdirbys Asel");

		AddPrerequisite(new LevelPrerequisite(245));
		AddPrerequisite(new CompletedPrerequisite("KATYN_45_1_SQ_7"));

		AddDialogHook("KATYN_45_1_AJEL3", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN_45_1_AJEL3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN_45_1_SQ_8_ST", "KATYN_45_1_SQ_8", "I'll go there", "I can only help so much"))
		{
			case 1:
				await dialog.Msg("KATYN_45_1_SQ_8_AG");
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

		await dialog.Msg("KATYN_45_1_SQ_8_SU");
		dialog.HideNPC("KATYN_45_1_AJEL3");
		await dialog.Msg("FadeOutIN/2000");
		dialog.UnHideNPC("KATYN_45_2_AJEL1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

