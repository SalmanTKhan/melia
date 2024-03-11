//--- Melia Script -----------------------------------------------------------
// The Hidden Sanctum's Revelation (2)
//--- Description -----------------------------------------------------------
// Quest to Tell the Paladin Master about the story so far.
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

[QuestScript(30031)]
public class Quest30031Script : QuestScript
{
	protected override void Load()
	{
		SetId(30031);
		SetName("The Hidden Sanctum's Revelation (2)");
		SetDescription("Tell the Paladin Master about the story so far");

		AddPrerequisite(new LevelPrerequisite(48));
		AddPrerequisite(new CompletedPrerequisite("CHAPLE577_MQ_10"));

		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 121));

		AddDialogHook("GELE573_MASTER", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CHAPLE577_MQ_10_03", "CHAPLE577_MQ_10_AFTER"))
		{
		}

		return HookResult.Break;
	}
}

