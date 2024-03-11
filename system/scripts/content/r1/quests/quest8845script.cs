//--- Melia Script -----------------------------------------------------------
// Intensified Rampage
//--- Description -----------------------------------------------------------
// Quest to Talk to Wilhelmina Carriot.
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

[QuestScript(8845)]
public class Quest8845Script : QuestScript
{
	protected override void Load()
	{
		SetId(8845);
		SetName("Intensified Rampage");
		SetDescription("Talk to Wilhelmina Carriot");

		AddPrerequisite(new LevelPrerequisite(196));

		AddObjective("kill0", "Kill 8 Lepusbunny(s) or Lemuria(s) or Rubabos(s)", new KillObjective(8, 41299, 47307, 47464));

		AddReward(new ExpReward(2379430, 2379430));
		AddReward(new ItemReward("expCard10", 2));
		AddReward(new ItemReward("Vis", 6076));

		AddDialogHook("FLASH64_KARRIAT", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH64_KARRIAT", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FLASH64_SQ_01_01", "FLASH64_SQ_01", "Tell him that you would help get rid of monsters", "Decline"))
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

		await dialog.Msg("FLASH64_SQ_01_03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

