//--- Melia Script -----------------------------------------------------------
// The Wandering Soul (2)
//--- Description -----------------------------------------------------------
// Quest to Soul and conversation of Assistant.
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

[QuestScript(8326)]
public class Quest8326Script : QuestScript
{
	protected override void Load()
	{
		SetId(8326);
		SetName("The Wandering Soul (2)");
		SetDescription("Soul and conversation of Assistant");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("KATYN18_MQ_19"));

		AddObjective("kill0", "Kill 6 Dark Slime(s)", new KillObjective(6, MonsterId.Slime_Dark));

		AddDialogHook("KATYN18_KEEPER", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN18_KEEPER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN18_MQ_20_01", "KATYN18_MQ_20", "I'll get rid of the Dark Slime", "Cancel"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

