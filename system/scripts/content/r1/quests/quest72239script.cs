//--- Melia Script -----------------------------------------------------------
// Creeping Darkness (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Neringa.
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

[QuestScript(72239)]
public class Quest72239Script : QuestScript
{
	protected override void Load()
	{
		SetId(72239);
		SetName("Creeping Darkness (2)");
		SetDescription("Talk to Neringa");

		AddPrerequisite(new LevelPrerequisite(420));
		AddPrerequisite(new CompletedPrerequisite("EP12_PRELUDE_01"));

		AddObjective("kill0", "Kill 15 Bishop Star(s) or Bumblegreen(s) or Beetlegreen(s) or Moltooth(s)", new KillObjective(15, 59092, 59114, 59113, 59091));

		AddReward(new ItemReward("Vis", 24360));
		AddReward(new ItemReward("expCard16", 2));

		AddDialogHook("EP12_PRELUDE_NERINGA_DCAPITAL_105A", "BeforeStart", BeforeStart);
		AddDialogHook("EP12_PRELUDE_NERINGA_DCAPITAL_105A", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP12_PRELUDE_02_DLG01", "EP12_PRELUDE_02", "Alright", "I need some time to think"))
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

		await dialog.Msg("EP12_PRELUDE_02_DLG03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

