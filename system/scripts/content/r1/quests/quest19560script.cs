//--- Melia Script -----------------------------------------------------------
// Curse of Sloth - Lethargy
//--- Description -----------------------------------------------------------
// Quest to Spoiled Tree Root Crystal at the Nomads Camp.
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

[QuestScript(19560)]
public class Quest19560Script : QuestScript
{
	protected override void Load()
	{
		SetId(19560);
		SetName("Curse of Sloth - Lethargy");
		SetDescription("Spoiled Tree Root Crystal at the Nomads Camp");

		AddPrerequisite(new LevelPrerequisite(124));

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 3100));

		AddDialogHook("PILGRIM47_CRYST02", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM47_CRYST02_E", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("NPCAin/PILGRIM47_CRYST02/DEAD/0");
		dialog.HideNPC("PILGRIM47_CRY_CORE");
		await Task.Delay(3000);
		dialog.HideNPC("PILGRIM47_CRYST02");
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "You destroyed all the cores and the Tree Root Crystal was destroyed as well");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

