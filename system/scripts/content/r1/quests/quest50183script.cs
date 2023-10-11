//--- Melia Script -----------------------------------------------------------
// The Altars of Kadumel Cliff (2)
//--- Description -----------------------------------------------------------
// Quest to Investigate the Altar.
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

[QuestScript(50183)]
public class Quest50183Script : QuestScript
{
	protected override void Load()
	{
		SetId(50183);
		SetName("The Altars of Kadumel Cliff (2)");
		SetDescription("Investigate the Altar");

		AddPrerequisite(new LevelPrerequisite(250));
		AddPrerequisite(new CompletedPrerequisite("TABLELAND_73_SQ7"));

		AddReward(new ExpReward(985061, 985061));
		AddReward(new ItemReward("expCard12", 3));
		AddReward(new ItemReward("Vis", 10000));

		AddDialogHook("TABLE73_SUBQ_ALTAR2", "BeforeStart", BeforeStart);
		AddDialogHook("TABLE73_SUBQ_ALTAR2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "The altar's power has been restored.");
		// Func/TABLE73_SUBQ8_COMPLETE;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

