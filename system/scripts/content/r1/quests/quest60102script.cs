//--- Melia Script -----------------------------------------------------------
// Large-Scale Search Operation (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Agent Larena.
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

[QuestScript(60102)]
public class Quest60102Script : QuestScript
{
	protected override void Load()
	{
		SetId(60102);
		SetName("Large-Scale Search Operation (4)");
		SetDescription("Talk to Agent Larena");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("SIAU11RE_MQ_03"));

		AddDialogHook("SIAULIAI11RE_RARENA", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI11RE_SENDAL", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SIAU11RE_MQ_04_01", "SIAU11RE_MQ_04", "I will follow it", "It's nothing serious"))
		{
			case 1:
				dialog.UnHideNPC("SIAULIAI11RE_SENDAL");
				dialog.UnHideNPC("SIAULIAI11RE_JEGAUS");
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

