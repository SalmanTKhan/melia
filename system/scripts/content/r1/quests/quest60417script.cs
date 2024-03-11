//--- Melia Script -----------------------------------------------------------
// Different Circumstances (7)
//--- Description -----------------------------------------------------------
// Quest to Talk to Nergui.
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

[QuestScript(60417)]
public class Quest60417Script : QuestScript
{
	protected override void Load()
	{
		SetId(60417);
		SetName("Different Circumstances (7)");
		SetDescription("Talk to Nergui");

		AddPrerequisite(new LevelPrerequisite(401));
		AddPrerequisite(new CompletedPrerequisite("CASTLE96_MQ_6"));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));
		AddReward(new ItemReward("Vis", 22857));

		AddDialogHook("CASTLE96_MQ_NERGUI_NPC", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CASTLE96_MQ_7_1", "CASTLE96_MQ_7", "Alright", "I'm gonna need to prepare first."))
		{
			case 1:
				dialog.HideNPC("CASTLE96_MQ_NERGUI_NPC");
				// Func/CASTLE96_FOLLOWNPC_LIB/CASTLE96_MQ_7;
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}
}

