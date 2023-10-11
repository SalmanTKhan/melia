//--- Melia Script -----------------------------------------------------------
// Revelation Guardian Zanas(1)
//--- Description -----------------------------------------------------------
// Quest to Listen to the Soul's voice.
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

[QuestScript(30145)]
public class Quest30145Script : QuestScript
{
	protected override void Load()
	{
		SetId(30145);
		SetName("Revelation Guardian Zanas(1)");
		SetDescription("Listen to the Soul's voice");

		AddPrerequisite(new LevelPrerequisite(259));

		AddReward(new ExpReward(11281842, 11281842));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 17));

		AddDialogHook("PRISON_78_OBJ_1", "BeforeStart", BeforeStart);
		AddDialogHook("PRISON_78_NPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PRISON_78_MQ_1_select", "PRISON_78_MQ_1"))
		{
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("PRISON_78_MQ_1_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

