//--- Melia Script -----------------------------------------------------------
// Threat at Poslinkis Forest (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Weak Owl Sculpture.
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

[QuestScript(19430)]
public class Quest19430Script : QuestScript
{
	protected override void Load()
	{
		SetId(19430);
		SetName("Threat at Poslinkis Forest (2)");
		SetDescription("Talk to the Weak Owl Sculpture");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "KATYN13_ADDQUEST3_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(112));
		AddPrerequisite(new CompletedPrerequisite("KATYN13_NEWSUB_01"));

		AddObjective("kill0", "Kill 1 Soggy Mushwort", new KillObjective(1, MonsterId.Boss_Mushwort));

		AddReward(new ExpReward(542808, 542808));
		AddReward(new ItemReward("expCard7", 5));
		AddReward(new ItemReward("Vis", 2688));

		AddDialogHook("KATYN13_1_OWLJUNIOR3_AFTER", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN13_1_OWLJUNIOR3_AFTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN13_ADDQUEST1_01", "KATYN13_NEWSUB_02", "I'll save the owls", "Decline"))
		{
			case 1:
				await dialog.Msg("KATYN13_ADDQUEST1_AG");
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

		await dialog.Msg("KATYN13_ADDQUEST3_succ1");
		ZoneServer.Instance.World.FindNPC("KATYN13_1_OWLBOSS")?.PlayEffectLocal(character.Connection, "F_light018", 1f, "MID");
		await dialog.Msg("NPCForceEffect/KATYN13_1_OWLBOSS/1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

