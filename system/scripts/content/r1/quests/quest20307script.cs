//--- Melia Script -----------------------------------------------------------
// Well Hidden Holy Relics
//--- Description -----------------------------------------------------------
// Quest to Talk with Priest Inea.
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

[QuestScript(20307)]
public class Quest20307Script : QuestScript
{
	protected override void Load()
	{
		SetId(20307);
		SetName("Well Hidden Holy Relics");
		SetDescription("Talk with Priest Inea");

		AddPrerequisite(new LevelPrerequisite(137));

		AddReward(new ExpReward(852900, 852900));
		AddReward(new ItemReward("expCard8", 4));
		AddReward(new ItemReward("Vis", 3425));

		AddDialogHook("CHATHEDRAL53_SQ01", "BeforeStart", BeforeStart);
		AddDialogHook("CHATHEDRAL53_SQ01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CHATHEDRAL53_SQ02_select", "CHATHEDRAL53_SQ02", "Tell her not to worry and trust you", "Better give up as it's dangerous"))
		{
			case 1:
				dialog.UnHideNPC("CATHEDRAL_SQ_OBJECT01");
				dialog.UnHideNPC("CATHEDRAL_SQ_OBJECT02");
				dialog.UnHideNPC("CATHEDRAL_SQ_OBJECT03");
				dialog.UnHideNPC("CATHEDRAL_SQ_OBJECT04");
				dialog.UnHideNPC("CATHEDRAL_SQ_OBJECT05");
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

		await dialog.Msg("CHATHEDRAL53_SQ02_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

