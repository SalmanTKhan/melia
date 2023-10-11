//--- Melia Script -----------------------------------------------------------
// Have You Heard of the Saalus Convent?
//--- Description -----------------------------------------------------------
// Quest to Talk to Sister Aiste at the Saalus Convent.
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

[QuestScript(80233)]
public class Quest80233Script : QuestScript
{
	protected override void Load()
	{
		SetId(80233);
		SetName("Have You Heard of the Saalus Convent?");
		SetDescription("Talk to Sister Aiste at the Saalus Convent");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ExpReward(2955183, 2955183));
		AddReward(new ItemReward("expCard12", 1));
		AddReward(new ItemReward("Vis", 8880));

		AddDialogHook("REQUEST_MISSION_ABBEY", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}

	public override void OnStart(Character character, Quest quest)
	{
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "You can now use the Saalus Convent missions to obtain exclusive items!{nl}Press the F5 key to read the details in the Quest info window!");
	}
}

