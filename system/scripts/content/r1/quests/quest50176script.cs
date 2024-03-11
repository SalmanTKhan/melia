//--- Melia Script -----------------------------------------------------------
// Cursed Statues (1)
//--- Description -----------------------------------------------------------
// Quest to Destroy the Cursed Statues with the Purification Sphere.
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

[QuestScript(50176)]
public class Quest50176Script : QuestScript
{
	protected override void Load()
	{
		SetId(50176);
		SetName("Cursed Statues (1)");
		SetDescription("Destroy the Cursed Statues with the Purification Sphere");

		AddPrerequisite(new LevelPrerequisite(250));
		AddPrerequisite(new CompletedPrerequisite("TABLELAND_72_SQ9"));

		AddReward(new ExpReward(5910366, 5910366));
		AddReward(new ItemReward("expCard12", 2));
		AddReward(new ItemReward("Vis", 10000));

		AddDialogHook("TABLE73_SUB_ARTIFACT1", "BeforeStart", BeforeStart);
		AddDialogHook("TABLE73_SUB_ARTIFACT1", "BeforeEnd", BeforeEnd);
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

		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "Destroy the cursed statues with the Purification Sphere.");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

