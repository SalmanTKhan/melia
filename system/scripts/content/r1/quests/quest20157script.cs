//--- Melia Script -----------------------------------------------------------
// Mop Up the Forger (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kevin.
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

[QuestScript(20157)]
public class Quest20157Script : QuestScript
{
	protected override void Load()
	{
		SetId(20157);
		SetName("Mop Up the Forger (1)");
		SetDescription("Talk to Kevin");

		AddPrerequisite(new LevelPrerequisite(61));
		AddPrerequisite(new CompletedPrerequisite("ROKAS25_EX2"));

		AddReward(new ExpReward(50652, 50652));
		AddReward(new ItemReward("expCard3", 4));
		AddReward(new ItemReward("Vis", 1159));

		AddDialogHook("ROKAS25_KEBIN", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS25_KEBIN", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS25_SQ_01_select1", "ROKAS25_SQ_01", "It's the famous genius of forgery", "You came to the wrong place"))
		{
			case 1:
				dialog.HideNPC("ROKAS25_SUB1");
				await dialog.Msg("ROKAS25_SQ_01_AG");
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

		await dialog.Msg("ROKAS25_SQ_01_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ROKAS25_SQ_02");
	}
}

