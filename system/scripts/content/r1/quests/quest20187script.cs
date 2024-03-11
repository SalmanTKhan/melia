//--- Melia Script -----------------------------------------------------------
// Mop Up the Forger (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Vincent.
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

[QuestScript(20187)]
public class Quest20187Script : QuestScript
{
	protected override void Load()
	{
		SetId(20187);
		SetName("Mop Up the Forger (4)");
		SetDescription("Talk to Vincent");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ROKAS25_SQ_BRIDGE2_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(61));
		AddPrerequisite(new CompletedPrerequisite("ROKAS25_SQ_04"));

		AddObjective("kill0", "Kill 1 Yonazolem", new KillObjective(1, MonsterId.Boss_Yonazolem_Q1));

		AddReward(new ExpReward(75978, 75978));
		AddReward(new ItemReward("expCard3", 5));
		AddReward(new ItemReward("misc_yonazolem_Q1", 1));
		AddReward(new ItemReward("Vis", 1159));

		AddDialogHook("ROKAS25_BINSENT", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS25_SQ_BRIDGE2_ST", "ROKAS25_SQ_BRIDGE2"))
		{
		}

		return HookResult.Break;
	}
}

