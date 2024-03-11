//--- Melia Script -----------------------------------------------------------
// Destroyer of the Main Purifier (2)
//--- Description -----------------------------------------------------------
// Quest to Use the Mine Compass.
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

[QuestScript(4501)]
public class Quest4501Script : QuestScript
{
	protected override void Load()
	{
		SetId(4501);
		SetName("Destroyer of the Main Purifier (2)");
		SetDescription("Use the Mine Compass");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "mine_2_5", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(19));
		AddPrerequisite(new CompletedPrerequisite("MINE_2_CRYSTAL_14"));

		AddObjective("kill0", "Kill 1 Stone Whale", new KillObjective(1, MonsterId.Boss_Stone_Whale));

		AddReward(new ExpReward(16116, 16116));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 7));
		AddReward(new ItemReward("MINE_2_CRYSTAL_20_ITEM", 1));
		AddReward(new ItemReward("Vis", 247));

		AddDialogHook("MINE_2_CRYSTAL_20_PART", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		dialog.HideNPC("MINE_2_CRYSTAL_20_PART");
		character.AddonMessage(AddonMessage.NOTICE_Dm_Exclaimation, "You've found the parts of the Purifier{nl}Repair the Main Purifier and activate it", 5);
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnStart(Character character, Quest quest)
	{
		var dialog = new Dialog(character, null);
		dialog.UnHideNPC("MINE_2_CRYSTAL_20_PART");
	}
}

