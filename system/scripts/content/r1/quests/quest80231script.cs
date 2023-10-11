//--- Melia Script -----------------------------------------------------------
// Klaipeda's Mercenary Post 
//--- Description -----------------------------------------------------------
// Quest to Talk to Rota, Klaipeda's Mercenary Post Manager. .
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

[QuestScript(80231)]
public class Quest80231Script : QuestScript
{
	protected override void Load()
	{
		SetId(80231);
		SetName("Klaipeda's Mercenary Post ");
		SetDescription("Talk to Rota, Klaipeda's Mercenary Post Manager. ");

		AddPrerequisite(new LevelPrerequisite(100));

		AddReward(new ExpReward(301560, 301560));
		AddReward(new ItemReward("expCard7", 1));
		AddReward(new ItemReward("Vis", 2400));

		AddDialogHook("FEDIMIAN_ROTA_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("TUTO_REQUEST_MISSION_succ01");
		dialog.ShowHelp("TUTO_REQUEST_MISSION");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnStart(Character character, Quest quest)
	{
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "You can now use the Mercenary Post!{nl}Press the F5 key to read the details in the Quest info window!");
	}
}

