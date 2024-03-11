//--- Melia Script -----------------------------------------------------------
// Castle Wall Soldier's Unfinished Business (2)
//--- Description -----------------------------------------------------------
// Quest to Talk with the Soul of Castle Wall Soldier.
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

[QuestScript(30268)]
public class Quest30268Script : QuestScript
{
	protected override void Load()
	{
		SetId(30268);
		SetName("Castle Wall Soldier's Unfinished Business (2)");
		SetDescription("Talk with the Soul of Castle Wall Soldier");

		AddPrerequisite(new LevelPrerequisite(300));
		AddPrerequisite(new CompletedPrerequisite("KATYN_18_RE_SQ_3"));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 13800));

		AddDialogHook("KATYN_18_RE_SQ_NPC_2", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN_18_RE_SQ_4_select", "KATYN_18_RE_SQ_4", "As you wish.", "A pointless and meaningless task, it sounds like."))
		{
			case 1:
				await dialog.Msg("KATYN_18_RE_SQ_4_agree");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}
}

