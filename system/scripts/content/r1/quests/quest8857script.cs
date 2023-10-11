//--- Melia Script -----------------------------------------------------------
// Secret Trade (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Grave Robber Amanda.
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

[QuestScript(8857)]
public class Quest8857Script : QuestScript
{
	protected override void Load()
	{
		SetId(8857);
		SetName("Secret Trade (3)");
		SetDescription("Talk to Grave Robber Amanda");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "FLASH64_MQ_03_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(200));
		AddPrerequisite(new CompletedPrerequisite("FLASH64_MQ_02"));

		AddObjective("kill0", "Kill 1 Gargoyle", new KillObjective(1, MonsterId.Boss_Gargoyle));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 24));
		AddReward(new ItemReward("Vis", 7000));

		AddDialogHook("FLASH64_AMANDA", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH64_AMANDA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FLASH64_MQ_03_01", "FLASH64_MQ_03", "I will defeat Gargoyle", "They are too strong to face against"))
		{
			case 1:
				dialog.UnHideNPC("FLASH64_MQ_03_NPC");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("FLASH64_MQ_03_03");
		await dialog.Msg("FadeOutIN/1000");
		dialog.HideNPC("FLASH64_AMANDA");
		dialog.UnHideNPC("AMANDA_65_1");
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "Go to the Fortress of the Land by following the Grave Robber Amanda");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

