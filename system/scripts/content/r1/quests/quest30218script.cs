//--- Melia Script -----------------------------------------------------------
// Never again
//--- Description -----------------------------------------------------------
// Quest to Talk to Researcher Sireah.
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

[QuestScript(30218)]
public class Quest30218Script : QuestScript
{
	protected override void Load()
	{
		SetId(30218);
		SetName("Never again");
		SetDescription("Talk to Researcher Sireah");

		AddPrerequisite(new LevelPrerequisite(223));
		AddPrerequisite(new CompletedPrerequisite("ORCHARD_34_3_SQ_11"));

		AddObjective("kill0", "Kill 5 Alchemy Table 1 Monster(s) or Workbench Monster(s)", new KillObjective(5, 107007, 107008));

		AddReward(new ExpReward(541023, 541023));
		AddReward(new ItemReward("expCard11", 3));
		AddReward(new ItemReward("Vis", 8028));

		AddDialogHook("ORCHARD_34_3_SQ_NPC_3", "BeforeStart", BeforeStart);
		AddDialogHook("ORCHARD_34_3_SQ_NPC_3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ORCHARD_34_3_SQ_14_select", "ORCHARD_34_3_SQ_14", "Say that you will destroy everything", "Say that you think that is overreacting"))
		{
			case 1:
				await dialog.Msg("ORCHARD_34_3_SQ_14_agree");
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

		await dialog.Msg("ORCHARD_34_3_SQ_14_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

