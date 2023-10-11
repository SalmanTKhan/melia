//--- Melia Script -----------------------------------------------------------
// Demon at Lemprasa Pond
//--- Description -----------------------------------------------------------
// Quest to Talk to Orsha Damage Recovery Team.
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

[QuestScript(92035)]
public class Quest92035Script : QuestScript
{
	protected override void Load()
	{
		SetId(92035);
		SetName("Demon at Lemprasa Pond");
		SetDescription("Talk to Orsha Damage Recovery Team");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP13_F_SIAULIAI_1_SQ_02_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(450));
		AddPrerequisite(new CompletedPrerequisite("EP13_F_SIAULIAI_1_SQ_01"));

		AddObjective("kill0", "Kill All 20 Monsters", new KillObjective(-1, -1));

		AddReward(new ItemReward("Vis", 27900));
		AddReward(new ItemReward("expCard18", 2));

		AddDialogHook("EP13_SUB_RECONSTRUCTION_NPC_SIAU_1_1", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP13_F_SIAULIAI_1_SQ_02_1", "EP13_F_SIAULIAI_1_SQ_02", "Leave it to me", "Without backup, no"))
		{
			case 1:
				// Func/EP13_F_SIAULIAI_1_SQ_02_HIDE_RUN;
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP13_F_SIAULIAI_1_SQ_03");
	}
}

