//--- Melia Script -----------------------------------------------------------
// Owl Sculpture in Danger
//--- Description -----------------------------------------------------------
// Quest to Follow the light bead to Bonewide Cliff.
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

[QuestScript(30051)]
public class Quest30051Script : QuestScript
{
	protected override void Load()
	{
		SetId(30051);
		SetName("Owl Sculpture in Danger");
		SetDescription("Follow the light bead to Bonewide Cliff");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "KATYN_10_MQ_03_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("KATYN_10_MQ_02"));

		AddObjective("kill0", "Kill 1 Moa", new KillObjective(1, MonsterId.Boss_Moa_Q3));

		AddReward(new ExpReward(42210, 42210));
		AddReward(new ItemReward("expCard3", 1));
		AddReward(new ItemReward("Vis", 1026));

		AddDialogHook("KATYN_10_NPC_02", "BeforeEnd", BeforeEnd);
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
		character.AddonMessage(AddonMessage.NOTICE_Dm_Exclaimation, "The light bead disappeared over the slope!{nl}Turn around and go up Bonewide Cliff.", 5);
	}
}

