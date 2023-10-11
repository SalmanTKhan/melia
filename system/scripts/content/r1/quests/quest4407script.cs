//--- Melia Script -----------------------------------------------------------
// One More Time
//--- Description -----------------------------------------------------------
// Quest to Talk to the Worrying Owl Sculpture..
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

[QuestScript(4407)]
public class Quest4407Script : QuestScript
{
	protected override void Load()
	{
		SetId(4407);
		SetName("One More Time");
		SetDescription("Talk to the Worrying Owl Sculpture.");

		AddPrerequisite(new LevelPrerequisite(123));
		AddPrerequisite(new CompletedPrerequisite("THORN23_Q_16"));

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 3075));

		AddDialogHook("THORN23_OWL3", "BeforeStart", BeforeStart);
		AddDialogHook("THORN23_OWL3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN23_Q_17_select1", "THORN23_Q_17", "I'll do it", "Help him with his mental readiness"))
		{
			case 1:
				await dialog.Msg("NPCState;d_thorn_23/515");
				await dialog.Msg("NPCState;d_thorn_23/516");
				await dialog.Msg("NPCState;d_thorn_23/517");
				await dialog.Msg("THORN23_Q_17_startnpc01");
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

		await dialog.Msg("NPCState;d_thorn_23/518");
		await dialog.Msg("THORN23_Q_17_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("THORN23_BOSSKILL_1");
	}
}

