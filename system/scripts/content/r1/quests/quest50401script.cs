//--- Melia Script -----------------------------------------------------------
// The Frightening Research Papers
//--- Description -----------------------------------------------------------
// Quest to Talk to Wizard Nidia.
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

[QuestScript(50401)]
public class Quest50401Script : QuestScript
{
	protected override void Load()
	{
		SetId(50401);
		SetName("The Frightening Research Papers");
		SetDescription("Talk to Wizard Nidia");

		AddPrerequisite(new LevelPrerequisite(387));
		AddPrerequisite(new CompletedPrerequisite("F_NICOPOLIS_81_3_SQ_02"));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("expCard15", 1));
		AddReward(new ItemReward("Vis", 27000));

		AddDialogHook("NICO813_SUBQ_NPC2_1", "BeforeStart", BeforeStart);
		AddDialogHook("NICO813_SUBQ_NPC2_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("NICO813_SUBQ03_START1", "F_NICOPOLIS_81_3_SQ_03", "I'll use the Micro Magic Detector.", "Wish them the best of luck"))
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

		await dialog.Msg("NICO813_SUBQ03_SUCC2");
		await dialog.Msg("FadeOutIN/1000");
		dialog.HideNPC("NICO813_SUBQ_NPC2_1");
		dialog.UnHideNPC("NICO813_SUBQ_NPC2_2");
		dialog.HideNPC("NICO813_SUBQ_NPC3_1");
		dialog.HideNPC("NICO813_SUBQ_NPC1_1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("F_NICOPOLIS_81_3_SQ_04");
	}
}

