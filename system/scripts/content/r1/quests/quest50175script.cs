//--- Melia Script -----------------------------------------------------------
// Anxiety in the Village
//--- Description -----------------------------------------------------------
// Quest to Talk to Villager Emils.
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

[QuestScript(50175)]
public class Quest50175Script : QuestScript
{
	protected override void Load()
	{
		SetId(50175);
		SetName("Anxiety in the Village");
		SetDescription("Talk to Villager Emils");

		AddPrerequisite(new LevelPrerequisite(246));

		AddObjective("kill0", "Kill 16 White Spion(s) or Blue Cronewt Magician(s) or Red Hohen Orben(s) or Brown Lapasape(s)", new KillObjective(16, 57908, 57955, 57975, 57942));

		AddReward(new ExpReward(1970122, 1970122));
		AddReward(new ItemReward("expCard12", 4));
		AddReward(new ItemReward("Vis", 9102));

		AddDialogHook("TABLE72_PEAPLE4", "BeforeStart", BeforeStart);
		AddDialogHook("TABLE72_PEAPLE4", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TABLELAND_72_SQ11_startnpc1", "TABLELAND_72_SQ11", "I'll defeat the monsters.", "You should ask nearby troops to do that."))
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

		await dialog.Msg("TABLELAND_72_SQ11_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

