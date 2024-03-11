//--- Melia Script -----------------------------------------------------------
// Unchained
//--- Description -----------------------------------------------------------
// Quest to Investigate Carejvnes Hill.
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

[QuestScript(70702)]
public class Quest70702Script : QuestScript
{
	protected override void Load()
	{
		SetId(70702);
		SetName("Unchained");
		SetDescription("Investigate Carejvnes Hill");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "BRACKEN42_1_SQ03_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(278));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN42_1_SQ02"));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 11398));

		AddDialogHook("BRACKEN421_SQ_03_1", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN421_SQ_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("UnHideNPC/BRACKEN421_SQ_03/0", "BRACKEN42_1_SQ03"))
		{
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("BRACKEN421_SQ_03_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

