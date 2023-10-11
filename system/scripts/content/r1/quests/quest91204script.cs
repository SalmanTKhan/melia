//--- Melia Script -----------------------------------------------------------
// Upinis
//--- Description -----------------------------------------------------------
// Quest to Talk to Goddess Ausrine.
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

[QuestScript(91204)]
public class Quest91204Script : QuestScript
{
	protected override void Load()
	{
		SetId(91204);
		SetName("Upinis");
		SetDescription("Talk to Goddess Ausrine");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP15_2_D_NICOPOLIS_1_MQ_8_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(490));
		AddPrerequisite(new CompletedPrerequisite("EP15_2_D_NICOPOLIS_1_MQ_7"));

		AddObjective("kill0", "Kill 1 Upinis", new KillObjective(1, MonsterId.Boss_Upinis_Q1));

		AddReward(new ExpReward(5699999744, 5699999744));
		AddReward(new ItemReward("Vis", 47586));

		AddDialogHook("EP15_2_D_NICO_AUSIRINE_3", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP15_2_D_NICOPOLIS_1_MQ_8_DLG1", "EP15_2_D_NICOPOLIS_1_MQ_8", "I am ready.", "I'm not ready yet."))
		{
			case 1:
				// Func/SCR_FOLLOWNPC_AUSIRINE_SUMMON;
				await dialog.Msg("FadeOutIN/1500");
				dialog.HideNPC("EP15_2_D_NICO_AUSIRINE_3");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP15_2_D_NICOPOLIS_2_MQ_1");
	}
}

